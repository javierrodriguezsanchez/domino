using System;
using DominoGame;
using DominoPlayer;
using DominoRules;
using DominoTable;

Torney torneo = new Torney(new Player[]
{
    new Player("Juanito", new estrategiaBotaGorda(),1 ),
    new Player("Fefito", new estrategiaBotaGorda(),1 ), 
    new Player("Menganito", new estrategiaBotaGorda(),1), 
    new Player("Esperancejo", new estrategiaBotaGorda(),1)
}, new Rules());

Console.WriteLine("Ha comenzado el juego!!!!!!!!!! :D");

while(true){
    foreach (Game item in torneo.JuegoActual){
      Console.WriteLine("Es el turno del jugador {0}", item.JugadorActual.nombre);  
      Console.WriteLine("El jugador actual ha jugado el{0}", item.jugadas[item.jugadas.Count-1].Item1);
    }
    }
   