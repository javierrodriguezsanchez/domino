using System;

namespace DominoRules{
public class Rules{
   public int Numero_de_Jugadores{get; private set;}
   public int Cantidad_Inicial_En_La_Mano{get; private set;}
   //holds how many pieces initialy have every player at the start of the game
   
   public readonly int Tope;
   public readonly IEndCondition Final;
   public readonly IEvaluadorFichas Evaluador;
   public readonly ITurn Turno;
   public readonly ILegalPlay JugadaLegal;
   public readonly IWinner Ganador;
   public readonly ITorn TipoDeTorneo;
   public Rules(IEndCondition final, IEvaluadorFichas evaluador, ITurn turn, ILegalPlay validador, IWinner ganador, ITorn tipoTorn, int tope, int cantJug, int cantInicialMano)   //Feisima esta clase, pero weno, no la voa tocar por ahora.
   {
      Tope = tope;
      Numero_de_Jugadores = cantJug;
      Cantidad_Inicial_En_La_Mano = cantInicialMano;
      Final = final  ;
      Evaluador = evaluador;
      Turno = turn;
      JugadaLegal = validador;
      Ganador = ganador;
      TipoDeTorneo = tipoTorn;
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
