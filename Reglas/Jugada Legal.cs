using DominoTable;

namespace DominoRules{

public interface ILegalPlay
{
    public bool IsLegal(Table mesa, Piece ficha,int pos, int cara);
}

public class RegularLegalPlay:ILegalPlay
{
    public virtual bool IsLegal(Table mesa, Piece ficha,int pos, int cara)
    {
        if(mesa.nuevaMesa)
            {return true;}

                if(mesa[pos] == ficha.values[cara]){
                     return true;   }
        return false;
    }
}

public class AlwaysCanUseDobles:RegularLegalPlay
{
    public override bool IsLegal(Table mesa, Piece ficha,int pos, int cara)
    {
        int value=ficha.values[0];
        bool IsDouble=true;
        foreach(int face in ficha.values)
            if (face!=value)
            {
                IsDouble=false;
                break;
            }
        if(IsDouble)
            return true;
        return base.IsLegal(mesa,ficha,pos, cara);
    }   
}
}
/* public class Escareromino:ILegalPlay{
    public bool IsLegal(Table mesa, Piece ficha, int pos){

    }
}
}*/