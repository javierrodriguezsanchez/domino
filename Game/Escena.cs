namespace DominoGame;
using DominoTable;
using DominoPlayer;
public class Escena
{
    public IEnumerable<Piece> Tablero;
    public Player JugadorUltimaJugada;
    public Dictionary<Player, List<Piece>> manos;
    int ganador;
    public Escena(Game Juego)
    {
        Tablero = Juego.Tablero.VerMesaActual();
        JugadorUltimaJugada = Juego.JugadorActual;
        manos = Juego.manos;
    }
}