using System;
using DominoGame;
using DominoPlayer;
using DominoRules;
using DominoTable;
using System.Text;
Torney torneo = new Torney(new Player[]
{
    new Player("Juanito", new BotaMasRepetida(),1 ),
    new Player("Fefito", new BotaMasRepetida(),2 ), 
    new Player("Menganito", new estrategiaBotaGorda(),3), 
    new Player("Esperancejo", new estrategiaBotaGorda(),4)
}, new Rules(new FinPorTranque(), new EvaluadorSuma(), new NormalTur(), new RegularLegalPlay(), new finalPorPuntos(), new TornPorPuntos(), new distribucionRandom(), 9, 7));

Console.WriteLine("Ha comenzado el juego!!!!!!!!!! :D");

foreach (var Game in torneo)
{
  foreach (var escena in torneo.JuegoActual){
     Console.WriteLine("Manos:");
      foreach (var jug in escena.manos.Keys)
      {
        Console.WriteLine("Jugador {0}: {1}", jug.Nombre, FichasAString(escena.manos[jug])); 
      }
      Console.WriteLine(FichasAString(escena.Tablero));
    }
    Console.WriteLine("Nuevo juego");
}
    Console.WriteLine("Se acabo el torneo \n Ganador: Equipo {0}", torneo.Ganador);   

string FichasAString(IEnumerable<Piece> mano){
    StringBuilder imprimir = new();
    foreach (var item in mano)
    {
        imprimir.Append(item.ToString());
    }
    return imprimir.ToString();
}
