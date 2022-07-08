using System;
using DominoTable;
public interface IGenerator<T>{
    List<Piece<T>> Generate(int Tope);
}
public class ClassicGenerator: IGenerator<int>{
    public List<Piece<int>> Generate(int Top){
        List<Piece<int>> list = new List<Piece<int>>();
        for (int i = 0; i <= Top; i++){
            for (int j = i; j <= Top; j++){
                list.Add(new Piece<int>(new int[]{i , j}));
            }
        }
        return list;
     }
}
public class CrazyGenerator: IGenerator<int>{
    public List<Piece<int>> Generate(int top){
        List<Piece<int>> list = new();
        int cant = (top * (top + 1))/2;
        Random r = new();
        for (int i = 0; i < cant; i++){
            list.Add(new Piece<int>(new int[] {r.Next(top), r.Next(top)}));
        }
        return list;
    }
}
public class CharGenerator: IGenerator<char>{
    public List<Piece<char>> Generate(int top){
        char[] abc = new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        List<Piece<char>> list = new();
        for (int i = 0; i < Math.Min(top, abc.Length); i++){
            for (int j = i; j < Math.Min(top, abc.Length); j++){
             list.Add(new Piece<char>(new char[]{abc[i] , abc[j]}));
        }
        }
        return list;
    }
}