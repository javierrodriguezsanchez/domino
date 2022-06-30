namespace DominoGame;
using DominoTable;
using DominoPlayer;
public class Escena
{
    public Piece ultimaFicha;
    public Player JugadorUltimaJugada;
    public int posicionUltimaJugada;
    public Dictionary<Player, List<Piece>> manos;
    int ganador;
    public Escena(Game Juego)
    {
        ultimaFicha = Juego.jugadas[Juego.jugadas.Count - 1].ficha;
        JugadorUltimaJugada = Juego.jugadas[Juego.jugadas.Count -1].jugador;
        posicionUltimaJugada = Juego.jugadas[Juego.jugadas.Count -1].posicion;
        manos = Juego.manos;
    }
}