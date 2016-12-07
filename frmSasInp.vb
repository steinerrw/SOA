Option Strict Off
Option Explicit Off

Imports System.Math
'Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmSasInp
	Inherits System.Windows.Forms.Form
	
    Private Sub frmSasInp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        mnuWithSOE.Visible = False
        mnuSasPrint.Visible = False

        idxCnt = 0

        FileOpen(2, New_Filename, OpenMode.Input)
        FileOpen(4, Aln_Filename, OpenMode.Output)
        FileOpen(5, Pnt_Filename, OpenMode.Append)
        FileOpen(6, SasRpt_Filename, OpenMode.Output)
        FileOpen(11, Cla_Filename, OpenMode.Output)
        '
        WriteLine(6, "Survey File :", New_Filename, " Control Points Listing", "", "", "")
        WriteLine(6, "Point", "X Coord", "Y Coord", "Z Coord", "Description", "")
        '
        '   Line Input(2, Record
        Do While Not EOF(2)
            Record = LineInput(2)
            If Mid(Record, 1, 1) <> "*" And Len(Record) > 0 Then
                Pnt = CShort(Str(CDbl(Mid(Record, 1, 5))))
                Desc = Mid(Record, 49, 20)
                iY = CDbl(Str(CDbl(Mid(Record, 7, 13))))
                iX = CDbl(Str(CDbl(Mid(Record, 21, 13))))
                iZ = CDbl(Str(CDbl(Mid(Record, 35, 13))))

                'write  #11 .cla File
                If Mid(Record, 49, 2) = "CL" Or Mid(Record, 49, 3) = "CLP" And Pnt > 0 Then
                    WriteLine(11, Pnt, iX, iY, iZ, Desc)
                End If
                'write  #5 .pnt File
                If Mid(Record, 49, 2) = "XR" Or Mid(Record, 49, 2) = "XL" And Pnt > 0 Then
                    WriteLine(5, Pnt, iX, iY, iZ, Desc)
                End If
                'load array from .pnt File
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
        FileOpen(1, Alg_Filename, OpenMode.Append)
        MySize = LOF(1)
        FileClose(1)
        If MySize = 0 Then
            FileOpen(1, Alg_Filename, OpenMode.Append)
        Else
            FileOpen(1, Alg_Filename, OpenMode.Input)
            While Not EOF(1)
                Input(1, RecType)
                Input(1, Col1)
                Input(1, Col2)
                Input(1, Col3)
                Input(1, Col4)
                Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
                lstSAS_Data.Items.Add(Entry)
            End While
        End If
        FileClose(1)
        cmdReplace.Visible = False
        cmdAdd.Visible = True
        Save_Flag = "N"
    End Sub

    Private Sub cmdAdd_Click()
        If optType1.AutoCheck = True Then
            Call Desc_Proc()
            RC = "Y"
        ElseIf optType2.AutoCheck = True Then
            Call Line_Proc()
        ElseIf optType3.AutoCheck = True Then
            Call Curve_Proc()
        End If
        If RC = "Y" Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
            lstSAS_Data.Items.Add(Entry)
            Col1 = ""
            Col2 = ""
            Col3 = ""
            Col4 = ""

            optType.Visible = True
            optType1.Checked = False
            optType2.Checked = False
            optType3.Checked = False
            optType1.Visible = True
            optType2.Visible = True
            optType3.Visible = True

            lstSAS_Data.Refresh()
        End If
        Save_Flag = "Y"
    End Sub

    Private Sub cmdReplace_Click()
        If optType1.AutoCheck = True Then
            Call Desc_Proc()
            RC = "Y"
        ElseIf optType2.AutoCheck = True Then
            Call Line_Proc()
        ElseIf optType3.AutoCheck = True Then
            Call Curve_Proc()
        End If

        If RC = "Y" Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
            lstSAS_Data.Items.RemoveAt(lstSAS_Data.SelectedIndex)
            lstSAS_Data.Items.Insert(lstIndex, Entry)
            Col1 = ""
            Col2 = ""
            Col3 = ""
            Col4 = ""

            optType.Visible = True
            optType1.Checked = False
            optType2.Checked = False
            optType3.Checked = False
            optType1.Visible = True
            optType2.Visible = True
            optType3.Visible = True

            lstSAS_Data.Refresh()
        End If
        Save_Flag = "Y"
        cmdAdd.Visible = True
        cmdReplace.Visible = False
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
            txtPnt1.Focus()
            Focus_Flag = "Y"
        End If
        Col2 = txtPnt2.Text
        Call Alignment.Point_Check(Val(Col2), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt2.Text = ""
            If Focus_Flag = "N" Then
                txtPnt2.Focus()
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
        If optCurve1.AutoCheck = True Then
            RecType = "C0"
            Call Curve_Pnt_Proc(3)
        ElseIf optCurve2.AutoCheck = True Then
            RecType = "C1"
            Call Curve_Pnt_Proc(3)
        ElseIf optCurve3.AutoCheck = True Then
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

            optCurve.Visible = False
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
            txtPnt1.Focus()
            Focus_Flag = "Y"
        End If
        Col2 = txtPnt2.Text
        Call Point_Check(Val(Col2), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt2.Text = ""
            If Focus_Flag = "N" Then
                txtPnt2.Focus()
                Focus_Flag = "Y"
            End If
        End If
        Col3 = txtPnt3.Text
        Call Point_Check(Val(Col3), RC, idx_Pnt, idxCnt)
        If RC = "N" Then
            txtPnt3.Text = ""
            If Focus_Flag = "N" Then
                txtPnt3.Focus()
                Focus_Flag = "Y"
            End If
        End If
        If numPnt = 4 Then
            Col4 = txtPnt4.Text
            Call Point_Check(Val(Col4), RC, idx_Pnt, idxCnt)
            If RC = "N" Then
                txtPnt4.Text = ""
                If Focus_Flag = "N" Then
                    txtPnt4.Focus()
                    Focus_Flag = "Y"
                End If
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click()
        If optType1.AutoCheck = True Then
            txtDescription.Text = ""
            txtAlignment.Text = ""
            txtStation.Text = ""
            txtDescription.Focus()
        ElseIf optType2.AutoCheck = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.Focus()
        ElseIf optType3.AutoCheck = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.Focus()
        End If
        cmdAdd.Visible = True
        cmdReplace.Visible = False
    End Sub

    Private Sub cmdDelete_Click()
        lstSAS_Data.Items.RemoveAt(lstSAS_Data.SelectedIndex)
        lstSAS_Data.Refresh()
    End Sub

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
        '        Me.FileClose()
    End Sub

    Private Sub ReformData(sList, RecType, Col1, Col2, Col3, Col4)
        Pos1 = InStr(1, sList, "* ", 0)
        Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
        Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
        Pos4 = InStr(Pos3 + 2, sList, "* ", 0)
        Pos5 = InStr(Pos4 + 2, sList, "*", 0)

        RecType = Mid(sList, 1, Pos1 - 1)
        Col1 = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
        Col2 = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
        Col3 = Mid(sList, Pos3 + 2, Pos4 - Pos3 - 2)
        Col4 = Mid(sList, Pos4 + 2, Pos5 - Pos4 - 2)
    End Sub

    Private Sub cmdSave_Click()
        Dim I As Short
        FileOpen(30, My.Application.Info.DirectoryPath & "\tmp.dat", OpenMode.Output)
        For I = 0 To lstSAS_Data.Items.Count - 1
            sList = lstSAS_Data.Items.Item(index:=I)
            Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
            WriteLine(30, RecType, Col1, Col2, Col3, Col4)
        Next I

        FileClose(30)

        FileOpen(1, Alg_Filename, OpenMode.Output)
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

    Private Sub lstSAS_Data_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmdReplace.Visible = True
        cmdAdd.Visible = False

        sList = lstSAS_Data.Items.Item(lstSAS_Data.SelectedIndex)
        lstIndex = lstSAS_Data.SelectedIndex
        Pos1 = InStr(1, sList, "* ", 0)

        RecType = Mid(sList, 1, Pos1 - 1)
        If RecType = "D" Then
            optType1.AutoCheck = True

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
            optType2.AutoCheck = True

            txtDescription.Enabled = False
            txtAlignment.Enabled = False
            txtStation.Enabled = False
            comboUnits.Enabled = False

            lblPnt1.Text = "Beg Pnt"
            lblPnt2.Text = "End Pnt"
            txtPnt1.Visible = True
            txtPnt2.Visible = True
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = True
            lblPnt2.Visible = True
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            optCurve.Visible = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False

            Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
            Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
            txtPnt1.Text = Mid(sList, Pos1 + 2, Pos2 - Pos1 - 2)
            txtPnt2.Text = Mid(sList, Pos2 + 2, Pos3 - Pos2 - 2)
        ElseIf Mid(RecType, 1, 1) = "C" Then
            optType3.AutoCheck = True
            If Mid(RecType, 2, 1) = "0" Then
                optCurve1.AutoCheck = True
                lblPnt1.Text = "PC"
                lblPnt2.Text = "PI"
                lblPnt3.Text = "PT"
                txtPnt1.Visible = True
                txtPnt2.Visible = True
                txtPnt3.Visible = True
                txtPnt4.Visible = False
                lblPnt1.Visible = True
                lblPnt2.Visible = True
                lblPnt3.Visible = True
                lblPnt4.Visible = False
            ElseIf Mid(RecType, 2, 1) = "1" Then
                optCurve2.AutoCheck = True
                lblPnt1.Text = "PC"
                lblPnt2.Text = "POC"
                lblPnt3.Text = "PT"
                txtPnt1.Visible = True
                txtPnt2.Visible = True
                txtPnt3.Visible = True
                txtPnt4.Visible = False
                lblPnt1.Visible = True
                lblPnt2.Visible = True
                lblPnt3.Visible = True
                lblPnt4.Visible = False
            ElseIf Mid(RecType, 2, 1) = "2" Then
                optCurve3.AutoCheck = True
                lblPnt1.Text = "PC"
                lblPnt2.Text = "POST"
                lblPnt3.Text = "POST"
                lblPnt4.Text = "PT"
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

    Public Sub mnuRunAlign_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        For I = 0 To lstSAS_Data.Items.Count - 1
            sList = VB6.GetItemString(lstSAS_Data, I)
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
                sta(2) = sta(1) + Dist(x(1), y(1), x(2), y(2))
                ESta = sta(2)
                dY = y(2) - y(1)
                dX = x(2) - x(1)

                CC(1) = dY
                CC(1) = CDbl(Format(CC(1), "#####0.000"))
                CC(2) = -dX
                CC(2) = CDbl(Format(CC(2), "#####0.000"))
                CC(3) = -dY * x(1) + dX * y(1)
                CC(3) = CDbl(Format(CC(3), "#####0.000"))

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
                    x(K) = CDbl(Format(x(K), "#####0.000"))
                    y(K) = CDbl(Format(y(K), "#####0.000"))
                    z(K) = CDbl(Format(z(K), "#####0.000"))
                    sta(K) = CDbl(Format(sta(K), "#####0.000"))
                    WriteLine(6, LDesc(K), x(K), y(K), z(K), sta(K), "")
                Next K
                '
                WriteLine(4, Align, ElemArray(NumElem), Desc, x(1), y(1), x(2), y(2), x(3), y(3), sta(1), sta(2), sta(3), CC(1), CC(2), CC(3), DirArray(NumElem))
                '
                Length = CDbl(Format(Length, "#####0.000"))
                Bearing = Format(Bearing, "#####0.000")
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
                TanLen = Dist(x(1), y(1), x(2), y(2))
                TanLen = CDbl(Format(TanLen, "#####0.000"))
                ChdLen = Dist(x(1), y(1), x(3), y(3))
                ChdLen = CDbl(Format(ChdLen, "#####0.000"))
                ExtLen = Dist(x0, y0, x(2), y(2)) - rad
                ExtLen = CDbl(Format(ExtLen, "#####0.000"))
                curveLength = rad * Ang
                curveLength = CDbl(Format(curveLength, "#####0.000"))
                Angle = Rad2Deg(Ang)
                Call DdmmssConv(Angle, Delta)
                sta(1) = ESta
                sta(2) = ESta + Dist(x(1), y(1), x(2), y(2))
                sta(3) = ESta + curveLength
                ESta = sta(3)

                CC(1) = x0
                CC(1) = CDbl(Format(CC(1), "#####0.000"))
                CC(2) = y0
                CC(2) = CDbl(Format(CC(2), "#####0.000"))
                CC(3) = rad
                CC(3) = CDbl(Format(CC(3), "#####0.000"))

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
                    x(K) = CDbl(Format(x(K), "#####0.000"))
                    y(K) = CDbl(Format(y(K), "#####0.000"))
                    z(K) = CDbl(Format(z(K), "#####0.000"))
                    sta(K) = CDbl(Format(sta(K), "#####0.000"))
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

    Public Sub mnuWithSOE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

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
        lstSAS_Data.Visible = False
        optType.Visible = False
        optCurve.Visible = False

        txtBegAlign.Visible = True
        lblBegAlign.Visible = True
        txtGP3Cnt.Visible = True
        lblGP3Cnt.Visible = True
        cmdProcess.Visible = True
        VB6.SetDefault(cmdProcess, True)
        txtBegAlign.Focus()

        '   FileOpen SasRpt_Filename For Append As #6
        '   FileOpen XYZ_Filename For Output As #7
        '   FileOpen GP3_Filename For Output As #20
        '
        '   FileOpen SOE_Filename For Input As #8
        '   FileOpen SOR_Filename For Output As #14

        IReturn = Shell("c:\soesort.bat" & " " & SOE_Filename & " " & " " & SOR_Filename)

        '   While Not EOF(8)
        '      Line Input(8, Record
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
        '            lstSOESort.Items.Add Entry
        '         End If
        '      End If
        '   Wend
        '   FileClose(8
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
        '      Write(14, SoePnt, SoeSta, SoeOff, SoeElv, SoeDesc
        '   Next Cnt
        '   FileClose(14
        '
    End Sub

    Private Sub cmdProcess_Click()
        '
        FileOpen(6, SasRpt_Filename, OpenMode.Append)
        FileOpen(7, XYZ_Filename, OpenMode.Output)
        FileOpen(20, GP3_Filename, OpenMode.Output)
        '
        FileOpen(10, SO1_Filename, OpenMode.Output)
        FileOpen(14, SOR_Filename, OpenMode.Input)

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
        lstSAS_Data.Visible = True
        optType.Visible = True

        FileClose(6)
        FileClose(10)
        FileClose(14)
    End Sub

    Public Sub mnuSasPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSasPrint.Click
        Dim Printer As New Printer
        Dim Font As New Font("Currier New", 10)

        Msg = "Continue Printing"
        Style = CStr(MsgBoxStyle.YesNo)
        Title = "Print Proc"
        Response = CStr(MsgBox(Msg, CDbl(Style), Title))

        FileOpen(6, SasRpt_Filename, OpenMode.Input)

        If Response = CStr(MsgBoxResult.No) Then
            Printer.KillDoc() ' Terminate print job abruptly.
            Printer.EndDoc()
        Else
            If Response = CStr(MsgBoxResult.Yes) Then
                Printer.Orientation = 1 ' Portrait orientation
                Printer.Font = Font
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
                            WriteLine(12, F1a, F2a, F3a, F4a, F5a, F6a)
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
                    WriteLine(12, F1, F2, F3, F4, F5, F6)
                End While

                Printer.EndDoc()
                Msg = "Finished SAS Print"
                Style = CStr(MsgBoxStyle.OkOnly)
                Title = "Print Proc"
                Response = CStr(MsgBox(Msg, CDbl(Style), Title))
            End If
        End If
    End Sub

    Private Sub Header(Page)
        Dim Printer As New Printer

        MyDate = "Date:" & Now
        MyPage = "Page:" & Page
        WriteLine(12, "                                                                                " & MyPage)
        WriteLine(12, "")
        WriteLine(12, "                            SOUTH CAROLINA DEPARTMENT OF TRANSPORTATION")
        WriteLine(12, "")
        WriteLine(12, "                                     SURVEY AUTOMATION SYSTEM")
        WriteLine(12, "")
        WriteLine(12, "                         VERSION:WIN/NT 2.0                         " & MyDate)
        WriteLine(12, "")
        WriteLine(12, "====================================================================================================")
    End Sub

    Private Sub optType1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optType1.CheckedChanged
        txtPnt1.Text = ""
        txtPnt2.Text = ""
        txtPnt3.Text = ""
        txtPnt4.Text = ""
        lblPnt1.Text = "PC"
        lblPnt2.Text = "PI"
        lblPnt3.Text = "PT"
        txtPnt1.Visible = True
        txtPnt2.Visible = True
        txtPnt3.Visible = True
        txtPnt4.Visible = False
        lblPnt1.Visible = True
        lblPnt2.Visible = True
        lblPnt3.Visible = True
        lblPnt4.Visible = False
    End Sub

    Private Sub optType2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optType2.CheckedChanged
        txtPnt1.Text = ""
        txtPnt2.Text = ""
        txtPnt3.Text = ""
        txtPnt4.Text = ""
        lblPnt1.Text = "PC"
        lblPnt2.Text = "POC"
        lblPnt3.Text = "PT"
        txtPnt1.Visible = True
        txtPnt2.Visible = True
        txtPnt3.Visible = True
        txtPnt4.Visible = False
        lblPnt1.Visible = True
        lblPnt2.Visible = True
        lblPnt3.Visible = True
        lblPnt4.Visible = False
    End Sub

    Private Sub optType3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optType3.CheckedChanged
        txtPnt1.Text = ""
        txtPnt2.Text = ""
        txtPnt3.Text = ""
        txtPnt4.Text = ""
        lblPnt1.Text = "PC"
        lblPnt2.Text = "POST1"
        lblPnt3.Text = "POST2"
        lblPnt4.Text = "PT"
        txtPnt1.Visible = True
        txtPnt2.Visible = True
        txtPnt3.Visible = True
        txtPnt4.Visible = True
        lblPnt1.Visible = True
        lblPnt2.Visible = True
        lblPnt3.Visible = True
        lblPnt4.Visible = True
    End Sub

    Private Sub optCurve1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCurve1.CheckedChanged
        Focus_Flag = "N"
        RecType = "C0"
        Call Curve_Pnt_Proc(3)

        If RC = "Y" Then
            txtPnt1.Visible = False
            txtPnt2.Visible = False
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = False
            lblPnt2.Visible = False
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            optCurve.Visible = False
            optCurve1.AutoCheck = False
            optCurve2.AutoCheck = False
            optCurve3.AutoCheck = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False
        End If
    End Sub

    Private Sub optCurve2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCurve1.CheckedChanged
        Focus_Flag = "N"
        RecType = "C1"
        Call Curve_Pnt_Proc(3)

        If RC = "Y" Then
            txtPnt1.Visible = False
            txtPnt2.Visible = False
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = False
            lblPnt2.Visible = False
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            optCurve.Visible = False
            optCurve1.AutoCheck = False
            optCurve2.AutoCheck = False
            optCurve3.AutoCheck = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False
        End If

    End Sub
    Private Sub optCurve3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCurve1.CheckedChanged
        Focus_Flag = "N"
        RecType = "C2"
        Call Curve_Pnt_Proc(4)

        If RC = "Y" Then
            txtPnt1.Visible = False
            txtPnt2.Visible = False
            txtPnt3.Visible = False
            txtPnt4.Visible = False
            lblPnt1.Visible = False
            lblPnt2.Visible = False
            lblPnt3.Visible = False
            lblPnt4.Visible = False

            optCurve.Visible = False
            optCurve1.AutoCheck = False
            optCurve2.AutoCheck = False
            optCurve3.AutoCheck = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False
        End If
    End Sub

    Private Sub Curve_Pnt_Proc(numPnt As Integer)
        Col1 = txtPnt1.Text
        Call Point_Check(Val(Col1), RC, idx_Pnt(numPnt), idxCnt)
        If RC = "N" Then
            txtPnt1.Text = ""
            txtPnt1.Focus()
            Focus_Flag = "Y"
        End If
        Col2 = txtPnt2.Text
        Call Point_Check(Val(Col2), RC, idx_Pnt(numPnt), idxCnt)
        If RC = "N" Then
            txtPnt2.Text = ""
            If Focus_Flag = "N" Then
                txtPnt2.Focus()
                Focus_Flag = "Y"
            End If
        End If
        Col3 = txtPnt3.Text
        Call Point_Check(Val(Col3), RC, idx_Pnt(numPnt), idxCnt)
        If RC = "N" Then
            txtPnt3.Text = ""
            If Focus_Flag = "N" Then
                txtPnt3.Focus()
                Focus_Flag = "Y"
            End If
        End If
        If numPnt = 4 Then
            Col4 = txtPnt4.Text
            Call Point_Check(Val(Col4), RC, idx_Pnt, idxCnt)
            If RC = "N" Then
                txtPnt4.Text = ""
                If Focus_Flag = "N" Then
                    txtPnt4.Focus()
                    Focus_Flag = "Y"
                End If
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        If optType1.AutoCheck = True Then
            txtDescription.Text = ""
            txtAlignment.Text = ""
            txtStation.Text = ""
            txtDescription.Focus()
        ElseIf optType2.AutoCheck = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.Focus()
        ElseIf optType3.AutoCheck = True Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            txtPnt1.Focus()
        End If
        cmdAdd.Visible = True
        cmdReplace.Visible = False
    End Sub

    Private Sub cmdDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelete.Click
        lstSAS_Data.Items.Remove(lstSAS_Data.SelectedItem)
        lstSAS_Data.Refresh()
    End Sub

    Private Sub cmdQuit_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuit.Click
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
        Dispose()
    End Sub

    Private Sub ReformData(sList As IList, RecType As String, Col1 As String, Col2 As String, Col3 As String, Col4 As String)
        Pos1 = InStr(1, sList, "* ", 0)
        Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
        Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
        Pos4 = InStr(Pos3 + 2, sList, "* ", 0)
        Pos5 = InStr(Pos4 + 2, sList, "*", 0)

        RecType = Mid(sList, 1, (Pos1 - 1))
        Col1 = Mid(sList, Pos1 + 2, (Pos2 - Pos1 - 2))
        Col2 = Mid(sList, Pos2 + 2, (Pos3 - Pos2 - 2))
        Col3 = Mid(sList, Pos3 + 2, (Pos4 - Pos3 - 2))
        Col4 = Mid(sList, Pos4 + 2, (Pos5 - Pos4 - 2))
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim I As Integer
        FileOpen(30, "tmp.dat", OpenMode.Output)
        For I = 0 To lstSAS_Data.Items.Count - 1
            sList = lstSAS_Data.SelectedItem(I)
            Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
            Write(30, RecType, Col1, Col2, Col3, Col4)
        Next I

        FileClose(30)

        FileOpen(1, Alg_Filename, OpenMode.Output)
        FileOpen(30, "tmp.dat", OpenMode.Input)
        Input(30, RecType)
        Input(30, Col1)
        Input(30, Col2)
        Input(30, Col3)
        Input(30, Col4)
        While Not EOF(30)
            Write(1, RecType, Col1, Col2, Col3, Col4)
            Input(30, RecType)
            Input(30, Col1)
            Input(30, Col2)
            Input(30, Col3)
            Input(30, Col4)
        End While
        ' write last record...
        Write(1, RecType, Col1, Col2, Col3, Col4)
        FileClose(1)
        FileClose(30)
        Kill("\tmp.dat")
        Save_Flag = "N"
    End Sub
End Class