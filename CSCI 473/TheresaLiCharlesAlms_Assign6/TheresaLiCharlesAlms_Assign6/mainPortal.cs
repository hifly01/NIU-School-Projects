/********************************************************************
CSCI 473 - Assignment 6 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   4/27/20

Purpose:    This program is teaching us how to make charts in C#
*********************************************************************/

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
    public partial class mainPortal : Form
    {
        public mainPortal()
        {
            InitializeComponent();
        }

        //when the bargraph button is clicked 
        private void bargraph_button_Click(object sender, EventArgs e)
        {
            this.Hide(); //this form will hide
            barGraph graph1 = new barGraph(); //bargraph will be created
            graph1.ShowDialog(); //and displayed 
        }

        //when the linegraph button is clicked 
        private void lineGraph_button_Click(object sender, EventArgs e)
        {
            this.Hide(); //this form will hide
            lineGraph graph2 = new lineGraph(); //linegraph will be created
            graph2.ShowDialog(); //and displayed 
        }

        //when the piechart button is clicked 
        private void pieChart_button_Click(object sender, EventArgs e)
        {
            this.Hide(); //this form will hide
            pieChart graph3 = new pieChart(); //piechart will be created
            graph3.ShowDialog(); //and displayed 
        }

        //when the pyramidgraph button is clicked 
        private void pyramidGraph_button_Click(object sender, EventArgs e)
        {
            this.Hide(); //this form will hide
            pyramidGraph graph4 = new pyramidGraph(); //pyramidgraph will be created
            graph4.ShowDialog(); //and displayed 
        }
    }
}