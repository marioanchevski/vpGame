using FinkiGAME.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinkiGAME
{
    public partial class Form1 : Form
    {
        int n;
        int pom;
        public Items scene { get; set; }
        public Box myBox { get; set; }
        Image BeerBox;
        Image beer;

        public Form1()
        {
            InitializeComponent();
            scene = new Items();
            DoubleBuffered = true;
            n = 1;
            myBox = new Box();
            beer = Resources.ZMA13254;
            BeerBox = Resources.sk;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (n % 10 == 0)
                scene.addItem();
            scene.move();
            n++;
            scene.isHit(myBox);
            textBox1.Text = scene.points.ToString();
            textBox2.Text = scene.misses.ToString();
            if (scene.misses == 3)
                timer1.Stop();
                Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            scene.draw(e.Graphics);
            myBox.draw(e.Graphics);
           
            for(int i=0;i<scene.items.Count;i++) {
                e.Graphics.DrawImageUnscaled(beer, scene.items[i].Location);
            }
            e.Graphics.DrawImageUnscaled(BeerBox, myBox.Location);

            Brush b = new SolidBrush(Color.Red);
            if (scene.misses == 3) {
                e.Graphics.DrawString("GAME OVER!", new Font("Arial", 18,FontStyle.Bold), b, 300, 222);
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            myBox.move(e.X);
        }
    }
}
