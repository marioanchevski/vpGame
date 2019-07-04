using System;
using System.Windows.Forms;

namespace FinkiGAME
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void showPoints(int pointS)
        {
            labelScore.Text = "Your score is: " + pointS;
        }
        public int Points { get; internal set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Cursor.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
