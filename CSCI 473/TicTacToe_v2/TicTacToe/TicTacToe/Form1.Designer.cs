namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.X_Button = new System.Windows.Forms.RadioButton();
            this.O_Button = new System.Windows.Forms.RadioButton();
            this.X_Label = new System.Windows.Forms.Label();
            this.O_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(145, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(300, 300);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            // 
            // Reset_Button
            // 
            this.Reset_Button.ForeColor = System.Drawing.Color.Black;
            this.Reset_Button.Location = new System.Drawing.Point(13, 13);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 1;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.O_Button);
            this.groupBox1.Controls.Add(this.X_Button);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Choice";
            // 
            // X_Button
            // 
            this.X_Button.AutoSize = true;
            this.X_Button.Location = new System.Drawing.Point(7, 26);
            this.X_Button.Name = "X_Button";
            this.X_Button.Size = new System.Drawing.Size(39, 24);
            this.X_Button.TabIndex = 0;
            this.X_Button.TabStop = true;
            this.X_Button.Text = "X";
            this.X_Button.UseVisualStyleBackColor = true;
            this.X_Button.Click += new System.EventHandler(this.TicOrToe_Button_Click);
            // 
            // O_Button
            // 
            this.O_Button.AutoSize = true;
            this.O_Button.Location = new System.Drawing.Point(52, 26);
            this.O_Button.Name = "O_Button";
            this.O_Button.Size = new System.Drawing.Size(40, 24);
            this.O_Button.TabIndex = 1;
            this.O_Button.TabStop = true;
            this.O_Button.Text = "O";
            this.O_Button.UseVisualStyleBackColor = true;
            this.O_Button.Click += new System.EventHandler(this.TicOrToe_Button_Click);
            // 
            // X_Label
            // 
            this.X_Label.AutoSize = true;
            this.X_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_Label.Location = new System.Drawing.Point(13, 127);
            this.X_Label.Name = "X_Label";
            this.X_Label.Size = new System.Drawing.Size(96, 20);
            this.X_Label.TabIndex = 3;
            this.X_Label.Text = "X Victories";
            // 
            // O_Label
            // 
            this.O_Label.AutoSize = true;
            this.O_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.O_Label.Location = new System.Drawing.Point(13, 158);
            this.O_Label.Name = "O_Label";
            this.O_Label.Size = new System.Drawing.Size(97, 20);
            this.O_Label.TabIndex = 4;
            this.O_Label.Text = "O Victories";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(458, 325);
            this.Controls.Add(this.O_Label);
            this.Controls.Add(this.X_Label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Canvas);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton O_Button;
        private System.Windows.Forms.RadioButton X_Button;
        private System.Windows.Forms.Label X_Label;
        private System.Windows.Forms.Label O_Label;
    }
}

