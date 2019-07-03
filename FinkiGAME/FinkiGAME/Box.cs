using System.Drawing;

namespace FinkiGAME
{
    public class Box
    {
        public Point Location { get; set; }

        public Box()
        {
            Location = new Point(300, 450);
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Transparent);
            g.FillRectangle(b, Location.X, Location.Y, 122, 70);
            b.Dispose();
        }

        public void Move(int x)
        {
            //Left separator >= 100 right <=580
            if (x >= 110 && x <= 580)
            {
                Location = new Point(x, Location.Y);
            }
        }
    }
}
