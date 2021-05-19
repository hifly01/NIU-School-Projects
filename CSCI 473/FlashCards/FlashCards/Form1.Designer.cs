namespace FlashCards
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
            this.FlashCard = new System.Windows.Forms.RichTextBox();
            this.Right_Button = new System.Windows.Forms.Button();
            this.Wrong_Button = new System.Windows.Forms.Button();
            this.Percentage_Output = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.HistoryLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SlackerBar = new System.Windows.Forms.TrackBar();
            this.TrackBar_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SlackerBar)).BeginInit();
            this.SuspendLayout();
            // 
            // FlashCard
            // 
            this.FlashCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlashCard.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlashCard.Location = new System.Drawing.Point(13, 13);
            this.FlashCard.Name = "FlashCard";
            this.FlashCard.ReadOnly = true;
            this.FlashCard.Size = new System.Drawing.Size(449, 277);
            this.FlashCard.TabIndex = 0;
            this.FlashCard.Text = "";
            this.FlashCard.Click += new System.EventHandler(this.FlashCard_Click);
            // 
            // Right_Button
            // 
            this.Right_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right_Button.ForeColor = System.Drawing.Color.Black;
            this.Right_Button.Location = new System.Drawing.Point(468, 187);
            this.Right_Button.Name = "Right_Button";
            this.Right_Button.Size = new System.Drawing.Size(40, 40);
            this.Right_Button.TabIndex = 1;
            this.Right_Button.Text = "R";
            this.Right_Button.UseVisualStyleBackColor = true;
            this.Right_Button.Click += new System.EventHandler(this.Button_Response_Event);
            // 
            // Wrong_Button
            // 
            this.Wrong_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wrong_Button.ForeColor = System.Drawing.Color.Black;
            this.Wrong_Button.Location = new System.Drawing.Point(514, 187);
            this.Wrong_Button.Name = "Wrong_Button";
            this.Wrong_Button.Size = new System.Drawing.Size(40, 40);
            this.Wrong_Button.TabIndex = 2;
            this.Wrong_Button.Text = "W";
            this.Wrong_Button.UseVisualStyleBackColor = true;
            this.Wrong_Button.Click += new System.EventHandler(this.Button_Response_Event);
            // 
            // Percentage_Output
            // 
            this.Percentage_Output.BackColor = System.Drawing.Color.White;
            this.Percentage_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percentage_Output.Location = new System.Drawing.Point(469, 86);
            this.Percentage_Output.Name = "Percentage_Output";
            this.Percentage_Output.ReadOnly = true;
            this.Percentage_Output.Size = new System.Drawing.Size(154, 29);
            this.Percentage_Output.TabIndex = 3;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(469, 37);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(154, 23);
            this.ProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "History";
            // 
            // HistoryLog
            // 
            this.HistoryLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryLog.Location = new System.Drawing.Point(13, 322);
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.Size = new System.Drawing.Size(607, 22);
            this.HistoryLog.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(469, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quiz Progress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(469, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Response";
            // 
            // SlackerBar
            // 
            this.SlackerBar.Location = new System.Drawing.Point(485, 271);
            this.SlackerBar.Name = "SlackerBar";
            this.SlackerBar.Size = new System.Drawing.Size(104, 45);
            this.SlackerBar.TabIndex = 10;
            this.SlackerBar.Scroll += new System.EventHandler(this.SlackerBar_Scroll);
            // 
            // TrackBar_Label
            // 
            this.TrackBar_Label.AutoSize = true;
            this.TrackBar_Label.Location = new System.Drawing.Point(492, 255);
            this.TrackBar_Label.Name = "TrackBar_Label";
            this.TrackBar_Label.Size = new System.Drawing.Size(43, 13);
            this.TrackBar_Label.TabIndex = 11;
            this.TrackBar_Label.Text = "Slacker";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(635, 356);
            this.Controls.Add(this.TrackBar_Label);
            this.Controls.Add(this.SlackerBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HistoryLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Percentage_Output);
            this.Controls.Add(this.Wrong_Button);
            this.Controls.Add(this.Right_Button);
            this.Controls.Add(this.FlashCard);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SlackerBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox FlashCard;
        private System.Windows.Forms.Button Right_Button;
        private System.Windows.Forms.Button Wrong_Button;
        private System.Windows.Forms.TextBox Percentage_Output;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HistoryLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar SlackerBar;
        private System.Windows.Forms.Label TrackBar_Label;
    }
}


