using DominoGame;
using DominoPlayer;
using DominoTable;
using System.Collections;
using System.Linq;
using System;
namespace DominoRules
{
public interface  IEndCondition<T>{
   public bool EndOfTheGame(Game<T> juego);
}
public interface IWinner<T>{
    public int Winner(Game<T> juego);
}
 class FinPorTranque<T>: IEndCondition<T>{
    //Se acaba cuando los pases consecutivos es igual a la cantidad de jugadores o cuando un jugador se queda 
    //sin fichas en la mano
  public bool EndOfTheGame(Game<T> juego) =>
  juego.cantFichasJugadorActual == 0|| juego.PasadosSeguidos >= juego.Jugadores.Length;
    }

  class Mesa150puntos<T>: IEndCondition<T>{
    //El juego termina cuando se acumulan 150 puntos en la mesa o se reunen las condiciones del fin por tranque
    public bool EndOfTheGame(Game<T> juego) => 
    juego.Tablero.Historial().Select(jug => jug.Ficha).Sum(t => juego.reglas.Evaluador.Evaluar(t)) >= 150 ||
     juego.cantFichasJugadorActual == 0 || juego.PasadosSeguidos >= juego.Jugadores.Length;
  }
  class DosPases<T>:IEndCondition<T>{
    //El juego termina al ocurrir dos pases seguidos
     public bool EndOfTheGame(Game<T> juego) =>
     juego.cantFichasJugadorActual == 0|| juego.PasadosSeguidos == 2;
  }

class finalPorPuntos<T>: IWinner<T>{
    //Gana el equipo que tenga al jugador con menor suma de puntos en la mano
    public int Winner(Game<T> juego){
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
class TeamPoints<T>: IWinner<T>{
    //Gana el equipo que, en su conjunto, sume menor cantidad de puntos
    public int Winner(Game<T> juego){
        if(juego.cantFichasJugadorActual == 0) 
            return juego.JugadorActual.Equipo;
        int minimo = int.MaxValue;
        bool empate = true;
        Dictionary<int,double> teamScores = new Dictionary<int,double>();
        int candidato=0;
        foreach(var team in juego.equipos)
        {
            teamScores.Add(team.Key,0);
            foreach (var jug in team.Value)
            {
                foreach(var ficha in juego.manos[jug])
                    teamScores[team.Key]+=juego.reglas.Evaluador.Evaluar(ficha);
            }
        }
        foreach(var team in teamScores)
        {
            if(team.Value<minimo)
            {
                candidato=team.Key;
                empate=false;
            }
            if(team.Value==minimo)
                empate=true;
        }
        return empate? -1 :candidato;
    }
}
}