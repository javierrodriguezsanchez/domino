using DominoPlayer;
using DominoRules;
using DominoTable;
using System.Collections;

namespace DominoGame {
public class Game : IEnumerable<Escena> {
	public int Turno = 0;
    
	bool primerTurno = true;
	public GamePieces fichasDelJuego;
	//Turno actual
	public Dictionary<int, List<Player>> equipos = new();

	//Diccionario que, a cada equipo le hace corresponder una lista de jugadores que lo componen
	public int PasadosSeguidos = 0; //sirve para diferentes condiciones de victoria

	public Player JugadorActual => Jugadores[Turno % Jugadores.Length];
    //Jugador al cual le corresponde jugar
	public int cantFichasJugadorActual => manos[JugadorActual].Count;
    //Cantidad de fichas en la mano del jugador actual
    
	public Player[] Jugadores; //Voa cambiar esto despues. Ese array  ta feo
	public Dictionary<Player, List<Piece>> manos = new();
	//Diccionario que le hace corresponder su mano a cada jugador
	public Rules reglas;
	//Reglas del juego
	public Table Tablero = new(); //Mutar despues

	public Game(Player[] jugadores, Rules reglas) {
		Jugadores = jugadores;
		this.reglas = reglas;
		fichasDelJuego = new GamePieces(reglas.Tope);
		foreach (var jug in jugadores) {
			if (!equipos.ContainsKey(jug.Equipo)) {
				equipos.Add(jug.Equipo, new List<Player>());
			}
			equipos[jug.Equipo].Add(jug);
			manos.Add(jug, new List<Piece>());	
		}
		reglas.Repartidor.distribuir(this, reglas.Tope);		
	}

	public void Jugar() => reglas.Turno.Play(JugadorActual, this);

	public bool SeAcabo() => reglas.Final.EndOfTheGame(this);

	private void AvanzarTurno() => Turno++;


	public IEnumerator<Escena> GetEnumerator() {
		while (!SeAcabo()) {
			if(primerTurno){
            primerTurno = false;
			}
			else{
			AvanzarTurno();
			}
			Jugar();
			yield return new(this);
		}
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
}