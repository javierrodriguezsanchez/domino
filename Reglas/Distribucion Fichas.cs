namespace DominoRules;

public interface IPieceDistributer{
    void distribuir(DominoGame.Game juego, int tope);
}
public class distribucionEquitativa: IPieceDistributer{
   public void distribuir(DominoGame.Game juego, int tope){
        foreach (var jug in juego.Jugadores)
        {
             for (var i = 0; i < juego.reglas.Cantidad_Inicial_En_La_Mano; i++) {
				juego.manos[jug].Add(juego.fichasDelJuego.TomarUna());
			}
        }
    }
}
public class distribucionRandom: IPieceDistributer{
   public void distribuir(DominoGame.Game juego, int tope){
             Random r = new();
             while(true){
               int jugadorACoger = r.Next(juego.Jugadores.Count());
               juego.manos[juego.Jugadores[jugadorACoger]].Add(juego.fichasDelJuego.TomarUna());
               if(juego.manos[juego.Jugadores[jugadorACoger]].Count >= tope - 1){
                break;
               }
             }
<<<<<<< HEAD
             foreach (var jug in juego.Jugadores)
               juego.manos[jug].Add(juego.fichasDelJuego.TomarUna());
            
=======
             foreach (var jug in juego.Jugadores){
               juego.manos[jug].Add(juego.fichasDelJuego.TomarUna());
            }
>>>>>>> a5c8ef3634e4866c67e9015da09fd504cace0998
		}
}