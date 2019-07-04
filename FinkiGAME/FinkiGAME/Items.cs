using System;
using System.Collections.Generic;
using System.Drawing;

namespace FinkiGAME
{
    public class Items
    {
        public List<Beer> ItemsList { get; set; } = new List<Beer>();
        public static int points;
        public int Speed { get; set; }
        public int Misses { get; set; }
        private static readonly Random random = new Random();

        public void AddItem()
        {
            ItemsList.Add(new Beer(new Point(random.Next(111, 610), -50)));
        }

        public void Draw(Graphics g)
        {
            foreach (var i in ItemsList)
            {
                i.Draw(g);
            }
        }


        public void Move()
        {
            foreach (var i in ItemsList)
            {
                i.Move(Speed);
            }
        }

        public void IsHit(Box b)
        {
            foreach (var i in ItemsList)
            {
                if (i.IsHit(b))
                {
                    i.Delete = 1;
                    points++;
                }
            }
            foreach (var i in ItemsList)
            {
                if (i.IsFallen())
                {
                    i.Delete = 2;
                    Misses++;
                }
            }

            for (int i = ItemsList.Count - 1; i >= 0; i--)
            {
                if (ItemsList[i].Delete >= 1)
                {
                    ItemsList.RemoveAt(i);
                }
            }
        }
    }
}
