Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSasOptions


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
    Public WithEvents mnuRunAlign As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuWithSOE As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSasPrint As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Public WithEvents comboUnits As System.Windows.Forms.ComboBox
    Public WithEvents txtGP3Cnt As System.Windows.Forms.TextBox
    Public WithEvents lstSOESort As System.Windows.Forms.ListBox
    Public WithEvents cmdProcess As System.Windows.Forms.Button
    Public WithEvents txtBegAlign As System.Windows.Forms.TextBox
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents cmdDelete As System.Windows.Forms.Button
    Public WithEvents lstSASData As System.Windows.Forms.ListBox
    Public WithEvents _optCurve_2 As System.Windows.Forms.RadioButton
    Public WithEvents _optCurve_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optCurve_0 As System.Windows.Forms.RadioButton
    Public WithEvents frameCurve As System.Windows.Forms.GroupBox
    Public WithEvents _optType_2 As System.Windows.Forms.RadioButton
    Public WithEvents _optType_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optType_0 As System.Windows.Forms.RadioButton
    Public WithEvents frameType As System.Windows.Forms.GroupBox
    Public WithEvents txtPnt4 As System.Windows.Forms.TextBox
    Public WithEvents txtPnt3 As System.Windows.Forms.TextBox
    Public WithEvents txtPnt2 As System.Windows.Forms.TextBox
    Public WithEvents txtPnt1 As System.Windows.Forms.TextBox
    Public WithEvents cmdNewAlign As System.Windows.Forms.Button
    Public WithEvents txtDescription As System.Windows.Forms.TextBox
    Public WithEvents txtAlignment As System.Windows.Forms.TextBox
    Public WithEvents txtStation As System.Windows.Forms.TextBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdQuit As System.Windows.Forms.Button
    Public WithEvents cmdReplace As System.Windows.Forms.Button
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents lblUnits As System.Windows.Forms.Label
    Public WithEvents lblGP3Cnt As System.Windows.Forms.Label
    Public WithEvents lblBegAlign As System.Windows.Forms.Label
    Public WithEvents lblPnt4 As System.Windows.Forms.Label
    Public WithEvents lblPnt2 As System.Windows.Forms.Label
    Public WithEvents lblPnt1 As System.Windows.Forms.Label
    Public WithEvents lblPnt3 As System.Windows.Forms.Label
    Public WithEvents lblStation As System.Windows.Forms.Label
    Public WithEvents lblAlign As System.Windows.Forms.Label
    Public WithEvents lblDesc As System.Windows.Forms.Label
    Public WithEvents optCurve As System.Windows.Forms.RadioButton
    Public WithEvents optType As System.Windows.Forms.RadioButton
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optTypeProc7 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc6 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc5 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc4 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc3 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc2 = New System.Windows.Forms.RadioButton()
        Me.optTypeProc1 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(605, 33)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.GroupBox1.Location = New System.Drawing.Point(21, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 250)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Typy Proc Options"
        '
        'optTypeProc7
        '
        Me.optTypeProc7.AutoSize = True
        Me.optTypeProc7.Location = New System.Drawing.Point(13, 212)
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
        Me.optTypeProc6.Location = New System.Drawing.Point(13, 184)
        Me.optTypeProc6.Name = "optTypeProc6"
        Me.optTypeProc6.Size = New System.Drawing.Size(271, 24)
        Me.optTypeProc6.TabIndex = 5
        Me.optTypeProc6.TabStop = True
        Me.optTypeProc6.Text = "Single Alignment w/Station Points"
        Me.optTypeProc6.UseVisualStyleBackColor = True
        '
        'optTypeProc5
        '
        Me.optTypeProc5.AutoSize = True
        Me.optTypeProc5.Location = New System.Drawing.Point(13, 154)
        Me.optTypeProc5.Name = "optTypeProc5"
        Me.optTypeProc5.Size = New System.Drawing.Size(260, 24)
        Me.optTypeProc5.TabIndex = 4
        Me.optTypeProc5.TabStop = True
        Me.optTypeProc5.Text = "Single Alignment w/Point Range"
        Me.optTypeProc5.UseVisualStyleBackColor = True
        '
        'optTypeProc4
        '
        Me.optTypeProc4.AutoSize = True
        Me.optTypeProc4.Location = New System.Drawing.Point(13, 124)
        Me.optTypeProc4.Name = "optTypeProc4"
        Me.optTypeProc4.Size = New System.Drawing.Size(237, 24)
        Me.optTypeProc4.TabIndex = 3
        Me.optTypeProc4.TabStop = True
        Me.optTypeProc4.Text = "Single Alignment w/All Points"
        Me.optTypeProc4.UseVisualStyleBackColor = True
        '
        'optTypeProc3
        '
        Me.optTypeProc3.AutoSize = True
        Me.optTypeProc3.Location = New System.Drawing.Point(13, 94)
        Me.optTypeProc3.Name = "optTypeProc3"
        Me.optTypeProc3.Size = New System.Drawing.Size(248, 24)
        Me.optTypeProc3.TabIndex = 2
        Me.optTypeProc3.TabStop = True
        Me.optTypeProc3.Text = "All Alignment w/Station Range"
        Me.optTypeProc3.UseVisualStyleBackColor = True
        '
        'optTypeProc2
        '
        Me.optTypeProc2.AutoSize = True
        Me.optTypeProc2.Location = New System.Drawing.Point(13, 66)
        Me.optTypeProc2.Name = "optTypeProc2"
        Me.optTypeProc2.Size = New System.Drawing.Size(233, 24)
        Me.optTypeProc2.TabIndex = 1
        Me.optTypeProc2.TabStop = True
        Me.optTypeProc2.Text = "All Alignment w/Point Range"
        Me.optTypeProc2.UseVisualStyleBackColor = True
        '
        'optTypeProc1
        '
        Me.optTypeProc1.AutoSize = True
        Me.optTypeProc1.Location = New System.Drawing.Point(13, 36)
        Me.optTypeProc1.Name = "optTypeProc1"
        Me.optTypeProc1.Size = New System.Drawing.Size(210, 24)
        Me.optTypeProc1.TabIndex = 0
        Me.optTypeProc1.TabStop = True
        Me.optTypeProc1.Text = "All Alignment w/All Points"
        Me.optTypeProc1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(52, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Quit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(444, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(123, 35)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Continue"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(477, 113)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(90, 26)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(477, 154)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(90, 26)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(477, 197)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(90, 26)
        Me.TextBox3.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(426, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Font:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(412, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Height:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(418, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Width:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(201, 352)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(365, 26)
        Me.TextBox4.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(26, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(281, 24)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Do you want to process every point"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmSasOptions
        '
        Me.ClientSize = New System.Drawing.Size(605, 421)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmSasOptions"
        Me.Text = "SOA Options Screen"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optTypeProc7 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc6 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc5 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc4 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc3 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc2 As System.Windows.Forms.RadioButton
    Friend WithEvents optTypeProc1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
#End Region
End Class