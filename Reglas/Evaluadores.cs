using System;
using DominoTable;

 namespace DominoRules
 {
 public interface IEvaluadorFichas{
    double Evaluar(Piece Ficha);
 }
 public class EvaluadorSuma: IEvaluadorFichas{
 public double Evaluar(Piece Ficha) => Ficha.values.Sum();
}
//Devuelve la suma de las caras de la ficha

 public class EvaluadorMaximal: IEvaluadorFichas{
     public double Evaluar(Piece Ficha) => Ficha.values.Max();
     }
     //Devuelve el maximo entre las caras de la ficha

public class EvaluadorVectorial: IEvaluadorFichas{  
    public double Evaluar(Piece Ficha) => Math.Sqrt(Ficha.values.Sum(t => Math.Pow(t,2)));
}  
//Considera a cada ficha un vector y devuelve su norma euclideana (la raiz cuadrada de la
//sumatoria de sus componentes al cuadrado

public class EvaluadorMultiplicatorio: IEvaluadorFichas{
  public double Evaluar(Piece Ficha){
      double acum = 1;
      foreach (var item in Ficha.values){
          acum *= item;
      }
      return acum;
  }
  //Retorna la multiplicatoria de las caras de cada ficha

public class EvaluadorEquitativo: IEvaluadorFichas{
    public double Evaluar(Piece Ficha) => 1;
}
//Retorna un valor constante para toda ficha
public class DoblesValenDobles: IEvaluadorFichas{
    public double Evaluar(Piece Ficha) =>
    Ficha.values.Distinct().Count() == 1?  Ficha.values.Sum() * 2: Ficha.values.Sum();
// Si es un doble, devuelve el doble de la suma de las caras de la ficha, 
// en otro caso, se comporta como un evaluador por suma
}
}
}