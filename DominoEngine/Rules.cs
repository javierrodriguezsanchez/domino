using System;
using DominoGame;
using DominoInterfaces;

namespace DominoRules;

public class Rules
{
    public int NumberOfPlayers{get; private set;}
    public Piece[] PiecesOfThePlay{get; private set;}
    public int InitialPiecesInHand{get; private set;}
    //holds how many pieces initialy have every player at the start of the game
    private IOrder OrderToPlay;
    //holds the order of the turns of every player
    private ILegalPlay CheckMove;
    //Holds the way to check if some piece could be played in the table
    private IWinCondition ConditionToWin;
    //Holds the way check if someone win
    private IPieceValue PieceValue;
    //holds the opinion of value for a piece
    public Rules()
    //by default create a simple domino 9 game
    {
        NumberOfPlayers = 4;
        InitialPiecesInHand = 10;
        Piece = Standart(9);
        OrderToPlay = new StandartRules(NumberOfPlayers);
        CheckMove = new StandartRules();
        ConditionToWin = new StandartRules();
        PieceValue = new StandartRules();
    }
    public int GetNextPlayer()
    //get the next player's turn 
    {
        return OrderToPlay.Next();
    }
    public bool IsValidMove(Piece piece, Table table)
    //check if is posible to play the piece in the game
    {
        return CheckMove(piece,table);
    }
    public int Win(Player[] players, Table table)
    //check if someone win
    {
        return ConditionToWin.Win(players,table);
    }
    public int GetValue(Piece piece)
    //check the value of a piece acording to the criterio
    {
        return PieceValue.GetValue(piece);
    }
    private Piece[] Standart(int n)
    //gets a doble n domino(doble 6, doble 9...)
    {
        Piece[] newPieces=new Piece[(n+1)*n/2+n+1];
        int count=0;
        for(int i=0;i<=n;i++)
            for(int j=i;j<=n;j++)
                newPieces[count++]=new Piece(new int[]{i,j});
    }

    public Repart(Player[] players)
    {
        List<Piece> pieces= new List<Piece>(PiecesOfThePlay);
        Random random;
        Piece[] hand=new Piece[10];
        for(int i=0;i<players.Length;i++)
        {
            for (int j = 0; j < InitialPiecesInHand; j++)
            {
                int aux=random.Next();
                hand[j]=pieces[aux];
                pieces.Delete(aux);
            }
            players[i].newHand(hand);    
        }
    }
    public void NewSetOfPieces(Piece[] newSet)
    //change the current pieces for those ones in the argument
    {
        PiecesOfThePlay=newSet;
        if(NumberOfPlayers<PiecesOfThePlay.Length)
            NumberOfPlayers=PiecesOfThePlay.Length;
        if(InitialPiecesInHand*NumberOfPlayers>PiecesOfThePlay.Length)
            InitialPiecesInHand=PiecesOfThePlay.Length/NumberOfPlayers;
    }    
    public void ChangeNumberOfPlayers(int newNumber)
    {
        if(newNumber*InitialPiecesInHand>PiecesOfThePlay)
            throw ArgumentException("Number of players must be less than the number of pieces");
        NumberOfPlayers=newNumber;
    }
    public void ChangePieces(int newLimit,int NewInitialPiecesInHand=InitialPiecesInHand,int newNumberOfPlayers=NumberOfPlayers)
    {
        if((newLimit+1)*newLimit/2+newLimit+1<newNumberOfPlayers*newInitialPiecesInHand)
            throw ArgumentException("Can't distribute this Pieces between the Players");
        NumberOfPlayers=newNumberOfPlayers;
        InitialPiecesInHand=NewInitialPiecesInHand;
        PiecesOfThePlay=Standart(newLimit);
    }
    public int NewInitialDistribution(int newNumber)
    //change the numbers of pieces per player at the start of the game
    {
        if(newNumber*InitialPiecesInHand>PiecesOfThePlay)
            throw ArgumentException("Number of players must be less than the number of pieces");
        InitialPiecesInHand=newNumber;
    }
    public int ChangeOrderToPlay(IOrder newOrder)
    //change the order to play
    {
        OrderToPlay=newOrder;
    }
    public int NewConditionToPlay(ILegalPlay newRule)
    //change the rules of the play
    {
        CheckMove=newRule;
    }
    public int NewValue(IPieceValue newPieceValue)
    //change the criterio of value of the pieces
    {
        PieceValue=newPieceValue;
    }
    public int NewConditionToWin(IWinCondition newWin)
    //change the condition to win
    {
        ConditionToWin=newWin;
    }
}

