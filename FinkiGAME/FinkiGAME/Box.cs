using System.Drawing;

namespace FinkiGAME
{
    public class Box
    {
        public Point Location { get; set; }
        public Image slika;

        public Box()
        {
            Location = new Point(500, 450);
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Blue);
            g.FillRectangle(b, Location.X, Location.Y, 122, 70);
            b.Dispose();
        }

        public void Move(int x)
        {
            Location = new Point(x, Location.Y);
        }
    }
}
