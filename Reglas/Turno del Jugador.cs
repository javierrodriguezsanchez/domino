using DominoTable;
using DominoPlayer;
using DominoGame;
namespace DominoRules;

public interface ITurn
{
    public (Piece, int) Play(Player Jugador, Game Juego);
}

public class NormalTurn:ITurn
{
    public (Piece, int) Play(Player Jugador, Game Juego)
    {
        (Piece, int) AJugar = Jugador.Play(Juego.tablero,Juego.reglas);
        
        if(AJugar.Item2 == int.MaxValue){
                Juego.pasadosSeguidos ++;
                return AJugar;
        }
        if(Juego.tablero.nuevaMesa){
            Juego.tablero.nuevaMesa = false;
            Juego.tablero[0] = AJugar.Item1.values[0];
            Juego.tablero[1] = AJugar.Item1.values[1];
            return (AJugar.Item1, -1);
        }
         
        if(Juego.tablero.Disponibles[AJugar.Item2] == AJugar.Item1.values[0]){
            Juego.tablero.Disponibles[AJugar.Item2] = AJugar.Item1.values[1]; }
        else
        {
            Juego.tablero.Disponibles[AJugar.Item2] = AJugar.Item1.values[0];
        }
        return AJugar;
        
    }
}