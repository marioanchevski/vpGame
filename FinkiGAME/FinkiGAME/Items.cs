using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiGAME
{
    public class Items
    {
        public List<Beer> items { get; set; }
        public int points;
        public int Speed  { get; set; }
        public int misses { get; set; }

        public Items() {
            items = new List<Beer>();
            points = 0;
            Speed = 10;
            misses = 0;
        }

        public void addItem() {
            Random r = new Random();
            items.Add(new Beer(new Point(r.Next(111, 610), -50 )));
        }

        public void draw(Graphics g) {
            foreach (var i in items) {
                i.draw(g);
            }
        }


        public void move() {
            foreach (var i in items) {
                i.move(Speed);
            }
        }

        public void isHit(Box b) {
            foreach (var i in items) {
                if (i.isHit(b)) { 
                i.delete = 1;
                    points++;
                
                }
            }
            foreach (var i in items) {
                if (i.fallen()) {
                    i.delete = 2;
                    misses++;
                }
            }

            for (int i = items.Count - 1; i >= 0; i--) {
                if (items[i].delete >= 1)
                {
                    items.RemoveAt(i);
                    
                }
            }
            
        }

    }
}
