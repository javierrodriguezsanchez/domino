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
        (Piece ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero,  Juego.reglas);
        
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
        if(Juego.reglas.JugadaLegal.IsLegal(Juego.Tablero,AJugar.Item1,AJugar.Item2,AJugar.Item3)){
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
        (Piece ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero,  Juego.reglas);
        
        if(AJugar.Item1.IsNull){
                Juego.PasadosSeguidos ++;
                if(Juego.fichasDelJuego.Length > 0) 
                Juego.manos[Jugador].Add(Juego.fichasDelJuego.TomarUna());
                Juego.Tablero.pasarse(Jugador);
                return;
        }
        if(Juego.Tablero.nuevaMesa){
            Juego.Tablero.abrirMesa(AJugar.ficha, Jugador);
            Juego.manos[Jugador].Remove(AJugar.ficha);
            Play(Jugador, Juego);
            return;
        }
        if(Juego.reglas.JugadaLegal.IsLegal(Juego.Tablero,AJugar.Item1,AJugar.Item2,AJugar.Item3)){
            Juego.Tablero.JugarEnPos(AJugar.ficha, Jugador, AJugar.cara, AJugar.posicion);
            Juego.PasadosSeguidos = 0;
            Juego.manos[Jugador].Remove(AJugar.ficha);
            if(AJugar.ficha.values.Distinct().Count() == 1) Play(Jugador, Juego);
        }
    }
}
class MetodosAux{
    static void Invertir<T>(T[] array, int indice){
        T[] aux = new T[array.Length];
        for (int i = 0; i < array.Length; i++){
            aux[(indice + i) % array.Length] = aux[(indice - i) % array.Length];
        }

    }
}
}