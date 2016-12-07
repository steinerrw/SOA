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
        Me.frameType = New System.Windows.Forms.GroupBox()
        Me.optType3 = New System.Windows.Forms.RadioButton()
        Me.optType2 = New System.Windows.Forms.RadioButton()
        Me.optType1 = New System.Windows.Forms.RadioButton()
        Me.frameCurve = New System.Windows.Forms.GroupBox()
        Me.optCurve1 = New System.Windows.Forms.RadioButton()
        Me.optCurve2 = New System.Windows.Forms.RadioButton()
        Me.optCurve3 = New System.Windows.Forms.RadioButton()
        Me.cmdNewAlign = New System.Windows.Forms.Button()
        Me.cmdReplace = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSOA_Quit = New System.Windows.Forms.Button()
        Me.txtBegAlign = New System.Windows.Forms.TextBox()
        Me.txtGP3Cnt = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtAlignment = New System.Windows.Forms.TextBox()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.lblBegAlign = New System.Windows.Forms.Label()
        Me.lblGP3Cnt = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblAlign = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblUnits = New System.Windows.Forms.Label()
        Me.comboUnits = New System.Windows.Forms.ComboBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.RunAlignmentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWithSOE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSOEPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstSOAData = New System.Windows.Forms.ListBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtPnt1 = New System.Windows.Forms.TextBox()
        Me.txtPnt2 = New System.Windows.Forms.TextBox()
        Me.txtPnt3 = New System.Windows.Forms.TextBox()
        Me.txtPnt4 = New System.Windows.Forms.TextBox()
        Me.lblPnt1 = New System.Windows.Forms.Label()
        Me.lblPnt2 = New System.Windows.Forms.Label()
        Me.lblPnt3 = New System.Windows.Forms.Label()
        Me.lblPnt4 = New System.Windows.Forms.Label()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.frameType.SuspendLayout()
        Me.frameCurve.SuspendLayout()
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
        'frameType
        '
        Me.frameType.Controls.Add(Me.optType3)
        Me.frameType.Controls.Add(Me.optType2)
        Me.frameType.Controls.Add(Me.optType1)
        Me.frameType.Location = New System.Drawing.Point(13, 115)
        Me.frameType.Name = "frameType"
        Me.frameType.Size = New System.Drawing.Size(199, 119)
        Me.frameType.TabIndex = 1
        Me.frameType.TabStop = False
        Me.frameType.Text = "Record Type"
        '
        'optType3
        '
        Me.optType3.AutoSize = True
        Me.optType3.Location = New System.Drawing.Point(8, 89)
        Me.optType3.Name = "optType3"
        Me.optType3.Size = New System.Drawing.Size(75, 24)
        Me.optType3.TabIndex = 2
        Me.optType3.TabStop = True
        Me.optType3.Text = "Curve"
        Me.optType3.UseVisualStyleBackColor = True
        '
        'optType2
        '
        Me.optType2.AutoSize = True
        Me.optType2.Location = New System.Drawing.Point(8, 59)
        Me.optType2.Name = "optType2"
        Me.optType2.Size = New System.Drawing.Size(64, 24)
        Me.optType2.TabIndex = 1
        Me.optType2.TabStop = True
        Me.optType2.Text = "Line"
        Me.optType2.UseVisualStyleBackColor = True
        '
        'optType1
        '
        Me.optType1.AutoSize = True
        Me.optType1.Location = New System.Drawing.Point(8, 29)
        Me.optType1.Name = "optType1"
        Me.optType1.Size = New System.Drawing.Size(114, 24)
        Me.optType1.TabIndex = 0
        Me.optType1.TabStop = True
        Me.optType1.Text = "Description"
        Me.optType1.UseVisualStyleBackColor = True
        '
        'frameCurve
        '
        Me.frameCurve.Controls.Add(Me.optCurve1)
        Me.frameCurve.Controls.Add(Me.optCurve2)
        Me.frameCurve.Controls.Add(Me.optCurve3)
        Me.frameCurve.Location = New System.Drawing.Point(15, 252)
        Me.frameCurve.Name = "frameCurve"
        Me.frameCurve.Size = New System.Drawing.Size(197, 122)
        Me.frameCurve.TabIndex = 2
        Me.frameCurve.TabStop = False
        Me.frameCurve.Text = "Curve Types"
        '
        'optCurve1
        '
        Me.optCurve1.AutoSize = True
        Me.optCurve1.Location = New System.Drawing.Point(6, 32)
        Me.optCurve1.Name = "optCurve1"
        Me.optCurve1.Size = New System.Drawing.Size(105, 24)
        Me.optCurve1.TabIndex = 3
        Me.optCurve1.TabStop = True
        Me.optCurve1.Text = "PC, PI, PT"
        Me.optCurve1.UseVisualStyleBackColor = True
        '
        'optCurve2
        '
        Me.optCurve2.AutoSize = True
        Me.optCurve2.Location = New System.Drawing.Point(6, 62)
        Me.optCurve2.Name = "optCurve2"
        Me.optCurve2.Size = New System.Drawing.Size(132, 24)
        Me.optCurve2.TabIndex = 4
        Me.optCurve2.TabStop = True
        Me.optCurve2.Text = "PC, POST, PT"
        Me.optCurve2.UseVisualStyleBackColor = True
        '
        'optCurve3
        '
        Me.optCurve3.AutoSize = True
        Me.optCurve3.Location = New System.Drawing.Point(6, 92)
        Me.optCurve3.Name = "optCurve3"
        Me.optCurve3.Size = New System.Drawing.Size(178, 24)
        Me.optCurve3.TabIndex = 5
        Me.optCurve3.TabStop = True
        Me.optCurve3.Text = "PC,POST, POST, PT"
        Me.optCurve3.UseVisualStyleBackColor = True
        '
        'cmdNewAlign
        '
        Me.cmdNewAlign.Location = New System.Drawing.Point(15, 396)
        Me.cmdNewAlign.Name = "cmdNewAlign"
        Me.cmdNewAlign.Size = New System.Drawing.Size(184, 43)
        Me.cmdNewAlign.TabIndex = 3
        Me.cmdNewAlign.Text = "NEW ALIGNMENT"
        Me.cmdNewAlign.UseVisualStyleBackColor = True
        '
        'cmdReplace
        '
        Me.cmdReplace.Location = New System.Drawing.Point(205, 396)
        Me.cmdReplace.Name = "cmdReplace"
        Me.cmdReplace.Size = New System.Drawing.Size(97, 43)
        Me.cmdReplace.TabIndex = 4
        Me.cmdReplace.Text = "REPLACE"
        Me.cmdReplace.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(308, 396)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(91, 43)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "SAVE"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(405, 396)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(91, 43)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "DELETE"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(502, 396)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(91, 43)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "CANCEL"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSOA_Quit
        '
        Me.cmdSOA_Quit.Location = New System.Drawing.Point(599, 396)
        Me.cmdSOA_Quit.Name = "cmdSOA_Quit"
        Me.cmdSOA_Quit.Size = New System.Drawing.Size(91, 43)
        Me.cmdSOA_Quit.TabIndex = 8
        Me.cmdSOA_Quit.Text = "QUIT"
        Me.cmdSOA_Quit.UseVisualStyleBackColor = True
        '
        'txtBegAlign
        '
        Me.txtBegAlign.Location = New System.Drawing.Point(246, 35)
        Me.txtBegAlign.Name = "txtBegAlign"
        Me.txtBegAlign.Size = New System.Drawing.Size(468, 26)
        Me.txtBegAlign.TabIndex = 9
        '
        'txtGP3Cnt
        '
        Me.txtGP3Cnt.Location = New System.Drawing.Point(246, 67)
        Me.txtGP3Cnt.Name = "txtGP3Cnt"
        Me.txtGP3Cnt.Size = New System.Drawing.Size(468, 26)
        Me.txtGP3Cnt.TabIndex = 10
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(352, 115)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(171, 26)
        Me.txtDescription.TabIndex = 11
        '
        'txtAlignment
        '
        Me.txtAlignment.Location = New System.Drawing.Point(352, 158)
        Me.txtAlignment.Name = "txtAlignment"
        Me.txtAlignment.Size = New System.Drawing.Size(171, 26)
        Me.txtAlignment.TabIndex = 12
        '
        'txtStation
        '
        Me.txtStation.Location = New System.Drawing.Point(352, 206)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(171, 26)
        Me.txtStation.TabIndex = 13
        '
        'lblBegAlign
        '
        Me.lblBegAlign.AutoSize = True
        Me.lblBegAlign.Location = New System.Drawing.Point(20, 38)
        Me.lblBegAlign.Name = "lblBegAlign"
        Me.lblBegAlign.Size = New System.Drawing.Size(155, 20)
        Me.lblBegAlign.TabIndex = 16
        Me.lblBegAlign.Text = "Beginning Alignment"
        '
        'lblGP3Cnt
        '
        Me.lblGP3Cnt.AutoSize = True
        Me.lblGP3Cnt.Location = New System.Drawing.Point(20, 73)
        Me.lblGP3Cnt.Name = "lblGP3Cnt"
        Me.lblGP3Cnt.Size = New System.Drawing.Size(220, 20)
        Me.lblGP3Cnt.TabIndex = 17
        Me.lblGP3Cnt.Text = "Beginning GP3 Point Number "
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(251, 121)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(89, 20)
        Me.lblDesc.TabIndex = 18
        Me.lblDesc.Text = "Description"
        '
        'lblAlign
        '
        Me.lblAlign.AutoSize = True
        Me.lblAlign.Location = New System.Drawing.Point(260, 164)
        Me.lblAlign.Name = "lblAlign"
        Me.lblAlign.Size = New System.Drawing.Size(80, 20)
        Me.lblAlign.TabIndex = 19
        Me.lblAlign.Text = "Alignment"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(280, 212)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(60, 20)
        Me.lblStation.TabIndex = 20
        Me.lblStation.Text = "Station"
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(283, 258)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(46, 20)
        Me.lblUnits.TabIndex = 21
        Me.lblUnits.Text = "Units"
        '
        'comboUnits
        '
        Me.comboUnits.FormattingEnabled = True
        Me.comboUnits.Items.AddRange(New Object() {"US", "Metric"})
        Me.comboUnits.Location = New System.Drawing.Point(354, 249)
        Me.comboUnits.Name = "comboUnits"
        Me.comboUnits.Size = New System.Drawing.Size(95, 28)
        Me.comboUnits.TabIndex = 23
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunAlignmentToolStripMenuItem1, Me.mnuWithSOE, Me.mnuSOEPrint})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(723, 33)
        Me.MenuStrip2.TabIndex = 24
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'RunAlignmentToolStripMenuItem1
        '
        Me.RunAlignmentToolStripMenuItem1.Name = "RunAlignmentToolStripMenuItem1"
        Me.RunAlignmentToolStripMenuItem1.Size = New System.Drawing.Size(142, 29)
        Me.RunAlignmentToolStripMenuItem1.Text = "Run Alignment"
        '
        'mnuWithSOE
        '
        Me.mnuWithSOE.Name = "mnuWithSOE"
        Me.mnuWithSOE.Size = New System.Drawing.Size(283, 29)
        Me.mnuWithSOE.Text = "Center Line Process with SOE File"
        '
        'mnuSOEPrint
        '
        Me.mnuSOEPrint.Name = "mnuSOEPrint"
        Me.mnuSOEPrint.Size = New System.Drawing.Size(60, 29)
        Me.mnuSOEPrint.Text = "Print"
        '
        'lstSOAData
        '
        Me.lstSOAData.FormattingEnabled = True
        Me.lstSOAData.ItemHeight = 20
        Me.lstSOAData.Location = New System.Drawing.Point(334, 366)
        Me.lstSOAData.Name = "lstSOAData"
        Me.lstSOAData.Size = New System.Drawing.Size(356, 24)
        Me.lstSOAData.TabIndex = 25
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(205, 394)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(97, 45)
        Me.cmdAdd.TabIndex = 26
        Me.cmdAdd.Text = "ADD"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtPnt1
        '
        Me.txtPnt1.Location = New System.Drawing.Point(352, 302)
        Me.txtPnt1.Name = "txtPnt1"
        Me.txtPnt1.Size = New System.Drawing.Size(98, 26)
        Me.txtPnt1.TabIndex = 27
        '
        'txtPnt2
        '
        Me.txtPnt2.Location = New System.Drawing.Point(351, 334)
        Me.txtPnt2.Name = "txtPnt2"
        Me.txtPnt2.Size = New System.Drawing.Size(98, 26)
        Me.txtPnt2.TabIndex = 28
        '
        'txtPnt3
        '
        Me.txtPnt3.Location = New System.Drawing.Point(592, 302)
        Me.txtPnt3.Name = "txtPnt3"
        Me.txtPnt3.Size = New System.Drawing.Size(98, 26)
        Me.txtPnt3.TabIndex = 29
        '
        'txtPnt4
        '
        Me.txtPnt4.Location = New System.Drawing.Point(592, 334)
        Me.txtPnt4.Name = "txtPnt4"
        Me.txtPnt4.Size = New System.Drawing.Size(98, 26)
        Me.txtPnt4.TabIndex = 30
        '
        'lblPnt1
        '
        Me.lblPnt1.AutoSize = True
        Me.lblPnt1.Location = New System.Drawing.Point(289, 308)
        Me.lblPnt1.Name = "lblPnt1"
        Me.lblPnt1.Size = New System.Drawing.Size(0, 20)
        Me.lblPnt1.TabIndex = 31
        '
        'lblPnt2
        '
        Me.lblPnt2.AutoSize = True
        Me.lblPnt2.Location = New System.Drawing.Point(288, 340)
        Me.lblPnt2.Name = "lblPnt2"
        Me.lblPnt2.Size = New System.Drawing.Size(0, 20)
        Me.lblPnt2.TabIndex = 32
        '
        'lblPnt3
        '
        Me.lblPnt3.AutoSize = True
        Me.lblPnt3.Location = New System.Drawing.Point(529, 308)
        Me.lblPnt3.Name = "lblPnt3"
        Me.lblPnt3.Size = New System.Drawing.Size(0, 20)
        Me.lblPnt3.TabIndex = 33
        '
        'lblPnt4
        '
        Me.lblPnt4.AutoSize = True
        Me.lblPnt4.Location = New System.Drawing.Point(529, 340)
        Me.lblPnt4.Name = "lblPnt4"
        Me.lblPnt4.Size = New System.Drawing.Size(0, 20)
        Me.lblPnt4.TabIndex = 34
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(593, 220)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(96, 38)
        Me.cmdProcess.TabIndex = 35
        Me.cmdProcess.Text = "PROCESS"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'frmSoaInp
        '
        Me.ClientSize = New System.Drawing.Size(723, 489)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.lblPnt4)
        Me.Controls.Add(Me.lblPnt3)
        Me.Controls.Add(Me.lblPnt2)
        Me.Controls.Add(Me.lblPnt1)
        Me.Controls.Add(Me.txtPnt4)
        Me.Controls.Add(Me.txtPnt3)
        Me.Controls.Add(Me.txtPnt2)
        Me.Controls.Add(Me.txtPnt1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lstSOAData)
        Me.Controls.Add(Me.comboUnits)
        Me.Controls.Add(Me.lblUnits)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblAlign)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.lblGP3Cnt)
        Me.Controls.Add(Me.lblBegAlign)
        Me.Controls.Add(Me.txtStation)
        Me.Controls.Add(Me.txtAlignment)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtGP3Cnt)
        Me.Controls.Add(Me.txtBegAlign)
        Me.Controls.Add(Me.cmdSOA_Quit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdReplace)
        Me.Controls.Add(Me.cmdNewAlign)
        Me.Controls.Add(Me.frameCurve)
        Me.Controls.Add(Me.frameType)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "frmSoaInp"
        Me.frameType.ResumeLayout(False)
        Me.frameType.PerformLayout()
        Me.frameCurve.ResumeLayout(False)
        Me.frameCurve.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RunAlignmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CenterLineProcessUsingSOEFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frameType As System.Windows.Forms.GroupBox
    Friend WithEvents optType3 As System.Windows.Forms.RadioButton
    Friend WithEvents optType2 As System.Windows.Forms.RadioButton
    Friend WithEvents optType1 As System.Windows.Forms.RadioButton
    Friend WithEvents frameCurve As System.Windows.Forms.GroupBox
    Friend WithEvents optCurve1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCurve2 As System.Windows.Forms.RadioButton
    Friend WithEvents optCurve3 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdNewAlign As System.Windows.Forms.Button
    Friend WithEvents cmdReplace As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSOA_Quit As System.Windows.Forms.Button
    Friend WithEvents txtBegAlign As System.Windows.Forms.TextBox
    Friend WithEvents txtGP3Cnt As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAlignment As System.Windows.Forms.TextBox
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblBegAlign As System.Windows.Forms.Label
    Friend WithEvents lblGP3Cnt As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblAlign As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents comboUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents RunAlignmentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWithSOE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSOEPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstSOAData As System.Windows.Forms.ListBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtPnt1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt4 As System.Windows.Forms.TextBox
    Friend WithEvents lblPnt1 As System.Windows.Forms.Label
    Friend WithEvents lblPnt2 As System.Windows.Forms.Label
    Friend WithEvents lblPnt3 As System.Windows.Forms.Label
    Friend WithEvents lblPnt4 As System.Windows.Forms.Label
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
#End Region 
End Class