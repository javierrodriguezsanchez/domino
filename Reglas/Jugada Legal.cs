using DominoTable;
using System;

namespace DominoRules{

public interface ILegalPlay
//Determina si una jugada es legal o no
{
    public bool IsLegal(Table mesa, Piece ficha,int pos, int cara);
}

public class RegularLegalPlay:ILegalPlay
{
    public virtual bool IsLegal(Table mesa, Piece ficha,int pos, int cara) =>
     mesa.nuevaMesa || mesa[pos] == ficha.values[cara];
} //Una jugada es valida si la cara por donde se juega es igual al valor de la posicion donde
  //se quiere jugar

public class AlwaysCanUseDobles:RegularLegalPlay
{
    public override bool IsLegal(Table mesa, Piece ficha,int pos, int cara) => 
    ficha.values.Distinct().Count() == 1|| base.IsLegal(mesa,ficha,pos, cara);
     //Siempre se pueden usar dobles, por lo demas, es un juego regular
}

 public class Escareromino: ILegalPlay{
    public bool IsLegal(Table mesa, Piece ficha, int pos, int cara)=>
     mesa.nuevaMesa ||ficha.values[cara]== 0 || ficha.values[cara] == mesa.Disponibles[pos] + 1;
}
//Siempre se puede jugar un blanco o un valor una unidad mayor a la cara donde se desea jugar
 public class Piramiomino: ILegalPlay{
     public bool IsLegal(Table mesa, Piece ficha, int pos, int cara) => 
     mesa.nuevaMesa|| Math.Abs(ficha.values[cara] - mesa.Disponibles[pos]) == 1;
     }
//Siempre se puede jugar una unidad mayor o una unidad menor a lo que se desa jugar
 }