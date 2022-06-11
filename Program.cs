using System;
using DominoGame;
using DominoPlayer;
using DominoRules;
using DominoTable;

Game juego = new Game(new Player[]
{
    new Player("Juanito", new estrategiaBotaGorda()),
    new Player("Fefito", new estrategiaBotaGorda()), 
    new Player("Menganito", new estrategiaBotaGorda()), 
    new Player("Esperancejo", new estrategiaBotaGorda())
}, new Rules());

Console.WriteLine("Ha comenzado el juego!!!!!!!!!! :D");
while(true){
    Console.WriteLine("Turno # {0} \n Le toca jugar a {1} \n Le quedan {2} fichas", juego.turno, juego.NombreJugadorActual, juego.cantFichasJugadorActual);
    (Piece, int,int) jugada = juego.Jugar();
    if(jugada.Item2 == int.MaxValue){
        Console.WriteLine("{0} se ha pasado :(", juego.JugadorActual);}
    else{
        if(jugada.Item2 == -1){
            Console.WriteLine("{0} ha comenzado con {1}", juego.NombreJugadorActual, jugada.Item1);
        }
        else{

        if(jugada.Item2 == 0){
            Console.WriteLine("El jugador ha jugado el {0} por la izquierda", jugada.Item1);
        }
        else{
            Console.WriteLine("El jugador ha jugado el {0} por la derecha", jugada.Item1);
        }
          }
          //Console.ReadLine();
          //Console.Clear();
    }
    if(juego.SeAcabo()){
        Console.WriteLine("Se acabo el juego!!!!!!!!");
        break;
    }
    juego.AvanzarTurno();
    }
    int Ganador = juego.Ganador();
    if(Ganador == -1){
        Console.WriteLine("Es un empate!!!!!");
    }
    else{
        Console.WriteLine("El ganador es {0} !!!!!!!!!!!!!!!! :D", juego.Jugadores[Ganador].nombre );
    }