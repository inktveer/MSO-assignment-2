using System.Runtime.Intrinsics.X86;
using Object = Atk.Object;

namespace Ass2;

public class Grid(Grid.Tile[,] grid) {
    public static Grid empty = new Grid(new Tile[10000, 10000]);
    public        int  dim(int n) => grid.GetLength(n);

    public Tile this [int x, int y ] => grid[x, y];

    public enum Tile {
        Empty = 0,
        Full  = 1,
    }
}