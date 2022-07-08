using DominoTable;
using System;

namespace DominoRules{

public interface ILegalPlay<T>
//Determina si una jugada es legal o no
{
    public bool IsLegal(T[] disp, Piece<T> ficha,int pos, int cara, bool nuevaMesa);
}

public class RegularLegalPlay<T>:ILegalPlay<T>
{
    public virtual bool IsLegal(T[] disp, Piece<T> ficha,int pos, int cara, bool nuevaMesa) =>
     nuevaMesa || ficha.values[cara]!.Equals(disp[pos]);
} //Una jugada es valida si la cara por donde se juega es igual al valor de la posicion donde
  //se quiere jugar

public class AlwaysCanUseDobles<T>:RegularLegalPlay<T>
{
    public override bool IsLegal(T[] disp, Piece<T> ficha,int pos, int cara, bool nuevaMesa) => 
    ficha.values.Distinct().Count() == 1|| base.IsLegal(disp ,ficha,pos, cara, nuevaMesa);
     //Siempre se pueden usar dobles, por lo demas, es un juego regular
}

 public class Escareromino: ILegalPlay<int>{
    public bool IsLegal(int[] disp, Piece<int> ficha, int pos, int cara, bool nuevaMesa)=>
     nuevaMesa ||ficha.values[cara]== 0 || ficha.values[cara] == disp[pos] + 1;
}
//Siempre se puede jugar un blanco o un valor una unidad mayor a la cara donde se desea jugar
 public class Piramiomino: ILegalPlay<int>{
     public bool IsLegal(int[] disp, Piece<int> ficha, int pos, int cara, bool nuevaMesa) => 
     nuevaMesa|| Math.Abs(ficha.values[cara] - disp[pos]) == 1;
     }
//Siempre se puede jugar una unidad mayor o una unidad menor a lo que se desa jugar
 }