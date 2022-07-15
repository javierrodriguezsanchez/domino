using System;
using DominoPlayer;
namespace DominoTable{
    public class Table<T>
{   int cant = 0;
    public bool nuevaMesa = true;
    private Jugada<T>? Salida = null;
    private Jugada<T>? Izquierda = null;
    private Jugada<T>? Derecha = null;
    private List<Pase<T>> Pases = new List<Pase<T>>();
    public T[] Disponibles = new T[2];
  
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
        foreach (var jug in jugadas()){
            if(jug.invertida) {yield return new Piece<T>(jug.Ficha.values.Reverse().ToArray());} 
            else {
               yield return new Piece<T>(jug.Ficha.values);
            }
        }
    }
    public IEnumerable<Jugada<T>> Historial(bool Sort=true){
        if(Sort)
            return jugadas().OrderBy(t => t.Momento);
        else
            return jugadas();
    }
    public IEnumerable<Pase<T>> ListaDePases() => Pases;
    
    
    public void pasarse(Player<T> jug){
        Pases.Add(new Pase<T>(Disponibles, jug, cant));
        cant ++;
    }
    public void abrirMesa(Piece<T> ficha, Player<T> jug){
        nuevaMesa = false;
        Disponibles = (T[])ficha.values.Clone();
        Izquierda = Derecha = Salida = new Jugada<T>(ficha, jug, cant);
        cant ++;
    }
    public void JugarEnPos(Piece<T> Ficha, Player<T> jug, int cara, int pos){
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
        public readonly T[] Disponibles;
        public readonly Player<T> Jug;
        public readonly int Momento;
        public Pase(T[] disponibles, Player<T> jug, int momento){
            Disponibles = disponibles;
            Jug = jug;
            Momento = momento;
        }
    }
public class Jugada<T>{
    public bool invertida = false;
    public Piece<T> Ficha;
    public Jugada<T>? Izquierda = null;
    public Jugada<T>? Derecha = null;
    public int Momento;
    public Player<T> Jugador;
    public Jugada(Piece<T> ficha, Player<T> jug, int cant){
        Ficha = ficha;
        Jugador = jug;
        Momento = cant;
    }
}

}