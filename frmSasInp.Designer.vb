<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSasInp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optType1 = New System.Windows.Forms.RadioButton()
        Me.optType2 = New System.Windows.Forms.RadioButton()
        Me.optType3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optCurve1 = New System.Windows.Forms.RadioButton()
        Me.optCurve2 = New System.Windows.Forms.RadioButton()
        Me.optCurve3 = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuRunAlign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWithSOE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSasPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lstSASData = New System.Windows.Forms.ListBox()
        Me.lstSOESort = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optType1)
        Me.GroupBox1.Controls.Add(Me.optType2)
        Me.GroupBox1.Controls.Add(Me.optType3)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "C:\SOA\FSoa.NET\frmSoaTypeProcInp.vbC:\SOA\FSoa.NET\frmSoaTypeProcInp.vb"
        Me.GroupBox1.Text = "Record Type"
        '
        'optType1
        '
        Me.optType1.AutoSize = True
        Me.optType1.Location = New System.Drawing.Point(12, 30)
        Me.optType1.Name = "optType1"
        Me.optType1.Size = New System.Drawing.Size(114, 24)
        Me.optType1.TabIndex = 2
        Me.optType1.TabStop = True
        Me.optType1.Text = "Description"
        Me.optType1.UseVisualStyleBackColor = True
        '
        'optType2
        '
        Me.optType2.AutoSize = True
        Me.optType2.Location = New System.Drawing.Point(12, 60)
        Me.optType2.Name = "optType2"
        Me.optType2.Size = New System.Drawing.Size(64, 24)
        Me.optType2.TabIndex = 3
        Me.optType2.TabStop = True
        Me.optType2.Text = "Line"
        Me.optType2.UseVisualStyleBackColor = True
        '
        'optType3
        '
        Me.optType3.AutoSize = True
        Me.optType3.Location = New System.Drawing.Point(12, 90)
        Me.optType3.Name = "optType3"
        Me.optType3.Size = New System.Drawing.Size(75, 24)
        Me.optType3.TabIndex = 4
        Me.optType3.TabStop = True
        Me.optType3.Text = "Curve"
        Me.optType3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optCurve1)
        Me.GroupBox2.Controls.Add(Me.optCurve2)
        Me.GroupBox2.Controls.Add(Me.optCurve3)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 119)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Curve Types"
        '
        'optCurve1
        '
        Me.optCurve1.AutoSize = True
        Me.optCurve1.Location = New System.Drawing.Point(6, 29)
        Me.optCurve1.Name = "optCurve1"
        Me.optCurve1.Size = New System.Drawing.Size(97, 24)
        Me.optCurve1.TabIndex = 5
        Me.optCurve1.TabStop = True
        Me.optCurve1.Text = "PC,PI,PT"
        Me.optCurve1.UseVisualStyleBackColor = True
        '
        'optCurve2
        '
        Me.optCurve2.AutoSize = True
        Me.optCurve2.Location = New System.Drawing.Point(6, 59)
        Me.optCurve2.Name = "optCurve2"
        Me.optCurve2.Size = New System.Drawing.Size(115, 24)
        Me.optCurve2.TabIndex = 6
        Me.optCurve2.TabStop = True
        Me.optCurve2.Text = "PC,POC,PT"
        Me.optCurve2.UseVisualStyleBackColor = True
        '
        'optCurve3
        '
        Me.optCurve3.AutoSize = True
        Me.optCurve3.Location = New System.Drawing.Point(6, 89)
        Me.optCurve3.Name = "optCurve3"
        Me.optCurve3.Size = New System.Drawing.Size(170, 24)
        Me.optCurve3.TabIndex = 7
        Me.optCurve3.TabStop = True
        Me.optCurve3.Text = "PC,POST,POST,PT"
        Me.optCurve3.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRunAlign, Me.mnuWithSOE, Me.mnuSasPrint})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(858, 33)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuRunAlign
        '
        Me.mnuRunAlign.Name = "mnuRunAlign"
        Me.mnuRunAlign.Size = New System.Drawing.Size(142, 29)
        Me.mnuRunAlign.Text = "Run Alignment"
        '
        'mnuWithSOE
        '
        Me.mnuWithSOE.Name = "mnuWithSOE"
        Me.mnuWithSOE.Size = New System.Drawing.Size(295, 29)
        Me.mnuWithSOE.Text = "CenterLine Process Using SOE File "
        '
        'mnuSasPrint
        '
        Me.mnuSasPrint.Name = "mnuSasPrint"
        Me.mnuSasPrint.Size = New System.Drawing.Size(60, 29)
        Me.mnuSasPrint.Text = "Print"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Beginning Alignment"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Beginning GP3 Point Number"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(252, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(148, 26)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(252, 85)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(148, 26)
        Me.TextBox2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(254, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Alignment"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Units"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(340, 195)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(271, 26)
        Me.TextBox3.TabIndex = 12
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(340, 227)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 26)
        Me.TextBox4.TabIndex = 13
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(485, 227)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(126, 26)
        Me.TextBox5.TabIndex = 14
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Items.AddRange(New Object() {"US", "Metric"})
        Me.ListBox1.Location = New System.Drawing.Point(340, 265)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(109, 24)
        Me.ListBox1.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(246, 314)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 45)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "New Alignment"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(377, 314)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 45)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Replace"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(485, 314)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 45)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(596, 314)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 45)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(377, 383)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(102, 45)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(485, 383)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(102, 45)
        Me.Button6.TabIndex = 22
        Me.Button6.Text = "Quit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(419, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Station"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(711, 231)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(123, 38)
        Me.Button7.TabIndex = 24
        Me.Button7.Text = "Process"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'lstSASData
        '
        Me.lstSASData.FormattingEnabled = True
        Me.lstSASData.ItemHeight = 20
        Me.lstSASData.Location = New System.Drawing.Point(688, 156)
        Me.lstSASData.Name = "lstSASData"
        Me.lstSASData.Size = New System.Drawing.Size(145, 44)
        Me.lstSASData.TabIndex = 25
        '
        'lstSOESort
        '
        Me.lstSOESort.FormattingEnabled = True
        Me.lstSOESort.ItemHeight = 20
        Me.lstSOESort.Location = New System.Drawing.Point(689, 100)
        Me.lstSOESort.Name = "lstSOESort"
        Me.lstSOESort.Size = New System.Drawing.Size(143, 44)
        Me.lstSOESort.TabIndex = 26
        '
        'frmSasInp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 444)
        Me.Controls.Add(Me.lstSOESort)
        Me.Controls.Add(Me.lstSASData)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmSasInp"
        Me.Text = "SAS Data Entry Screen"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optType1 As System.Windows.Forms.RadioButton
    Friend WithEvents optType2 As System.Windows.Forms.RadioButton
    Friend WithEvents optType3 As System.Windows.Forms.RadioButton
    Friend WithEvents optCurve1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCurve2 As System.Windows.Forms.RadioButton
    Friend WithEvents optCurve3 As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuRunAlign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWithSOE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSasPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lstSASData As System.Windows.Forms.ListBox
    Friend WithEvents lstSOESort As System.Windows.Forms.ListBox
End Class
