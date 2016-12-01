Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Option Strict Off
Option Explicit On

Friend Class frmSoaTypeProcInp
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_ISSUE: CommandButton event cmdContinue.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub cmdContinue_Click()
        If frmSoaInp.optTypeProc1.Checked = True Then
        ElseIf frmSoaInp.optTypeProc2.Checked = True Then
            BegPnt = Val(txtField2.Text)
            EndPnt = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc3.Checked = True Then
            BegSta = Val(txtField2.Text)
            EndSta = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc4.Checked = True Then
            AlignNum = Val(txtField1.Text)
        ElseIf frmSoaInp.optTypeProc5.Checked = True Then
            AlignNum = Val(txtField1.Text)
            BegPnt = Val(txtField2.Text)
            EndPnt = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc6.Checked = True Then
            AlignNum = Val(txtField1.Text)
            BegSta = Val(txtField2.Text)
            EndSta = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc7.Checked = True Then
        End If
        LOff = Val(txtLOff.Text)
        ROff = Val(txtROff.Text)
        Do While Not EOF(4)
            Input(4, Align)
            Input(4, ElemType)
            Input(4, AlignDesc)
            Input(4, x1)
            Input(4, y1)
            Input(4, X2)
            Input(4, Y2)
            Input(4, X3)
            Input(4, Y3)
            Input(4, bsta)
            Input(4, ESta)
            Input(4, CEsta)
            Input(4, A)
            Input(4, B)
            Input(4, C)
            Input(4, dir_Renamed)
            If Align <> 0 And frmSoaInp.optTypeProc7.Checked = False Then
                If frmSoaInp.optTypeProc4.Checked = True Or frmSoaInp.optTypeProc5.Checked = True Or frmSoaInp.optTypeProc6.Checked = True Then
                    Do While AlignNum = Align And Not EOF(4)
                        Input(4, Align)
                        Input(4, ElemTyp)
                        Input(4, AlignDesc)
                        Input(4, x1)
                        Input(4, y1)
                        Input(4, X2)
                        Input(4, Y2)
                        Input(4, X3)
                        Input(4, Y3)
                        Input(4, bsta)
                        Input(4, ESta)
                        Input(4, CEsta)
                        Input(4, A)
                        Input(4, B)
                        Input(4, C)
                        Input(4, dir_Renamed)
                        '
                        If ElemType = "L" Then
                            Call SoaLine(x1, y1, X2, Y2, A, B, C, bsta, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, AlignNum, AlignDesc)
                        Else
                            C1 = A
                            C2 = B
                            Radius = C
                            Call SoaCurve(x1, y1, X3, Y3, bsta, C1, C2, Radius, dir_Renamed, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, AlignNum, AlignDesc)
                        End If
                        '
                    Loop
                Else
                    '
                    If ElemType = "L" Then
                        Call SoaLine(x1, y1, X2, Y2, A, B, C, bsta, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, Align, AlignDesc)
                    Else
                        C1 = A
                        C2 = B
                        Radius = C
                        Call SoaCurve(x1, y1, X3, Y3, bsta, C1, C2, Radius, dir_Renamed, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, Align, AlignDesc)
                    End If
                    '
                End If
            End If
        Loop
        Me.Close()
    End Sub


    'UPGRADE_NOTE: Form_Initialize was upgraded to Form_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Form_Initialize_Renamed()
        txtLOff.Text = CStr(-100)
        txtROff.Text = CStr(100)
        If frmSoaInp.optTypeProc7.Checked = True Then
            If Align_Num <> Align_nr Then
                If wUnits = "English" Then
                    txtLOff.Text = CStr(-250)
                    txtROff.Text = CStr(250)
                Else
                    txtLOff.Text = CStr(-100)
                    txtROff.Text = CStr(100)
                End If
            End If
            Align_Num = Align_nr
        Else
            If AlnCntr = 0 Or Align_Num <> Align_nr Then
                If wUnits = "English" Then
                    txtLOff.Text = CStr(-50)
                    txtROff.Text = CStr(50)
                Else
                    txtLOff.Text = CStr(-15)
                    txtROff.Text = CStr(15)
                End If
            End If
            Align_Num = Align_nr
        End If

    End Sub

    Private Sub frmSoaTypeProcInp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtField1.Visible = False
        txtField2.Visible = False
        txtField3.Visible = False
        lblField1.Visible = False
        lblField2.Visible = False
        lblField3.Visible = False
        cmdContinue.Visible = False
    End Sub

    'UPGRADE_WARNING: Form event frmSoaTypeProcInp.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmSoaTypeProcInp_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim txtLOff As Short
        Dim txtROff As Short

        If frmSoaInp.optTypeProc1.Checked = True Then ' All / All          ~popt 1
        ElseIf frmSoaInp.optTypeProc2.Checked = True Then  ' All / Points       ~popt 2
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField2.Caption = "Enter Begining Point"
            lblField3.Caption = "Enter Ending Point"
            txtField2.SetFocus()
        ElseIf frmSoaInp.optTypeProc3.Checked = True Then  ' All / Station      ~popt 3
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField2.Caption = "Enter Begining Station"
            lblField3.Caption = "Enter Ending Station"
            txtField2.SetFocus()
        ElseIf frmSoaInp.optTypeProc4.Checked = True Then  ' Single / All       ~popt 4
            txtField1.Enabled = True
            txtField1.Visible = True
            lblField1.Visible = True
            lblField1.Caption = "Enter Alignment to Process"
            txtField1.SetFocus()
        ElseIf frmSoaInp.optTypeProc5.Checked = True Then  ' Single / Points    ~popt 5
            txtField1.Enabled = True
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField1.Visible = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField1.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField1.Caption = "Enter Alignment to Process"
            lblField2.Caption = "Enter Begining Point"
            lblField3.Caption = "Enter Ending Point"
            txtField1.SetFocus()
        ElseIf frmSoaInp.optTypeProc6.Checked = True Then  ' Single / Station   ~popt 6
            txtField1.Enabled = True
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField1.Visible = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField1.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField1.Caption = "Enter Alignment to Process"
            lblField2.Caption = "Enter Begining Station"
            lblField3.Caption = "Enter Ending Station"
            txtField1.SetFocus()
        ElseIf frmSoaInp.optTypeProc7.Checked = True Then  ' Drainage           ~popt 7
        End If
    End Sub

    Private Sub frmSoaTypeProcInp_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FileClose(22)
    End Sub

    'UPGRADE_WARNING: Event txtField3.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtField3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.TextChanged
        cmdContinue.Visible = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If frmSoaInp.optTypeProc1 = True Then
        ElseIf frmSoaInp.optTypeProc2 = True Then
            BegPnt = Val(txtField2)
            EndPnt = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc3 = True Then
            BegSta = Val(txtField2)
            EndSta = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc4 = True Then
            AlignNum = Val(txtField1)
        ElseIf frmSoaInp.optTypeProc5 = True Then
            AlignNum = Val(txtField1)
            BegPnt = Val(txtField2)
            EndPnt = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc6 = True Then
            AlignNum = Val(txtField1)
            BegSta = Val(txtField2)
            EndSta = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc7 = True Then
        End If
        LOff = Val(txtLOff)
        ROff = Val(txtROff)
        Do While Not EOF(4)
      Input #4, Align, ElemType, AlignDesc, x1, y1, X2, Y2, X3, Y3, bsta, ESta, CEsta, A, B, C, dir
            If Align <> 0 And frmSoaInp.optTypeProc7 = False Then
                If frmSoaInp.optTypeProc4 = True Or frmSoaInp.optTypeProc5 = True Or frmSoaInp.optTypeProc6 = True Then
                    Do While AlignNum = Align And Not EOF(4)
               Input #4, Align, ElemTyp, AlignDesc, x1, y1, X2, Y2, X3, Y3, bsta, ESta, CEsta, A, B, C, dir
                        '
                        If ElemType = "L" Then
                            Call SoaLine(x1, y1, X2, Y2, A, B, C, bsta, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, AlignNum, AlignDesc)
                        Else
                            C1 = A
                            C2 = B
                            Radius = C
                            Call SoaCurve(x1, y1, X3, Y3, bsta, C1, C2, Radius, Dir, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, AlignNum, AlignDesc)
                        End If
                        '
                    Loop
                Else
                    '
                    If ElemType = "L" Then
                        Call SoaLine(x1, y1, X2, Y2, A, B, C, bsta, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, Align, AlignDesc)
                    Else
                        C1 = A
                        C2 = B
                        Radius = C
                        Call SoaCurve(x1, y1, X3, Y3, bsta, C1, C2, Radius, Dir, LOff, ROff, BegPnt, EndPnt, BegSta, EndSta, Align, AlignDesc)
                    End If
                    '
                End If
            End If
        Loop
        Unload(frmSoaTypeProcInp)
    End Sub
End Class