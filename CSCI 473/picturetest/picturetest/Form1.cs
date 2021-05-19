using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picturetest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox_Paint();
        }
        void pictureBox_Paint()
        {
            pictureBox1.Image = Image.FromFile("editedblackqueen.png");
        }
    }
}
