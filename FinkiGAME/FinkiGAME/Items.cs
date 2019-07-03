using System;
using System.Collections.Generic;
using System.Drawing;

namespace FinkiGAME
{
    public class Items
    {
        public List<Beer> items { get; set; }
        public static int points;
        public int Speed { get; set; }
        public int Misses { get; set; }
        private static readonly Random random = new Random();

        public Items()
        {
            items = new List<Beer>();
            points = 0;
            Speed = 10;
            Misses = 0;
        }

        public void AddItem()
        {
            items.Add(new Beer(new Point(random.Next(111, 610), -50)));
        }

        public void Draw(Graphics g)
        {
            foreach (var i in items)
            {
                i.Draw(g);
            }
        }


        public void Move()
        {
            foreach (var i in items)
            {
                i.Move(Speed);
            }
        }

        public void IsHit(Box b)
        {
            foreach (var i in items)
            {
                if (i.IsHit(b))
                {
                    i.Delete = 1;
                    points++;
                }
            }
            foreach (var i in items)
            {
                if (i.IsFallen())
                {
                    i.Delete = 2;
                    Misses++;
                }
            }

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Delete >= 1)
                {
                    items.RemoveAt(i);
                }
            }
        }
    }
}
