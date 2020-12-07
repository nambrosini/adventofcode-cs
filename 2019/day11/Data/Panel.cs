namespace day11.Data {
    public class Panel {
        public Point Coordinates { get; set; }
        public int Color { get; set; }

        public Panel(Point coordinates, int color) {
            Coordinates = coordinates;
            Color = color;
        }
    }
}