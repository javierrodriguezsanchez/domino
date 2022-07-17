using System;
using DominoTable;
using System.Collections.Generic;
namespace DominoRules{

public class GamePieces<T>{
    List<Piece<T>> _pieces;
    //Fichas que no se han repartido
    Random _r = new();
    //Variable random auxiliar

    public GamePieces(int cant, IGenerator<T> generator){
         _pieces = generator.Generate(cant);
    }
    public Piece<T> TomarUna(){
        //Toma una ficha aleatoriamente
      
       int fichaSeleccionada = _r.Next((_pieces).Count);
       Piece<T> devolver = _pieces[fichaSeleccionada];
       _pieces.RemoveAt(fichaSeleccionada);
       return devolver;
    }
  
    public int Count => _pieces.Count;
    //Cantidad de fichas restyantes en la reserva
}
}
