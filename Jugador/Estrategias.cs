using DominoTable;
using DominoGame;
using DominoRules;
using System.Collections.Generic;
using System.Linq;

namespace DominoPlayer{

public interface IEstrategia
{
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table table, Rules reglas);
    //Retorno la pieza a jugar, la posicion donde jugarla y la cara por donde jugar.
}

public class estrategiaBorracho: IEstrategia{   
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas){
        return JugadasComunes.CogerPrimera(mano, mesa,reglas);
    }
}
public class estrategiaBotaGorda: IEstrategia{
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas){
       
        IEnumerable<Piece> manoOrdenada = mano.OrderByDescending(ficha => reglas.evaluador.Evaluar(ficha));
        return JugadasComunes.CogerPrimera(manoOrdenada, mesa,reglas);
    }
}
/*public class estrategiaRandom: IEstrategia{
    public(int, int)
}*/

static class JugadasComunes{
    public static (Piece, int, int) CogerPrimera(IEnumerable<Piece> mano, Table mesa, Rules reglas){
            
          foreach (Piece ficha in mano)
          {
              for (int i = 0; i < mesa.Disponibles.Length; i++)
              {
                  for (int j = 0; j < ficha.values.Length; j++)
                  {
                      if(reglas.jugadaLegal.IsLegal(mesa, ficha, i, j))
                        return (ficha,i,j);
                  }
              }
          }
        
        return (new Piece(), int.MaxValue,int.MaxValue);
   }

}
}

