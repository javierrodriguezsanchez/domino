using DominoGame;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;

namespace DominoPlayer{
public class Player{
    public readonly string nombre;
    public readonly int equipo;
    IEstrategia Estrategia;
   public (Piece, int,int) Play(IEnumerable<Piece> mano, Table mesa, Rules reglas){
        return Estrategia.Play(mano, mesa, reglas);
    }
    public Player(String nombre, IEstrategia estrategia, int equipo)
    { 
        this.nombre = nombre;
        this.Estrategia = estrategia;
        this.equipo = equipo;
    }
    }
}