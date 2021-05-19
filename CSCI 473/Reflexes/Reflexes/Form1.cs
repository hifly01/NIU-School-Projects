using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Reflexes
{
    public partial class Form1 : Form
    {
        public static List<Circles> theCircles;
        public static System.Timers.Timer newCircle;
        public static System.Timers.Timer ageCircle;
        public static Random rng;

        public static readonly int MAX_RADIUS = 35;
        public static readonly int MIN_RADIUS = 15;
        public static readonly int OBJECTIVE = 5;
        public static readonly int YELLOW = 1100;
        public static readonly int RED = 1750;

        public static int totalMS;
        public static int totalCleared;

        public class Circles
        {
            public int X;
            public int Y;
            public int R;

            public Stopwatch sw;

            public Color myColor;

            public Circles()
            {
                X = Y = R = 0;
            }

            public Circles(int newX, int newY, int newR)
            {
                X = newX;
                Y = newY;
                R = newR;

                sw = new Stopwatch();
                sw.Start();

                myColor = Color.Green;
            }
        }

        public Form1()
        {
            InitializeComponent();
            theCircles = new List<Circles>();

            newCircle = new System.Timers.Timer(2150);
            newCircle.Elapsed += MakeANewCircle;
            newCircle.AutoReset = true;
            newCircle.Enabled = true;

            ageCircle = new System.Timers.Timer(275);
            ageCircle.Elapsed += AgeTheCircles;
            ageCircle.AutoReset = true;
            ageCircle.Enabled = true;

            rng = new Random();
        }

        private void MakeANewCircle(object sender, ElapsedEventArgs e)
        {
            theCircles.Add(new Circles(rng.Next(Canvas.Width - (2 * MAX_RADIUS)) + MAX_RADIUS,
                                       rng.Next(Canvas.Height - (2 * MAX_RADIUS)) + MAX_RADIUS,
                                       rng.Next(MAX_RADIUS - MIN_RADIUS) + MIN_RADIUS));

            Canvas.Refresh();
        }

        private void AgeTheCircles(object sender, ElapsedEventArgs e)
        {
            foreach (Circles i in theCircles)
            {
                if (i.sw.ElapsedMilliseconds < YELLOW)
                    i.myColor = Color.FromArgb(255, (int)(255 * (float)i.sw.ElapsedMilliseconds / YELLOW),
                                               255, 0);
                else if (i.sw.ElapsedMilliseconds < RED)
                {
                    i.myColor = Color.FromArgb(255, 255,
                                               255 - ((int)(255 * (float)(i.sw.ElapsedMilliseconds - YELLOW) / (RED - YELLOW))),
                                               0);
                }
                else // i.sw.ElapsedMilliseconds >= RED
                    i.myColor = Color.Red;

                /*
                if (i.sw.ElapsedMilliseconds > 800 &&
                    i.sw.ElapsedMilliseconds < 1600)
                {
                    i.myColor = Color.Yellow;
                }

                if (i.sw.ElapsedMilliseconds > 1600)
                {
                    i.myColor = Color.Red;
                }
                */
            }

            Canvas.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            newCircle.Dispose();
            ageCircle.Dispose();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Circles i in theCircles)
            {
                using (Brush myBrush = new SolidBrush(i.myColor))
                {
                    g.FillCircle(myBrush, i.X, i.Y, i.R);
                }
            }
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Circles i in theCircles)
            {
                if ( ((e.X - i.X) * (e.X - i.X)) + ((e.Y - i.Y) * (e.Y - i.Y)) < (i.R * i.R))
                {
                    //MessageBox.Show(String.Format("The circle has been cleared in {0: 0.000} seconds.",
                    //                ((float)i.sw.ElapsedMilliseconds / 1000) ));
                    totalMS = (int)i.sw.ElapsedMilliseconds;
                    totalCleared++;

                    if (totalCleared >= OBJECTIVE)
                    {
                        newCircle.Enabled = false;

                        theCircles.Clear();
                        Canvas.Refresh();

                        MessageBox.Show(String.Format("Your average clear time was {0: 0.000} seconds, for {1} circles.",
                                        (float)totalMS / (totalCleared * 1000), totalCleared));
                    }

                    theCircles.Remove(i);
                    Canvas.Refresh();

                    return;
                }
            }
        }
    }

    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
