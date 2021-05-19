using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashCards
{
    public partial class Form1 : Form
    {
        public static List<string> pool;
        public static bool[] picked;
        public static Random rng;

        public static UInt16 total;
        public static UInt16 rightQ;
        public static UInt16 wrongQ;

        public static UInt16 index;

        public void ResetFlags()
        {
            for (int i = 0; i < picked.Length; i++)
                picked[i] = false;
        }

        public ushort NewIndex()
        {
            ushort result = (ushort)rng.Next(pool.Count);

            while (picked[result])
            {
                result = (ushort)rng.Next(pool.Count);
            }
            picked[result] = true;

            return result;
        }

        public void PopulatePool()
        {
            string slacker;
            using (StreamReader inFile = new StreamReader("../../cards.txt"))
            {
                slacker = inFile.ReadLine();

                while (slacker != null)
                {
                    pool.Add(slacker);
                    slacker = inFile.ReadLine();
                }
            }

            picked = new bool[pool.Count];
            ResetFlags();
        }

        public Form1()
        {
            InitializeComponent();

            pool = new List<string>();
            rng = new Random();
            total = rightQ = wrongQ = 0;
            FlashCard.SelectionAlignment = HorizontalAlignment.Center;
            Percentage_Output.TextAlign = HorizontalAlignment.Center;

            PopulatePool();

            if (pool.Count > 0)
            {
                index = NewIndex();

                FlashCard.Text = "\n\n\n\n" + pool[index].Split('#')[0];
            }
            /*
            FlashCard.Text = "\n\n\n\nThe answer to life and everything.";
            */
        }

        private void FlashCard_Click(object sender, EventArgs e)
        {
            if (FlashCard.Text.CompareTo("\n\n\n\n" + pool[index].Split('#')[0]) == 0)
                FlashCard.Text = "\n\n\n\n" + pool[index].Split('#')[1];
            else
                FlashCard.Text = "\n\n\n\n" + pool[index].Split('#')[0];
        }

        public void Button_Response_Event(object sender, EventArgs args)
        {
            Button alpha = sender as Button;

            if (alpha.Text.CompareTo("R") == 0)
                rightQ++;
            else // You got the question wrong
                wrongQ++;

            total++;

            float temp = (float)rightQ / total;
            Percentage_Output.BackColor = Color.FromArgb(255,
                                                         (int)(255 * (1 - temp)),
                                                         (int)(255 * temp),
                                                         0);
            //MessageBox.Show(Percentage_Output.ForeColor.ToString());
            Percentage_Output.Text = String.Format("{0: 0.00%}", temp);
            ProgressBar.Value += ProgressBar.Step;

            if (ProgressBar.Value >= ProgressBar.Maximum)
            {
                HistoryLog.AppendText(Percentage_Output.Text + "   ");
                Percentage_Output.BackColor = Color.White;
                Percentage_Output.Text = "";
                ProgressBar.Value = ProgressBar.Minimum;
                ResetFlags();
                rightQ = wrongQ = total = 0;
            }

            index = NewIndex();

            if (index < pool.Count)
                FlashCard.Text = "\n\n\n\n" + pool[index].Split('#')[0];
        }

        private void SlackerBar_Scroll(object sender, EventArgs e)
        {
            TrackBar_Label.Text = "Slacker " + SlackerBar.Value;
        }
    }
}

