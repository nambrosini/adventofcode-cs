
namespace day11.Data {
    public enum DirectionEnum {
        Up,
        Left,
        Down,
        Right
    }

    public class Direction {
        public DirectionEnum Dir { get; set; }

        public void TurnLeft() {
            Dir = Dir switch {
                DirectionEnum.Up => DirectionEnum.Left,
                DirectionEnum.Left => DirectionEnum.Down,
                DirectionEnum.Down => DirectionEnum.Right,
                DirectionEnum.Right => DirectionEnum.Up
            };
        }

        public void TurnRight() {
            Dir = Dir switch {
                DirectionEnum.Up => DirectionEnum.Right,
                DirectionEnum.Right => DirectionEnum.Down,
                DirectionEnum.Down => DirectionEnum.Left,
                DirectionEnum.Left => DirectionEnum.Up
            };
        }
    }
}