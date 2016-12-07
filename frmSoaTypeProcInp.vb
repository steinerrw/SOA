Option Strict Off
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms


Friend Class frmSoaTypeProcInp
	Inherits System.Windows.Forms.Form
	
    Private Sub cmdContinue_Click()
        If frmSoaInp.optTypeProc1.AutoCheck = True Then
        ElseIf frmSoaInp.optTypeProc2.AutoCheck = True Then
            BegPnt = Val(txtField2.Text)
            EndPnt = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc3.AutoCheck = True Then
            BegSta = Val(txtField2.Text)
            EndSta = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc4.AutoCheck = True Then
            AlignNum = Val(txtField1.Text)
        ElseIf frmSoaInp.optTypeProc5.AutoCheck = True Then
            AlignNum = Val(txtField1.Text)
            BegPnt = Val(txtField2.Text)
            EndPnt = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc6.AutoCheck = True Then
            AlignNum = Val(txtField1.Text)
            BegSta = Val(txtField2.Text)
            EndSta = Val(txtField3.Text)
        ElseIf frmSoaInp.optTypeProc7.AutoCheck = True Then
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
                If frmSoaInp.optTypeProc4.AutoCheck = True Or frmSoaInp.optTypeProc5.AutoCheck = True Or frmSoaInp.optTypeProc6.AutoCheck = True Then
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
        FileClose()
    End Sub

    Private Sub Form_Initialize_Renamed()
        txtLOff.Text = CStr(-100)
        txtROff.Text = CStr(100)
        If frmSoaInp.optTypeProc7.AutoCheck = True Then
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

    Private Sub frmSoaTypeProcInp_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        If frmSoaInp.optTypeProc1.AutoCheck = True Then ' All / All          ~popt 1
        ElseIf frmSoaInp.optTypeProc2.AutoCheck = True Then  ' All / Points       ~popt 2
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField2.Text = "Enter Begining Point"
            lblField3.Text = "Enter Ending Point"
            txtField2.Focus()
        ElseIf frmSoaInp.optTypeProc3.AutoCheck = True Then  ' All / Station      ~popt 3
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField2.Text = "Enter Begining Station"
            lblField3.Text = "Enter Ending Station"
            txtField2.Focus()
        ElseIf frmSoaInp.optTypeProc4.AutoCheck = True Then  ' Single / All       ~popt 4
            txtField1.Enabled = True
            txtField1.Visible = True
            lblField1.Visible = True
            lblField1.Text = "Enter Alignment to Process"
            txtField1.Focus()
        ElseIf frmSoaInp.optTypeProc5.AutoCheck = True Then  ' Single / Points    ~popt 5
            txtField1.Enabled = True
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField1.Visible = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField1.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField1.Text = "Enter Alignment to Process"
            lblField2.Text = "Enter Begining Point"
            lblField3.Text = "Enter Ending Point"
            txtField1.Focus()
        ElseIf frmSoaInp.optTypeProc6.AutoCheck = True Then  ' Single / Station   ~popt 6
            txtField1.Enabled = True
            txtField2.Enabled = True
            txtField3.Enabled = True
            txtField1.Visible = True
            txtField2.Visible = True
            txtField3.Visible = True
            lblField1.Visible = True
            lblField2.Visible = True
            lblField3.Visible = True
            lblField1.Text = "Enter Alignment to Process"
            lblField2.Text = "Enter Begining Station"
            lblField3.Text = "Enter Ending Station"
            txtField1.Focus()
        ElseIf frmSoaInp.optTypeProc7.AutoCheck = True Then  ' Drainage           ~popt 7
        End If
    End Sub

    Private Sub txtField3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.TextChanged
        cmdContinue.Visible = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If frmSoaInp.optTypeProc1.AutoCheck = True Then
        ElseIf frmSoaInp.optTypeProc2.AutoCheck = True Then
            BegPnt = Val(txtField2)
            EndPnt = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc3.AutoCheck = True Then
            BegSta = Val(txtField2)
            EndSta = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc4.AutoCheck = True Then
            AlignNum = Val(txtField1)
        ElseIf frmSoaInp.optTypeProc5.AutoCheck = True Then
            AlignNum = Val(txtField1)
            BegPnt = Val(txtField2)
            EndPnt = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc6.AutoCheck = True Then
            AlignNum = Val(txtField1)
            BegSta = Val(txtField2)
            EndSta = Val(txtField3)
        ElseIf frmSoaInp.optTypeProc7.AutoCheck = True Then
        End If
        LOff = Val(txtLOff)
        ROff = Val(txtROff)
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
            Input(4, Align)
            Input(4, C)
            Input(4, Dir)
            If Align <> 0 And frmSoaInp.optTypeProc7.AutoCheck = False Then
                If frmSoaInp.optTypeProc4.AutoCheck = True Or frmSoaInp.optTypeProc5.AutoCheck = True Or frmSoaInp.optTypeProc6.AutoCheck = True Then
                    Do While AlignNum = Align And Not EOF(4)
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
                        Input(4, Align)
                        Input(4, C)
                        Input(4, Dir)
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
        Dispose()
    End Sub
End Class