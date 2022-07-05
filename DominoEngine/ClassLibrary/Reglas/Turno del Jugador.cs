using DominoTable;
using DominoPlayer;
using DominoGame;
namespace DominoRules
{
public interface ITurn
{
    public void Play(Player Jugador, Game Juego);
}

public class NormalTur:ITurn
{
    public void Play(Player Jugador, Game Juego)
    {
        (Piece ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero.Disponibles.ToArray(),  Juego.reglas, Juego.Tablero.nuevaMesa);
        
        if(AJugar.Item1.IsNull){
                Juego.PasadosSeguidos ++;
                Juego.Tablero.pasarse(Jugador);
                return;
        }
        if(Juego.Tablero.nuevaMesa){
            Juego.Tablero.abrirMesa(AJugar.ficha, Jugador);
            Juego.manos[Jugador].Remove(AJugar.ficha);
            return;
        }
        if(Juego.reglas.JugadaLegal.IsLegal(Juego.Tablero.Disponibles.ToArray(),AJugar.Item1,AJugar.Item2,AJugar.Item3, Juego.Tablero.nuevaMesa)){
            Juego.Tablero.JugarEnPos(AJugar.ficha, Jugador, AJugar.cara, AJugar.posicion);
            Juego.PasadosSeguidos = 0;
            Juego.manos[Jugador].Remove(AJugar.ficha);
        }
    }
}
public class Ciclomino: ITurn{
    public void Play(Player Jugador, Game Juego)
    {   
        if(Juego.manos[Jugador].Count == 0) return; 
        (Piece ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero.Disponibles.ToArray(),  Juego.reglas, Juego.Tablero.nuevaMesa);
        
        if(AJugar.Item1.IsNull){
                Juego.PasadosSeguidos ++;
                if(Juego.fichasDelJuego.Count > 0) 
                Juego.manos[Jugador].Add(Juego.fichasDelJuego.TomarUna());
                MetodosAux.Invertir(Juego.Jugadores, Juego.Turno % Juego.Jugadores.Length);
                Juego.Tablero.pasarse(Jugador);
                return;
        }
        if(Juego.Tablero.nuevaMesa){
            Juego.Tablero.abrirMesa(AJugar.ficha, Jugador);
            Juego.manos[Jugador].Remove(AJugar.ficha);
            Play(Jugador, Juego);
            return;
        }
        if(Juego.reglas.JugadaLegal.IsLegal(Juego.Tablero.Disponibles.ToArray(),AJugar.Item1,AJugar.Item2,AJugar.Item3, Juego.Tablero.nuevaMesa)){
            Juego.Tablero.JugarEnPos(AJugar.ficha, Jugador, AJugar.cara, AJugar.posicion);
            Juego.PasadosSeguidos = 0;
            Juego.manos[Jugador].Remove(AJugar.ficha);
            if(AJugar.ficha.values.Distinct().Count() == 1) Play(Jugador, Juego);
        }
    }
}
class MetodosAux{
    public static void Invertir<T>(T[] array, int indice){
        T[] aux = new T[array.Length];
        for (int i = 0; i < array.Length; i++){
            if (i< indice) aux[i] = array[(indice + (indice - i))% array.Length];
           else{
            int a = indice -(i - indice);
            if(a< 0) a += array.Length;
            aux[i] = array[a];
           }
        }
        aux.CopyTo(array, 0);
   }
}
}