using DominoTable;
using DominoPlayer;
using DominoGame;
namespace DominoRules
{
public interface ITurn
{
    public (Piece, int,int, Player) Play(Player Jugador, Game Juego);
}

public class NormalTurn:ITurn
{
    public (Piece, int,int, Player) Play(Player Jugador, Game Juego)
    {
        (Piece ficha, int posicion,int cara) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual], Juego.tablero,Juego.reglas);
        
        if(AJugar.Item1.IsNull){
                Juego.PasadosSeguidos ++;
                return (AJugar.Item1, AJugar.Item2, AJugar.Item3, Jugador);
        }
        if(Juego.tablero.nuevaMesa){
            Juego.tablero.nuevaMesa = false;
            Juego.tablero[0] = AJugar.Item1.values[0];
            Juego.tablero[1] = AJugar.Item1.values[1];
            Juego.manos[Jugador].Remove(AJugar.ficha);
            return (AJugar.Item1, -1,-1, Jugador);
        }
        
        if(Juego.reglas.JugadaLegal.IsLegal(Juego.tablero,AJugar.Item1,AJugar.Item2,AJugar.Item3))
        {
            Juego.tablero[AJugar.Item2]=AJugar.Item1.values[AJugar.Item3];
            Juego.PasadosSeguidos = 0;
            Juego.manos[Jugador].Remove(AJugar.ficha);
        }
        return (AJugar.Item1, AJugar.Item2, AJugar.Item3, Jugador);
        
    }
}
}