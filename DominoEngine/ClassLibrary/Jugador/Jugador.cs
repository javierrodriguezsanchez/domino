using DominoGame;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;

namespace DominoPlayer{
public class Player<T>{
    public readonly string Nombre;
    public readonly int Equipo;
    IEstrategia<T> _estrategia;
   public (Piece<T>, int,int) Play(IEnumerable<Piece<T>> mano, T[] disp, Rules<T> reglas, bool nuevaMesa) => 
   _estrategia.Play(mano, disp, reglas, nuevaMesa);
    
    public Player(String nombre, IEstrategia<T> estrategia, int equipo)
    { 
        Nombre = nombre;
        _estrategia = estrategia;
        Equipo = equipo;
    }
    }
}