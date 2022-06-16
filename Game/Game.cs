
using DominoPlayer;
using DominoRules;
using DominoTable;
using System;
using System.Collections.Generic;
using System.Collections;
namespace DominoGame{
public class Game: IEnumerable<Game> {
    public int turno = 0;
    //Turno actual
    public Dictionary<int, List<Player>> equipos = new Dictionary<int, List<Player>>();
    //Diccionario que, a cada equipo le hace corresponder una lista de jugadores que lo componen
    public int pasadosSeguidos = 0;//sirve para diferentes condiciones de victoria
    public Player JugadorActual {get {return Jugadores[turno % Jugadores.Length];}}
    public int cantFichasJugadorActual{get{return manos[JugadorActual].Count; }}
    public string NombreJugadorActual {get {return JugadorActual.nombre;}}  
    public List<(Piece, int, int)> jugadas = new List<(Piece, int, int)>(); //Recordar ponerle el jugador que hizo cada jugada despues
    public Player[] Jugadores; //Voa cambiar esto despues. Ese array  ta feo
    public Dictionary<Player, List<Piece>> manos = new Dictionary<Player, List<Piece>>();
    public Rules reglas;
    public Table tablero = new Table(); //Mutar despues
    public Game(Player[] Jugadores, Rules reglas){
      this.reglas = reglas;
      foreach (Player jug in Jugadores){
         if (!equipos.ContainsKey(jug.equipo))
         {
             equipos.Add(jug.equipo, new List<Player>());
         }
         equipos[jug.equipo].Add(jug);
           manos.Add(jug, new List<Piece>());
          for (int i = 0; i < reglas.Cantidad_Inicial_En_La_Mano; i++){
              manos[jug].Add(reglas.Fichas_Del_Juego.TomarUna());
          }
       }
       this.Jugadores = Jugadores;
    } 
    public void Jugar() {
        jugadas.Add(reglas.turno.Play(JugadorActual,this));
    }
     public bool SeAcabo(){
         if (reglas.final.EndOfTheGame(this)){ 
              return true;
         }
         return false;
     }
     public void AvanzarTurno(){
         turno ++;
     }
    public IEnumerator GetEnumerator(){
            return new RecorreJuegos(this);
    }
     IEnumerator<Game> IEnumerable<Game>.GetEnumerator(){
         return new RecorreJuegos(this);
     }

     private class RecorreJuegos: IEnumerator<Game>{
      Game juego;
       public RecorreJuegos(Game juego){
             this.juego = juego;
       }
        Game IEnumerator<Game>.Current{get {return juego;}}

       public object Current{get{return juego;}}
       public bool MoveNext(){
           if(!juego.SeAcabo()){
           juego.AvanzarTurno();
           juego.Jugar();
           return true;
           }
           return false;
       }//Lo arreglo despues, esta dando bateo, me devuelvuelde el jugador del turno anterior
       public void Reset(){}
       public void Dispose(){}
     }
}
}