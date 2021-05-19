/********************************************************************
CSCI 473 - Assignment 2 - Spring 2020

Programmers: Theresa Li (Z1814730), Charles Alms (Z1797837) 
Section:    1
TA:         Jennifer Ho & Sridivya Pagadala
Date Due:   2/13/20

Purpose:    This program is teaching us to make a real estate GUI using 
            C#
*********************************************************************/

namespace TheresaLiCharlesAlms_Assign2
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
            this.selectCommunity = new System.Windows.Forms.GroupBox();
            this.sycamore_radioButton = new System.Windows.Forms.RadioButton();
            this.dekalb_radioButton = new System.Windows.Forms.RadioButton();
            this.addResident = new System.Windows.Forms.GroupBox();
            this.Residence_dropdown = new System.Windows.Forms.ComboBox();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.addResident_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.occupation_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addProperty = new System.Windows.Forms.GroupBox();
            this.garageAttached_checkBox = new System.Windows.Forms.CheckBox();
            this.floors_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.baths_numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.beds_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sqft_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.garage_checkBox = new System.Windows.Forms.CheckBox();
            this.apt_textBox = new System.Windows.Forms.TextBox();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addProperty_button = new System.Windows.Forms.Button();
            this.forSale_button = new System.Windows.Forms.Button();
            this.buyProperty_button = new System.Windows.Forms.Button();
            this.addRes_button = new System.Windows.Forms.Button();
            this.removeRes_button = new System.Windows.Forms.Button();
            this.person_listBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.residence_listBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.output_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.selectCommunity.SuspendLayout();
            this.addResident.SuspendLayout();
            this.addProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floors_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baths_numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beds_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqft_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // selectCommunity
            // 
            this.selectCommunity.BackColor = System.Drawing.SystemColors.ControlDark;
            this.selectCommunity.Controls.Add(this.sycamore_radioButton);
            this.selectCommunity.Controls.Add(this.dekalb_radioButton);
            this.selectCommunity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCommunity.Location = new System.Drawing.Point(12, 12);
            this.selectCommunity.Name = "selectCommunity";
            this.selectCommunity.Size = new System.Drawing.Size(244, 97);
            this.selectCommunity.TabIndex = 5;
            this.selectCommunity.TabStop = false;
            this.selectCommunity.Text = "Communities";
            // 
            // sycamore_radioButton
            // 
            this.sycamore_radioButton.AutoSize = true;
            this.sycamore_radioButton.Font = new System.Drawing.Font("Arial", 12F);
            this.sycamore_radioButton.Location = new System.Drawing.Point(16, 56);
            this.sycamore_radioButton.Name = "sycamore_radioButton";
            this.sycamore_radioButton.Size = new System.Drawing.Size(97, 22);
            this.sycamore_radioButton.TabIndex = 1;
            this.sycamore_radioButton.Text = "Sycamore";
            this.sycamore_radioButton.UseVisualStyleBackColor = true;
            this.sycamore_radioButton.CheckedChanged += new System.EventHandler(this.sycamore_radioButton_CheckedChanged);
            // 
            // dekalb_radioButton
            // 
            this.dekalb_radioButton.AutoSize = true;
            this.dekalb_radioButton.Font = new System.Drawing.Font("Arial", 12F);
            this.dekalb_radioButton.Location = new System.Drawing.Point(16, 26);
            this.dekalb_radioButton.Name = "dekalb_radioButton";
            this.dekalb_radioButton.Size = new System.Drawing.Size(79, 22);
            this.dekalb_radioButton.TabIndex = 0;
            this.dekalb_radioButton.Text = "DeKalb";
            this.dekalb_radioButton.UseVisualStyleBackColor = true;
            this.dekalb_radioButton.CheckedChanged += new System.EventHandler(this.dekalb_radioButton_CheckedChanged);
            // 
            // addResident
            // 
            this.addResident.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.addResident.Controls.Add(this.Residence_dropdown);
            this.addResident.Controls.Add(this.birthdayPicker);
            this.addResident.Controls.Add(this.addResident_button);
            this.addResident.Controls.Add(this.label4);
            this.addResident.Controls.Add(this.occupation_textBox);
            this.addResident.Controls.Add(this.label3);
            this.addResident.Controls.Add(this.label2);
            this.addResident.Controls.Add(this.name_textBox);
            this.addResident.Controls.Add(this.label1);
            this.addResident.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addResident.Location = new System.Drawing.Point(12, 181);
            this.addResident.Name = "addResident";
            this.addResident.Size = new System.Drawing.Size(244, 278);
            this.addResident.TabIndex = 6;
            this.addResident.TabStop = false;
            this.addResident.Text = "Add New Resident";
            // 
            // Residence_dropdown
            // 
            this.Residence_dropdown.AllowDrop = true;
            this.Residence_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Residence_dropdown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Residence_dropdown.FormattingEnabled = true;
            this.Residence_dropdown.Location = new System.Drawing.Point(6, 202);
            this.Residence_dropdown.Name = "Residence_dropdown";
            this.Residence_dropdown.Size = new System.Drawing.Size(229, 24);
            this.Residence_dropdown.TabIndex = 18;
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.CalendarFont = new System.Drawing.Font("Arial", 12F);
            this.birthdayPicker.Font = new System.Drawing.Font("Arial", 8F);
            this.birthdayPicker.Location = new System.Drawing.Point(6, 150);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(229, 20);
            this.birthdayPicker.TabIndex = 17;
            // 
            // addResident_button
            // 
            this.addResident_button.Location = new System.Drawing.Point(129, 242);
            this.addResident_button.Name = "addResident_button";
            this.addResident_button.Size = new System.Drawing.Size(109, 23);
            this.addResident_button.TabIndex = 12;
            this.addResident_button.Text = "Add";
            this.addResident_button.UseVisualStyleBackColor = true;
            this.addResident_button.Click += new System.EventHandler(this.addNewResident_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(7, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Residence";
            // 
            // occupation_textBox
            // 
            this.occupation_textBox.Font = new System.Drawing.Font("Arial", 12F);
            this.occupation_textBox.Location = new System.Drawing.Point(7, 100);
            this.occupation_textBox.Name = "occupation_textBox";
            this.occupation_textBox.Size = new System.Drawing.Size(231, 26);
            this.occupation_textBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Birthday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Occupation";
            // 
            // name_textBox
            // 
            this.name_textBox.Font = new System.Drawing.Font("Arial", 12F);
            this.name_textBox.Location = new System.Drawing.Point(7, 49);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(231, 26);
            this.name_textBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // addProperty
            // 
            this.addProperty.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addProperty.Controls.Add(this.garageAttached_checkBox);
            this.addProperty.Controls.Add(this.floors_numericUpDown);
            this.addProperty.Controls.Add(this.baths_numericUpDown1);
            this.addProperty.Controls.Add(this.beds_numericUpDown);
            this.addProperty.Controls.Add(this.sqft_numericUpDown);
            this.addProperty.Controls.Add(this.garage_checkBox);
            this.addProperty.Controls.Add(this.apt_textBox);
            this.addProperty.Controls.Add(this.address_textBox);
            this.addProperty.Controls.Add(this.label10);
            this.addProperty.Controls.Add(this.label9);
            this.addProperty.Controls.Add(this.label8);
            this.addProperty.Controls.Add(this.label7);
            this.addProperty.Controls.Add(this.label6);
            this.addProperty.Controls.Add(this.label5);
            this.addProperty.Controls.Add(this.addProperty_button);
            this.addProperty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProperty.Location = new System.Drawing.Point(262, 181);
            this.addProperty.Name = "addProperty";
            this.addProperty.Size = new System.Drawing.Size(264, 278);
            this.addProperty.TabIndex = 7;
            this.addProperty.TabStop = false;
            this.addProperty.Text = "Add Property";
            // 
            // garageAttached_checkBox
            // 
            this.garageAttached_checkBox.AutoSize = true;
            this.garageAttached_checkBox.Font = new System.Drawing.Font("Arial", 12F);
            this.garageAttached_checkBox.Location = new System.Drawing.Point(147, 202);
            this.garageAttached_checkBox.Name = "garageAttached_checkBox";
            this.garageAttached_checkBox.Size = new System.Drawing.Size(98, 22);
            this.garageAttached_checkBox.TabIndex = 25;
            this.garageAttached_checkBox.Text = "Attached?";
            this.garageAttached_checkBox.UseVisualStyleBackColor = true;
            this.garageAttached_checkBox.Visible = false;
            // 
            // floors_numericUpDown
            // 
            this.floors_numericUpDown.Font = new System.Drawing.Font("Arial", 12F);
            this.floors_numericUpDown.Location = new System.Drawing.Point(195, 152);
            this.floors_numericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.floors_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.floors_numericUpDown.Name = "floors_numericUpDown";
            this.floors_numericUpDown.Size = new System.Drawing.Size(55, 26);
            this.floors_numericUpDown.TabIndex = 23;
            this.floors_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // baths_numericUpDown1
            // 
            this.baths_numericUpDown1.Font = new System.Drawing.Font("Arial", 12F);
            this.baths_numericUpDown1.Location = new System.Drawing.Point(106, 152);
            this.baths_numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.baths_numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.baths_numericUpDown1.Name = "baths_numericUpDown1";
            this.baths_numericUpDown1.Size = new System.Drawing.Size(55, 26);
            this.baths_numericUpDown1.TabIndex = 22;
            this.baths_numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // beds_numericUpDown
            // 
            this.beds_numericUpDown.Font = new System.Drawing.Font("Arial", 12F);
            this.beds_numericUpDown.Location = new System.Drawing.Point(9, 150);
            this.beds_numericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.beds_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.beds_numericUpDown.Name = "beds_numericUpDown";
            this.beds_numericUpDown.Size = new System.Drawing.Size(55, 26);
            this.beds_numericUpDown.TabIndex = 21;
            this.beds_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sqft_numericUpDown
            // 
            this.sqft_numericUpDown.Font = new System.Drawing.Font("Arial", 12F);
            this.sqft_numericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sqft_numericUpDown.Location = new System.Drawing.Point(9, 100);
            this.sqft_numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sqft_numericUpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sqft_numericUpDown.Name = "sqft_numericUpDown";
            this.sqft_numericUpDown.Size = new System.Drawing.Size(89, 26);
            this.sqft_numericUpDown.TabIndex = 20;
            this.sqft_numericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // garage_checkBox
            // 
            this.garage_checkBox.AutoSize = true;
            this.garage_checkBox.Font = new System.Drawing.Font("Arial", 12F);
            this.garage_checkBox.Location = new System.Drawing.Point(9, 202);
            this.garage_checkBox.Name = "garage_checkBox";
            this.garage_checkBox.Size = new System.Drawing.Size(89, 22);
            this.garage_checkBox.TabIndex = 19;
            this.garage_checkBox.Text = "Garage?";
            this.garage_checkBox.UseVisualStyleBackColor = true;
            this.garage_checkBox.CheckedChanged += new System.EventHandler(this.garage_checkBox_CheckedChanged);
            // 
            // apt_textBox
            // 
            this.apt_textBox.Font = new System.Drawing.Font("Arial", 12F);
            this.apt_textBox.Location = new System.Drawing.Point(195, 49);
            this.apt_textBox.Name = "apt_textBox";
            this.apt_textBox.Size = new System.Drawing.Size(49, 26);
            this.apt_textBox.TabIndex = 18;
            this.apt_textBox.TextChanged += new System.EventHandler(this.apt_textBox_TextChanged);
            // 
            // address_textBox
            // 
            this.address_textBox.Font = new System.Drawing.Font("Arial", 12F);
            this.address_textBox.Location = new System.Drawing.Point(9, 49);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(180, 26);
            this.address_textBox.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.Location = new System.Drawing.Point(195, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "Apt. #";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Arial", 12F);
            this.label9.Location = new System.Drawing.Point(192, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Floors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.Location = new System.Drawing.Point(103, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Baths";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(6, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Bedrooms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(6, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Square Footage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Street Address";
            // 
            // addProperty_button
            // 
            this.addProperty_button.Location = new System.Drawing.Point(147, 242);
            this.addProperty_button.Name = "addProperty_button";
            this.addProperty_button.Size = new System.Drawing.Size(109, 23);
            this.addProperty_button.TabIndex = 13;
            this.addProperty_button.Text = "Add";
            this.addProperty_button.UseVisualStyleBackColor = true;
            this.addProperty_button.Click += new System.EventHandler(this.addNewProperty_button_Click);
            // 
            // forSale_button
            // 
            this.forSale_button.Location = new System.Drawing.Point(409, 26);
            this.forSale_button.Name = "forSale_button";
            this.forSale_button.Size = new System.Drawing.Size(117, 32);
            this.forSale_button.TabIndex = 8;
            this.forSale_button.Text = "Toggle For-Sale";
            this.forSale_button.UseVisualStyleBackColor = true;
            this.forSale_button.Click += new System.EventHandler(this.ToggleForSale_Click);
            // 
            // buyProperty_button
            // 
            this.buyProperty_button.Location = new System.Drawing.Point(409, 64);
            this.buyProperty_button.Name = "buyProperty_button";
            this.buyProperty_button.Size = new System.Drawing.Size(117, 32);
            this.buyProperty_button.TabIndex = 9;
            this.buyProperty_button.Text = "Buy Property";
            this.buyProperty_button.UseVisualStyleBackColor = true;
            this.buyProperty_button.Click += new System.EventHandler(this.buyProperty_button_Click);
            // 
            // addRes_button
            // 
            this.addRes_button.Location = new System.Drawing.Point(409, 105);
            this.addRes_button.Name = "addRes_button";
            this.addRes_button.Size = new System.Drawing.Size(117, 32);
            this.addRes_button.TabIndex = 10;
            this.addRes_button.Text = "Add Resident ";
            this.addRes_button.UseVisualStyleBackColor = true;
            this.addRes_button.Click += new System.EventHandler(this.addRes_button_Click);
            // 
            // removeRes_button
            // 
            this.removeRes_button.Location = new System.Drawing.Point(409, 143);
            this.removeRes_button.Name = "removeRes_button";
            this.removeRes_button.Size = new System.Drawing.Size(117, 32);
            this.removeRes_button.TabIndex = 11;
            this.removeRes_button.Text = "Remove Resident";
            this.removeRes_button.UseVisualStyleBackColor = true;
            this.removeRes_button.Click += new System.EventHandler(this.removeRes_button_Click);
            // 
            // person_listBox
            // 
            this.person_listBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.person_listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.person_listBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.person_listBox.FormattingEnabled = true;
            this.person_listBox.HorizontalScrollbar = true;
            this.person_listBox.ItemHeight = 17;
            this.person_listBox.Location = new System.Drawing.Point(532, 26);
            this.person_listBox.Name = "person_listBox";
            this.person_listBox.Size = new System.Drawing.Size(267, 446);
            this.person_listBox.TabIndex = 12;
            this.person_listBox.SelectedIndexChanged += new System.EventHandler(this.person_listBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(528, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Person";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(800, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 19);
            this.label12.TabIndex = 14;
            this.label12.Text = "Residence (*== For Sale)";
            // 
            // residence_listBox
            // 
            this.residence_listBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.residence_listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.residence_listBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.residence_listBox.FormattingEnabled = true;
            this.residence_listBox.HorizontalScrollbar = true;
            this.residence_listBox.ItemHeight = 17;
            this.residence_listBox.Location = new System.Drawing.Point(804, 26);
            this.residence_listBox.Name = "residence_listBox";
            this.residence_listBox.Size = new System.Drawing.Size(267, 446);
            this.residence_listBox.TabIndex = 15;
            this.residence_listBox.SelectedIndexChanged += new System.EventHandler(this.residence_listBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(8, 489);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 19);
            this.label13.TabIndex = 17;
            this.label13.Text = "Output";
            // 
            // output_RichTextBox
            // 
            this.output_RichTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_RichTextBox.Location = new System.Drawing.Point(7, 511);
            this.output_RichTextBox.Name = "output_RichTextBox";
            this.output_RichTextBox.ReadOnly = true;
            this.output_RichTextBox.Size = new System.Drawing.Size(1064, 96);
            this.output_RichTextBox.TabIndex = 18;
            this.output_RichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1083, 633);
            this.Controls.Add(this.output_RichTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.residence_listBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.person_listBox);
            this.Controls.Add(this.removeRes_button);
            this.Controls.Add(this.addRes_button);
            this.Controls.Add(this.buyProperty_button);
            this.Controls.Add(this.forSale_button);
            this.Controls.Add(this.addProperty);
            this.Controls.Add(this.addResident);
            this.Controls.Add(this.selectCommunity);
            this.Name = "Form1";
            this.Text = "Form1";
            this.selectCommunity.ResumeLayout(false);
            this.selectCommunity.PerformLayout();
            this.addResident.ResumeLayout(false);
            this.addResident.PerformLayout();
            this.addProperty.ResumeLayout(false);
            this.addProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floors_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baths_numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beds_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqft_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox selectCommunity;
        private System.Windows.Forms.GroupBox addResident;
        private System.Windows.Forms.GroupBox addProperty;
        private System.Windows.Forms.RadioButton sycamore_radioButton;
        private System.Windows.Forms.RadioButton dekalb_radioButton;
        private System.Windows.Forms.Button forSale_button;
        private System.Windows.Forms.Button buyProperty_button;
        private System.Windows.Forms.Button addRes_button;
        private System.Windows.Forms.Button removeRes_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.TextBox occupation_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addResident_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addProperty_button;
        private System.Windows.Forms.TextBox apt_textBox;
        private System.Windows.Forms.TextBox address_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox garage_checkBox;
        private System.Windows.Forms.NumericUpDown sqft_numericUpDown;
        private System.Windows.Forms.NumericUpDown baths_numericUpDown1;
        private System.Windows.Forms.NumericUpDown beds_numericUpDown;
        private System.Windows.Forms.NumericUpDown floors_numericUpDown;
        private System.Windows.Forms.ListBox person_listBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox residence_listBox;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox garageAttached_checkBox;
        private System.Windows.Forms.RichTextBox output_RichTextBox;
        private System.Windows.Forms.ComboBox Residence_dropdown;
    }
}

