using DominoGame;
using DominoPlayer;
using DominoTable;
using System.Collections;
using System.Linq;
using System;
namespace DominoRules
{
public interface  IEndCondition{
   public bool EndOfTheGame(Game juego);
}
public interface IWinner{
    public int Winner(Game juego);
}
 class FinPorTranque: IEndCondition{
  public bool EndOfTheGame(Game juego) =>
  juego.cantFichasJugadorActual == 0|| juego.PasadosSeguidos >= juego.Jugadores.Length;
    }

  class Mesa150puntos: IEndCondition{
    public bool EndOfTheGame(Game juego) => 
    juego.Tablero.Historial().Select(jug => jug.Ficha).Sum(t => juego.reglas.Evaluador.Evaluar(t)) >= 150 ||
     juego.cantFichasJugadorActual == 0 || juego.PasadosSeguidos >= juego.Jugadores.Length;
  }
  class DosPases:IEndCondition{
     public bool EndOfTheGame(Game juego) =>
     juego.cantFichasJugadorActual == 0|| juego.PasadosSeguidos == 2;
  }

class finalPorPuntos: IWinner{
    public int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0){
        return juego.JugadorActual.Equipo;}
        bool empate = true;
        int candidato = -1;
        double minimo = double.MaxValue;
        foreach (var jug in juego.Jugadores)
        {
            double puntos = juego.manos[jug].Sum(t => juego.reglas.Evaluador.Evaluar(t));
            if(puntos == minimo){
                empate = true;
            }
            if(puntos < minimo){
                minimo = puntos;
                candidato = jug.Equipo;
                empate = false;
            }
        }
            return empate? -1: candidato;
}
}
class finalPorCantidad: IWinner{
    public int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0) 
        return juego.JugadorActual.Equipo;
        int minimo = int.MaxValue;
        bool empate = true;
        int candidato = int.MaxValue;
        foreach (var jug in juego.Jugadores)
        {   
            int FichasLeQuedan = juego.manos[jug].Count;
            if(FichasLeQuedan == minimo){
                empate = true;
                continue;
            }
            if(FichasLeQuedan < minimo){
                minimo = FichasLeQuedan;
                candidato = jug.Equipo;
                empate = false;
            }
        }
        return empate? -1 :candidato;
    }
}
}