using System.Collections;
using DominoPlayer;
using DominoRules;
using DominoTable;

namespace DominoGame;
public class Torney<T>: IEnumerable<Game<T>> {
	Player<T>[] _jugadores; 
	public readonly Rules<T> Reglas;
	public Game<T> JuegoActual;
	public Dictionary<int, double> Scores = new();
	//Diccionario que a cada equipo le hace corresponder su puntuacion
	public int Ganador = -1;
	public bool primerMovenext = true;

	public Torney(Player<T>[] jugadores, Rules<T> reglas) {
		_jugadores = jugadores;
		Reglas = reglas;
		JuegoActual = new Game<T>(jugadores, reglas);
        foreach (var jug in jugadores){
			if(!Scores.ContainsKey(jug.Equipo)){
                Scores.Add(jug.Equipo, 0);
			}
		}
	}	

	void RepartidorDePuntos() => Reglas.TipoDeTorneo.RepartidorDePuntos(this);
		
	void NuevaPartida() => JuegoActual = new Game<T>(_jugadores, Reglas);

	bool SeAcabo() => Reglas.TipoDeTorneo.SeAcabo(this);

    public IEnumerator<Game<T>> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    class Enumerator : IEnumerator<Game<T>>
    {
		Torney<T> _torn;
        public Enumerator(Torney<T> torn) {
			_torn= torn;
        }

        public Game<T> Current => _torn.JuegoActual;

        object IEnumerator.Current => Current;

        public void Dispose(){}
        public bool MoveNext(){
			if(_torn.primerMovenext){
				_torn.primerMovenext = false;
				return true;
			}
            _torn.RepartidorDePuntos();
			if (_torn.SeAcabo()){
				return false;
			}
			_torn.NuevaPartida();
			return true;
        }
        public void Reset() => _torn = new(_torn._jugadores, _torn.Reglas);
    }
}