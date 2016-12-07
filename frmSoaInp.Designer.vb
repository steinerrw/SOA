<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSoaInp
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents lstSoaSort As System.Windows.Forms.ListBox
	Public WithEvents cmdPrint As System.Windows.Forms.Button
	Public WithEvents txtWidth As System.Windows.Forms.TextBox
	Public WithEvents txtHight As System.Windows.Forms.TextBox
	Public WithEvents txtFont As System.Windows.Forms.TextBox
	Public WithEvents chkPnt As System.Windows.Forms.CheckBox
	Public WithEvents _optTypeProc_6 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_5 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_4 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optTypeProc_0 As System.Windows.Forms.RadioButton
	Public WithEvents frameTypeProcOpt As System.Windows.Forms.GroupBox
	Public WithEvents cmdQuit As System.Windows.Forms.Button
	Public WithEvents lblWidth As System.Windows.Forms.Label
	Public WithEvents lblHight As System.Windows.Forms.Label
	Public WithEvents lblFont As System.Windows.Forms.Label
	Public WithEvents optTypeProc As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RunAlignmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CenterLineProcessUsingSOEFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optTypeProc7 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc6 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc5 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc4 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc3 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc2 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc1 = New System.Windows.Forms.RadioButton()
        Me.cmdSOA_Print = New System.Windows.Forms.Button()
        Me.cmdSOA_Quit = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lblSOA_Font = New System.Windows.Forms.Label()
        Me.lblSOA_Height = New System.Windows.Forms.Label()
        Me.lblSOA_Width = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.PrintToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ckhPnt = New System.Windows.Forms.CheckBox()
        Me.lstSoa_Sort = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunAlignmentToolStripMenuItem
        '
        Me.RunAlignmentToolStripMenuItem.Name = "RunAlignmentToolStripMenuItem"
        Me.RunAlignmentToolStripMenuItem.Size = New System.Drawing.Size(142, 29)
        Me.RunAlignmentToolStripMenuItem.Text = "Run Alignment"
        '
        'CenterLineProcessUsingSOEFileToolStripMenuItem
        '
        Me.CenterLineProcessUsingSOEFileToolStripMenuItem.Name = "CenterLineProcessUsingSOEFileToolStripMenuItem"
        Me.CenterLineProcessUsingSOEFileToolStripMenuItem.Size = New System.Drawing.Size(290, 29)
        Me.CenterLineProcessUsingSOEFileToolStripMenuItem.Text = "CenterLine Process Using SOE File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(60, 29)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optTypeProc7)
        Me.GroupBox1.Controls.Add(Me.optTypeProc6)
        Me.GroupBox1.Controls.Add(Me.optTypeProc5)
        Me.GroupBox1.Controls.Add(Me.optTypeProc4)
        Me.GroupBox1.Controls.Add(Me.optTypeProc3)
        Me.GroupBox1.Controls.Add(Me.optTypeProc2)
        Me.GroupBox1.Controls.Add(Me.optTypeProc1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 245)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type Process Options"
        '
        'optTypeProc7
        '
        Me.optTypeProc7.AutoSize = True
        Me.optTypeProc7.Location = New System.Drawing.Point(8, 209)
        Me.optTypeProc7.Name = "optTypeProc7"
        Me.optTypeProc7.Size = New System.Drawing.Size(99, 24)
        Me.optTypeProc7.TabIndex = 6
        Me.optTypeProc7.TabStop = True
        Me.optTypeProc7.Text = "Drainage"
        Me.optTypeProc7.UseVisualStyleBackColor = True
        '
        'optTypeProc6
        '
        Me.optTypeProc6.AutoSize = True
        Me.optTypeProc6.Location = New System.Drawing.Point(6, 179)
        Me.optTypeProc6.Name = "optTypeProc6"
        Me.optTypeProc6.Size = New System.Drawing.Size(279, 24)
        Me.optTypeProc6.TabIndex = 5
        Me.optTypeProc6.TabStop = True
        Me.optTypeProc6.Text = "Single Alignment w/ Station Range"
        Me.optTypeProc6.UseVisualStyleBackColor = True
        '
        'optTypeProc5
        '
        Me.optTypeProc5.AutoSize = True
        Me.optTypeProc5.Location = New System.Drawing.Point(6, 149)
        Me.optTypeProc5.Name = "optTypeProc5"
        Me.optTypeProc5.Size = New System.Drawing.Size(264, 24)
        Me.optTypeProc5.TabIndex = 4
        Me.optTypeProc5.TabStop = True
        Me.optTypeProc5.Text = "Single Alignment w/ Point Range"
        Me.optTypeProc5.UseVisualStyleBackColor = True
        '
        'optTypeProc4
        '
        Me.optTypeProc4.AutoSize = True
        Me.optTypeProc4.Location = New System.Drawing.Point(6, 119)
        Me.optTypeProc4.Name = "optTypeProc4"
        Me.optTypeProc4.Size = New System.Drawing.Size(241, 24)
        Me.optTypeProc4.TabIndex = 3
        Me.optTypeProc4.TabStop = True
        Me.optTypeProc4.Text = "Single Alignment w/ All Points"
        Me.optTypeProc4.UseVisualStyleBackColor = True
        '
        'optTypeProc3
        '
        Me.optTypeProc3.AutoSize = True
        Me.optTypeProc3.Location = New System.Drawing.Point(8, 89)
        Me.optTypeProc3.Name = "optTypeProc3"
        Me.optTypeProc3.Size = New System.Drawing.Size(260, 24)
        Me.optTypeProc3.TabIndex = 2
        Me.optTypeProc3.TabStop = True
        Me.optTypeProc3.Text = "All Alignments w/ Station Range"
        Me.optTypeProc3.UseVisualStyleBackColor = True
        '
        'optTypeProc2
        '
        Me.optTypeProc2.AutoSize = True
        Me.optTypeProc2.Location = New System.Drawing.Point(8, 59)
        Me.optTypeProc2.Name = "optTypeProc2"
        Me.optTypeProc2.Size = New System.Drawing.Size(245, 24)
        Me.optTypeProc2.TabIndex = 1
        Me.optTypeProc2.TabStop = True
        Me.optTypeProc2.Text = "All Alignments w/ Point Range"
        Me.optTypeProc2.UseVisualStyleBackColor = True
        '
        'optTypeProc1
        '
        Me.optTypeProc1.AutoSize = True
        Me.optTypeProc1.Location = New System.Drawing.Point(8, 29)
        Me.optTypeProc1.Name = "optTypeProc1"
        Me.optTypeProc1.Size = New System.Drawing.Size(210, 24)
        Me.optTypeProc1.TabIndex = 0
        Me.optTypeProc1.TabStop = True
        Me.optTypeProc1.Text = "All Alignment w/All Points"
        Me.optTypeProc1.UseVisualStyleBackColor = True
        '
        'cmdSOA_Print
        '
        Me.cmdSOA_Print.Location = New System.Drawing.Point(468, 255)
        Me.cmdSOA_Print.Name = "cmdSOA_Print"
        Me.cmdSOA_Print.Size = New System.Drawing.Size(91, 43)
        Me.cmdSOA_Print.TabIndex = 7
        Me.cmdSOA_Print.Text = "Print"
        Me.cmdSOA_Print.UseVisualStyleBackColor = True
        '
        'cmdSOA_Quit
        '
        Me.cmdSOA_Quit.Location = New System.Drawing.Point(359, 255)
        Me.cmdSOA_Quit.Name = "cmdSOA_Quit"
        Me.cmdSOA_Quit.Size = New System.Drawing.Size(91, 43)
        Me.cmdSOA_Quit.TabIndex = 8
        Me.cmdSOA_Quit.Text = "QUIT"
        Me.cmdSOA_Quit.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(428, 132)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(171, 26)
        Me.TextBox3.TabIndex = 11
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(428, 164)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(171, 26)
        Me.TextBox4.TabIndex = 12
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(428, 196)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(171, 26)
        Me.TextBox5.TabIndex = 13
        '
        'lblSOA_Font
        '
        Me.lblSOA_Font.AutoSize = True
        Me.lblSOA_Font.Location = New System.Drawing.Point(380, 138)
        Me.lblSOA_Font.Name = "lblSOA_Font"
        Me.lblSOA_Font.Size = New System.Drawing.Size(42, 20)
        Me.lblSOA_Font.TabIndex = 18
        Me.lblSOA_Font.Text = "Font"
        '
        'lblSOA_Height
        '
        Me.lblSOA_Height.AutoSize = True
        Me.lblSOA_Height.Location = New System.Drawing.Point(366, 167)
        Me.lblSOA_Height.Name = "lblSOA_Height"
        Me.lblSOA_Height.Size = New System.Drawing.Size(56, 20)
        Me.lblSOA_Height.TabIndex = 19
        Me.lblSOA_Height.Text = "Height"
        '
        'lblSOA_Width
        '
        Me.lblSOA_Width.AutoSize = True
        Me.lblSOA_Width.Location = New System.Drawing.Point(372, 199)
        Me.lblSOA_Width.Name = "lblSOA_Width"
        Me.lblSOA_Width.Size = New System.Drawing.Size(50, 20)
        Me.lblSOA_Width.TabIndex = 20
        Me.lblSOA_Width.Text = "Width"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem1})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(723, 33)
        Me.MenuStrip2.TabIndex = 24
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'PrintToolStripMenuItem1
        '
        Me.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        Me.PrintToolStripMenuItem1.Size = New System.Drawing.Size(60, 29)
        Me.PrintToolStripMenuItem1.Text = "Print"
        '
        'ckhPnt
        '
        Me.ckhPnt.AutoSize = True
        Me.ckhPnt.Location = New System.Drawing.Point(16, 46)
        Me.ckhPnt.Name = "ckhPnt"
        Me.ckhPnt.Size = New System.Drawing.Size(290, 24)
        Me.ckhPnt.TabIndex = 25
        Me.ckhPnt.Text = "Do you want to process every point?"
        Me.ckhPnt.UseVisualStyleBackColor = True
        '
        'lstSoa_Sort
        '
        Me.lstSoa_Sort.FormattingEnabled = True
        Me.lstSoa_Sort.ItemHeight = 20
        Me.lstSoa_Sort.Location = New System.Drawing.Point(52, 382)
        Me.lstSoa_Sort.Name = "lstSoa_Sort"
        Me.lstSoa_Sort.Size = New System.Drawing.Size(613, 44)
        Me.lstSoa_Sort.TabIndex = 26
        Me.lstSoa_Sort.Visible = False
        '
        'frmSoaInp
        '
        Me.ClientSize = New System.Drawing.Size(723, 489)
        Me.Controls.Add(Me.lstSoa_Sort)
        Me.Controls.Add(Me.ckhPnt)
        Me.Controls.Add(Me.lblSOA_Width)
        Me.Controls.Add(Me.lblSOA_Height)
        Me.Controls.Add(Me.lblSOA_Font)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.cmdSOA_Quit)
        Me.Controls.Add(Me.cmdSOA_Print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "frmSoaInp"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RunAlignmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CenterLineProcessUsingSOEFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optTypeProc3 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc2 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdSOA_Print As System.Windows.Forms.Button
    Friend WithEvents cmdSOA_Quit As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents lblSOA_Font As System.Windows.Forms.Label
    Friend WithEvents lblSOA_Height As System.Windows.Forms.Label
    Friend WithEvents lblSOA_Width As System.Windows.Forms.Label
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents PrintToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ckhPnt As System.Windows.Forms.CheckBox
    Friend WithEvents optTypeProc7 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc6 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc5 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc4 As System.Windows.Forms.RadioButton
    Friend WithEvents lstSoa_Sort As System.Windows.Forms.ListBox
#End Region 
End Class