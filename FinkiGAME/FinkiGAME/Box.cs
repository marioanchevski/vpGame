using System.Drawing;

namespace FinkiGAME
{
    public class Box
    {
        public Point Location { get; set; }

        public Box()
        {
            Location = new Point(300, 461);
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Transparent);
            g.FillRectangle(b, Location.X, Location.Y, 115, 0);
            b.Dispose();
        }

        public void Move(int x)
        {
            //Left separator >= 108 right <=583
            if (x >= 165 && x <= 638)
            {
                Location = new Point(x - 57, Location.Y);
            }
        }
    }
}
