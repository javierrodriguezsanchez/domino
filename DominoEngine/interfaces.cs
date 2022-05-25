using System;
using DominoGame;
using DominoRules;

namespace DominoInterfaces;

public interface IEstrategia
{
    public int Play(Piece[] hand, Table table, Rules rules);
    public Piece Take(Piece[] hand, Table table, Rules rules);
}

public interface IRoundScore
{
    public int PlayerScore(Player player, Table table);
}

public interface IPieceValue
{
    public int CalculateValue(Piece piece);
}

public interface IOrder
{
    public int Next();
}

public interface ILegalPlay
{
    public bool CheckMove(Piece piece, Table table);
}
public interface IWinCondition
{
    public int Win(Player[] players, Table table);
}