using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singularity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ColorWheel.Image = Image.FromFile("..//..//colorwheel.png");
        }

        private void ColorWheel_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                TitleLabel.ForeColor = cd.Color;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            new Form2().Show(); this.Hide();
        }
    }
}
