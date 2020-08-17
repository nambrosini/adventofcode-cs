using System.Collections.Generic;
using System.Linq;

namespace day03.Wire
{
    public class Wire
    {
        public List<Point> Path { get; set; }

        public Wire()
        {
            Path = new List<Point>();
            Path.Add(new Point(0, 0));
        }

        public static Wire CreateWire(Direction[] dirs)
        {
            var wire = new Wire();

            foreach (Direction dir in dirs)
            {
                Point dirPoint = null;
                switch (dir.Dir)
                {
                    case DirectionEnum.Up:
                        dirPoint = new Point(0, 1);
                        break;
                    case DirectionEnum.Down:
                        dirPoint = new Point(0, -1);
                        break;
                    case DirectionEnum.Left:
                        dirPoint = new Point(-1, 0);
                        break;
                    case DirectionEnum.Right:
                        dirPoint = new Point(1, 0);
                        break;
                }

                for (var i = 0; i < dir.Value; i++)
                {
                    wire.Path.Add(wire.Path.Last() + dirPoint);
                }
            }

            return wire;
        }
    }
}
