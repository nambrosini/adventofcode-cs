namespace day11.Data {
    public class Robot {
        public Direction Dir { get; set; }
        public Panel Position { get; set; }

        public Robot() {
            Dir = new Direction {
                Dir = DirectionEnum.Up
            };
            Position = new Panel(new Point(0, 0), 0);
        }

        public void Move() {
            Position.Coordinates = Position.Coordinates + Dir.Dir;
        }
    }
}