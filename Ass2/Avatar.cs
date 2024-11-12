namespace Backend;

public abstract class Avatar {
    public (int, int) position;
    public Direction      facing;

    public abstract void Move(int     steps);
    public abstract void Turn(Lateral dir);
}

public class Character: Avatar {
    public override void Move(int steps) {
        switch (facing) {
        case Direction.North:
            position = (position.Item1, position.Item2 + steps);
            break;
        case Direction.East:
            position = (position.Item1 + steps, position.Item2);
            break;
        case Direction.South:
            position = (position.Item1, position.Item2 - steps);
            break;
        case Direction.West:
            position = (position.Item1 - steps, position.Item2);
            break;
        }
    }

    public override void Turn(Lateral dir) {
        switch (dir) {
        case Lateral.Left:
            facing = (Direction)(((int)facing - 1) % 4);
            break;
        case Lateral.Right:
            facing = (Direction)(((int)facing + 1) % 4);
            break;
        }
    }
}

public enum Direction {
    North,
    East,
    South,
    West,
}

public enum Lateral {
    Left,
    Right,
}