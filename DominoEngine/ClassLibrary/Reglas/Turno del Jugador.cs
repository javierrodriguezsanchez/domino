using DominoTable;
using DominoPlayer;
using DominoGame;
namespace DominoRules;

public interface ITurn<T>
{
    public void Play(Player<T> Jugador, Game<T> Juego);
}

public class NormalTur<T>:ITurn<T>
{
    public void Play(Player<T> Jugador, Game<T> Juego)
    {
        (Piece<T> ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero.Disponibles.ToArray(),Juego.Tablero.Historial(false),Juego.Tablero.ListaDePases(),  Juego.reglas, Juego.Tablero.nuevaMesa);
        
        if(AJugar.Item1.IsNull){
                Juego.PasadosSeguidos ++;
                Juego.Tablero.pasarse(Jugador);
                return;
        }
        MetodosAux.PonerFicha(Juego,AJugar,Jugador);
    }
}

public class Robadito<T>:ITurn<T>{
    public void Play(Player<T> Jugador, Game<T> Juego)
    {
        (Piece<T> ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero.Disponibles.ToArray(),Juego.Tablero.Historial(false),Juego.Tablero.ListaDePases(),  Juego.reglas, Juego.Tablero.nuevaMesa);
        
        if(AJugar.Item1.IsNull){
                Juego.Tablero.pasarse(Jugador);
                if(Juego.fichasDelJuego.Count>0)
                    Juego.manos[Jugador].Add(Juego.fichasDelJuego.TomarUna());
                else
                    Juego.PasadosSeguidos ++;
            return;
        }
        
        MetodosAux.PonerFicha<T>(Juego,AJugar,Jugador);
    }

}

public class Ciclomino<T>: ITurn<T>{
    public void Play(Player<T> Jugador, Game<T> Juego)
    {   
        if(Juego.manos[Jugador].Count == 0) return; 
        (Piece<T> ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual].AsReadOnly(), Juego.Tablero.Disponibles.ToArray(),Juego.Tablero.Historial(false),Juego.Tablero.ListaDePases(),  Juego.reglas, Juego.Tablero.nuevaMesa);
        
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
   public static void PonerFicha<T>(Game<T> Juego, (Piece<T> ficha, int posicion,int cara) AJugar,Player<T> Jugador)
   {
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
