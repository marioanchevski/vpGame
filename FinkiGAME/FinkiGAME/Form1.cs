using FinkiGAME.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace FinkiGAME
{
    public partial class Form1 : Form
    {
        int numberOfItems;
        bool flag;
        int countPoints;
        public Items Scene { get; set; }
        public Box MyBox { get; set; }
        private double remainingTimeForBeers;
        readonly Image BeerBox;
        readonly Image beer;
        readonly Image backgroundPicture;
        readonly Form2 form2Obj = new Form2();

        public Form1()
        {
            InitializeComponent();
            NewGame();
            beer = Resources.BeerBottleTransparent;
            BeerBox = Resources.Box;
            backgroundPicture = Resources.wood_background_final;
        }
        public void NewGame()
        {
            panel1.BackgroundImage = Resources.Lvl1;
            label1.BackColor = ColorTranslator.FromHtml("#CDE9D8");
            label2.BackColor = ColorTranslator.FromHtml("#CDE9D8");
            Cursor.Hide();
            flag = true;
            remainingTimeForBeers = 18;
            Items.points = 0;
            Scene = new Items();
            DoubleBuffered = true;
            numberOfItems = 1;
            MyBox = new Box();
            Beer.SPEED = 5;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (numberOfItems % remainingTimeForBeers == 0)
            {
                Scene.AddItem();
            }

            if (Items.points % 10 == 0 && Items.points != 0 && countPoints != Items.points)
            {
                timer1.Stop();
                remainingTimeForBeers -= 3;
                if (Items.points > 40)
                {
                    Beer.SPEED = (int)(Beer.SPEED * 1.3);
                }
                else
                {
                    Beer.SPEED = (int)(Beer.SPEED * 1.5);
                }

                Cursor.Show();
                panelBackground();
                Thread.Sleep(3000);
                Cursor.Hide();
                countPoints = Items.points;
                timer1.Start();
            }
            Scene.Move();
            numberOfItems++;
            Scene.IsHit(MyBox);
            textBox1.Text = Items.points.ToString();
            textBox2.Text = Scene.Misses.ToString();

            if (Scene.Misses == 3)
                timer1.Stop();
            form2Obj.showPoints(Items.points);

            if (Items.points == 50)
            {
                endGame();

            }
            Invalidate();
        }

        private void endGame()
        {
            timer1.Stop();
            Cursor.Show();
        }

        public void panelBackground()
        {
            if (Items.points == 10)
            {
                label1.BackColor = ColorTranslator.FromHtml("#fff0b9");
                label2.BackColor = ColorTranslator.FromHtml("#fff0b9");
                panel1.BackgroundImage = Resources.Lvl2;
            }
            else if (Items.points == 20)
            {
                label1.BackColor = ColorTranslator.FromHtml("#fed9b0");
                label2.BackColor = ColorTranslator.FromHtml("#fed9b0");
                panel1.BackgroundImage = Resources.Lvl3;
            }
            else if (Items.points == 30)
            {
                label1.BackColor = ColorTranslator.FromHtml("#fbcdbe");
                label2.BackColor = ColorTranslator.FromHtml("#fbcdbe");
                panel1.BackgroundImage = Resources.Lvl4;
            }
            else
            {
                label1.BackColor = ColorTranslator.FromHtml("#ebb9ba");
                label2.BackColor = ColorTranslator.FromHtml("#ebb9ba");
                panel1.BackgroundImage = Resources.Lvl5;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Scene.Draw(e.Graphics);
            MyBox.Draw(e.Graphics);
            e.Graphics.DrawImageUnscaled(backgroundPicture, 108, 0);


            for (int i = 0; i < Scene.ItemsList.Count; i++)
            {
                e.Graphics.DrawImageUnscaled(beer, Scene.ItemsList[i].Location);
            }
            e.Graphics.DrawImageUnscaled(BeerBox, MyBox.Location);

            Brush b = new SolidBrush(Color.Red);
            if (Scene.Misses == 3)
            {

                if (flag)
                {
                    flag = false;
                    NewGameForm();
                }
            }
        }
        public void NewGameForm()
        {
            Cursor.Show();
            if (form2Obj.ShowDialog() == DialogResult.Yes)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor.Show();
            DialogResult result = MessageBox.Show("Are you sure you want to Quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
            else
            {
                timer1.Start();
                Cursor.Hide();
            }
        }
        public static int ScorePoints()
        {
            Form1 obj = new Form1();
            if (int.TryParse(obj.textBox1.Text, out var points))
            {
                return points;
            }
            else
            {
                return 0;
            }
        }

        private void Panel1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void Panel1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void ButtonQuit_MouseEnter(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.Red;
        }

        private void ButtonQuit_MouseLeave(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.Transparent;
        }
    }
}
