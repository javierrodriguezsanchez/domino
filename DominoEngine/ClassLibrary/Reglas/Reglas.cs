using System;

namespace DominoRules{
public class Rules<T>{

   public int Cantidad_Inicial_En_La_Mano{get; private set;}
   //holds how many pieces initialy have every player at the start of the game
   
   public readonly int Tope;
   //Maximo de fichas en el juego
   public readonly IEndCondition<T> Final;
   //Decide cuando el juego termina 
   public readonly IPieceEvaluator<T> Evaluador;
   //A cada ficha le asigna su valor
   public readonly ITurn<T> Turno;
   //Establece las acciones a realizar durante un turno
   public readonly ILegalPlay<T> JugadaLegal;
   //Establece las posibles jugadas legales en el juego
   public readonly IWinner<T> Ganador;
   //Decide cual es el equipo ganador una vez concluido el juego
   public readonly ITorn<T> TipoDeTorneo;
   //Establece la forma de repartir los puntos en el torneo y las condiciones de finalizacion del mismo
   public readonly IPieceDistributer<T> Repartidor;
   //Decide la forma de distribuir las fichas una vez iniciado el juego
   public readonly IGenerator<T> Generator;
   //Genera las fichas de la reserva al iniciar el juego
   public Rules(IEndCondition<T> final, IPieceEvaluator<T> evaluador, ITurn<T> turn, ILegalPlay<T> validador, IWinner<T> ganador, ITorn<T> tipoTorn, IPieceDistributer<T> repartidor, IGenerator<T> generator, int tope, int cantInicialMano)   //Feisima esta clase, pero weno, no la voa tocar por ahora.
   {
      Tope = tope;
      Cantidad_Inicial_En_La_Mano = cantInicialMano;
      Final = final;
      Evaluador = evaluador;
      Turno = turn;
      JugadaLegal = validador;
      Ganador = ganador;
      TipoDeTorneo = tipoTorn;
      Repartidor = repartidor;
      Generator = generator;
   }
}
}
