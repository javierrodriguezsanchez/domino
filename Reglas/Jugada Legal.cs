using DominoTable;

namespace DominoRules;

public interface ILegalPlay
{
    public bool IsLegal(Table mesa, Piece ficha,int pos);
}

public class RegularLegalPlay:ILegalPlay
{
    public virtual bool IsLegal(Table mesa, Piece ficha,int pos)
    {
        if(mesa.nuevaMesa)
            {return true;}
            for (int i = 0; i < ficha.values.Length; i++){
                if(mesa[pos] == ficha.values[i]){
                     return true;
                }
        }
        return false;
    }
}

public class AlwaysCanUseDobles:RegularLegalPlay
{
    public override bool IsLegal(Table mesa, Piece ficha,int pos)
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
        return base.IsLegal(mesa,ficha,pos);
    }   
}