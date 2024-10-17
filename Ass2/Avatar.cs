using System;

namespace Ass2 {
    public abstract class Avatar {
        public abstract void Move(int steps);
        public abstract void Turn(Lateral dir);
    }

    public partial class Character : Avatar {
        private Tuple<float, float> coordinate;
        private Direction           facing;
        
        public override void Move(int steps) {
            switch (facing) {
                case Direction.North:
                    coordinate = new Tuple<float, float>(coordinate.Item1, coordinate.Item2 + steps);
                    break;
                case Direction.East:
                    coordinate = new Tuple<float, float>(coordinate.Item1 + steps, coordinate.Item2);
                    break;
                case Direction.South:
                    coordinate = new Tuple<float, float>(coordinate.Item1, coordinate.Item2 - steps);
                    break;
                case Direction.West:
                    coordinate = new Tuple<float, float>(coordinate.Item1 - steps, coordinate.Item2);
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
        West
    }

    public enum Lateral {
        Left,
        Right
    }
}