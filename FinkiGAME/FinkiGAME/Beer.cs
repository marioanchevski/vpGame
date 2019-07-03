using System.Drawing;

namespace FinkiGAME
{
    public class Beer
    {
        public Point Location { get; set; }
        public int delete { get; set; }
        public static int SPEED = 10;

        public Beer(Point p)
        {

            Location = p;
            delete = 0;

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
            return Location.X >= b.Location.X && Location.X <= b.Location.X + 122 && Location.Y >= b.Location.Y && Location.Y <= b.Location.Y + 70;
        }
        public bool IsFallen()
        {

            //720 form width
            //570 form height
            return Location.Y >= 520;
        }
    }
}
