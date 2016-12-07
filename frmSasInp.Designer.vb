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
        Me.optType = New System.Windows.Forms.GroupBox()
        Me.optType1 = New System.Windows.Forms.RadioButton()
        Me.optType2 = New System.Windows.Forms.RadioButton()
        Me.optType3 = New System.Windows.Forms.RadioButton()
        Me.optCurve = New System.Windows.Forms.GroupBox()
        Me.optCurve1 = New System.Windows.Forms.RadioButton()
        Me.optCurve2 = New System.Windows.Forms.RadioButton()
        Me.optCurve3 = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuRunAlign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWithSOE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSasPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblBegAlign = New System.Windows.Forms.Label()
        Me.lblGP3Cnt = New System.Windows.Forms.Label()
        Me.txtBegAlign = New System.Windows.Forms.TextBox()
        Me.txtGP3Cnt = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblAlign = New System.Windows.Forms.Label()
        Me.lblUnits = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtAlignment = New System.Windows.Forms.TextBox()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.comboUnits = New System.Windows.Forms.ListBox()
        Me.cmdNewAlign = New System.Windows.Forms.Button()
        Me.cmdReplace = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdQuit = New System.Windows.Forms.Button()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.lstSAS_Data = New System.Windows.Forms.ListBox()
        Me.lstSOESort = New System.Windows.Forms.ListBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtPnt1 = New System.Windows.Forms.TextBox()
        Me.txtPnt2 = New System.Windows.Forms.TextBox()
        Me.txtPnt3 = New System.Windows.Forms.TextBox()
        Me.txtPnt4 = New System.Windows.Forms.TextBox()
        Me.lblPnt1 = New System.Windows.Forms.Label()
        Me.lblPnt2 = New System.Windows.Forms.Label()
        Me.lblPnt3 = New System.Windows.Forms.Label()
        Me.lblPnt4 = New System.Windows.Forms.Label()
        Me.lstSAS_Data = New System.Windows.Forms.ListBox()
        Me.lstSAS_Sort = New System.Windows.Forms.ListBox()
        Me.optType.SuspendLayout()
        Me.optCurve.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'optType
        '
        Me.optType.Controls.Add(Me.optType1)
        Me.optType.Controls.Add(Me.optType2)
        Me.optType.Controls.Add(Me.optType3)
        Me.optType.Location = New System.Drawing.Point(17, 125)
        Me.optType.Name = "optType"
        Me.optType.Size = New System.Drawing.Size(215, 120)
        Me.optType.TabIndex = 0
        Me.optType.TabStop = False
        Me.optType.Tag = "C:\SOA\FSoa.NET\frmSoaTypeProcInp.vbC:\SOA\FSoa.NET\frmSoaTypeProcInp.vb"
        Me.optType.Text = "Record Type"
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
        'optCurve
        '
        Me.optCurve.Controls.Add(Me.optCurve1)
        Me.optCurve.Controls.Add(Me.optCurve2)
        Me.optCurve.Controls.Add(Me.optCurve3)
        Me.optCurve.Location = New System.Drawing.Point(23, 265)
        Me.optCurve.Name = "optCurve"
        Me.optCurve.Size = New System.Drawing.Size(217, 119)
        Me.optCurve.TabIndex = 1
        Me.optCurve.TabStop = False
        Me.optCurve.Text = "Curve Types"
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
        'lblBegAlign
        '
        Me.lblBegAlign.AutoSize = True
        Me.lblBegAlign.Location = New System.Drawing.Point(86, 55)
        Me.lblBegAlign.Name = "lblBegAlign"
        Me.lblBegAlign.Size = New System.Drawing.Size(155, 20)
        Me.lblBegAlign.TabIndex = 3
        Me.lblBegAlign.Text = "Beginning Alignment"
        '
        'lblGP3Cnt
        '
        Me.lblGP3Cnt.AutoSize = True
        Me.lblGP3Cnt.Location = New System.Drawing.Point(25, 85)
        Me.lblGP3Cnt.Name = "lblGP3Cnt"
        Me.lblGP3Cnt.Size = New System.Drawing.Size(216, 20)
        Me.lblGP3Cnt.TabIndex = 4
        Me.lblGP3Cnt.Text = "Beginning GP3 Point Number"
        '
        'txtBegAlign
        '
        Me.txtBegAlign.Location = New System.Drawing.Point(252, 53)
        Me.txtBegAlign.Name = "txtBegAlign"
        Me.txtBegAlign.Size = New System.Drawing.Size(148, 26)
        Me.txtBegAlign.TabIndex = 5
        '
        'txtGP3Cnt
        '
        Me.txtGP3Cnt.Location = New System.Drawing.Point(252, 85)
        Me.txtGP3Cnt.Name = "txtGP3Cnt"
        Me.txtGP3Cnt.Size = New System.Drawing.Size(148, 26)
        Me.txtGP3Cnt.TabIndex = 6
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(245, 202)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(89, 20)
        Me.lblDesc.TabIndex = 7
        Me.lblDesc.Text = "Description"
        '
        'lblAlign
        '
        Me.lblAlign.AutoSize = True
        Me.lblAlign.Location = New System.Drawing.Point(254, 233)
        Me.lblAlign.Name = "lblAlign"
        Me.lblAlign.Size = New System.Drawing.Size(80, 20)
        Me.lblAlign.TabIndex = 8
        Me.lblAlign.Text = "Alignment"
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(288, 269)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(46, 20)
        Me.lblUnits.TabIndex = 9
        Me.lblUnits.Text = "Units"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(340, 195)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(271, 26)
        Me.txtDescription.TabIndex = 12
        '
        'txtAlignment
        '
        Me.txtAlignment.Location = New System.Drawing.Point(340, 227)
        Me.txtAlignment.Name = "txtAlignment"
        Me.txtAlignment.Size = New System.Drawing.Size(72, 26)
        Me.txtAlignment.TabIndex = 13
        '
        'txtStation
        '
        Me.txtStation.Location = New System.Drawing.Point(485, 227)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(126, 26)
        Me.txtStation.TabIndex = 14
        '
        'comboUnits
        '
        Me.comboUnits.FormattingEnabled = True
        Me.comboUnits.ItemHeight = 20
        Me.comboUnits.Items.AddRange(New Object() {"US", "Metric"})
        Me.comboUnits.Location = New System.Drawing.Point(340, 265)
        Me.comboUnits.Name = "comboUnits"
        Me.comboUnits.Size = New System.Drawing.Size(109, 24)
        Me.comboUnits.TabIndex = 16
        '
        'cmdNewAlign
        '
        Me.cmdNewAlign.Location = New System.Drawing.Point(17, 390)
        Me.cmdNewAlign.Name = "cmdNewAlign"
        Me.cmdNewAlign.Size = New System.Drawing.Size(123, 45)
        Me.cmdNewAlign.TabIndex = 17
        Me.cmdNewAlign.Text = "New Alignment"
        Me.cmdNewAlign.UseVisualStyleBackColor = True
        '
        'cmdReplace
        '
        Me.cmdReplace.Location = New System.Drawing.Point(146, 392)
        Me.cmdReplace.Name = "cmdReplace"
        Me.cmdReplace.Size = New System.Drawing.Size(102, 45)
        Me.cmdReplace.TabIndex = 18
        Me.cmdReplace.Text = "Replace"
        Me.cmdReplace.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(258, 390)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(102, 45)
        Me.cmdDelete.TabIndex = 19
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(366, 390)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(102, 45)
        Me.cmdSave.TabIndex = 20
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(474, 387)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(102, 45)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdQuit
        '
        Me.cmdQuit.Location = New System.Drawing.Point(582, 387)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(102, 45)
        Me.cmdQuit.TabIndex = 22
        Me.cmdQuit.Text = "Quit"
        Me.cmdQuit.UseVisualStyleBackColor = True
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(419, 230)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(60, 20)
        Me.lblStation.TabIndex = 23
        Me.lblStation.Text = "Station"
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(711, 231)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(123, 38)
        Me.cmdProcess.TabIndex = 24
        Me.cmdProcess.Text = "Process"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'lstSAS_Data
        '
        Me.lstSAS_Data.FormattingEnabled = True
        Me.lstSAS_Data.ItemHeight = 20
        Me.lstSAS_Data.Location = New System.Drawing.Point(688, 156)
        Me.lstSAS_Data.Name = "lstSAS_Data"
        Me.lstSAS_Data.Size = New System.Drawing.Size(145, 44)
        Me.lstSAS_Data.TabIndex = 25
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
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(143, 392)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(105, 41)
        Me.cmdAdd.TabIndex = 27
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtPnt1
        '
        Me.txtPnt1.Location = New System.Drawing.Point(399, 308)
        Me.txtPnt1.Name = "txtPnt1"
        Me.txtPnt1.Size = New System.Drawing.Size(90, 26)
        Me.txtPnt1.TabIndex = 28
        '
        'txtPnt2
        '
        Me.txtPnt2.Location = New System.Drawing.Point(399, 340)
        Me.txtPnt2.Name = "txtPnt2"
        Me.txtPnt2.Size = New System.Drawing.Size(90, 26)
        Me.txtPnt2.TabIndex = 29
        '
        'txtPnt3
        '
        Me.txtPnt3.Location = New System.Drawing.Point(619, 308)
        Me.txtPnt3.Name = "txtPnt3"
        Me.txtPnt3.Size = New System.Drawing.Size(90, 26)
        Me.txtPnt3.TabIndex = 30
        '
        'txtPnt4
        '
        Me.txtPnt4.Location = New System.Drawing.Point(619, 340)
        Me.txtPnt4.Name = "txtPnt4"
        Me.txtPnt4.Size = New System.Drawing.Size(90, 26)
        Me.txtPnt4.TabIndex = 31
        '
        'lblPnt1
        '
        Me.lblPnt1.AutoSize = True
        Me.lblPnt1.Location = New System.Drawing.Point(327, 314)
        Me.lblPnt1.Name = "lblPnt1"
        Me.lblPnt1.Size = New System.Drawing.Size(57, 20)
        Me.lblPnt1.TabIndex = 32
        Me.lblPnt1.Text = "Label6"
        '
        'lblPnt2
        '
        Me.lblPnt2.AutoSize = True
        Me.lblPnt2.Location = New System.Drawing.Point(327, 343)
        Me.lblPnt2.Name = "lblPnt2"
        Me.lblPnt2.Size = New System.Drawing.Size(57, 20)
        Me.lblPnt2.TabIndex = 33
        Me.lblPnt2.Text = "Label8"
        '
        'lblPnt3
        '
        Me.lblPnt3.AutoSize = True
        Me.lblPnt3.Location = New System.Drawing.Point(547, 314)
        Me.lblPnt3.Name = "lblPnt3"
        Me.lblPnt3.Size = New System.Drawing.Size(57, 20)
        Me.lblPnt3.TabIndex = 34
        Me.lblPnt3.Text = "Label9"
        '
        'lblPnt4
        '
        Me.lblPnt4.AutoSize = True
        Me.lblPnt4.Location = New System.Drawing.Point(547, 343)
        Me.lblPnt4.Name = "lblPnt4"
        Me.lblPnt4.Size = New System.Drawing.Size(66, 20)
        Me.lblPnt4.TabIndex = 35
        Me.lblPnt4.Text = "Label10"
        '
        'lstSAS_Data
        '
        Me.lstSAS_Data.FormattingEnabled = True
        Me.lstSAS_Data.ItemHeight = 20
        Me.lstSAS_Data.Location = New System.Drawing.Point(440, 55)
        Me.lstSAS_Data.Name = "lstSAS_Data"
        Me.lstSAS_Data.Size = New System.Drawing.Size(207, 44)
        Me.lstSAS_Data.TabIndex = 36
        '
        'lstSAS_Sort
        '
        Me.lstSAS_Sort.FormattingEnabled = True
        Me.lstSAS_Sort.ItemHeight = 20
        Me.lstSAS_Sort.Location = New System.Drawing.Point(441, 116)
        Me.lstSAS_Sort.Name = "lstSAS_Sort"
        Me.lstSAS_Sort.Size = New System.Drawing.Size(205, 44)
        Me.lstSAS_Sort.TabIndex = 37
        '
        'frmSasInp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 444)
        Me.Controls.Add(Me.lstSAS_Sort)
        Me.Controls.Add(Me.lstSAS_Data)
        Me.Controls.Add(Me.lblPnt4)
        Me.Controls.Add(Me.lblPnt3)
        Me.Controls.Add(Me.lblPnt2)
        Me.Controls.Add(Me.lblPnt1)
        Me.Controls.Add(Me.txtPnt4)
        Me.Controls.Add(Me.txtPnt3)
        Me.Controls.Add(Me.txtPnt2)
        Me.Controls.Add(Me.txtPnt1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lstSOESort)
        Me.Controls.Add(Me.lstSAS_Data)
        Me.Controls.Add(Me.cmdProcess)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdReplace)
        Me.Controls.Add(Me.cmdNewAlign)
        Me.Controls.Add(Me.comboUnits)
        Me.Controls.Add(Me.txtStation)
        Me.Controls.Add(Me.txtAlignment)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblUnits)
        Me.Controls.Add(Me.lblAlign)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.txtGP3Cnt)
        Me.Controls.Add(Me.txtBegAlign)
        Me.Controls.Add(Me.lblGP3Cnt)
        Me.Controls.Add(Me.lblBegAlign)
        Me.Controls.Add(Me.optCurve)
        Me.Controls.Add(Me.optType)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmSasInp"
        Me.Text = "SAS Data Entry Screen"
        Me.optType.ResumeLayout(False)
        Me.optType.PerformLayout()
        Me.optCurve.ResumeLayout(False)
        Me.optCurve.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optType As System.Windows.Forms.GroupBox
    Friend WithEvents optCurve As System.Windows.Forms.GroupBox
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
    Friend WithEvents lblBegAlign As System.Windows.Forms.Label
    Friend WithEvents lblGP3Cnt As System.Windows.Forms.Label
    Friend WithEvents txtBegAlign As System.Windows.Forms.TextBox
    Friend WithEvents txtGP3Cnt As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblAlign As System.Windows.Forms.Label
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtAlignment As System.Windows.Forms.TextBox
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents comboUnits As System.Windows.Forms.ListBox
    Friend WithEvents cmdNewAlign As System.Windows.Forms.Button
    Friend WithEvents cmdReplace As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents lstSAS_Data As System.Windows.Forms.ListBox
    Friend WithEvents lstSOESort As System.Windows.Forms.ListBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtPnt1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPnt4 As System.Windows.Forms.TextBox
    Friend WithEvents lblPnt1 As System.Windows.Forms.Label
    Friend WithEvents lblPnt2 As System.Windows.Forms.Label
    Friend WithEvents lblPnt3 As System.Windows.Forms.Label
    Friend WithEvents lblPnt4 As System.Windows.Forms.Label
    Friend WithEvents lstSAS_Sort As System.Windows.Forms.ListBox
End Class
