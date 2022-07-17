using DominoGame;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;

namespace DominoPlayer{
public class Player<T>{
    public readonly string Nombre;
    //Nombre del jugador
    public readonly int Equipo;
    //Equipo del jugador
    IEstrategia<T> _estrategia;
    //Estrategia a seguir
   public (Piece<T>, int,int) Play(IEnumerable<Piece<T>> mano, T[] disp, IEnumerable<Jugada<T>> Historial,IEnumerable<Pase<T>> pases, Rules<T> reglas, bool nuevaMesa) => 
   _estrategia.Play(mano, disp, Historial, pases, reglas, nuevaMesa,Equipo);
   //Recibe datos del juego y decide cual es la mejor ficha a jugar
    
    public Player(String nombre, IEstrategia<T> estrategia, int equipo)
    { 
        Nombre = nombre;
        _estrategia = estrategia;
        Equipo = equipo;
    }
    }
}