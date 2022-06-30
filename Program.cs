using System;
using DominoGame;
using DominoPlayer;
using DominoRules;
using DominoTable;

Torney torneo = new Torney(new Player[]
{
    new Player("Juanito", new BotaMasRepetida(),1 ),
    new Player("Fefito", new BotaMasRepetida(),2 ), 
    new Player("Menganito", new estrategiaBotaGorda(),3), 
    new Player("Esperancejo", new estrategiaBotaGorda(),4)
}, new Rules());

Console.WriteLine("Ha comenzado el juego!!!!!!!!!! :D");

foreach (var Game in torneo)
{
  foreach (var escena in torneo.JuegoActual){
      Console.WriteLine("Es el turno del jugador {0}", escena.JugadorUltimaJugada.Nombre);  
      Console.WriteLine("El jugador actual ha jugado el {0} por la {1}", escena.ultimaFicha, escena.posicionUltimaJugada);
    }
    Console.WriteLine("Nuevo juego");
}
    Console.WriteLine("Se acabo el torneo \n Ganador: Equipo {0}", torneo.Ganador);   