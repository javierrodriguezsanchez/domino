using DominoGame;
using DominoRules;
using DominoTable;
namespace DominoPlayer;

public class Player{
    private List<Piece> mano = new List<Piece>();
    public string nombre{get; private set;}
    public int FichasLeQuedan {get{return mano.Count;}} 
    IEstrategia Estrategia;
    public (Piece, int) Play(Table mesa, Rules reglas){
        (int,int) seleccion = Estrategia.Play(mano, mesa, reglas);
        if(seleccion.Item1==int.MaxValue)
            return (new Piece(new int[]{int.MaxValue}),int.MaxValue);
        Piece seleccionada=mano[seleccion.Item1];
        mano.RemoveAt(seleccion.Item1);
        return (seleccionada,seleccion.Item2);
    }
    public Player(String nombre, IEstrategia estrategia)
    { 
        this.nombre = nombre;
        this.Estrategia = estrategia;
    }
    public void CogerFicha(Piece Ficha){
        mano.Add(Ficha);
    }
    public IEnumerable<Piece> mostrarMano(){
        return mano;
    }
}

