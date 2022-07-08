using System;
using DominoTable;
using System.Collections.Generic;
namespace DominoRules{

public class GamePieces<T>{
    List<Piece<T>> _pieces;
    Random _r = new();

    public GamePieces(int cant, IGenerator<T> generator){
         _pieces = generator.Generate(cant);
    }
    public Piece<T> TomarUna(){
      
       int fichaSeleccionada = _r.Next((_pieces).Count);
       Piece<T> devolver = _pieces[fichaSeleccionada];
       _pieces.RemoveAt(fichaSeleccionada);
       return devolver;
    }
  
    public int Count => _pieces.Count;
}
}
