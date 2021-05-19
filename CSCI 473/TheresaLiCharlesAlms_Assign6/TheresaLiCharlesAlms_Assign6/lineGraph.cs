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
    public partial class lineGraph : Form
    {
        public lineGraph()
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
