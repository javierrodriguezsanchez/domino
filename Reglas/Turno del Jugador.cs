using DominoTable;
using DominoPlayer;
using DominoGame;
namespace DominoRules
{
public interface ITurn
{
    public (Piece, int,int) Play(Player Jugador, Game Juego);
}

public class NormalTurn:ITurn
{
    public (Piece, int,int) Play(Player Jugador, Game Juego)
    {
        (Piece, int,int) AJugar = Jugador.Play(Juego.manos[Juego.JugadorActual], Juego.tablero,Juego.reglas);
        
        if(AJugar.Item1.IsNull){
                Juego.pasadosSeguidos ++;
                return AJugar;
        }
        if(Juego.tablero.nuevaMesa){
            Juego.tablero.nuevaMesa = false;
            Juego.tablero[0] = AJugar.Item1.values[0];
            Juego.tablero[1] = AJugar.Item1.values[1];
            return (AJugar.Item1, -1,-1);
        }
        
        if(Juego.reglas.jugadaLegal.IsLegal(Juego.tablero,AJugar.Item1,AJugar.Item2,AJugar.Item3))
            Juego.tablero[AJugar.Item2]=AJugar.Item1.values[AJugar.Item3];
            Juego.pasadosSeguidos = 0;
        return AJugar;
        
    }
}
}