Option Strict Off
Option Explicit Off
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Friend Class frmSasOptions
    Inherits System.Windows.Forms.Form

    Dim Caption As String
    Dim LinkTopic As String
    Dim ScaleHeight As Integer
    Dim ScaleWidth As Integer
    Dim Cursor As Integer
    Dim ScaleMode As Integer

    Private Property vbButtonFace As Color

    Private Property vbWindowBackground As Color

    Private Property vbWindowText As Color

    Private Property vbButtonText As Color

    Private Sub frmSasInp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        mnuWithSOE.Visible = False
        mnuSasPrint.Visible = False

        idxCnt = 0

        FileOpen(2, New_filename, OpenMode.Input)
        FileOpen(4, Aln_filename, OpenMode.Output)
        FileOpen(5, Pnt_filename, OpenMode.Append)
        FileOpen(6, SasRpt_filename, OpenMode.Output)
        FileOpen(11, Cla_filename, OpenMode.Output)
        '
        WriteLine(6, "Survey File :", New_filename, " Control Points Listing", "", "", "")
        WriteLine(6, "Point", "X Coord", "Y Coord", "Z Coord", "Description", "")
        '
        '   Line Input #2, Record
        Do While Not EOF(2)
            Record = LineInput(2)
            If Mid(Record, 1, 1) <> "*" And Len(Record) > 0 Then
                Pnt = CShort(Str(CDbl(Mid(Record, 1, 5))))
                Desc = Mid(Record, 49, 20)
                iY = CDbl(Str(CDbl(Mid(Record, 7, 13))))
                iX = CDbl(Str(CDbl(Mid(Record, 21, 13))))
                iZ = CDbl(Str(CDbl(Mid(Record, 35, 13))))

                'write  #11 .cla file
                If Mid(Record, 49, 2) = "CL" Or Mid(Record, 49, 3) = "CLP" And Pnt > 0 Then
                    WriteLine(11, Pnt, iX, iY, iZ, Desc)
                End If
                'write  #5 .pnt file
                If Mid(Record, 49, 2) = "XR" Or Mid(Record, 49, 2) = "XL" And Pnt > 0 Then
                    WriteLine(5, Pnt, iX, iY, iZ, Desc)
                End If
                'load array from .pnt file
                If Mid(Record, 49, 3) = "POT" Or Mid(Record, 49, 4) = "POST" Or Mid(Record, 49, 2) = "PC" Or Mid(Record, 49, 3) = "POC" Or Mid(Record, 49, 2) = "PI" Or Mid(Record, 49, 2) = "PT" Or Mid(Record, 49, 2) = "RP" Or Mid(Record, 49, 3) = "PRC" Or Mid(Record, 49, 2) = "CP" Or Mid(Record, 49, 2) = "BM" Or Mid(Record, 49, 3) = "ICL" And Pnt > 0 Then
                    idxCnt = idxCnt + 1
                    idx_Pnt(idxCnt) = Pnt
                    idx_X(idxCnt) = iX
                    idx_Y(idxCnt) = iY
                    idx_Z(idxCnt) = iZ
                    WriteLine(6, Pnt, iX, iY, iZ, Desc, "")
                End If
            End If
        Loop
        FileClose(2)
        FileClose(11)
        FileOpen(1, Alg_filename, OpenMode.Append)
        MySize = LOF(1)
        FileClose(1)
        If MySize = 0 Then
            FileOpen(1, Alg_filename, OpenMode.Append)
        Else
            FileOpen(1, Alg_filename, OpenMode.Input)
            While Not EOF(1)
                Input(1, RecType)
                Input(1, Col1)
                Input(1, Col2)
                Input(1, Col3)
                Input(1, Col4)
                Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
                lstSASData.Items.Add(Entry)
            End While
        End If
        FileClose(1)
        cmdReplace.Visible = False
        cmdAdd.Visible = True
        VB6.SetDefault(cmdAdd, True)
        Save_Flag = "N"
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdAdd.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdAdd_Click()
        If optType1.Checked = True Then
            Call Desc_Proc()
            RC = "Y"
        ElseIf optType2.Checked = True Then
            Call Line_Proc()
        ElseIf optType3.Checked = True Then
            Call Curve_Proc()
        End If
        If RC = "Y" Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
            lstSASData.Items.Add(Entry)
            Col1 = ""
            Col2 = ""
            Col3 = ""
            Col4 = ""

            frameType.Visible = True
            optType1.Checked = False
            optType2.Checked = False
            optType3.Checked = False
            optType1.Visible = True
            optType2.Visible = True
            optType3.Visible = True

            lstSASData.Refresh()
        End If
        Save_Flag = "Y"
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdReplace.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdReplace_Click()
        If optType1.Checked = True Then
            Call Desc_Proc()
            RC = "Y"
        ElseIf optType2.Checked = True Then
            Call Line_Proc()
        ElseIf optType3.Checked = True Then
            Call Curve_Proc()
        End If

        If RC = "Y" Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
            lstSASData.Items.RemoveAt(lstSASData.SelectedIndex)
            lstSASData.Items.Insert(lstIndex, Entry)
            Col1 = ""
            Col2 = ""
            Col3 = ""
            Col4 = ""

            frameType.Visible = True
            optType1.Checked = False
            optType2.Checked = False
            optType3.Checked = False
            optType1.Visible = True
            optType2.Visible = True
            optType3.Visible = True

            lstSASData.Refresh()
        End If
        Save_Flag = "Y"
        cmdAdd.Visible = True
        VB6.SetDefault(cmdAdd, True)
        cmdReplace.Visible = False
        VB6.SetDefault(cmdReplace, False)
    End Sub

    Private Sub Desc_Proc()
        Col1 = txtDescription.Text
        Col2 = txtAlignment.Text
        Col3 = txtStation.Text
        Col4 = comboUnits.Text
        RecType = "D"
        txtDescription.Enabled = False
        txtAlignment.Enabled = False
        txtStation.Enabled = False
        comboUnits.Enabled = False
    End Sub

    Private Sub Line_Proc()
        Focus_Flag = "N"
        Col1 = txtPnt1.Text
        Call Alignment.Point_Check(Val(Col1), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt1.Text = ""
            txtPnt1.SetFocus()
            Focus_Flag = "Y"
        End If
        Col2 = txtPnt2.Text
        Call Alignment.Point_Check(Val(Col2), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt2.Text = ""
            If Focus_Flag = "N" Then
                txtPnt2.SetFocus()
            End If
        End If
        Col3 = ""
        Col4 = ""
        RecType = "L"

        If RC = "Y" Then
            txtPnt1.Visible = False
            txtPnt2.Visible = False
            lblPnt1.Visible = False
            lblPnt2.Visible = False
        End If
    End Sub

    Private Sub Curve_Proc()
        Focus_Flag = "N"
        If optCurve1.Checked = True Then
            RecType = "C0"
            Call Curve_Pnt_Proc(3)
        ElseIf optCurve2.Checked = True Then
            RecType = "C1"
            Call Curve_Pnt_Proc(3)
        ElseIf optCurve3.Checked = True Then
            RecType = "C2"
            Call Curve_Pnt_Proc(4)
        End If

        If RC = "Y" Then
            txtPnt1.Visible = False
            txtPnt2.Visible = False
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = False
            lblPnt2.Visible = False
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            frameCurve.Visible = False
            optCurve1.Checked = False
            optCurve2.Checked = False
            optCurve3.Checked = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False
        End If
    End Sub

    Private Sub Curve_Pnt_Proc(ByRef numPnt As Short)
        Col1 = txtPnt1.Text
        Call Point_Check(Val(Col1), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt1.Text = ""
            txtPnt1.SetFocus()
            Focus_Flag = "Y"
        End If
        Col2 = txtPnt2.Text
        Call Point_Check(Val(Col2), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt2.Text = ""
            If Focus_Flag = "N" Then
                txtPnt2.SetFocus()
                Focus_Flag = "Y"
            End If
        End If
        Col3 = txtPnt3.Text
        Call Point_Check(Val(Col3), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt3.Text = ""
            If Focus_Flag = "N" Then
                txtPnt3.SetFocus()
                Focus_Flag = "Y"
            End If
        End If
        If numPnt = 4 Then
            Col4 = txtPnt4.Text
            Call Point_Check(Val(Col4), RC, idx_Pnt, idxCnt)
            If RC = "N" Then
                txtPnt4.Text = ""
                If Focus_Flag = "N" Then
                    txtPnt4.SetFocus()
                    Focus_Flag = "Y"
                End If
            End If
        End If
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdCancel.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdCancel_Click()
        If optType1.Checked = True Then
            txtDescription.Text = ""
            txtAlignment.Text = ""
            txtStation.Text = ""
            txtDescription.SetFocus()
        ElseIf optType2.Checked = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.SetFocus()
        ElseIf optType3.Checked = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.SetFocus()
        End If
        cmdAdd.Visible = True
        VB6.SetDefault(cmdAdd, True)
        cmdReplace.Visible = False
        VB6.SetDefault(cmdReplace, False)
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdDelete.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdDelete_Click()
        lstSASData.Items.RemoveAt(lstSASData.SelectedIndex)
        lstSASData.Refresh()
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdQuit.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdQuit_Click()
        FileClose(2)
        FileClose(4)
        FileClose(5)
        FileClose(6)
        FileClose(7)
        FileClose(11)
        FileClose(20)
        If Save_Flag = "Y" Then
            Call cmdSave_Click()
        End If
        Me.Close()
    End Sub

    Private Sub ReformData(ByRef sList As Object, ByRef RecType As Object, ByRef Col1 As Object, ByRef Col2 As Object, ByRef Col3 As Object, ByRef Col4 As Object)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pos1 = InStr(1, sList, "* ", 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pos4 = InStr(Pos3 + 2, sList, "* ", 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Pos5 = InStr(Pos4 + 2, sList, "*", 0)

        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object RecType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        RecType = Mid(sList, 1, Pos1 - 1)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object Col1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Col1 = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object Col2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Col2 = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object Col3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Col3 = Mid(sList, Pos3 + 2, Pos4 - Pos3 - 2)
        'UPGRADE_WARNING: Couldn't resolve default property of object sList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object Col4. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Col4 = Mid(sList, Pos4 + 2, Pos5 - Pos4 - 2)
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdSave.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdSave_Click()
        Dim I As Short
        FileOpen(30, My.Application.Info.DirectoryPath & "\tmp.dat", OpenMode.Output)
        For I = 0 To lstSASData.Items.Count - 1
            sList = VB6.GetItemString(lstSASData, I)
            Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
            WriteLine(30, RecType, Col1, Col2, Col3, Col4)
        Next I

        FileClose(30)

        FileOpen(1, Alg_filename, OpenMode.Output)
        FileOpen(30, My.Application.Info.DirectoryPath & "\tmp.dat", OpenMode.Input)
        Input(30, RecType)
        Input(30, Col1)
        Input(30, Col2)
        Input(30, Col3)
        Input(30, Col4)
        While Not EOF(30)
            WriteLine(1, RecType, Col1, Col2, Col3, Col4)
            Input(30, RecType)
            Input(30, Col1)
            Input(30, Col2)
            Input(30, Col3)
            Input(30, Col4)
        End While
        ' write last record...
        WriteLine(1, RecType, Col1, Col2, Col3, Col4)
        FileClose(1)
        FileClose(30)
        Kill(My.Application.Info.DirectoryPath & "\tmp.dat")
        Save_Flag = "N"
    End Sub

    'UPGRADE_WARNING: Event lstSASData.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub lstSASData_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSASData.SelectedIndexChanged
        cmdReplace.Visible = True
        cmdAdd.Visible = False
        VB6.SetDefault(cmdReplace, True)

        sList = VB6.GetItemString(lstSASData, lstSASData.SelectedIndex)
        lstIndex = lstSASData.SelectedIndex
        Pos1 = InStr(1, sList, "* ", 0)

        RecType = Mid(sList, 1, Pos1 - 1)
        If RecType = "D" Then
            optType1.Checked = True

            Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
            Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
            Pos4 = InStr(Pos3 + 2, sList, "* ", 0)
            Pos5 = InStr(Pos4 + 2, sList, "*", 0)
            txtDescription.Text = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
            txtAlignment.Text = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
            txtStation.Text = Mid(sList, Pos3 + 2, Pos4 - Pos3 - 2)
            comboUnits.Text = Mid(sList, Pos4 + 2, Pos5 - Pos4 - 2)
            txtDescription.Enabled = True
            txtAlignment.Enabled = True
            txtStation.Enabled = True
            comboUnits.Enabled = True
            If txtPnt1.Visible = True Then
                txtPnt1.Visible = False
                txtPnt2.Visible = False
                txtPnt3.Visible = False
                txtPnt4.Visible = False
                lblPnt1.Visible = False
                lblPnt2.Visible = False
                lblPnt3.Visible = False
                lblPnt4.Visible = False
            End If
        ElseIf RecType = "L" Then
            optType2.Checked = True

            txtDescription.Enabled = False
            txtAlignment.Enabled = False
            txtStation.Enabled = False
            comboUnits.Enabled = False

            lblPnt1.Caption = "Beg Pnt"
            lblPnt2.Caption = "End Pnt"
            txtPnt1.Visible = True
            txtPnt2.Visible = True
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = True
            lblPnt2.Visible = True
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            frameCurve.Visible = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False

            Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
            Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
            txtPnt1.Text = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
            txtPnt2.Text = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
        ElseIf Mid(RecType, 1, 1) = "C" Then
            optType3.Checked = True
            If Mid(RecType, 2, 1) = "0" Then
                optCurve1.Checked = True
                lblPnt1.Caption = "PC"
                lblPnt2.Caption = "PI"
                lblPnt3.Caption = "PT"
                txtPnt1.Visible = True
                txtPnt2.Visible = True
                txtPnt3.Visible = True
                txtPnt4.Visible = False
                lblPnt1.Visible = True
                lblPnt2.Visible = True
                lblPnt3.Visible = True
                lblPnt4.Visible = False
            ElseIf Mid(RecType, 2, 1) = "1" Then
                optCurve2.Checked = True
                lblPnt1.Caption = "PC"
                lblPnt2.Caption = "POC"
                lblPnt3.Caption = "PT"
                txtPnt1.Visible = True
                txtPnt2.Visible = True
                txtPnt3.Visible = True
                txtPnt4.Visible = False
                lblPnt1.Visible = True
                lblPnt2.Visible = True
                lblPnt3.Visible = True
                lblPnt4.Visible = False
            ElseIf Mid(RecType, 2, 1) = "2" Then
                optCurve3.Checked = True
                lblPnt1.Caption = "PC"
                lblPnt2.Caption = "POST"
                lblPnt3.Caption = "POST"
                lblPnt4.Caption = "PT"
                txtPnt1.Visible = True
                txtPnt2.Visible = True
                txtPnt3.Visible = True
                txtPnt4.Visible = True
                lblPnt1.Visible = True
                lblPnt2.Visible = True
                lblPnt3.Visible = True
                lblPnt4.Visible = True
            End If

            Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
            Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
            Pos4 = InStr(Pos3 + 2, sList, "* ", 0)
            Pos5 = InStr(Pos4 + 2, sList, "*", 0)
            txtPnt1.Text = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
            txtPnt2.Text = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
            txtPnt3.Text = Mid(sList, Pos3 + 2, Pos4 - Pos3 - 2)
            txtPnt4.Text = Mid(sList, Pos4 + 2, Pos5 - Pos4 - 2)
        End If
    End Sub

    Public Sub mnuRunAlign_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRunAlign.Click

        For I = 0 To lstSASData.Items.Count - 1
            sList = VB6.GetItemString(lstSASData, I)
            If Mid(sList, 1, 1) = "D" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                Desc = Col1
                bsta = CDbl(Str(CDbl(Col3)))
                ESta = bsta
                Align = CShort(Str(CDbl(Col2)))
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "Description of Alignment", Align, Desc, "", "", "")
                WriteLine(6, "", "", "", "", "", "")
            ElseIf Mid(sList, 1, 1) = "L" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                NPT = 2
                LDesc(1) = "BP"
                LDesc(2) = "EP"
                IPN(1) = CShort(Str(CDbl(Col1)))
                IPN(2) = CShort(Str(CDbl(Col2)))
                Call Find_XYZ(IPN, x, y, z, NPT)
                sta(1) = ESta
                'UPGRADE_WARNING: Couldn't resolve default property of object Dist(x(1), y(1), x(2), y(2)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sta(2) = sta(1) + Dist(x(1), y(1), x(2), y(2))
                ESta = sta(2)
                dY = y(2) - y(1)
                dX = x(2) - x(1)

                CC(1) = dY
                CC(1) = CDbl(VB6.Format(CC(1), "#####0.000"))
                CC(2) = -dX
                CC(2) = CDbl(VB6.Format(CC(2), "#####0.000"))
                CC(3) = -dY * x(1) + dX * y(1)
                CC(3) = CDbl(VB6.Format(CC(3), "#####0.000"))

                Call Find_Bearing(x(1), y(1), x(2), y(2), Bearing)
                Length = sta(2) - sta(1)

                NumElem = NumElem + 1
                TotElem = TotElem + 1
                AlignArray(NumElem) = Align
                ElemArray(NumElem) = "L"
                DirArray(NumElem) = ""
                For J = 1 To 3
                    XArray(NumElem, J) = x(J)
                    YArray(NumElem, J) = y(J)
                    CArray(NumElem, J) = CC(J)
                Next J
                For J = 1 To 2
                    StaArray(NumElem, J) = sta(J)
                Next J
                '
                ' write out data to report here.
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "LINE ELEMENT", "", "", "", "", "")
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "Point", "X", "Y", "Z", "STA", "")
                For K = 1 To NPT
                    x(K) = CDbl(VB6.Format(x(K), "#####0.000"))
                    y(K) = CDbl(VB6.Format(y(K), "#####0.000"))
                    z(K) = CDbl(VB6.Format(z(K), "#####0.000"))
                    sta(K) = CDbl(VB6.Format(sta(K), "#####0.000"))
                    WriteLine(6, LDesc(K), x(K), y(K), z(K), sta(K), "")
                Next K
                '
                WriteLine(4, Align, ElemArray(NumElem), Desc, x(1), y(1), x(2), y(2), x(3), y(3), sta(1), sta(2), sta(3), CC(1), CC(2), CC(3), DirArray(NumElem))
                '
                Length = CDbl(VB6.Format(Length, "#####0.000"))
                Bearing = VB6.Format(Bearing, "#####0.000")
                WriteLine(6, "Length=", Length, "Bearing=", Bearing, "", "")
                '
            ElseIf Mid(sList, 1, 1) = "C" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                IPN(1) = CShort(Str(CDbl(Col1)))
                IPN(2) = CShort(Str(CDbl(Col2)))
                IPN(3) = CShort(Str(CDbl(Col3)))
                LDesc(1) = "PC"
                LDesc(2) = "PI"
                LDesc(3) = "PT"
                LDesc(4) = "CC"
                bsta = ESta
                ' process curve with PC,PI, PT
                If Mid(sList, 2, 1) = "0" Then
                    NPT = 3
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, dir_Renamed, rad)
                    ' process curve with PC,POC, PT
                ElseIf Mid(sList, 2, 1) = "1" Then
                    NPT = 3
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_PI_CC(IPN, x, y, NPT, xPI, yPI, Ang, dir_Renamed, rad)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, dir_Renamed, rad)
                    ' process curve with PC,POST, POST, PT
                ElseIf Mid(sList, 2, 1) = "2" Then
                    IPN(4) = CShort(Str(CDbl(Col4)))
                    NPT = 4
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_PI(IPN, x, y)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, dir_Renamed, rad)
                End If
                'UPGRADE_WARNING: Couldn't resolve default property of object Dist(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TanLen = Dist(x(1), y(1), x(2), y(2))
                TanLen = CDbl(VB6.Format(TanLen, "#####0.000"))
                'UPGRADE_WARNING: Couldn't resolve default property of object Dist(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ChdLen = Dist(x(1), y(1), x(3), y(3))
                ChdLen = CDbl(VB6.Format(ChdLen, "#####0.000"))
                'UPGRADE_WARNING: Couldn't resolve default property of object Dist(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ExtLen = Dist(x0, y0, x(2), y(2)) - rad
                ExtLen = CDbl(VB6.Format(ExtLen, "#####0.000"))
                curveLength = rad * Ang
                curveLength = CDbl(VB6.Format(curveLength, "#####0.000"))
                'UPGRADE_WARNING: Couldn't resolve default property of object Rad2Deg(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Angle = Rad2Deg(Ang)
                Call DdmmssConv(Angle, Delta)
                sta(1) = ESta
                'UPGRADE_WARNING: Couldn't resolve default property of object Dist(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sta(2) = ESta + Dist(x(1), y(1), x(2), y(2))
                sta(3) = ESta + curveLength
                ESta = sta(3)

                CC(1) = x0
                CC(1) = CDbl(VB6.Format(CC(1), "#####0.000"))
                CC(2) = y0
                CC(2) = CDbl(VB6.Format(CC(2), "#####0.000"))
                CC(3) = rad
                CC(3) = CDbl(VB6.Format(CC(3), "#####0.000"))

                Angle = 5729.578 / rad
                Call DdmmssConv(Angle, Degree)
                Call Find_Bearing(x(1), y(1), x(2), y(2), Back)
                Call Find_Bearing(x(2), y(2), x(3), y(3), Ahead)

                NumElem = NumElem + 1
                TotElem = TotElem + 1
                AlignArray(NumElem) = Align
                ElemArray(NumElem) = "C"
                DirArray(NumElem) = dir_Renamed
                For J = 1 To 3
                    XArray(NumElem, J) = x(J)
                    YArray(NumElem, J) = y(J)
                    CArray(NumElem, J) = CC(J)
                    StaArray(NumElem, J) = sta(J)
                Next J
                '
                ' write out data to report here.
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "CURVE ELEMENT", "", "", "", "", "")
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "Point", "X", "Y", "Z", "STA", "")
                For K = 1 To NPT
                    x(K) = CDbl(VB6.Format(x(K), "#####0.000"))
                    y(K) = CDbl(VB6.Format(y(K), "#####0.000"))
                    z(K) = CDbl(VB6.Format(z(K), "#####0.000"))
                    sta(K) = CDbl(VB6.Format(sta(K), "#####0.000"))
                    WriteLine(6, LDesc(K), x(K), y(K), z(K), sta(K), "")
                Next K
                '
                WriteLine(4, Align, ElemArray(NumElem), Desc, x(1), y(1), x(2), y(2), x(3), y(3), sta(1), sta(2), sta(3), CC(1), CC(2), CC(3), DirArray(NumElem))
                '
                WriteLine(6, "", "", "", "", "", "")
                WriteLine(6, "Radius=", CC(3), " Delta=", Delta, "", "")
                WriteLine(6, "Length=", curveLength, " Degree=", Degree, "", "")
                WriteLine(6, "Back=", Back, " Ahead=", Ahead, "", "")
                WriteLine(6, "Tangent=", TanLen, " Chord=", ChdLen, "", "")
                WriteLine(6, "External=", ExtLen, "", "", "", "")
                '
            End If
        Next I
        Msg = "Successfully completed"
        Style = CStr(MsgBoxResult.Ok)
        Title = "Alignment Processing"
        Response = CStr(MsgBox(Msg, CDbl(Style), Title))
        FileClose(6)
        mnuWithSOE.Visible = True
        mnuSasPrint.Visible = True
    End Sub

    Public Sub mnuWithSOE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWithSOE.Click

        Dim IReturn As Short

        cmdNewAlign.Visible = False
        cmdAdd.Visible = False
        cmdReplace.Visible = False
        cmdDelete.Visible = False
        cmdSave.Visible = False
        cmdCancel.Visible = False
        cmdQuit.Visible = False
        txtDescription.Visible = False
        txtAlignment.Visible = False
        txtStation.Visible = False
        comboUnits.Visible = False
        txtDescription.Enabled = False
        txtAlignment.Enabled = False
        txtStation.Enabled = False
        comboUnits.Enabled = False
        txtPnt1.Visible = False
        txtPnt2.Visible = False
        txtPnt3.Visible = False
        txtPnt4.Visible = False
        lblDesc.Visible = False
        lblAlign.Visible = False
        lblStation.Visible = False
        lblUnits.Visible = False
        lblPnt1.Visible = False
        lblPnt2.Visible = False
        lblPnt3.Visible = False
        lblPnt4.Visible = False
        lstSASData.Visible = False
        frameType.Visible = False
        frameCurve.Visible = False

        txtBegAlign.Visible = True
        lblBegAlign.Visible = True
        txtGP3Cnt.Visible = True
        lblGP3Cnt.Visible = True
        cmdProcess.Visible = True
        VB6.SetDefault(cmdProcess, True)
        txtBegAlign.SetFocus()

        '   Open SasRpt_filename For Append As #6
        '   Open XYZ_filename For Output As #7
        '   Open GP3_filename For Output As #20
        '
        '   Open SOE_filename For Input As #8
        '   Open SOR_filename For Output As #14

        IReturn = Shell("c:\soesort.bat" & " " & SOE_filename & " " & " " & SOR_filename)

        '   While Not EOF(8)
        '      Line Input #8, Record
        '      If Mid(Record, 1, 1) <> "*" Then
        '         If Mid(Record, 1, 5) <> "     " Then
        '            SoePnt = Mid(Record, 1, 5)
        '            SoeSta = Mid(Record, 7, 13)
        '            SoeOff = Mid(Record, 21, 13)
        '            SoeElv = Mid(Record, 35, 13)
        '            SoeDesc = Mid(Record, 49, 12)
        '            If SoeOff < 0 Then
        '               SoeOff = 500000000 - SoeOff
        '            ElseIf SoeOff = 0 Then
        '               SoeOff = 100000000
        '            ElseIf SoeOff > 0 Then
        '               SoeOff = SoeOff + 200000000
        '            End If
        '            Entry = SoeSta & "*" & SoeOff & "*" & SoePnt & "*" & SoeElv & "*" & SoeDesc & "*"
        '            lstSOESort.AddItem Entry
        '         End If
        '      End If
        '   Wend
        '   Close #8
        '   For Cnt = 0 To lstSOESort.ListCount - 1
        '      sList = lstSOESort.List(Cnt)
        '      Pos1 = InStr(1, sList, "*", 0)
        '      Pos2 = InStr(Pos1 + 1, sList, "*", 0)
        '      Pos3 = InStr(Pos2 + 1, sList, "*", 0)
        '      Pos4 = InStr(Pos3 + 1, sList, "*", 0)
        '      Pos5 = InStr(Pos4 + 1, sList, "*", 0)
        '      SoeSta = Mid(sList, 1, Pos1 - 1)
        '      SoeOff1 = Mid(sList, Pos1 + 1, Pos2 - Pos1 - 1)
        '
        '         If SoeOff1 > 500000000 Then
        '            SoeOff = (SoeOff1 - 500000000) * -1
        '         ElseIf SoeOff1 = 100000000 Then
        '            SoeOff = 0
        '         ElseIf SoeOff1 > 200000000 And SoeOff1 < 300000000 Then
        '            SoeOff = SoeOff1 - 200000000
        '         End If
        '      SoeOff = Format(SoeOff, "######0.00000")
        '      SoePnt = Mid(sList, Pos2 + 1, Pos3 - Pos2 - 1)
        '      SoeElv = Mid(sList, Pos3 + 1, Pos4 - Pos3 - 1)
        '      SoeDesc = Mid(sList, Pos4 + 1, Pos5 - Pos4 - 1)
        '      Write #14, SoePnt, SoeSta, SoeOff, SoeElv, SoeDesc
        '   Next Cnt
        '   Close #14
        '
    End Sub

    'UPGRADE_ISSUE: CommandButton event cmdProcess.Click was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub cmdProcess_Click()
        '
        FileOpen(6, SasRpt_filename, OpenMode.Append)
        FileOpen(7, XYZ_filename, OpenMode.Output)
        FileOpen(20, GP3_filename, OpenMode.Output)
        '
        FileOpen(10, SO1_filename, OpenMode.Output)
        FileOpen(14, SOR_filename, OpenMode.Input)

        WriteLine(6, "", "", "", "", "", "")
        WriteLine(6, "", "", "", "", "", "")
        WriteLine(6, "XYZ Conversion Report", "", "", "", "", "")
        WriteLine(6, "X Coord", "Y Coord", "Z Coord", "Station", "Offset", "Elevation ")

        If txtGP3Cnt.Text = "" Then
            GP3Cnt = 1000
        Else
            GP3Cnt = Val(txtGP3Cnt.Text)
        End If
        For Cnt = 1 To TotElem
            If Val(txtBegAlign.Text) = AlignArray(Cnt) Then
                IC = Cnt
                While Not EOF(14)
                    Record = LineInput(14)
                    If Mid(Record, 1, 1) <> "*" Then
                        '
                        Pos1 = InStr(1, Record, ",", 0)
                        Pos2 = InStr(Pos1 + 1, Record, ",", 0)
                        Pos3 = InStr(Pos2 + 1, Record, ",", 0)
                        Pos4 = InStr(Pos3 + 1, Record, ",", 0)

                        SoePnt = CShort(Mid(Record, 1, Pos1 - 1))
                        SoeSta = CDbl(Mid(Record, Pos1 + 1, Pos2 - Pos1 - 1))
                        SoeOff = CDbl(Mid(Record, Pos2 + 1, Pos3 - Pos2 - 1))
                        SoeElv = CDbl(Mid(Record, Pos3 + 1, Pos4 - Pos3 - 1))
                        SoeDesc = Mid(Record, Pos4 + 1, Len(Record) - Pos4)
                        '
200:                    If ElemArray(IC) = "C" Then
                            StaDist = StaArray(IC, 3) - SoeSta
                            If StaArray(IC, 3) > SoeSta Or System.Math.Abs(StaDist) <= 1 Then
                                If SoeOff = 0 Then
                                    CenterElev = SoeElv
                                    Call curveStat(CArray(IC, 1), CArray(IC, 2), XArray(IC, 1), YArray(IC, 1), StaArray(IC, 1), SoeSta, DirArray(IC), CArray(IC, 3), xc, yc)
                                End If
                                Call xyzCoord(xc, yc, CenterElev, CArray(IC, 1), CArray(IC, 2), XArray(IC, 2), YArray(IC, 2), offset, elev, ElemArray(IC), DirArray(IC), xx, yy, zz)
                                Call writeRtn(xx, yy, zz, SoeSta, SoeOff, SoeElv, GP3Cnt)
                                GP3Cnt = GP3Cnt + 1
                            ElseIf IC < TotElem And StaArray(IC, 3) <= SoeSta Then
                                IC = IC + 1
                                GoTo 200
                            ElseIf IC >= TotElem And StaArray(IC, 3) <= SoeSta Then
                                IC = Cnt
                            End If
                        ElseIf ElemArray(IC) = "L" Then
                            StaDist = StaArray(IC, 2) - SoeSta
                            If StaArray(IC, 2) > SoeSta Or System.Math.Abs(StaDist) <= 1 Then
                                If SoeOff = 0 Then
                                    CenterElev = SoeElv
                                    Call lineStat(XArray(IC, 1), XArray(IC, 2), YArray(IC, 1), YArray(IC, 2), StaArray(IC, 1), SoeSta, xs, ys)
                                End If
                                Call xyzCoord(xs, ys, CenterElev, XArray(IC, 1), YArray(IC, 1), XArray(IC, 2), YArray(IC, 2), SoeOff, SoeElv, ElemArray(IC), DirArray(IC), xx, yy, zz)
                                Call writeRtn(xx, yy, zz, SoeSta, SoeOff, SoeElv, GP3Cnt)
                                GP3Cnt = GP3Cnt + 1
                            ElseIf IC < TotElem And StaArray(IC, 2) <= SoeSta Then
                                IC = IC + 1
                                GoTo 200
                            ElseIf IC >= TotElem And StaArray(IC, 2) <= SoeSta Then
                                IC = Cnt
                            End If
                        End If
                    End If
                End While
            End If
        Next Cnt

        txtBegAlign.Visible = False
        lblBegAlign.Visible = False
        txtGP3Cnt.Visible = False
        lblGP3Cnt.Visible = False
        cmdProcess.Visible = False

        cmdNewAlign.Visible = True
        cmdAdd.Visible = True
        cmdReplace.Visible = True
        cmdDelete.Visible = True
        cmdSave.Visible = True
        cmdCancel.Visible = True
        cmdQuit.Visible = True
        txtDescription.Visible = True
        txtAlignment.Visible = True
        txtStation.Visible = True
        txtDescription.Enabled = True
        txtAlignment.Enabled = True
        txtStation.Enabled = True
        txtPnt1.Visible = True
        txtPnt2.Visible = True
        txtPnt3.Visible = True
        txtPnt4.Visible = True
        lblDesc.Visible = True
        lblAlign.Visible = True
        lblStation.Visible = True
        lblPnt1.Visible = True
        lblPnt2.Visible = True
        lblPnt3.Visible = True
        lblPnt4.Visible = True
        lstSASData.Visible = True
        frameType.Visible = True

        FileClose(6)
        FileClose(10)
        FileClose(14)
    End Sub

    'UPGRADE_WARNING: Event optType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optType.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = optType.GetIndex(eventSender)
            Select Case Index
                Case 0
                    cmdNewAlign.Visible = True

                    lblAlign.Visible = True
                    lblDesc.Visible = True
                    lblStation.Visible = True
                    lblUnits.Visible = True
                    comboUnits.Visible = True

                    txtDescription.Visible = True
                    txtAlignment.Visible = True
                    txtStation.Visible = True
                    txtDescription.Enabled = True
                    txtAlignment.Enabled = True
                    txtStation.Enabled = True

                    txtDescription.SetFocus()

                    txtPnt1.Visible = False
                    txtPnt2.Visible = False
                    txtPnt3.Visible = False
                    txtPnt4.Visible = False
                    lblPnt1.Visible = False
                    lblPnt2.Visible = False
                    lblPnt3.Visible = False
                    lblPnt4.Visible = False

                    frameCurve.Visible = False
                    optCurve1.Visible = False
                    optCurve2.Visible = False
                    optCurve3.Visible = False
                Case 1

                    txtDescription.Enabled = False
                    txtAlignment.Enabled = False
                    txtStation.Enabled = False

                    lblPnt1.Caption = "Beg Pnt"
                    lblPnt2.Caption = "End Pnt"
                    txtPnt1.Visible = True
                    txtPnt2.Visible = True
                    txtPnt3.Visible = False
                    txtPnt4.Visible = False
                    lblPnt1.Visible = True
                    lblPnt2.Visible = True
                    lblPnt3.Visible = False
                    lblPnt4.Visible = False

                    txtPnt1.SetFocus()

                    frameCurve.Visible = False
                    optCurve1.Visible = False
                    optCurve2.Visible = False
                    optCurve3.Visible = False
                Case 2

                    txtDescription.Enabled = False
                    txtAlignment.Enabled = False
                    txtStation.Enabled = False

                    txtPnt1.Visible = False
                    txtPnt2.Visible = False
                    txtPnt3.Visible = False
                    txtPnt4.Visible = False
                    lblPnt1.Visible = False
                    lblPnt2.Visible = False
                    lblPnt3.Visible = False
                    lblPnt4.Visible = False
                    frameCurve.Visible = True
                    optCurve1.Checked = False
                    optCurve2.Checked = False
                    optCurve3.Checked = False
                    optCurve1.Visible = True
                    optCurve2.Visible = True
                    optCurve3.Visible = True
            End Select
        End If
    End Sub

    'UPGRADE_WARNING: Event optCurve.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optCurve_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCurve.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = optCurve.GetIndex(eventSender)
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Select Case Index
                Case 0
                    lblPnt1.Caption = "PC"
                    lblPnt2.Caption = "PI"
                    lblPnt3.Caption = "PT"
                    txtPnt1.Visible = True
                    txtPnt2.Visible = True
                    txtPnt3.Visible = True
                    txtPnt4.Visible = False
                    lblPnt1.Visible = True
                    lblPnt2.Visible = True
                    lblPnt3.Visible = True
                    lblPnt4.Visible = False
                Case 1
                    lblPnt1.Caption = "PC"
                    lblPnt2.Caption = "POC"
                    lblPnt3.Caption = "PT"
                    txtPnt1.Visible = True
                    txtPnt2.Visible = True
                    txtPnt3.Visible = True
                    txtPnt4.Visible = False
                    lblPnt1.Visible = True
                    lblPnt2.Visible = True
                    lblPnt3.Visible = True
                    lblPnt4.Visible = False
                Case 2
                    lblPnt1.Caption = "PC"
                    lblPnt2.Caption = "POST1"
                    lblPnt3.Caption = "POST2"
                    lblPnt4.Caption = "PT"
                    txtPnt1.Visible = True
                    txtPnt2.Visible = True
                    txtPnt3.Visible = True
                    txtPnt4.Visible = True
                    lblPnt1.Visible = True
                    lblPnt2.Visible = True
                    lblPnt3.Visible = True
                    lblPnt4.Visible = True
            End Select
        End If
    End Sub


    Public Sub mnuSasPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSasPrint.Click
        Dim Printer As New Printer

        Msg = "Continue Printing"
        Style = CStr(MsgBoxStyle.YesNo)
        Title = "Print Proc"
        Response = CStr(MsgBox(Msg, CDbl(Style), Title))

        FileOpen(6, SasRpt_filename, OpenMode.Input)

        If Response = CStr(MsgBoxResult.No) Then
            Printer.KillDoc() ' Terminate print job abruptly.
            Printer.EndDoc()
        Else
            If Response = CStr(MsgBoxResult.Yes) Then
                Printer.Orientation = 1 ' Portrait orientation
                Printer.FontSize = 10
                'UPGRADE_ISSUE: Screen property Screen.Fonts was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                Printer.FontName = Screen.Fonts(12)
                Printer.FontSize = 10
                Page = 1
                Call Header(Page)

                IRow = 9
                xyzSwitch = "N"
                While Not EOF(6)
                    Input(6, F1)
                    Input(6, F2)
                    Input(6, F3)
                    Input(6, F4)
                    Input(6, F5)
                    Input(6, F6)
                    IRow = IRow + 1
                    If IRow > 60 Then
                        IRow = 9
                        Printer.NewPage()
                        Page = Page + 1
                        Call Header(Page)
                        If xyzSwitch = "Y" Then
                            F1a = "X Coord"
                            F2a = "Y Coord"
                            F3a = "Z Coord"
                            F4a = "Station"
                            F5a = "Offset"
                            F6a = "Elevation"
                            Printer.Print(F1a, F2a, F3a, F4a, F5a, F6a)
                        End If
                    ElseIf F1 = "LINE ELEMENT" And IRow > 54 Then
                        IRow = 9
                        Printer.NewPage()
                        Page = Page + 1
                        Call Header(Page)
                    ElseIf F1 = "CURVE ELEMENT" And IRow > 47 Then
                        IRow = 9
                        Printer.NewPage()
                        Page = Page + 1
                        Call Header(Page)
                    ElseIf F1 = "XYZ Conversion Report" Then
                        xyzSwitch = "Y"
                    End If
                    Printer.Print(F1, F2, F3, F4, F5, F6)
                End While

                Printer.EndDoc()
                Msg = "Finished SAS Print"
                Style = CStr(MsgBoxStyle.OkOnly)
                Title = "Print Proc"
                Response = CStr(MsgBox(Msg, CDbl(Style), Title))
            End If
        End If
    End Sub
    Private Sub Header(ByRef Page As Object)
        Dim Printer As New Printer

        MyDate = "Date:" & Now
        'UPGRADE_WARNING: Couldn't resolve default property of object Page. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        MyPage = "Page:" & Page
        Printer.Print("                                                                                " & MyPage)
        Printer.FontBold = True
        Printer.Print("")
        Printer.Print("                            SOUTH CAROLINA DEPARTMENT OF TRANSPORTATION")
        Printer.Print("")
        Printer.Print("                                     SURVEY AUTOMATION SYSTEM")
        Printer.Print("")
        Printer.Print("                         VERSION:WIN/NT 2.0                         " & MyDate)
        Printer.Print("")
        Printer.FontBold = False
        Printer.Print("====================================================================================================")
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click

        Msg = "Continue Printing"
        Style = vbYesNo
        Title = "Print Proc"
        Response = MsgBox(Msg, Style, Title)

   Open Vld_filename For Input As #12

        If Response = vbNo Then
            Printer.KillDoc() ' Terminate print job abruptly.
            Printer.EndDoc()
        Else
            If Response = vbYes Then
                Printer.Orientation = 2       ' Portrait orientation
                Printer.FontSize = 9
                Printer.FontName = Screen.Fonts(12)
                Printer.FontSize = 9
                Page = 1
                Call Header(Page)

                IRow = 9
                While Not EOF(12)
            Input #12, SF1, SF2, SF3, SF4, SF5, SF6, SF7, SF8, SF9
                    IRow = IRow + 1
                    If IRow > 55 Then
                        IRow = 9
                        Printer.NewPage()
                        Page = Page + 1
                        Call Header(Page)
                    End If
                    SF1 = Format(SF1, "####0")
                    SF2 = Format(SF2, "###0.00")
                    SF3 = Format(SF3, "###0.00")
                    '            SF4 = Format(SF4, "###0.00")
                    SF5 = Format(SF5, "###0.00")
                    SF6 = Format(SF6, "###0.00")
                    SF7 = Format(SF7, "###0.00")
                    SF8 = Format(SF8, "###0")
                    '            SF9 = Format(SF9, "###0")
                    Printer.Print(SF1, SF2, SF3, SF5, SF6, SF7, SF4, SF8, SF9)
                End While

                Printer.EndDoc()
                Msg = "Finished SOA Print"
                Style = vbOKOnly
                Title = "Print Proc"
                Response = MsgBox(Msg, Style, Title)
            End If
        End If
   Close #12
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTypeProc1.CheckedChanged

   Open Map_filename For Input As #3
   Open Rej_filename For Output As #11
   Open Tmp_filename For Output As #22
        '
        Do While Not EOF(3)
      Input #3, Pnt, iX, iY, iZ, Desc
            If optTypeProc7 = True Then
                If Mid(Desc, 1, 3) = "CBN" Or Mid(Desc, 1, 2) = "DI" Or _
                   Mid(Desc, 1, 3) = "MHD" Or Mid(Desc, 1, 3) = "MHS" Or _
                   Mid(Desc, 1, 3) = "ODL" Or Mid(Desc, 1, 2) = "P " Or _
                   Mid(Desc, 1, 2) = "PA" Or Mid(Desc, 1, 2) = "PB" Or _
                   Mid(Desc, 1, 3) = "P1A" Or Mid(Desc, 1, 3) = "P1B" Or _
                   Mid(Desc, 1, 3) = "P2A" Or Mid(Desc, 1, 3) = "P2B" Or _
                   Mid(Desc, 1, 3) = "P3A" Or Mid(Desc, 1, 3) = "P3B" Or _
                   Mid(Desc, 1, 3) = "P4A" Or Mid(Desc, 1, 3) = "P4B" Or _
                   Mid(Desc, 1, 3) = "BRC" Or Mid(Desc, 1, 3) = "BRW" Or _
                   Mid(Desc, 1, 3) = "CUL" Or Mid(Desc, 1, 2) = "HW" Or _
                   Mid(Desc, 1, 2) = "WW" Or Mid(Desc, 1, 2) = "JB" Then
            Write #11, Pnt, iX, iY, iZ, Desc
                ElseIf Mid(Desc, 1, 4) = "*CBN" Or Mid(Desc, 1, 3) = "*DI" Or _
                   Mid(Desc, 1, 4) = "*MHD" Or Mid(Desc, 1, 4) = "*MHS" Or _
                   Mid(Desc, 1, 4) = "*ODL" Or Mid(Desc, 1, 3) = "*P " Or _
                   Mid(Desc, 1, 3) = "*PA" Or Mid(Desc, 1, 3) = "*PB" Or _
                   Mid(Desc, 1, 4) = "*P1A" Or Mid(Desc, 1, 4) = "*P1B" Or _
                   Mid(Desc, 1, 4) = "*P2A" Or Mid(Desc, 1, 4) = "*P2B" Or _
                   Mid(Desc, 1, 4) = "*P3A" Or Mid(Desc, 1, 4) = "*P3B" Or _
                   Mid(Desc, 1, 4) = "*P4A" Or Mid(Desc, 1, 4) = "*P4B" Or _
                   Mid(Desc, 1, 4) = "*BRC" Or Mid(Desc, 1, 4) = "*BRW" Or _
                   Mid(Desc, 1, 4) = "*CUL" Or Mid(Desc, 1, 3) = "*HW" Or _
                   Mid(Desc, 1, 3) = "*WW" Or Mid(Desc, 1, 3) = "*JB" Then
            Write #11, Pnt, iX, iY, iZ, Desc
                End If
            Else
                If chkPnt = False And IsNumeric(Pnt) And Mid(Desc, 1, 1) <> "*" Then
            Write #11, Pnt, iX, iY, iZ, Desc
                End If
            End If
        Loop

   Close #11
   Close #3
        '
   Open Aln_filename For Input As #4
        '
        frmSoaTypeProcInp.Show(vbModal, Me)
        '
   Close #4

   Close #12


    End Sub
End Class