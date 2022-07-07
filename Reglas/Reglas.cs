using System;

namespace DominoRules{
public class Rules<T>{

   public int Cantidad_Inicial_En_La_Mano{get; private set;}
   //holds how many pieces initialy have every player at the start of the game
   
   public readonly int Tope;
   public readonly IEndCondition<T> Final;
   public readonly IPieceEvaluator<T> Evaluador;
   public readonly ITurn<T> Turno;
   public readonly ILegalPlay<T> JugadaLegal;
   public readonly IWinner<T> Ganador;
   public readonly ITorn<T> TipoDeTorneo;
   public readonly IPieceDistributer<T> Repartidor;
   public readonly IGenerator<T> Generator;
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

 
  /* public void NewConditionToPlay(ILegalPlay newRule)
   //change the rules of the play
   {
      JugadaLegal=newRule;
   }
   public void NewValue(IEvaluadorFichas newPieceValue)
   //change the criterio of value of the pieces
   {
      Evaluador=newPieceValue;
   }
   public void NewConditionToWin(IEndCondition newWin)
   //change the condition to win
   {
      final=newWin;
   }
   public void ChangePlayersTurn(ITurn PlayerTurn)
   {
      this.Turno=PlayerTurn;
   }
   */
}
}
