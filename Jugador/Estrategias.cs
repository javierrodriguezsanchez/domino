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
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas) => 
    MetodosAuxiliares.CogerPrimera(mano, mesa,reglas);
    //Es el jugador booracho, juega la primera ficha que ve
    }
    
public class estrategiaBotaGorda: IEstrategia{
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas){
       
        IEnumerable<Piece> manoOrdenada = mano.OrderByDescending(ficha => reglas.Evaluador.Evaluar(ficha));
        return MetodosAuxiliares.CogerPrimera(manoOrdenada, mesa,reglas);
        //Es el famoso Bota-Gordas, siempre trata de jugar la ficha de mayor valor posible
    }
}

public class BotaMasRepetida: IEstrategia{
    public (Piece, int, int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas){
        IEnumerable<Piece> manoOrdenada = mano.OrderByDescending(fichaOrd => 
        mano.Where(FichaEnMano => FichaEnMano.values.Any(valor => fichaOrd.values.Contains(valor))).Count());
        return MetodosAuxiliares.CogerPrimera(mano,mesa,reglas);
    }
}



static class MetodosAuxiliares{
    public static (Piece ficha, int posicion, int cara) CogerPrimera(IEnumerable<Piece> mano, Table mesa, Rules reglas){
            
          foreach (Piece ficha in mano)
          {
              for (int i = 0; i < mesa.Disponibles.Length; i++)
              {
                  for (int j = 0; j < ficha.values.Length; j++)
                  {
                      if(reglas.JugadaLegal.IsLegal(mesa, ficha, i, j))
                        return (ficha,i,j);
                  }
              }
          }
        
        return (new Piece(), int.MaxValue,int.MaxValue);
   }
 
}
}