using System;

namespace DominoRules{
public class Rules{
<<<<<<< HEAD

=======
>>>>>>> a5c8ef3634e4866c67e9015da09fd504cace0998
   public int Cantidad_Inicial_En_La_Mano{get; private set;}
   //holds how many pieces initialy have every player at the start of the game
   
   public readonly int Tope;
   public readonly IEndCondition Final;
<<<<<<< HEAD
   public readonly IPieceEvaluator Evaluador;
=======
   public readonly IEvaluadorFichas Evaluador;
>>>>>>> a5c8ef3634e4866c67e9015da09fd504cace0998
   public readonly ITurn Turno;
   public readonly ILegalPlay JugadaLegal;
   public readonly IWinner Ganador;
   public readonly ITorn TipoDeTorneo;
   public readonly IPieceDistributer Repartidor;
<<<<<<< HEAD
   public readonly IGenerator Generator;
   public Rules(IEndCondition final, IPieceEvaluator evaluador, ITurn turn, ILegalPlay validador, IWinner ganador, ITorn tipoTorn, IPieceDistributer repartidor, IGenerator generator, int tope, int cantInicialMano)   //Feisima esta clase, pero weno, no la voa tocar por ahora.
=======
   public Rules(IEndCondition final, IEvaluadorFichas evaluador, ITurn turn, ILegalPlay validador, IWinner ganador, ITorn tipoTorn, IPieceDistributer repartidor, int tope, int cantInicialMano)   //Feisima esta clase, pero weno, no la voa tocar por ahora.
>>>>>>> a5c8ef3634e4866c67e9015da09fd504cace0998
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
