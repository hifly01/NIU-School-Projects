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

namespace Singularity
{
    public partial class Form2 : Form
    {
        public static int INITIAL_STAR_COUNT = 100;
        public static int MAX_STAR_RADIUS = 3;
        public static int MIN_STAR_RADIUS = 1;
        public static int MIN_STAR_ALPHA = 100;
        public static int TWINKLE_OFFSET = 50;

        Random rng;

        public static List<Star> theStars;
        public static Point one;
        public static Point two;

        public static System.Timers.Timer moveStars;
        public static System.Timers.Timer newStars;
        public static System.Timers.Timer twinkle;

        public class Star
        {
            public int x;
            public int y;
            public int r;
            public int a;

            public bool up;

            public Star()
            {
                x = y = r = a = 0;
                up = true;
            }

            public Star(int newX, int newY, int newR, int newA, int upOrDown)
            {
                x = newX;
                y = newY;
                r = newR;
                a = newA;

                if (upOrDown == 0)
                    up = false;
                else
                    up = true;
            }
        }

        public Form2()
        {
            InitializeComponent();
            rng = new Random();
            theStars = new List<Star>();

            moveStars = new System.Timers.Timer(17);
            moveStars.Elapsed += MovingTheStars;
            moveStars.AutoReset = true;
            moveStars.Enabled = true;

            newStars = new System.Timers.Timer(100);
            newStars.Elapsed += NewStar;
            newStars.AutoReset = true;
            newStars.Enabled = true;

            twinkle = new System.Timers.Timer(216);
            twinkle.Elapsed += TwinkleStars;
            twinkle.AutoReset = true;
            twinkle.Enabled = true;

            StarScape();
        }

        public void StarScape()
        {
            for (int i = 0; i < INITIAL_STAR_COUNT; i++)
            {
                theStars.Add(new Star(rng.Next(Canvas.Width), rng.Next(Canvas.Height),
                                      rng.Next(MAX_STAR_RADIUS - MIN_STAR_RADIUS) + MIN_STAR_RADIUS,
                                      rng.Next(255 - MIN_STAR_ALPHA) + MIN_STAR_ALPHA, rng.Next(2)));
            }

            Canvas.Refresh();
        }

        public void MovingTheStars(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < theStars.Count; i++)
            {
                if (theStars[i].r == 3)
                    theStars[i].y += 2;
                else
                    theStars[i].y++;

                //i.y += i.r;

                if (theStars[i].y + theStars[i].r >= Canvas.Height)
                    theStars.RemoveAt(i);
            }

            Canvas.Refresh();
        }

        public void NewStar(object sender, ElapsedEventArgs e)
        {
            theStars.Add(new Star(rng.Next(Canvas.Width), 0,
                                  rng.Next(MAX_STAR_RADIUS - MIN_STAR_RADIUS) + MIN_STAR_RADIUS,
                                  rng.Next(255 - MIN_STAR_ALPHA) + MIN_STAR_ALPHA, rng.Next(2)));

            Canvas.Refresh();
        }

        public void TwinkleStars(object sender, ElapsedEventArgs e)
        {
            foreach (Star i in theStars)
            {
                if (i.up)
                {
                    i.a += TWINKLE_OFFSET;
                    /*
                    if (i.a + TWINKLE_OFFSET >= 255)
                        i.a = 255;
                        */
                    i.up = false;
                }
                else
                {
                    i.a -= TWINKLE_OFFSET;
                    i.up = true;
                }
            }

            Canvas.Refresh();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            moveStars.Dispose();
            newStars.Dispose();
            twinkle.Dispose();
            Application.Exit();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Star i in theStars)
            {
                if (i.a >= 255)
                {
                    using (Brush myBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255)))
                    {
                        g.FillCircle(myBrush, i.x, i.y, i.r);
                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(Color.FromArgb(i.a, 255, 255, 255)))
                    {
                        g.FillCircle(myBrush, i.x, i.y, i.r);
                    }
                }
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            one = e.Location;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            two = e.Location;
            Point temp = one;

            one.X = Math.Min(temp.X, two.X);
            one.Y = Math.Min(temp.Y, two.Y);

            two.X = Math.Max(temp.X, two.X);
            two.Y = Math.Max(temp.Y, two.Y);

            for (int i = 0; i < theStars.Count; i++)
            {
                if (theStars[i].x > one.X && theStars[i].x < two.X &&
                    theStars[i].y > one.Y && theStars[i].y < two.Y)
                {
                    theStars.RemoveAt(i--);
                }
            }

            Canvas.Refresh();
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
