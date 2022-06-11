using DominoGame;
using DominoTable;
using System.Collections;
using System.Linq;
using System;
namespace DominoRules
{
public interface  IEndCondition{
   public bool EndOfTheGame(Game juego);
   public int Winner(Game Juego);
}
abstract class FinPorTranque: IEndCondition{
  public bool EndOfTheGame(Game juego){
        if(juego.cantFichasJugadorActual == 0|| juego.pasadosSeguidos >= juego.Jugadores.Length){
            return true;
        }
        return false;
    }
    public abstract int Winner(Game juego);
}

class finalPorPuntos: FinPorTranque{
    public override int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0){
        return juego.JugadorActual;}
        bool empate = true;
        int candidato = -1;
        int minimo = int.MaxValue;
        for (int i = 0; i < juego.Jugadores.Length; i++)
        {
              int total = 0;
              var mano = juego.Jugadores[i].mostrarMano();
              foreach (var ficha in mano){
                  total += juego.reglas.evaluador.Evaluar(ficha);
              }
              if(total == minimo){
                  empate = true;
              } else if (total < minimo){
                  minimo = total;
                  candidato = i;
                  empate = false;
              }
        }
         if(empate){
            return -1;
        }else return candidato;
    }
}
class finalPorCantidad: FinPorTranque{
    public override int Winner(Game juego){
        if(juego.cantFichasJugadorActual == 0) 
        return juego.JugadorActual;
        int minimo = int.MaxValue;
        bool empate = false;
        int candidato = int.MaxValue;
        for (int i= 0; i< juego.Jugadores.Length; i++){
             if (juego.Jugadores[i].FichasLeQuedan == minimo){   
                 empate = true;
                continue;
            }
            if (juego.Jugadores[i].FichasLeQuedan < minimo){
                minimo = juego.Jugadores[i].FichasLeQuedan;
                candidato = i;
                empate = false;
            }
        }
        if(empate){
            return -1;
        }
        else return candidato;
    }
}
}