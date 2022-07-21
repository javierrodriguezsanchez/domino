using DominoTable;
using DominoGame;
using DominoRules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DominoPlayer{

public interface IEstrategia<T>
{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] PosDisponibles , IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador);
    //Retorno la pieza a jugar, la posicion donde jugarla y la cara por donde jugar.
}

public class estrategiaBorracho<T>: IEstrategia<T>{   
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] posicionesDisp , IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador) => 
    MetodosAuxiliares.CogerPrimera(mano, posicionesDisp ,reglas, nuevaMesa);
    //Es el jugador booracho, juega la primera ficha que ve
    }
    
public class estrategiaBotaGorda<T>: IEstrategia<T>{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] disp, IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador){
       
        IEnumerable<Piece<T>> manoOrdenada = mano.OrderByDescending(ficha => reglas.Evaluador.Evaluar(ficha));
        return MetodosAuxiliares.CogerPrimera(manoOrdenada, disp,reglas, nuevaMesa);
        //Es el famoso Bota-Gordas, siempre trata de jugar la ficha de mayor valor posible
    }
}


public class Pro<T>: IEstrategia<T>
//Este jugador analiza el historial del juego y los pases de sus aliados y adversarios, decidiendo cual es 
//la mejor ficha a jugar en cada momento
{
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] disp, IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador)
    {
        if(nuevaMesa){
            return MetodosAuxiliares.CogerPrimera(mano, disp, reglas, nuevaMesa);
        }
        double[,,] Posibilitys = new double[mano.Count(),disp.Length,mano.First().values.Length];
        int f=0;
        foreach(var ficha in mano)
        {
            for(int i=0;i<disp.Length;i++)
            {
                Jugada<T> Referida=(i==0?Historial.First():Historial.Last());
                for(int j=0;j<ficha.values.Length;j++)
                {
                    if(!reglas.JugadaLegal.IsLegal(disp,ficha,i,j,nuevaMesa))
                        continue;
                    Posibilitys[f,i,j]=6;
                    if(Referida.Jugador.Equipo!=EquipoDelJugador)
                        Posibilitys[f,i,j]+=0.5;
                    for(int k=0;k<ficha.values.Length;k++)
                    {
                        if(k==j)
                            continue;
                        foreach (var pase in pases)
                        {
                            if(pase.Jug.Equipo==EquipoDelJugador)
                                continue;
                            if(pase.Disponibles.Contains(ficha.values[k]))
                            {
                                Posibilitys[f,i,j]+=3;
                                break;
                            }
                        }
                        foreach (var pase in pases)
                        {
                            if(pase.Jug.Equipo!=EquipoDelJugador)
                                continue;
                            if(pase.Disponibles.Contains(ficha.values[k]))
                            {
                                Posibilitys[f,i,j]-=3;
                                break;
                            }
                        }
                    }

                    foreach (var pase in pases)
                    {
                        if(pase.Jug.Equipo==EquipoDelJugador)
                            continue;
                        if(pase.Disponibles.Contains(disp[i]))
                        {
                            Posibilitys[f,i,j]-=2;
                            break;
                        }
                    }
                    foreach (var pase in pases)
                    {
                        if(pase.Jug.Equipo!=EquipoDelJugador)
                            continue;
                        if(pase.Disponibles.Contains(disp[i]))
                        {
                            Posibilitys[f,i,j]+=2;
                            break;
                        }
                    }
                }
            }
            f++;
        }
        (int,int,int) Max=(0,0,0);
        for (int i = 0; i < Posibilitys.GetLength(0); i++)
            for (int j = 0; j < Posibilitys.GetLength(1); j++)
                for (int k = 0; k < Posibilitys.GetLength(2); k++)
                    if(Posibilitys[Max.Item1,Max.Item2,Max.Item3]<Posibilitys[i,j,k])
                        Max=(i,j,k);
        if(Posibilitys[Max.Item1,Max.Item2,Max.Item3]!=0)
            return (mano.ElementAt(Max.Item1),Max.Item2,Max.Item3);
        return (new Piece<T>(), int.MaxValue,int.MaxValue);
                
    }
}


public class BotaMasRepetida<T>: IEstrategia<T>{
    //Trata de solatar la ficha mas reemplazable posible
    public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] disp, IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador){
        IEnumerable<Piece<T>> manoOrdenada = mano.OrderByDescending(fichaOrd => 
        mano.Where(FichaEnMano => FichaEnMano.values.Any(valor => fichaOrd.values.Contains(valor))).Count());
        return MetodosAuxiliares.CogerPrimera(manoOrdenada,disp,reglas, nuevaMesa);
    }
}

public class EstrategiaCambiante<T>: IEstrategia<T>{
    //Juega una de las demas estrategias de forma aleatoria
  IEstrategia<T>[] estrategias = new IEstrategia<T>[] {new estrategiaBorracho<T>(), new estrategiaBotaGorda<T>(), new BotaMasRepetida<T>(), new Pro<T>() };
  Random r = new();
  public (Piece<T>, int, int) Play(IEnumerable<Piece<T>> mano, T[] PosDisponibles , IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa,int EquipoDelJugador) =>
     estrategias[r.Next(estrategias.Length)].Play(mano, PosDisponibles, Historial, pases,reglas, nuevaMesa, EquipoDelJugador);
}


static class MetodosAuxiliares{
    public static (Piece<T> ficha, int posicion, int cara) CogerPrimera<T>(IEnumerable<Piece<T>> mano, T[] posicionesDisp, Rules<T> reglas, bool NuevaMesa){
        //Juega la promera ficha posible en la mano
            
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