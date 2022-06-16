using System;

namespace DominoRules{
public class Rules{
   public int numero_de_Jugadores{get; private set;}
   public int Cantidad_Inicial_En_La_Mano{get; private set;}
   //holds how many pieces initialy have every player at the start of the game
   public GamePieces Fichas_Del_Juego{get; private set;}
   public IEndCondition final;
   public IEvaluadorFichas evaluador;
   public ITurn turno;
   public ILegalPlay jugadaLegal;
   public IWinner ganador;

   public Rules()   //Feisima esta clase, pero weno, no la voa tocar por ahora.
   {
      numero_de_Jugadores=4;
      Cantidad_Inicial_En_La_Mano=7;
      Fichas_Del_Juego=new GamePieces(6);
      final=  new FinPorTranque();
      evaluador=new EvaluadorSuma();
      turno=new NormalTurn();
      jugadaLegal = new AlwaysCanUseDobles();
      ganador = new finalPorPuntos();
   }

   public void NewSetOfPieces(GamePieces newSet)
   //change the current pieces for those ones in the argument
   {
      if(newSet==null || newSet.Length==0)
         return;
      Fichas_Del_Juego=newSet;
        if(numero_de_Jugadores<Fichas_Del_Juego.Length)
            numero_de_Jugadores=Fichas_Del_Juego.Length;
        if(Cantidad_Inicial_En_La_Mano*numero_de_Jugadores>Fichas_Del_Juego.Length)
            Cantidad_Inicial_En_La_Mano=Fichas_Del_Juego.Length/numero_de_Jugadores;
    }    
   public void ChangeNumberOfPlayers(int newNumber)
   {
      if(newNumber*Cantidad_Inicial_En_La_Mano<=Fichas_Del_Juego.Length)
         numero_de_Jugadores=newNumber;
      else
      {
         numero_de_Jugadores=Math.Min(newNumber,Fichas_Del_Juego.Length);
         Cantidad_Inicial_En_La_Mano=Fichas_Del_Juego.Length/numero_de_Jugadores;
      }
   }
   public void NewInitialDistribution(int newNumber)
   //change the numbers of pieces per player at the start of the game
   {
      if(newNumber*numero_de_Jugadores<=Fichas_Del_Juego.Length)
         Cantidad_Inicial_En_La_Mano=newNumber;
   }
   
   public void NewConditionToPlay(ILegalPlay newRule)
   //change the rules of the play
   {
      jugadaLegal=newRule;
   }
   public void NewValue(IEvaluadorFichas newPieceValue)
   //change the criterio of value of the pieces
   {
      evaluador=newPieceValue;
   }
   public void NewConditionToWin(IEndCondition newWin)
   //change the condition to win
   {
      final=newWin;
   }
   public void ChangePlayersTurn(ITurn PlayerTurn)
   {
      this.turno=PlayerTurn;
   }
}
}
