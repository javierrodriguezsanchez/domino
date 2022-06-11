using DominoGame;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;

namespace DominoPlayer{
public class Player{
    private List<Piece> mano = new List<Piece>();
    public string nombre{get; private set;}
    public int FichasLeQuedan {get{return mano.Count;}} 
    IEstrategia Estrategia;
    public (Piece, int,int) Play(Table mesa, Rules reglas){
        (Piece,int,int) seleccion = Estrategia.Play(new List<Piece>(mano), mesa, reglas);
        if(mano.Remove(seleccion.Item1))
            return (seleccion.Item1,seleccion.Item2,seleccion.Item3);
        return (new Piece(), int.MaxValue,int.MaxValue);
    }
    public Player(String nombre, IEstrategia estrategia)
    { 
        this.nombre = nombre;
        this.Estrategia = estrategia;
    }
    public void CogerFicha(Piece Ficha){
        mano.Add(Ficha);
    }
    public IEnumerable<Piece> mostrarMano(){
        return mano;
    }
}
}

