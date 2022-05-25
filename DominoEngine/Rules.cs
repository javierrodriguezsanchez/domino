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
    private int PointsToWin;

    public IOrder OrderToPlay{get;private set;}
    //holds the order of the turns of every player
    public ILegalPlay CheckMove{get;private set;}
    //Holds the way to check if some piece could be played in the table
    public IWinCondition ConditionToWin{get;private set;}
    //Holds the way check if someone win
    public IPieceValue PieceValue{get;private set;}
    //holds the opinion of value for a piece
    public IPlayerTurn PlayerTurn{get;private set;}
    public IRoundScore RoundScore{get;private set;}
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
        RoundScore = new StandartRules();
        PlayerTurn = new StandartRules();
        PointsToWin = 1;
    }

    public void PlayTurn(Player player, Table table)
    {
        PlayerTurn.Play(player,table,this);
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
    public void GetScore(int[] ActualScore, Player[] players, int Winner)
    //actualize the score
    {
        PlayerScore(ActualScore, players, Winner);
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
    public void Repart(Player[] players)
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
        if(newSet==null || newSet<=0)
            throw ArgumentException("Invalid Argument");
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
        if (newLimit<=0)
        {
            throw ArgumentException("Invalid Argument");
        }
        if((newLimit+1)*newLimit/2+newLimit+1<newNumberOfPlayers*newInitialPiecesInHand)
            throw ArgumentException("Can't distribute this Pieces between the Players");
        NumberOfPlayers=newNumberOfPlayers;
        InitialPiecesInHand=NewInitialPiecesInHand;
        PiecesOfThePlay=Standart(newLimit);
    }
    public void NewInitialDistribution(int newNumber)
    //change the numbers of pieces per player at the start of the game
    {
        if(newNumber*InitialPiecesInHand>PiecesOfThePlay)
            throw ArgumentException("Number of players must be less than the number of pieces");
        InitialPiecesInHand=newNumber;
    }
    public void ChangeOrderToPlay(IOrder newOrder)
    //change the order to play
    {
        OrderToPlay=newOrder;
    }
    public void NewConditionToPlay(ILegalPlay newRule)
    //change the rules of the play
    {
        CheckMove=newRule;
    }
    public void NewValue(IPieceValue newPieceValue)
    //change the criterio of value of the pieces
    {
        PieceValue=newPieceValue;
    }
    public void NewConditionToWin(IWinCondition newWin)
    //change the condition to win
    {
        ConditionToWin=newWin;
    }
    public void ChangePlayersTurn(IPlayerTurn PlayerTurn)
    {
        this.PlayerTurn=PlayerTurn;
    }
    public void ChangeLimit(int newLimit)
    {
        if(newLimit<=0)
            throw ArgumentException("Invalid Argument. Must be bigger than 0");
        else
            PointsToWin=newLimit;
    }
}

