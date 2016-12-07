<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
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
	Public WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSas As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSoa As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Public WithEvents StatusBar1 As AxComctlLib.AxStatusBar
    '    Public OpenFileDialg1 As System.Windows.Forms.FileOpenFileDialog
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmSAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.frmSoa = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.frmSAS, Me.frmSoa})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(628, 33)
        Me.MenuStrip2.TabIndex = 0
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.frmNew, Me.frmOpen, Me.frmExit})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(50, 29)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'frmNew
        '
        Me.frmNew.Name = "frmNew"
        Me.frmNew.Size = New System.Drawing.Size(128, 30)
        Me.frmNew.Text = "New"
        '
        'frmOpen
        '
        Me.frmOpen.Name = "frmOpen"
        Me.frmOpen.Size = New System.Drawing.Size(128, 30)
        Me.frmOpen.Text = "Open"
        '
        'frmExit
        '
        Me.frmExit.Name = "frmExit"
        Me.frmExit.Size = New System.Drawing.Size(128, 30)
        Me.frmExit.Text = "Exit"
        '
        'frmSAS
        '
        Me.frmSAS.Name = "frmSAS"
        Me.frmSAS.Size = New System.Drawing.Size(56, 29)
        Me.frmSAS.Text = "SAS"
        '
        'frmSoa
        '
        Me.frmSoa.Name = "frmSoa"
        Me.frmSoa.Size = New System.Drawing.Size(57, 29)
        Me.frmSoa.Text = "SOE"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 383)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(628, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmMain
        '
        Me.ClientSize = New System.Drawing.Size(628, 405)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "frmMain"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SASToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SOAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmSAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frmSoa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
#End Region
End Class