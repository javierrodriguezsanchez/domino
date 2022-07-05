using System;
using DominoTable;

 namespace DominoRules
 {
 public interface IPieceEvaluator{
    double Evaluar(Piece Ficha);
 }
 public class SumEvaluator: IPieceEvaluator{
 public double Evaluar(Piece Ficha) => Ficha.values.Sum();
}
//Devuelve la suma de las caras de la ficha

 public class MaxEvaluator: IPieceEvaluator{
     public double Evaluar(Piece Ficha) => Ficha.values.Max();
     }
     //Devuelve el maximo entre las caras de la ficha

public class VectorialEvaluator: IPieceEvaluator{  
    public double Evaluar(Piece Ficha) => Math.Sqrt(Ficha.values.Sum(t => Math.Pow(t,2)));
}  
//Considera a cada ficha un vector y devuelve su norma euclideana (la raiz cuadrada de la
//sumatoria de sus componentes al cuadrado

public class MultiplicatoryEvaluator: IPieceEvaluator{
  public double Evaluar(Piece Ficha){
      double acum = 1;
      foreach (var item in Ficha.values){
          acum *= item;
      }
      return acum;
  }
  //Retorna la multiplicatoria de las caras de cada ficha
}
public class EquitativeEvaluator: IPieceEvaluator{
    public double Evaluar(Piece Ficha) => 1;
}
//Retorna un valor constante para toda ficha
public class DoubleDoublesEvaluator: IPieceEvaluator{
    public double Evaluar(Piece Ficha) =>
    Ficha.values.Distinct().Count() == 1?  Ficha.values.Sum() * 2: Ficha.values.Sum();
// Si es un doble, devuelve el doble de la suma de las caras de la ficha, 
// en otro caso, se comporta como un evaluador por suma
}
}
