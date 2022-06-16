using System;
using DominoTable;

 namespace DominoRules
 {
 public interface IEvaluadorFichas{
    double Evaluar(Piece Ficha);
 }
 public class EvaluadorSuma: IEvaluadorFichas{
 public double Evaluar(Piece Ficha){
         int suma = 0;
         foreach (var valor in Ficha.values){
             suma += valor;
         }
         return suma;
     }
 }
 public class EvaluadorMaximal: IEvaluadorFichas{
     public double Evaluar(Piece Ficha){
         int max = int.MinValue;
         foreach (var valor in Ficha.values){
             if(valor > max){
                 max = valor;
             }
         }
         return max;
     }
 }
public class EvaluadorVectorial: IEvaluadorFichas{  
    public double Evaluar(Piece Ficha){
        double sumaCuadrados = 0;
        foreach (var item in Ficha.values)
        {
            sumaCuadrados += Math.Pow(item, 2);
        }
        return Math.Sqrt(sumaCuadrados);
    }
}  //Precioso
public class EvaluadorMultiplicatorio: IEvaluadorFichas{
  public double Evaluar(Piece Ficha){
      double acum = 1;
      foreach (var item in Ficha.values)
      {
          acum *= item;
      }
      return acum;
  }
public class EvaluadorEquitativo: IEvaluadorFichas{
    public double Evaluar(Piece Ficha){
        return 1;
    }
}
}
}