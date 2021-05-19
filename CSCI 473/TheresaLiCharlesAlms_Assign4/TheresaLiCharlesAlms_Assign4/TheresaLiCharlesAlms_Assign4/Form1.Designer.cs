using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheresaLiCharlesAlms_Assign4
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
            this.components = new System.ComponentModel.Container();
            this.map = new System.Windows.Forms.PictureBox();
            this.results_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Legend = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.propertyInfo = new System.Windows.Forms.ToolTip(this.components);
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.zoomBarLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.max_trackBar = new System.Windows.Forms.TrackBar();
            this.MaxPrice_label = new System.Windows.Forms.Label();
            this.MinPrice_label = new System.Windows.Forms.Label();
            this.min_trackBar = new System.Windows.Forms.TrackBar();
            this.school_checkBox = new System.Windows.Forms.CheckBox();
            this.businesss_checkBox = new System.Windows.Forms.CheckBox();
            this.residental_checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.school_comboBox = new System.Windows.Forms.ComboBox();
            this.distanceSch_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showAllRes_Check = new System.Windows.Forms.CheckBox();
            this.business_comboBox = new System.Windows.Forms.ComboBox();
            this.distanceBus_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.attachedGarage_checkbox = new System.Windows.Forms.CheckBox();
            this.minSq_numeric = new System.Windows.Forms.NumericUpDown();
            this.bath_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bednumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.garage_checkBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.apartment_checkBox = new System.Windows.Forms.CheckBox();
            this.house_checkBox = new System.Windows.Forms.CheckBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.showZoomLabel = new System.Windows.Forms.Label();
            this.resetbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.Legend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_trackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSch_numericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBus_numericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minSq_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bath_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bednumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.White;
            this.map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.map.Location = new System.Drawing.Point(516, 199);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(500, 250);
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            this.map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map_MouseDown);
            this.map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
            this.map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map_MouseUp);
            this.map.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.map_MouseWheel);
            // 
            // results_richTextBox
            // 
            this.results_richTextBox.Location = new System.Drawing.Point(515, 455);
            this.results_richTextBox.Name = "results_richTextBox";
            this.results_richTextBox.Size = new System.Drawing.Size(501, 111);
            this.results_richTextBox.TabIndex = 1;
            this.results_richTextBox.Text = "";
            // 
            // Legend
            // 
            this.Legend.BackColor = System.Drawing.Color.White;
            this.Legend.Controls.Add(this.label10);
            this.Legend.Controls.Add(this.label9);
            this.Legend.Controls.Add(this.label8);
            this.Legend.Controls.Add(this.label7);
            this.Legend.Controls.Add(this.label6);
            this.Legend.Controls.Add(this.label5);
            this.Legend.Controls.Add(this.label4);
            this.Legend.Controls.Add(this.label3);
            this.Legend.Controls.Add(this.label2);
            this.Legend.Controls.Add(this.label1);
            this.Legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Legend.Location = new System.Drawing.Point(515, 12);
            this.Legend.Name = "Legend";
            this.Legend.Size = new System.Drawing.Size(200, 181);
            this.Legend.TabIndex = 2;
            this.Legend.TabStop = false;
            this.Legend.Text = "Legend";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(77, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "- Curves";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkOrange;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Orange";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "- Streets";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Black";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "- Residences";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "- Businesses";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "- Schools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Purple;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Purple";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Blue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // propertyInfo
            // 
            this.propertyInfo.UseAnimation = false;
            // 
            // zoomBar
            // 
            this.zoomBar.BackColor = System.Drawing.Color.White;
            this.zoomBar.LargeChange = 25;
            this.zoomBar.Location = new System.Drawing.Point(742, 134);
            this.zoomBar.Maximum = 175;
            this.zoomBar.Minimum = 100;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(249, 45);
            this.zoomBar.SmallChange = 25;
            this.zoomBar.TabIndex = 3;
            this.zoomBar.TickFrequency = 25;
            this.zoomBar.Value = 100;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // zoomBarLabel
            // 
            this.zoomBarLabel.AutoSize = true;
            this.zoomBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomBarLabel.Location = new System.Drawing.Point(726, 101);
            this.zoomBarLabel.Name = "zoomBarLabel";
            this.zoomBarLabel.Size = new System.Drawing.Size(87, 20);
            this.zoomBarLabel.TabIndex = 4;
            this.zoomBarLabel.Text = "Zoom Bar";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.max_trackBar);
            this.groupBox5.Controls.Add(this.MaxPrice_label);
            this.groupBox5.Controls.Add(this.MinPrice_label);
            this.groupBox5.Controls.Add(this.min_trackBar);
            this.groupBox5.Controls.Add(this.school_checkBox);
            this.groupBox5.Controls.Add(this.businesss_checkBox);
            this.groupBox5.Controls.Add(this.residental_checkBox1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(497, 162);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "For Sale Properties Within Price Range";
            // 
            // max_trackBar
            // 
            this.max_trackBar.LargeChange = 500;
            this.max_trackBar.Location = new System.Drawing.Point(176, 124);
            this.max_trackBar.Maximum = 350000;
            this.max_trackBar.Name = "max_trackBar";
            this.max_trackBar.Size = new System.Drawing.Size(172, 45);
            this.max_trackBar.SmallChange = 100;
            this.max_trackBar.TabIndex = 13;
            this.max_trackBar.Scroll += new System.EventHandler(this.max_trackBar_Scroll);
            // 
            // MaxPrice_label
            // 
            this.MaxPrice_label.AutoSize = true;
            this.MaxPrice_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxPrice_label.Location = new System.Drawing.Point(172, 101);
            this.MaxPrice_label.Name = "MaxPrice_label";
            this.MaxPrice_label.Size = new System.Drawing.Size(86, 20);
            this.MaxPrice_label.TabIndex = 12;
            this.MaxPrice_label.Text = "Max Price";
            // 
            // MinPrice_label
            // 
            this.MinPrice_label.AutoSize = true;
            this.MinPrice_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinPrice_label.Location = new System.Drawing.Point(172, 26);
            this.MinPrice_label.Name = "MinPrice_label";
            this.MinPrice_label.Size = new System.Drawing.Size(82, 20);
            this.MinPrice_label.TabIndex = 11;
            this.MinPrice_label.Text = "Min Price";
            // 
            // min_trackBar
            // 
            this.min_trackBar.LargeChange = 500;
            this.min_trackBar.Location = new System.Drawing.Point(176, 53);
            this.min_trackBar.Maximum = 350000;
            this.min_trackBar.Name = "min_trackBar";
            this.min_trackBar.Size = new System.Drawing.Size(172, 45);
            this.min_trackBar.SmallChange = 100;
            this.min_trackBar.TabIndex = 4;
            this.min_trackBar.Scroll += new System.EventHandler(this.min_trackBar_Scroll);
            // 
            // school_checkBox
            // 
            this.school_checkBox.AutoSize = true;
            this.school_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.school_checkBox.Location = new System.Drawing.Point(6, 104);
            this.school_checkBox.Name = "school_checkBox";
            this.school_checkBox.Size = new System.Drawing.Size(77, 24);
            this.school_checkBox.TabIndex = 3;
            this.school_checkBox.Text = "School";
            this.school_checkBox.UseVisualStyleBackColor = true;
            // 
            // businesss_checkBox
            // 
            this.businesss_checkBox.AutoSize = true;
            this.businesss_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businesss_checkBox.Location = new System.Drawing.Point(6, 74);
            this.businesss_checkBox.Name = "businesss_checkBox";
            this.businesss_checkBox.Size = new System.Drawing.Size(93, 24);
            this.businesss_checkBox.TabIndex = 2;
            this.businesss_checkBox.Text = "Business";
            this.businesss_checkBox.UseVisualStyleBackColor = true;
            // 
            // residental_checkBox1
            // 
            this.residental_checkBox1.AutoSize = true;
            this.residental_checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.residental_checkBox1.Location = new System.Drawing.Point(6, 44);
            this.residental_checkBox1.Name = "residental_checkBox1";
            this.residental_checkBox1.Size = new System.Drawing.Size(104, 24);
            this.residental_checkBox1.TabIndex = 1;
            this.residental_checkBox1.Text = "Residental";
            this.residental_checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.school_comboBox);
            this.groupBox2.Controls.Add(this.distanceSch_numericUpDown);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "For Sale Residences Within Range of a School";
            // 
            // school_comboBox
            // 
            this.school_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.school_comboBox.FormattingEnabled = true;
            this.school_comboBox.Location = new System.Drawing.Point(10, 54);
            this.school_comboBox.MaxDropDownItems = 20;
            this.school_comboBox.Name = "school_comboBox";
            this.school_comboBox.Size = new System.Drawing.Size(248, 24);
            this.school_comboBox.TabIndex = 11;
            // 
            // distanceSch_numericUpDown
            // 
            this.distanceSch_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceSch_numericUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.distanceSch_numericUpDown.Location = new System.Drawing.Point(277, 54);
            this.distanceSch_numericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.distanceSch_numericUpDown.Name = "distanceSch_numericUpDown";
            this.distanceSch_numericUpDown.Size = new System.Drawing.Size(80, 22);
            this.distanceSch_numericUpDown.TabIndex = 10;
            this.distanceSch_numericUpDown.ValueChanged += new System.EventHandler(this.distanceSch_numericUpDown_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(277, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Distance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "School";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showAllRes_Check);
            this.groupBox3.Controls.Add(this.business_comboBox);
            this.groupBox3.Controls.Add(this.distanceBus_numericUpDown);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 127);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hiring Business(es) Within Range of For Sale";
            // 
            // showAllRes_Check
            // 
            this.showAllRes_Check.AutoSize = true;
            this.showAllRes_Check.Checked = true;
            this.showAllRes_Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAllRes_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllRes_Check.Location = new System.Drawing.Point(391, 70);
            this.showAllRes_Check.Name = "showAllRes_Check";
            this.showAllRes_Check.Size = new System.Drawing.Size(78, 20);
            this.showAllRes_Check.TabIndex = 12;
            this.showAllRes_Check.Text = "Show All";
            this.showAllRes_Check.UseVisualStyleBackColor = true;
            this.showAllRes_Check.CheckedChanged += new System.EventHandler(this.showAllRes_Check_CheckedChanged);
            // 
            // business_comboBox
            // 
            this.business_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.business_comboBox.FormattingEnabled = true;
            this.business_comboBox.Location = new System.Drawing.Point(10, 68);
            this.business_comboBox.MaxDropDownItems = 20;
            this.business_comboBox.Name = "business_comboBox";
            this.business_comboBox.Size = new System.Drawing.Size(248, 24);
            this.business_comboBox.TabIndex = 12;
            // 
            // distanceBus_numericUpDown
            // 
            this.distanceBus_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceBus_numericUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.distanceBus_numericUpDown.Location = new System.Drawing.Point(277, 68);
            this.distanceBus_numericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.distanceBus_numericUpDown.Name = "distanceBus_numericUpDown";
            this.distanceBus_numericUpDown.Size = new System.Drawing.Size(80, 22);
            this.distanceBus_numericUpDown.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "For-Sale Residence";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(277, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Distance";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.attachedGarage_checkbox);
            this.groupBox4.Controls.Add(this.minSq_numeric);
            this.groupBox4.Controls.Add(this.bath_numericUpDown);
            this.groupBox4.Controls.Add(this.bednumericUpDown);
            this.groupBox4.Controls.Add(this.garage_checkBox);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.apartment_checkBox);
            this.groupBox4.Controls.Add(this.house_checkBox);
            this.groupBox4.Controls.Add(this.enterButton);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(497, 147);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Specific Residence Parameters";
            // 
            // attachedGarage_checkbox
            // 
            this.attachedGarage_checkbox.AutoSize = true;
            this.attachedGarage_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachedGarage_checkbox.Location = new System.Drawing.Point(391, 51);
            this.attachedGarage_checkbox.Name = "attachedGarage_checkbox";
            this.attachedGarage_checkbox.Size = new System.Drawing.Size(87, 20);
            this.attachedGarage_checkbox.TabIndex = 17;
            this.attachedGarage_checkbox.Text = "Attached?";
            this.attachedGarage_checkbox.UseVisualStyleBackColor = true;
            // 
            // minSq_numeric
            // 
            this.minSq_numeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minSq_numeric.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.minSq_numeric.Location = new System.Drawing.Point(286, 50);
            this.minSq_numeric.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.minSq_numeric.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.minSq_numeric.Name = "minSq_numeric";
            this.minSq_numeric.Size = new System.Drawing.Size(63, 22);
            this.minSq_numeric.TabIndex = 16;
            this.minSq_numeric.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // bath_numericUpDown
            // 
            this.bath_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bath_numericUpDown.Location = new System.Drawing.Point(199, 49);
            this.bath_numericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.bath_numericUpDown.Name = "bath_numericUpDown";
            this.bath_numericUpDown.Size = new System.Drawing.Size(52, 22);
            this.bath_numericUpDown.TabIndex = 15;
            // 
            // bednumericUpDown
            // 
            this.bednumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bednumericUpDown.Location = new System.Drawing.Point(123, 49);
            this.bednumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.bednumericUpDown.Name = "bednumericUpDown";
            this.bednumericUpDown.Size = new System.Drawing.Size(52, 22);
            this.bednumericUpDown.TabIndex = 10;
            // 
            // garage_checkBox
            // 
            this.garage_checkBox.AutoSize = true;
            this.garage_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.garage_checkBox.Location = new System.Drawing.Point(391, 25);
            this.garage_checkBox.Name = "garage_checkBox";
            this.garage_checkBox.Size = new System.Drawing.Size(73, 20);
            this.garage_checkBox.TabIndex = 14;
            this.garage_checkBox.Text = "Garage";
            this.garage_checkBox.UseVisualStyleBackColor = true;
            this.garage_checkBox.CheckedChanged += new System.EventHandler(this.garage_checkBox_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(283, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 16);
            this.label16.TabIndex = 13;
            this.label16.Text = "Min Sq.Ft.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(196, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 16);
            this.label17.TabIndex = 12;
            this.label17.Text = "Bath";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(120, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 16);
            this.label18.TabIndex = 11;
            this.label18.Text = "Bed";
            // 
            // apartment_checkBox
            // 
            this.apartment_checkBox.AutoSize = true;
            this.apartment_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apartment_checkBox.Location = new System.Drawing.Point(11, 51);
            this.apartment_checkBox.Name = "apartment_checkBox";
            this.apartment_checkBox.Size = new System.Drawing.Size(88, 20);
            this.apartment_checkBox.TabIndex = 5;
            this.apartment_checkBox.Text = "Apartment";
            this.apartment_checkBox.UseVisualStyleBackColor = true;
            this.apartment_checkBox.CheckedChanged += new System.EventHandler(this.apartment_checkBox_CheckedChanged);
            // 
            // house_checkBox
            // 
            this.house_checkBox.AutoSize = true;
            this.house_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.house_checkBox.Location = new System.Drawing.Point(11, 25);
            this.house_checkBox.Name = "house_checkBox";
            this.house_checkBox.Size = new System.Drawing.Size(67, 20);
            this.house_checkBox.TabIndex = 4;
            this.house_checkBox.Text = "House";
            this.house_checkBox.UseVisualStyleBackColor = true;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(391, 92);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(96, 37);
            this.enterButton.TabIndex = 3;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Query);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(721, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 20);
            this.label19.TabIndex = 13;
            this.label19.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(997, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 20);
            this.label20.TabIndex = 14;
            this.label20.Text = "+";
            // 
            // showZoomLabel
            // 
            this.showZoomLabel.AutoSize = true;
            this.showZoomLabel.BackColor = System.Drawing.Color.White;
            this.showZoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showZoomLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showZoomLabel.Location = new System.Drawing.Point(909, 199);
            this.showZoomLabel.Name = "showZoomLabel";
            this.showZoomLabel.Size = new System.Drawing.Size(49, 16);
            this.showZoomLabel.TabIndex = 15;
            this.showZoomLabel.Text = "|----|----|";
            // 
            // resetbutton
            // 
            this.resetbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbutton.Location = new System.Drawing.Point(895, 64);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(96, 37);
            this.resetbutton.TabIndex = 18;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.ClientSize = new System.Drawing.Size(1028, 577);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.showZoomLabel);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.zoomBarLabel);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.Legend);
            this.Controls.Add(this.results_richTextBox);
            this.Controls.Add(this.map);
            this.Name = "Form1";
            this.Text = "DeKalb Realestate";
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.Legend.ResumeLayout(false);
            this.Legend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_trackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceSch_numericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBus_numericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minSq_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bath_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bednumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.RichTextBox results_richTextBox;
        private System.Windows.Forms.GroupBox Legend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip propertyInfo;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TrackBar zoomBar;
        private Label zoomBarLabel;
        private GroupBox groupBox5;
        private TrackBar max_trackBar;
        private Label MaxPrice_label;
        private Label MinPrice_label;
        private TrackBar min_trackBar;
        private CheckBox school_checkBox;
        private CheckBox businesss_checkBox;
        private CheckBox residental_checkBox1;
        private GroupBox groupBox2;
        private ComboBox school_comboBox;
        private NumericUpDown distanceSch_numericUpDown;
        private Label label12;
        private Label label13;
        private GroupBox groupBox3;
        private ComboBox business_comboBox;
        private NumericUpDown distanceBus_numericUpDown;
        private Label label14;
        private Label label15;
        private GroupBox groupBox4;
        private CheckBox attachedGarage_checkbox;
        private NumericUpDown minSq_numeric;
        private NumericUpDown bath_numericUpDown;
        private NumericUpDown bednumericUpDown;
        private CheckBox garage_checkBox;
        private Label label16;
        private Label label17;
        private Label label18;
        private CheckBox apartment_checkBox;
        private CheckBox house_checkBox;
        private Button enterButton;
        private CheckBox showAllRes_Check;
        private Label label19;
        private Label label20;
        private Label showZoomLabel;
        private Button resetbutton;
    }
}

