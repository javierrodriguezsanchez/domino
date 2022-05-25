using System;
using DominoInterfaces;
using DominoGame;

public class StandartRules : IOrder,ILegalPlay,IWinCondition,IPieceValue,IRoundScore
//make the usual rules of the domino
{
    private int LastPlayer;
    private int numberOfPlayers;
    public StandartRules();
    public StandartRules(int NumberOfPlayers)
    //this constructor allows to give order
    {
        this.NumberOfPlayers=numberOfPlayers;
    }
    public int Next()
    {
        LastPlayer++;
        if(LastPlayer==numberOfPlayers)
            LastPlayer=0;
        return LastPlayer;
    }
    public override bool CheckMove(Piece piece, Table table)
    {
        for (int i = 0; i < piece.values.Length; i++)
            for (int j = 0; j < table.WhereToPlay.Length; j++)
            {
                if(piece[i]==table[j])
                    return true;
            }
        return false;
    }
    public override int Win(Player[] players, Table table)
    //return -1 if still no one still win, return -2 if no one can play, else return the number of the player  who won
    {
        for (int l = 0; l < players.Length; l++)
            if(players[l].Hand.Length==0)
                return l;
        for (int l = 0; l < players.Length; l++)
            for (int i = 0; i < players.Hand[l].values.Length; i++)
                for (int j = 0; j < table.WhereToPlay.Length; j++)
                {
                    if(players.Hand[l].values[i]==table[j])
                        return -1;
                }
            return -2;
    }
    public override int GetValue(Piece piece)
    {
        int value=0;
        for (int i = 0; i < piece.Length; i++)
        {
            value+=piece.values[i];
        }
        return value;
    }
    public override void PlayerScore(int[] OlderScore, Player[] players, int winner)
    {
        OlderScore[winner]++;
    }
}
