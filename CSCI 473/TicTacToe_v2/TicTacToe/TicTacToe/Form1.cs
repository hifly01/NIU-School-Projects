using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public static class CONSTANTS
        {
            public static UInt16 BUFFER = 10;
        }

        public static Nullable<bool>[,] array;
        public static bool current;
        public static UInt16 xWins;
        public static UInt16 oWins;
        // false == X
        // true  == O

        public Form1()
        {
            InitializeComponent();
            array = new Nullable<bool>[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    array[i, j] = null;

            current = O_Button.Checked = true;
            xWins = oWins = 0;
        }

        public static bool DidSomeoneWin()
        {
            int result = 0;
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] == null)
                    {
                        flag = true;
                        break;
                    }

                    if (array[i, j].Value)
                        result++;
                }
                if (flag)
                {
                    result = 0;
                    flag = false;
                    continue;
                }

                if (result == 0)
                {
                    MessageBox.Show("The X's have won!");
                    xWins++;
                    return true;
                }
                else if (result == 3)
                {
                    MessageBox.Show("The O's have won!");
                    oWins++;
                    return true;
                }
                // else
                result = 0;
            }
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[j, i] == null)
                    {
                        flag = true;
                        break;
                    }

                    if (array[j, i].Value)
                        result++;
                }
                if (flag)
                {
                    result = 0;
                    flag = false;
                    continue;
                }

                if (result == 0)
                {
                    MessageBox.Show("The X's have won!");
                    xWins++;
                    return true;
                }
                else if (result == 3)
                {
                    MessageBox.Show("The O's have won!");
                    oWins++;
                    return true;
                }
                // else
                result = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                if (array[i, i] == null)
                {
                    flag = true;
                    break;
                }

                if (array[i, i].Value)
                    result++;
            }

            if (result == 0 && !flag)
            {
                MessageBox.Show("The X's have won!");
                xWins++;
                return true;
            }
            else if (result == 3 && !flag)
            {
                MessageBox.Show("The O's have won!");
                oWins++;
                return true;
            }
            // else
            result = 0;
            flag = false;

            for (int i = 2; i >= 0; i--)
            {
                if (array[i, 2 - i] == null)
                {
                    flag = true;
                    break;
                }

                if (array[i, 2 - i].Value)
                    result++;
            }
            if (flag)
            {
                result = 0;
                flag = false;
                return false;
            }

            if (result == 0)
            {
                MessageBox.Show("The X's have won!");
                xWins++;
                return true;
            }
            else if (result == 3)
            {
                MessageBox.Show("The O's have won!");
                oWins++;
                return true;
            }
            // else
            result = 0;
            return false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen myPen = new Pen(Color.White))
            {
                // My hash mark -- begin
                g.DrawLine(myPen, (Canvas.Width / 3), 0,
                                  (Canvas.Width / 3), Canvas.Height);
                g.DrawLine(myPen, (2 * Canvas.Width) / 3, 0,
                                  (2 * Canvas.Width) / 3, Canvas.Height);

                g.DrawLine(myPen, 0, (Canvas.Height / 3), 
                                     Canvas.Width, (Canvas.Height / 3));
                g.DrawLine(myPen, 0, (2 * Canvas.Height / 3),
                                     Canvas.Width, (2 * Canvas.Height / 3));
                // My has mark -- end

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (array[i, j] == null) continue;
                        // otherwise, there's a defined value here

                        if (array[i, j].Value)
                            g.DrawEllipse(myPen,
                                         (j * (Canvas.Width / 3)) + CONSTANTS.BUFFER,
                                         (i * (Canvas.Height / 3)) + CONSTANTS.BUFFER,
                                         (Canvas.Width / 3) - (CONSTANTS.BUFFER * 2),
                                         (Canvas.Height / 3) - (CONSTANTS.BUFFER * 2));

                        if (!array[i, j].Value)
                        {
                            g.DrawLine(myPen,
                                       (j * (Canvas.Width / 3)) + CONSTANTS.BUFFER,
                                       (i * (Canvas.Height / 3)) + CONSTANTS.BUFFER,
                                       ((j + 1) * (Canvas.Width / 3)) - CONSTANTS.BUFFER,
                                       ((i + 1) * (Canvas.Height / 3)) - CONSTANTS.BUFFER);

                            g.DrawLine(myPen,
                                       (j * (Canvas.Width / 3)) + CONSTANTS.BUFFER,
                                       ((i + 1) * (Canvas.Height / 3)) - CONSTANTS.BUFFER,
                                       ((j + 1) * (Canvas.Width / 3)) - CONSTANTS.BUFFER,
                                       (i * (Canvas.Height / 3)) + CONSTANTS.BUFFER);
                        }
                    }
            }
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            int row, col;

            col = e.X / (Canvas.Width / 3);
            row = e.Y / (Canvas.Height / 3);

            // Check if the cell is already occupied
            if (array[row, col] != null) return;

            array[row, col] = current;
            current = !current;
            Canvas.Refresh();

            if (DidSomeoneWin())
            {
                X_Label.Text = "X Victories: " + xWins;
                O_Label.Text = "O Victories: " + oWins;
                Reset_Button.PerformClick();
            }

            //MessageBox.Show(String.Format("({0}, {1})", row, col));
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    array[i, j] = null;

            current = O_Button.Checked = true;

            Canvas.Refresh();
        }

        public void TicOrToe_Button_Click(object sender, EventArgs e)
        {
            if (X_Button.Checked)
                current = false;
            else // since there's only one other option
                current = true;
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
