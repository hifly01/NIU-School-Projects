using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace TheresaLiCharlesAlms_Assign6
{
    public partial class pyramidGraph : Form
    {
        public pyramidGraph()
        {
            InitializeComponent();
        }

        //When back button gets clicked, returns back to main portal 
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainPortal mp = new mainPortal();
            mp.ShowDialog();
            this.Close();
        }
    }
}
