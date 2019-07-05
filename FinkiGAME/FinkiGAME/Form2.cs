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
        public void ShowPoints(int pointS)
        {
            labelScore.Text = "Your score is: " + pointS;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
