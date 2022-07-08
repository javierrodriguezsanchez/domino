using System;

namespace DominoTable
{

 public class Piece<T>
{
    public T[] values{get; private set;}
    public bool IsNull{get; private set;}
    public Piece()
    {
        values=new T[0];
        IsNull=true;
    }
    public Piece(T[] values)
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