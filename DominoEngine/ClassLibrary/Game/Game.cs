using DominoPlayer;
using DominoRules;
using DominoTable;
using System.Collections;

namespace DominoGame {
public class Game<T> : IEnumerable<Escena<T>> {
	public int Turno = 0;
    
	bool primerTurno = true;
	public GamePieces<T> fichasDelJuego;
	//Turno actual
	public Dictionary<int, List<Player<T>>> equipos = new();

	//Diccionario que, a cada equipo le hace corresponder una lista de jugadores que lo componen
	public int PasadosSeguidos = 0; //sirve para diferentes condiciones de victoria

	public Player<T> JugadorActual => Jugadores[Turno % Jugadores.Length];
    //Jugador al cual le corresponde jugar
	public int cantFichasJugadorActual => manos[JugadorActual].Count;
    //Cantidad de fichas en la mano del jugador actual
    
	public Player<T>[] Jugadores; //Voa cambiar esto despues. Ese array  ta feo
	public Dictionary<Player<T>, List<Piece<T>>> manos = new();
	//Diccionario que le hace corresponder su mano a cada jugador
	public Rules<T> reglas;
	//Reglas del juego
	public Table<T> Tablero = new(); 
	//Tablero del juego

	public Game(Player<T>[] jugadores, Rules<T> reglas) {
		Jugadores = jugadores;
		this.reglas = reglas;
		fichasDelJuego = new GamePieces<T>(reglas.Tope, reglas.Generator);
		foreach (var jug in jugadores) {
			if (!equipos.ContainsKey(jug.Equipo)) {
				equipos.Add(jug.Equipo, new List<Player<T>>());
			}
			equipos[jug.Equipo].Add(jug);
			manos.Add(jug, new List<Piece<T>>());	
		}
		reglas.Repartidor.distribuir(this, reglas.Tope);		
	}

	public void Jugar() => reglas.Turno.Play(JugadorActual, this);

	public bool SeAcabo() => reglas.Final.EndOfTheGame(this);

	private void AvanzarTurno() => Turno++;


	public IEnumerator<Escena<T>> GetEnumerator() {
		while (!SeAcabo()) {
			if(primerTurno){
			yield return new(this);
            primerTurno = false;}
			else {AvanzarTurno();}
			Jugar();
			yield return new(this);
		}
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
}