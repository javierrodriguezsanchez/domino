using System;
using DominoTable;
using System.Collections.Generic;
namespace DominoRules{

public class GamePieces{
    List<Piece> Fichas;

    public GamePieces(int cant){
         Fichas = generador(cant);
    }
    public Piece TomarUna(){
       Random r = new ();
       int fichaSeleccionada = r.Next(Fichas.Count - 1);
       Piece devolver = Fichas[fichaSeleccionada];
       Fichas.RemoveAt(fichaSeleccionada);
       return devolver;
    }
  public static List<Piece> generador(int Tope){
        List<Piece> lista = new List<Piece>();
        for (int i = 0; i <= Tope; i++){
            for (int j = i; j <= Tope; j++){
                lista.Add(new Piece(new int[]{i , j}));
            }
        }
        return lista;
    }
    public int Length{ get{return Fichas.Count;}}
}
}
