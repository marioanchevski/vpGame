using FinkiGAME.Properties;
using System;
using System.Windows.Forms;

namespace FinkiGAME
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            panel1.BackgroundImage = Resources.DrunkFinish;
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
