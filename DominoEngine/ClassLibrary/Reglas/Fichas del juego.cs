using System;
using DominoTable;
using System.Collections.Generic;
namespace DominoRules{

public class GamePieces{
    List<Piece> _pieces;
    Random _r = new();

    public GamePieces(int cant, IGenerator generator){
         _pieces = generator.Generate(cant);
    }
    public Piece TomarUna(){
      
       int fichaSeleccionada = _r.Next((_pieces).Count);
       Piece devolver = _pieces[fichaSeleccionada];
       _pieces.RemoveAt(fichaSeleccionada);
       return devolver;
    }
  
    public int Count => _pieces.Count;
}
}
