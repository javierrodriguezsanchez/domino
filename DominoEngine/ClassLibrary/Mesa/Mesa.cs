using System;
using DominoPlayer;
namespace DominoTable{
    public class Table<T>
{   int cant = 0;
   //Cantidad de jugadas hasta el momento
    public bool nuevaMesa = true;
    //Indica si es una nueva mesa
    private Jugada<T>? Salida = null;
    //Primera ficha que se jugo 
    private Jugada<T>? Izquierda = null;
    //La jugada que coloco la ficha mas a la izquierda
    private Jugada<T>? Derecha = null;
    //Jugada que coloco la ficha mas a la derecha
    private List<Pase<T>> Pases = new List<Pase<T>>();
    //Pases que han ocurrido en el juego
    public T[] Disponibles = new T[2];
    //Posiciones disponibles para jugar
  
    private IEnumerable<Jugada<T>> jugadas(){
        if(Izquierda is not null){
            Jugada<T>? actual = Izquierda;
            while(actual is not null){
                yield return actual;
                actual = actual.Derecha;
            }
        }
    }
    public IEnumerable<Piece<T>> VerMesaActual(){
        //Enumerador que devuelve la forma en que la mesa debe mostrarse ante la pantalla
        foreach (var jug in jugadas()){
            if(jug.invertida) {yield return new Piece<T>(jug.Ficha.values.Reverse().ToArray());} 
            else {
               yield return new Piece<T>(jug.Ficha.values);
            }
        }
    }
    public IEnumerable<Jugada<T>> Historial(bool Sort=true){
        //Historial del juego, por defecto, devuelve las jugadas cronologicamente, sino las devuelve en el orden 
        //que estan en la mesa
        if(Sort)
            return jugadas().OrderBy(t => t.Momento);
        else
            return jugadas();
    }
    public IEnumerable<Pase<T>> ListaDePases() => Pases;
    //Pases que han ocurrido en el juego
    
    public void pasarse(Player<T> jug){
    //El juegador actual se ha pasado, archiva el dato en el historial de pases
        Pases.Add(new Pase<T>(Disponibles, jug, cant));
        cant ++;
    }
    public void abrirMesa(Piece<T> ficha, Player<T> jug){
        //Juega la primera ficha en la mesa
        nuevaMesa = false;
        Disponibles = (T[])ficha.values.Clone();
        Izquierda = Derecha = Salida = new Jugada<T>(ficha, jug, cant);
        cant ++;
    }
    public void JugarEnPos(Piece<T> Ficha, Player<T> jug, int cara, int pos){
        //Se juega una ficha en la posicion indicada, ademas, se guarda en el historial de pases
        Jugada<T> NJ = new Jugada<T>(Ficha, jug, cant);
        if(pos == 0){
            if(Izquierda is null) throw new Exception("Pos Invalida");
            NJ.Derecha = Izquierda; 
            Izquierda = Izquierda.Izquierda = NJ;
        if(cara == 0) {
            NJ.invertida = true;
            Disponibles[0] = Ficha.values[1];
            } else Disponibles[0] = Ficha.values[0];
        }
        if(pos == 1){
            if(Derecha is null) throw new Exception("Pos Invalida");
            NJ.Izquierda = Derecha;
            Derecha = Derecha.Derecha = NJ;

        if(cara == 1) {
            NJ.invertida = true;
            Disponibles[1] = Ficha.values[0];
        }
        else Disponibles[1] = Ficha.values[1];
        }
        cant ++;
    }
    
}

public class Pase<T>{
    //Dato que archiva un pase en el juego
        public readonly T[] Disponibles;
        //Posiciones que estaban disponibles al pasarse el jugador
        public readonly Player<T> Jug;
        //Jugador que se paso
        public readonly int Momento;
        //En que momento se paso
        public Pase(T[] disponibles, Player<T> jug, int momento){
            Disponibles = disponibles;
            Jug = jug;
            Momento = momento;
        }
    }
public class Jugada<T>{
    //Dato que archiva una jugada del juego
    public bool invertida = false;
    //True si se puso en orden que tiene su array de values, false si se puso invertida
    public Piece<T> Ficha;
    //Ficha jugada
    public Jugada<T>? Izquierda = null;
    //Jugada a la izquerda de esta ficha
    public Jugada<T>? Derecha = null;
    //Jugada a la derecha de esta ficha
    public int Momento;
    //Momento en que se realizo esta jugada
    public Player<T> Jugador;
     //Jugador que realizo esta jugada
    public Jugada(Piece<T> ficha, Player<T> jug, int cant){
        Ficha = ficha;
        Jugador = jug;
        Momento = cant;
    }
}

}