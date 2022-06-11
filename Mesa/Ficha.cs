using System;

namespace DominoTable
{

 public class Piece
{
    public int[] values{get; private set;}
    public bool IsNull{get; private set;}
    public Piece()
    {
        values=new int[0];
        IsNull=true;
    }
    public Piece(int[] values)
    {
        this.values=values;
        IsNull=false;
    }
    public override string ToString()
    {
        string retorno = "[";
        for (int i = 0; i < values.Length; i++,retorno+=",")
        {
            retorno+=values[i];
        }
        return retorno.Remove(retorno.Length-1)+"]";
    }
}
}