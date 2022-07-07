using System;
using DominoTable;

 namespace DominoRules
 {
 public interface IPieceEvaluator<T>{
    double Evaluar(Piece<T> Ficha);
 }
 public class SumEvaluator: IPieceEvaluator<int>{
 public double Evaluar(Piece<int> Ficha) => Ficha.values.Sum();
}
//Devuelve la suma de las caras de la ficha

 public class MaxEvaluator: IPieceEvaluator<int>{
     public double Evaluar(Piece<int> Ficha) => Ficha.values.Max();
     }
     //Devuelve el maximo entre las caras de la ficha

public class VectorialEvaluator: IPieceEvaluator<int>{  
    public double Evaluar(Piece<int> Ficha) => Math.Sqrt(Ficha.values.Sum(t => Math.Pow(t,2)));
}  
//Considera a cada ficha un vector y devuelve su norma euclideana (la raiz cuadrada de la
//sumatoria de sus componentes al cuadrado

public class MultiplicatoryEvaluator: IPieceEvaluator<int>{
  public double Evaluar(Piece<int> Ficha){
      double acum = 1;
      foreach (var item in Ficha.values){
          acum *= item;
      }
      return acum;
  }
}
  //Retorna la multiplicatoria de las caras de cada ficha

public class EquitativeEvaluator<T>: IPieceEvaluator<T>{
    public double Evaluar(Piece<T> Ficha) => 1;
}
//Retorna un valor constante para toda ficha
public class DoubleDoublesEvaluator: IPieceEvaluator<int>{
    public double Evaluar(Piece<int> Ficha) =>
    Ficha.values.Distinct().Count() == 1?  Ficha.values.Sum() * 2: Ficha.values.Sum();
// Si es un doble, devuelve el doble de la suma de las caras de la ficha, 
// en otro caso, se comporta como un evaluador por suma
}
public class CharEvaluator: IPieceEvaluator<Char>{
    Char[] abc = new Char[]{'a', 'b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    public double Evaluar(Piece<char> ficha){
        int llevo = 0;
        foreach (var cara in ficha.values)
        {
            llevo += Array.IndexOf(abc, cara);
        }
        return llevo;
    }
}
}