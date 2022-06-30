using System;

namespace DominoTable{
    public class Table
{
    public bool nuevaMesa = true;
    public int[] Disponibles = new int[]{-1, -1};
    public int this[int index] {get{return Disponibles[index];} set{Disponibles[index] = value;}}  
}
}