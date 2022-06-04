
using DominoPlayer;
using DominoRules;
using DominoTable;

namespace DominoGame;
public class Game{
    public int turno = 1;
    public int pasadosSeguidos = 0;//sirve para diferentes condiciones de victoria
    public int JugadorActual {get {return turno % Jugadores.Length;}}
    public int cantFichasJugadorActual{get{return Jugadores[JugadorActual].FichasLeQuedan; }}
    public string NombreJugadorActual {get {return Jugadores[JugadorActual].nombre;}}
    public Player[] Jugadores;
    public Rules reglas;
    public Table tablero = new Table();
    public Game(Player[] Jugadores, Rules reglas){
      this.reglas = reglas;
      foreach (Player jug in Jugadores){
          for (int i = 0; i < reglas.Cantidad_Inicial_En_La_Mano; i++){
              jug.CogerFicha(reglas.Fichas_Del_Juego.TomarUna());
          }
       }
       this.Jugadores = Jugadores;
    } 
    public (Piece, int) Jugar() {
        return reglas.turno.Play(Jugadores[JugadorActual],this);
    }
     public bool SeAcabo(){
         if (reglas.final.EndOfTheGame(this)){ 
              return true;
         }
         return false;
     }
    public int Ganador(){
         return reglas.final.Winner(this);
     }
     public void AvanzarTurno(){
         turno ++;
     }
}
