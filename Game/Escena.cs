namespace DominoGame;
using DominoTable;
using DominoPlayer;
public class Escena<T>
{
    public IEnumerable<Piece<T>> Tablero;
    public Player<T> JugadorUltimaJugada;
    public Dictionary<Player<T>, List<Piece<T>>> manos;
    int ganador;
    public Escena(Game<T> Juego)
    {
        Tablero = Juego.Tablero.VerMesaActual();
        JugadorUltimaJugada = Juego.JugadorActual;
        manos = Juego.manos;
    }
}