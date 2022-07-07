namespace DominoRules;
using DominoGame;
public interface ITorn<T>{
     void RepartidorDePuntos(Torney<T> torn);
     bool SeAcabo(Torney<T> torn);
}
public class TornPorPuntos<T>: ITorn<T>{
//Cada vez que termine un juego se suman los puntos de las fichas de los equipos perdedores y se le otogan al ganador.
//El equipo ganador es el primero en alcanzar los 100 puntos
    public void RepartidorDePuntos(Torney<T> torn){
         var ganador = torn.Reglas.Ganador.Winner(torn.JuegoActual);
		if (ganador == -1) {
			return;
		}
		var score = torn.JuegoActual.Jugadores.Where(jugador => jugador.Equipo != ganador)
			.SelectMany(jugador => torn.JuegoActual.manos[jugador]).Sum(ficha => torn.Reglas.Evaluador.Evaluar(ficha));
		torn.Scores[ganador] += score;
    }
	   public bool SeAcabo(Torney<T> torn) => MetodosAuxiliares.VerificarPuntuacionMaxima(torn, 100);
	   public bool SeAcabo(Torney<T> torn, int cant) => MetodosAuxiliares.VerificarPuntuacionMaxima(torn, cant);
	}
	public class TornPorVictorias<T>: ITorn<T>{
	//Cada vez que termine un juego se le otorga un punto al ganador.
	//El quipo ganador es el primero en alcanzar los 3 puntos
       public void RepartidorDePuntos(Torney<T> torn){
		if (torn.Reglas.Ganador.Winner(torn.JuegoActual) == -1) {
			return;
		}
		torn.Scores[torn.Reglas.Ganador.Winner(torn.JuegoActual)] += 1;
    }
	   public bool SeAcabo(Torney<T> torn) => MetodosAuxiliares.VerificarPuntuacionMaxima(torn, 3);
	   public bool SeAcabo(Torney<T> torn, int cant) => MetodosAuxiliares.VerificarPuntuacionMaxima(torn, cant);
	}
class MetodosAuxiliares{
	public static bool VerificarPuntuacionMaxima <T>(Torney<T> torn, int cant){
		foreach (int equipo in torn.Scores.Keys) {
			if (torn.Scores[equipo] >= cant) {
				torn.Ganador = equipo;
				return true;
			}
		}
		return false;
	}
}