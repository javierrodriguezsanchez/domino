using System;

namespace DominoTable
{

 public class Piece<T>
{
    public T[] values{get; private set;}
    //Valores en cada cara de la ficha
    public bool IsNull{get; private set;}
    //Variable auxiliar para indicar pases y jugadas no legales
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