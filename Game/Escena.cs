namespace DominoGame;
using DominoTable;
using DominoPlayer;
public class Escena
{
<<<<<<< HEAD
    public IEnumerable<Piece> Tablero;
    public Player JugadorUltimaJugada;
=======
    public Piece ultimaFicha;
    public Player JugadorUltimaJugada;
    public int posicionUltimaJugada;
>>>>>>> 06d46c5a1a8b04cce1e30f0cdc1440d10b79a4d0
    public Dictionary<Player, List<Piece>> manos;
    int ganador;
    public Escena(Game Juego)
    {
<<<<<<< HEAD
        Tablero = Juego.Tablero.VerMesaActual();
        JugadorUltimaJugada = Juego.JugadorActual;
=======
        ultimaFicha = Juego.jugadas[Juego.jugadas.Count - 1].ficha;
        JugadorUltimaJugada = Juego.jugadas[Juego.jugadas.Count -1].jugador;
        posicionUltimaJugada = Juego.jugadas[Juego.jugadas.Count -1].posicion;
>>>>>>> 06d46c5a1a8b04cce1e30f0cdc1440d10b79a4d0
        manos = Juego.manos;
    }
}