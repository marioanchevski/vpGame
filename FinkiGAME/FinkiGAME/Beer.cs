using System.Drawing;

namespace FinkiGAME
{
    public class Beer
    {
        public Point Location { get; set; }
        public int Delete { get; set; }
        public static int SPEED;

        public Beer(Point p)
        {
            Location = p;
            Delete = 0;

        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, Location.X, Location.Y, 30, 60);
            b.Dispose();
        }

        public void Move(int speed)
        {
            Location = new Point(Location.X, Location.Y + SPEED);
        }

        public bool IsHit(Box b)
        {
            return Location.X >= b.Location.X - 20 && Location.X <= b.Location.X + 85 && Location.Y >= b.Location.Y - 50 && Location.Y <= b.Location.Y + 50;
        }
        public bool IsFallen()
        {
            return Location.Y >= 520;
        }
    }
}
