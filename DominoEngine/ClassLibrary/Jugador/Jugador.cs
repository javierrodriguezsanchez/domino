using DominoGame;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;

namespace DominoPlayer{
public class Player{
    public readonly string Nombre;
    public readonly int Equipo;
    IEstrategia _estrategia;
   public (Piece, int,int) Play(IEnumerable<Piece> mano, int[] disp, Rules reglas, bool nuevaMesa) => 
   _estrategia.Play(mano, disp, reglas, nuevaMesa);
    
    public Player(String nombre, IEstrategia estrategia, int equipo)
    { 
        Nombre = nombre;
        _estrategia = estrategia;
        Equipo = equipo;
    }
    }
}