using System;
using DominoTable;
public interface IGenerator{
    List<Piece> Generate(int Tope);
}
public class ClassicGenerator: IGenerator{
    public List<Piece> Generate(int Top){
        List<Piece> list = new List<Piece>();
        for (int i = 0; i <= Top; i++){
            for (int j = i; j <= Top; j++){
                list.Add(new Piece(new int[]{i , j}));
            }
        }
        return list;
     }
}
public class CrazyGenerator: IGenerator{
    public List<Piece> Generate(int top){
        List<Piece> list = new();
        int cant = (top * (top + 1))/2;
        Random r = new();
        for (int i = 0; i < cant; i++){
            list.Add(new Piece(new int[] {r.Next(top), r.Next(top)}));
        }
        return list;
    }
}