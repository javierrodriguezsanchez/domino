using DominoTable;
using System;

namespace DominoRules{

public interface ILegalPlay
//Determina si una jugada es legal o no
{
    public bool IsLegal(int[] disp, Piece ficha,int pos, int cara, bool nuevaMesa);
}

public class RegularLegalPlay:ILegalPlay
{
    public virtual bool IsLegal(int[] disp, Piece ficha,int pos, int cara, bool nuevaMesa) =>
     nuevaMesa || disp[pos] == ficha.values[cara];
} //Una jugada es valida si la cara por donde se juega es igual al valor de la posicion donde
  //se quiere jugar

public class AlwaysCanUseDobles:RegularLegalPlay
{
    public override bool IsLegal(int[] disp, Piece ficha,int pos, int cara, bool nuevaMesa) => 
    ficha.values.Distinct().Count() == 1|| base.IsLegal(disp ,ficha,pos, cara, nuevaMesa);
     //Siempre se pueden usar dobles, por lo demas, es un juego regular
}

 public class Escareromino: ILegalPlay{
    public bool IsLegal(int[] disp, Piece ficha, int pos, int cara, bool nuevaMesa)=>
     nuevaMesa ||ficha.values[cara]== 0 || ficha.values[cara] == disp[pos] + 1;
}
//Siempre se puede jugar un blanco o un valor una unidad mayor a la cara donde se desea jugar
 public class Piramiomino: ILegalPlay{
     public bool IsLegal(int[] disp, Piece ficha, int pos, int cara, bool nuevaMesa) => 
     nuevaMesa|| Math.Abs(ficha.values[cara] - disp[pos]) == 1;
     }
//Siempre se puede jugar una unidad mayor o una unidad menor a lo que se desa jugar
 }