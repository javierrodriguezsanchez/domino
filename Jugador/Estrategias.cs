using DominoTable;
using DominoGame;
using DominoRules;

namespace DominoPlayer;

public interface IEstrategia
{
    public (int, int) Play(List<Piece> mano, Table table, Rules reglas);
}

public class estrategiaBorracho: IEstrategia{   
    public (int, int) Play(List<Piece> mano, Table mesa, Rules reglas){
        return JugadasComunes.CogerPrimera(mano, mesa,reglas);
    }
}
public class estrategiaBotaGorda: IEstrategia{
    bool EsPrimerTurno=true;
    public (int, int) Play(List<Piece> mano, Table mesa, Rules reglas){
        if(EsPrimerTurno)
        {
            EsPrimerTurno=false;
            mano.OrderByDescending(ficha => reglas.evaluador.Evaluar(ficha));
        }
        return JugadasComunes.CogerPrimera(mano, mesa,reglas);
    }
}

static class JugadasComunes{
    public static (int, int) CogerPrimera(List<Piece> mano, Table mesa, Rules reglas){
            
            for(int pieza=0;pieza<mano.Count;pieza++)
                for(int Posibilidad=0;Posibilidad<mesa.Disponibles.Length;Posibilidad++){
                    if(reglas.jugadaLegal.IsLegal(mesa,mano[pieza], Posibilidad)){
                        return (pieza, Posibilidad);
                    }
        }
        return (int.MaxValue, int.MaxValue);
   }

}

