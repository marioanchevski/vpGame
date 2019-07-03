using System.Drawing;

namespace FinkiGAME
{
    public class Beer
    {
        public Point Location { get; set; }
        public int Delete { get; set; }
        public static int SPEED = 23;

        public Beer(Point p)
        {
            Location = p;
            Delete = 0;

        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, Location.X, Location.Y, 15, 50);
            b.Dispose();
        }

        public void Move(int speed)
        {
            Location = new Point(Location.X, Location.Y + SPEED);
        }

        public bool IsHit(Box b)
        {
            return Location.X >= b.Location.X - 10 && Location.X <= b.Location.X + 122 && Location.Y >= b.Location.Y - 40 && Location.Y <= b.Location.Y + 30;
        }
        public bool IsFallen()
        {
            //720 form width
            //570 form height
            return Location.Y >= 520;
        }
    }
}
