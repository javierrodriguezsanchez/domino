using DominoTable;
using DominoGame;
using DominoRules;
using System.Collections.Generic;
using System.Linq;

namespace DominoPlayer{

public interface IEstrategia<T>
{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] PosDisponibles, Rules<T> reglas, bool nuevaMesa);
    //Retorno la pieza a jugar, la posicion donde jugarla y la cara por donde jugar.
}

public class estrategiaBorracho<T>: IEstrategia<T>{   
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] posicionesDisp, Rules<T> reglas, bool nuevaMesa) => 
    MetodosAuxiliares.CogerPrimera(mano, posicionesDisp ,reglas, nuevaMesa);
    //Es el jugador booracho, juega la primera ficha que ve
    }
    
public class estrategiaBotaGorda<T>: IEstrategia<T>{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] disp, Rules<T> reglas, bool nuevaMesa){
       
        IEnumerable<Piece<T>> manoOrdenada = mano.OrderByDescending(ficha => reglas.Evaluador.Evaluar(ficha));
        return MetodosAuxiliares.CogerPrimera(manoOrdenada, disp,reglas, nuevaMesa);
        //Es el famoso Bota-Gordas, siempre trata de jugar la ficha de mayor valor posible
    }
}

public class BotaMasRepetida<T>: IEstrategia<T>{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] disp, Rules<T> reglas, bool nuevaMesa){
        IEnumerable<Piece<T>> manoOrdenada = mano.OrderByDescending(fichaOrd => 
        mano.Where(FichaEnMano => FichaEnMano.values.Any(valor => fichaOrd.values.Contains(valor))).Count());
        return MetodosAuxiliares.CogerPrimera(mano,disp,reglas, nuevaMesa);
    }
}



static class MetodosAuxiliares{
    public static (Piece<T> ficha, int posicion, int cara) CogerPrimera<T>(IEnumerable<Piece<T>> mano, T[] posicionesDisp, Rules<T> reglas, bool NuevaMesa){
            
          foreach (Piece<T> ficha in mano)
          {
              for (int i = 0; i < posicionesDisp.Length; i++)
              {
                  for (int j = 0; j < ficha.values.Length; j++)
                  {
                      if(reglas.JugadaLegal.IsLegal(posicionesDisp, ficha, i, j, NuevaMesa))
                        return (ficha,i,j);
                  }
              }
          }
        
        return (new Piece<T>(), int.MaxValue,int.MaxValue);
   }
 
}
}