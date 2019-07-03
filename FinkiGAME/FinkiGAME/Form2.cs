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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            labelScore.Text = "Your score is: " + Items.points;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
