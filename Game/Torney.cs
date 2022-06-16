using DominoPlayer;
using DominoRules;
using DominoTable;
using System.Collections.Generic;
namespace DominoGame{

public class Torney
{
    Player[] jugadores;
    Rules reglas;
    public Game JuegoActual;
    Dictionary<int, double> Scores = new Dictionary<int, double>();
    public Torney(Player[] jugadores, Rules reglas){
    {
       this.jugadores = jugadores;
       this.reglas = reglas;
       this.JuegoActual = new Game(jugadores, reglas);
    }

    IEnumerable<Game> JugarUnJuego(Game juego){
        foreach (Game turnos in juego)
        {
            yield return turnos;
        }
    }
     void RepartidorDePuntos(Dictionary<int, double> scores, Game juego, Rules reglas){
             int ganador = reglas.ganador.Winner(juego);
             if(ganador == -1){
                 return;
             }
             double Score = 0;
             foreach (var jugador in juego.Jugadores)
             {
                 if(jugador.equipo == ganador){
                     continue;
                 }
                 foreach (Piece ficha in juego.manos[jugador])
                 {
                     Score += reglas.evaluador.Evaluar(ficha);
                 }
             }
             Scores[ganador] += Score;
    }
    void NextGame(){
        JuegoActual = new Game(jugadores, reglas);
    }
    bool SeAcabo(){
        foreach (double puntuacion in Scores.Values)
        {
            if(puntuacion>= 100){
                return true;
            }
        }
        return false;
    }
    }
}

}