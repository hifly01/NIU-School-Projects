<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.query_Button1 = New System.Windows.Forms.Button()
        Me.maxPrice_TrackBar = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.minPrice_TrackBar = New System.Windows.Forms.TrackBar()
        Me.school_CheckBox = New System.Windows.Forms.CheckBox()
        Me.business_CheckBox = New System.Windows.Forms.CheckBox()
        Me.residental_CheckBox = New System.Windows.Forms.CheckBox()
        Me.queryResults_textBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.schoolDis_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fsRes_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.sqft_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.bath_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.bed_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.garage_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.apartment_CheckBox = New System.Windows.Forms.CheckBox()
        Me.house_CheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.maxPrice_TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minPrice_TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.schoolDis_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fsRes_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.sqft_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bath_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bed_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.query_Button1)
        Me.GroupBox1.Controls.Add(Me.maxPrice_TrackBar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.minPrice_TrackBar)
        Me.GroupBox1.Controls.Add(Me.school_CheckBox)
        Me.GroupBox1.Controls.Add(Me.business_CheckBox)
        Me.GroupBox1.Controls.Add(Me.residental_CheckBox)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 172)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "For Sale Properties In Range"
        '
        'query_Button1
        '
        Me.query_Button1.Location = New System.Drawing.Point(493, 49)
        Me.query_Button1.Name = "query_Button1"
        Me.query_Button1.Size = New System.Drawing.Size(104, 38)
        Me.query_Button1.TabIndex = 7
        Me.query_Button1.Text = "Query"
        Me.query_Button1.UseVisualStyleBackColor = True
        '
        'maxPrice_TrackBar
        '
        Me.maxPrice_TrackBar.LargeChange = 500
        Me.maxPrice_TrackBar.Location = New System.Drawing.Point(109, 121)
        Me.maxPrice_TrackBar.Maximum = 350000
        Me.maxPrice_TrackBar.Name = "maxPrice_TrackBar"
        Me.maxPrice_TrackBar.Size = New System.Drawing.Size(200, 45)
        Me.maxPrice_TrackBar.SmallChange = 100
        Me.maxPrice_TrackBar.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Max Price"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Min Price"
        '
        'minPrice_TrackBar
        '
        Me.minPrice_TrackBar.LargeChange = 500
        Me.minPrice_TrackBar.Location = New System.Drawing.Point(109, 50)
        Me.minPrice_TrackBar.Maximum = 350000
        Me.minPrice_TrackBar.Name = "minPrice_TrackBar"
        Me.minPrice_TrackBar.Size = New System.Drawing.Size(200, 45)
        Me.minPrice_TrackBar.SmallChange = 100
        Me.minPrice_TrackBar.TabIndex = 3
        '
        'school_CheckBox
        '
        Me.school_CheckBox.AutoSize = True
        Me.school_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.school_CheckBox.Location = New System.Drawing.Point(7, 75)
        Me.school_CheckBox.Name = "school_CheckBox"
        Me.school_CheckBox.Size = New System.Drawing.Size(69, 20)
        Me.school_CheckBox.TabIndex = 2
        Me.school_CheckBox.Text = "School"
        Me.school_CheckBox.UseVisualStyleBackColor = True
        '
        'business_CheckBox
        '
        Me.business_CheckBox.AutoSize = True
        Me.business_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.business_CheckBox.Location = New System.Drawing.Point(7, 49)
        Me.business_CheckBox.Name = "business_CheckBox"
        Me.business_CheckBox.Size = New System.Drawing.Size(82, 20)
        Me.business_CheckBox.TabIndex = 1
        Me.business_CheckBox.Text = "Business"
        Me.business_CheckBox.UseVisualStyleBackColor = True
        '
        'residental_CheckBox
        '
        Me.residental_CheckBox.AutoSize = True
        Me.residental_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.residental_CheckBox.Location = New System.Drawing.Point(7, 23)
        Me.residental_CheckBox.Name = "residental_CheckBox"
        Me.residental_CheckBox.Size = New System.Drawing.Size(92, 20)
        Me.residental_CheckBox.TabIndex = 0
        Me.residental_CheckBox.Text = "Residental"
        Me.residental_CheckBox.UseVisualStyleBackColor = True
        '
        'queryResults_textBox
        '
        Me.queryResults_textBox.Location = New System.Drawing.Point(744, 35)
        Me.queryResults_textBox.Name = "queryResults_textBox"
        Me.queryResults_textBox.ReadOnly = True
        Me.queryResults_textBox.Size = New System.Drawing.Size(761, 597)
        Me.queryResults_textBox.TabIndex = 1
        Me.queryResults_textBox.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(740, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Query Results"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.schoolDis_NumericUpDown)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(707, 101)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "For Sale Residences In Range Of A School"
        '
        'schoolDis_NumericUpDown
        '
        Me.schoolDis_NumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schoolDis_NumericUpDown.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.schoolDis_NumericUpDown.Location = New System.Drawing.Point(245, 48)
        Me.schoolDis_NumericUpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.schoolDis_NumericUpDown.Name = "schoolDis_NumericUpDown"
        Me.schoolDis_NumericUpDown.Size = New System.Drawing.Size(120, 26)
        Me.schoolDis_NumericUpDown.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(241, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Distance"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(493, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 38)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Query"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 48)
        Me.ComboBox1.MaxDropDownItems = 20
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(215, 28)
        Me.ComboBox1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "School"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.fsRes_NumericUpDown)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 297)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(707, 105)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hiring Business(es) Within Range Of For Sale Residence"
        '
        'fsRes_NumericUpDown
        '
        Me.fsRes_NumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fsRes_NumericUpDown.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.fsRes_NumericUpDown.Location = New System.Drawing.Point(245, 61)
        Me.fsRes_NumericUpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.fsRes_NumericUpDown.Name = "fsRes_NumericUpDown"
        Me.fsRes_NumericUpDown.Size = New System.Drawing.Size(120, 26)
        Me.fsRes_NumericUpDown.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(241, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Distance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "For-Sale Residence"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(9, 61)
        Me.ComboBox2.MaxDropDownItems = 20
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(215, 28)
        Me.ComboBox2.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(493, 51)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 38)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Query"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.sqft_NumericUpDown)
        Me.GroupBox4.Controls.Add(Me.bath_NumericUpDown)
        Me.GroupBox4.Controls.Add(Me.bed_NumericUpDown)
        Me.GroupBox4.Controls.Add(Me.garage_CheckBox)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.apartment_CheckBox)
        Me.GroupBox4.Controls.Add(Me.house_CheckBox)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 408)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(707, 142)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Specific Residence Parameters"
        '
        'sqft_NumericUpDown
        '
        Me.sqft_NumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sqft_NumericUpDown.Increment = New Decimal(New Integer() {250, 0, 0, 0})
        Me.sqft_NumericUpDown.Location = New System.Drawing.Point(261, 62)
        Me.sqft_NumericUpDown.Maximum = New Decimal(New Integer() {6000, 0, 0, 0})
        Me.sqft_NumericUpDown.Minimum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.sqft_NumericUpDown.Name = "sqft_NumericUpDown"
        Me.sqft_NumericUpDown.Size = New System.Drawing.Size(92, 26)
        Me.sqft_NumericUpDown.TabIndex = 16
        Me.sqft_NumericUpDown.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'bath_NumericUpDown
        '
        Me.bath_NumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bath_NumericUpDown.Location = New System.Drawing.Point(192, 62)
        Me.bath_NumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.bath_NumericUpDown.Name = "bath_NumericUpDown"
        Me.bath_NumericUpDown.Size = New System.Drawing.Size(50, 26)
        Me.bath_NumericUpDown.TabIndex = 15
        '
        'bed_NumericUpDown
        '
        Me.bed_NumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bed_NumericUpDown.Location = New System.Drawing.Point(109, 61)
        Me.bed_NumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.bed_NumericUpDown.Name = "bed_NumericUpDown"
        Me.bed_NumericUpDown.Size = New System.Drawing.Size(50, 26)
        Me.bed_NumericUpDown.TabIndex = 14
        '
        'garage_CheckBox
        '
        Me.garage_CheckBox.AutoSize = True
        Me.garage_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.garage_CheckBox.Location = New System.Drawing.Point(349, 36)
        Me.garage_CheckBox.Name = "garage_CheckBox"
        Me.garage_CheckBox.Size = New System.Drawing.Size(73, 20)
        Me.garage_CheckBox.TabIndex = 8
        Me.garage_CheckBox.Text = "Garage"
        Me.garage_CheckBox.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(258, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Min Sq.Ft"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(189, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Bath"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(106, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Bed"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(493, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 38)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Query"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'apartment_CheckBox
        '
        Me.apartment_CheckBox.AutoSize = True
        Me.apartment_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.apartment_CheckBox.Location = New System.Drawing.Point(7, 61)
        Me.apartment_CheckBox.Name = "apartment_CheckBox"
        Me.apartment_CheckBox.Size = New System.Drawing.Size(88, 20)
        Me.apartment_CheckBox.TabIndex = 4
        Me.apartment_CheckBox.Text = "Apartment"
        Me.apartment_CheckBox.UseVisualStyleBackColor = True
        '
        'house_CheckBox
        '
        Me.house_CheckBox.AutoSize = True
        Me.house_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.house_CheckBox.Location = New System.Drawing.Point(7, 36)
        Me.house_CheckBox.Name = "house_CheckBox"
        Me.house_CheckBox.Size = New System.Drawing.Size(67, 20)
        Me.house_CheckBox.TabIndex = 3
        Me.house_CheckBox.Text = "House"
        Me.house_CheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 556)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(707, 76)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "List Of Properties Owned By Out-Of-Towners"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(493, 25)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 38)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Query"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1517, 644)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.queryResults_textBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Real Estate Query For DeKalb And Sycamore"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.maxPrice_TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minPrice_TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.schoolDis_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.fsRes_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.sqft_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bath_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bed_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents query_Button1 As Button
    Friend WithEvents maxPrice_TrackBar As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents minPrice_TrackBar As TrackBar
    Friend WithEvents school_CheckBox As CheckBox
    Friend WithEvents business_CheckBox As CheckBox
    Friend WithEvents residental_CheckBox As CheckBox
    Friend WithEvents queryResults_textBox As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents apartment_CheckBox As CheckBox
    Friend WithEvents house_CheckBox As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button4 As Button
    Friend WithEvents schoolDis_NumericUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents fsRes_NumericUpDown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents sqft_NumericUpDown As NumericUpDown
    Friend WithEvents bath_NumericUpDown As NumericUpDown
    Friend WithEvents bed_NumericUpDown As NumericUpDown
    Friend WithEvents garage_CheckBox As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
End Class
