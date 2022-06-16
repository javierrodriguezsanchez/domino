using DominoGame;
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
  public bool EndOfTheGame(Game juego){
        if(juego.cantFichasJugadorActual == 0|| juego.pasadosSeguidos >= juego.Jugadores.Length){
            return true;
        }
        return false;
    }
}

class finalPorPuntos: IWinner{
    public int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0){
        return juego.JugadorActual.equipo;}
        bool empate = true;
        int candidato = -1;
        double minimo = double.MaxValue;
        /*for (int i = 0; i < juego.Jugadores.Length; i++)
        {
              double total = 0;
              var mano = juego.Jugadores[i].mostrarMano();
              foreach (var ficha in mano){
                  total += juego.reglas.evaluador.Evaluar(ficha);
              }
              if(total == minimo){
                  empate = true;
              } else if (total < minimo){
                  minimo = total;
                  candidato = juego.Jugadores[i].equipo;
                  empate = false;
              }
        }*/
         if(empate){
            return -1;
        }else return candidato;
    }
}
class finalPorCantidad: IWinner{
    public int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0) 
        return juego.JugadorActual.equipo;
        int minimo = int.MaxValue;
        bool empate = false;
        int candidato = int.MaxValue;
        /*for (int i= 0; i< juego.Jugadores.Length; i++){
             if (juego.Jugadores[i].FichasLeQuedan == minimo){   
                 empate = true;
                continue;
            }
            if (juego.Jugadores[i].FichasLeQuedan < minimo){
                minimo = juego.Jugadores[i].FichasLeQuedan;
                candidato = juego.Jugadores[i].equipo;
                empate = false;
            }
        }*/
        if(empate){
            return -1;
        }
        else return candidato;
    }
}
}