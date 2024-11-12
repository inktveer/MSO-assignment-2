using System;

namespace Ass2;

public interface Predicate {
    public bool evaluate(Avatar avatar, Grid grid);
}

public class GridEdge: Predicate {
    public bool evaluate(Avatar avatar, Grid grid) {
        return avatar.facing switch {
            Direction.North => avatar.coordinate.Item2 == 0,
            Direction.East  => avatar.coordinate.Item1 == grid.dim(0),
            Direction.South => avatar.coordinate.Item2 == grid.dim(1),
            Direction.West  => avatar.coordinate.Item1 == 0,
        };
    }
}

public class WallAhead: Predicate {
    public bool evaluate(Avatar avatar, Grid grid) {
        (int x, int y) = avatar.coordinate;
        (int a, int b) = direction_to_tuple(avatar.facing);
        return grid[x + a, y + b] == Grid.Tile.Full;
    }

    (int, int) direction_to_tuple(Direction dir) {
        return dir switch {
            Direction.North => (0, 1),
            Direction.East  => (1, 0),
            Direction.South => (0, -1),
            Direction.West  => (-1, 0),
        };
    }
}