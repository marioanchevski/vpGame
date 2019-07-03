using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void draw(Graphics g) {
            Brush b = new SolidBrush(Color.Blue);
            g.FillRectangle(b,Location.X, Location.Y, 122, 70);
            b.Dispose();
        }

        public void move(int x) {
            Location = new Point(x,Location.Y);
        }
    
    }
}
