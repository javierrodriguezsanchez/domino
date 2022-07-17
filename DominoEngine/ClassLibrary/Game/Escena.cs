namespace DominoGame;
using DominoTable;
using DominoPlayer;
public class Escena<T>
{
    public IEnumerable<Piece<T>> Tablero;
    //Imagen que muestra como imprimir el tablero actual
    public Player<T> JugadorUltimaJugada;
    //Jugador que ralizo la ultima jugada
    public Dictionary<Player<T>, List<Piece<T>>> manos;
    //Diccionario que relaciona a cada jugador con su mano actual
    int ganador;
    //Ganador del juego actual, en caso de no haberse decidedo, el valor es -1
    public Escena(Game<T> Juego)
    {
        Tablero = Juego.Tablero.VerMesaActual();
        JugadorUltimaJugada = Juego.JugadorActual;
        manos = Juego.manos;
    }
}