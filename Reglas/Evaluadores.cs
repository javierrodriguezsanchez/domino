using System;
using DominoTable;

 namespace DominoRules;

 public interface IEvaluadorFichas{
    int Evaluar(Piece Ficha);
 }
 public class EvaluadorSuma: IEvaluadorFichas{
 public int Evaluar(Piece Ficha){
         int suma = 0;
         foreach (var valor in Ficha.values){
             suma += valor;
         }
         return suma;
     }
 }