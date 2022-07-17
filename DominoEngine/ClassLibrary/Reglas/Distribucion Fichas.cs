namespace DominoRules;

public interface IPieceDistributer<T>{
    void distribuir(DominoGame.Game<T> juego, int tope);
}
public class distribucionEquitativa<T>: IPieceDistributer<T>{
  //Se le reparte la misma cantidad de fichas a cada jugador
   public void distribuir(DominoGame.Game<T> juego, int tope){
        foreach (var jug in juego.Jugadores)
             for (var i = 0; i < tope; i++)
				        juego.manos[jug].Add(juego.fichasDelJuego.TomarUna());
    }
}
public class distribucionRandom<T>: IPieceDistributer<T>{
  //Se le reparte una cantidad aleatoria de fichas a cada jugador hasta qur uno de ellos tenga el maximo necesario
   public void distribuir(DominoGame.Game<T> juego, int tope){
             Random r = new();
             while(true){
               int jugadorACoger = r.Next(juego.Jugadores.Count());
               juego.manos[juego.Jugadores[jugadorACoger]].Add(juego.fichasDelJuego.TomarUna());
               if(juego.manos[juego.Jugadores[jugadorACoger]].Count >= tope - 1){
                break;
               }
             }
             foreach (var jug in juego.Jugadores)
               juego.manos[jug].Add(juego.fichasDelJuego.TomarUna());    
		}
}
