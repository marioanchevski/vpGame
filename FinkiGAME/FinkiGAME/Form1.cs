using FinkiGAME.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinkiGAME
{
    public partial class Form1 : Form
    {
        int numberOfItems;
        bool flag;
        public Items Scene { get; set; }
        public Box MyBox { get; set; }

        readonly Image BeerBox;
        readonly Image beer;

        public Form1()
        {
            InitializeComponent();
            NewGame();
            beer = Resources.ZMA13254;
            BeerBox = Resources.sk;
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;

        }
        public void NewGame()
        {
            flag = true;
            Scene = new Items();
            DoubleBuffered = true;
            numberOfItems = 1;
            MyBox = new Box();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (numberOfItems % 10 == 0)
                Scene.AddItem();
            Scene.Move();
            numberOfItems++;
            Scene.IsHit(MyBox);
            textBox1.Text = Items.points.ToString();
            textBox2.Text = Scene.Misses.ToString();
            if (Scene.Misses == 3)
                timer1.Stop();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Scene.Draw(e.Graphics);
            MyBox.Draw(e.Graphics);

            for (int i = 0; i < Scene.items.Count; i++)
            {
                e.Graphics.DrawImageUnscaled(beer, Scene.items[i].Location);
            }
            e.Graphics.DrawImageUnscaled(BeerBox, MyBox.Location);

            Brush b = new SolidBrush(Color.Red);
            if (Scene.Misses == 3)
            {
                //e.Graphics.DrawString("GAME OVER!", new Font("Arial", 18, FontStyle.Bold), b, 300, 222);
                if (flag)
                {
                    flag = false;
                    NewGameForm();
                }
            }
        }
        public void NewGameForm()
        {
            Form2 obj = new Form2();
            if (obj.ShowDialog() == DialogResult.Yes)
            {
                NewGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MyBox.Move(e.X);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
