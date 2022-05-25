using System;
using System.Collections;
using DominoRules;

namespace DominoGame;

public class Game
{
    public Player[] players{get; private set;}
    private Rules rules;
    public int[] score;
    public Table table{get; private set;}

    public Game(Player[] players, Rules rules)
    {
        this.players=players;
        this.rules=rules;
        this.score=players.Length;
    }
    public void NextRound()
    {
        table=new Table(rules.PiecesOfThePlay);
        rules.Repart(players,rules.InitialPiecesInHand);
    }
    public void NextPlay()
    {
        int i=rules.GetNextPlayer();
        rules.PlayTurn(Jugador[i],table);
        
    }
    public void RoundEnd()
    {
        //a modificar
    }
}

public class Player
{
    public List<Piece> Hand;
    public IEstrategia estrategia;
    public Player(ICollection<Piece> Hand,IEstrategia estrategia)
    {
        this.Hand=Hand;
        this.estrategia=estrategia;
    }
    public (Ficha,int) Play(Rules rules, Table table)
    {
        (int,int) selection=estrategia.Play(Hand,table,rules);
        Piece SelectedPiece = Hand[selection.Item1];
        Hand.Remove(selection.Item1);
        return (SelectedPiece,selection.Item2);
    }
    public Piece Take(Rules rules, Table table)
    {
        Piece Selected=estrategia.Take(hand,table,rules);
        Hand.Add(Selected);
        return Selected;
    }
    public void newHand(ICollection<Piece> pieces)
    {
        this.Hand=pieces;
    }
}

public class Piece
{
    public int[] values{get; private set;}

    public Piece(int[] values)
    {
        this.values=values;
    }
        
    public override string toString()
    {
        string retorno = "[";
        for (int i = 0; i < values.Length; i++)
        {
            retorno+=values[i]+",";
        }
        return retorno+"]";
    }
}    

public class Table
{
    public int[] WhereToPlay{get;private set;}
    public void NewPiece(int value,int pos)
    {

        WhereToPlay[pos]=value;
    }
    public void NewPiece(Piece piece, int pos)
    {
        if(piece.values[0]==WhereToPlay[pos])
            WhereToPlay[pos]=piece.values[1];
        WhereToPlay[pos]=piece.values[0];
    }
}