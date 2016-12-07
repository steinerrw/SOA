Option Strict Off
Option Explicit Off
'Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmSoaInp
	Inherits System.Windows.Forms.Form

    Dim lstSASData As Object

	Private Sub frmSoaInp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        FileOpen(9, SoaRpt_Filename, OpenMode.Output)
        FileOpen(12, Vld_Filename, OpenMode.Output)
        FileOpen(3, Map_Filename, OpenMode.Append)
        MySize = LOF(3)

        FileClose(3)
        If MySize = 0 Then
            Call CreateMap()
        End If

        Call CreateIdx()

        mnuPrint.Enabled = False

        FileOpen(1, Alg_Filename, OpenMode.Append)
        MySize = LOF(1)
        FileClose(1)
        If MySize = 0 Then
            Msg = "Missing ALG File. Please run the SAS option to create File."
            Style = CStr(MsgBoxResult.OK)
            Title = "File Processing Error"
            Response = CStr(MsgBox(Msg, CDbl(Style), Title))
        Else
            FileOpen(1, Alg_Filename, OpenMode.Input)
            Input(1, RecType)
            Input(1, Desc)
            Input(1, Align)
            Input(1, sta)
            Input(1, Units)
            wUnits = Units
            FileClose(1)
        End If
        FileOpen(4, Aln_Filename, OpenMode.Append)
        MySize = LOF(4)
        FileClose(4)
        If MySize = 0 Then
            Msg = "Missing ALN File. Please run the SAS option to create File."
            Style = CStr(MsgBoxResult.OK)
            Title = "File Processing Error"
            Response = CStr(MsgBox(Msg, CDbl(Style), Title))
        Else
            FileOpen(4, Aln_Filename, OpenMode.Input)
            AlnCntr = 1
            Do While Not EOF(4)
                Input(4, AlignNM(AlnCntr))
                Input(4, ElemTyp(AlnCntr))
                Input(4, AlgDesc(AlnCntr))
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
                If AlnCntr > 200 Then
                    Msg = "Error Trying to Process to many Alignments."
                    Style = CStr(MsgBoxResult.OK)
                    Title = "Critical Error-Alignment Processing"
                    Response = CStr(MsgBox(Msg, CDbl(Style), Title))
                    FileClose()
                End If
                AlnCntr = AlnCntr + 1
            Loop
            FileClose(4)
            AlnCntr = AlnCntr - 1
        End If
        ' Set print parms
        txtFont.Text = CStr(3)
        If wUnits = "Metric" Then
            txtWidth.Text = CStr(2)
            txtHight.Text = CStr(2)
        Else
            txtWidth.Text = CStr(5)
            txtHight.Text = CStr(5)
        End If
    End Sub

    Public Sub mnuPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrint.Click
        Dim Printer As New Printer
        Dim Font As New Font("Currier New", 9)

        Msg = "Continue Printing"
        Style = CStr(MsgBoxStyle.YesNo)
        Title = "Print Proc"
        Response = CStr(MsgBox(Msg, CDbl(Style), Title))

        FileOpen(12, Vld_Filename, OpenMode.Input)

        If Response = CStr(MsgBoxResult.No) Then
            Printer.KillDoc() ' Terminate print job abruptly.
            Printer.EndDoc()
        Else
            If Response = CStr(MsgBoxResult.Yes) Then
                Printer.Orientation = 2 ' Portrait orientation
                Printer.Font = Font
                Page = 1
                Call Header(Page)

                IRow = 9
                While Not EOF(12)
                    Input(12, SF1)
                    Input(12, SF2)
                    Input(12, SF3)
                    Input(12, SF4)
                    Input(12, SF5)
                    Input(12, SF6)
                    Input(12, SF7)
                    Input(12, SF8)
                    Input(12, SF9)
                    IRow = IRow + 1
                    If IRow > 55 Then
                        IRow = 9
                        Printer.NewPage()
                        Page = Page + 1
                        Call Header(Page)
                    End If
                    SF1 = CShort(Format(SF1, "####0"))
                    SF2 = CDbl(Format(SF2, "###0.00"))
                    SF3 = CDbl(Format(SF3, "###0.00"))
                    '            SF4 = Format(SF4, "###0.00")
                    SF5 = Format(SF5, "###0.00")
                    SF6 = Format(SF6, "###0.00")
                    SF7 = CDbl(Format(SF7, "###0.00"))
                    SF8 = CShort(Format(SF8, "###0"))
                    '            SF9 = Format(SF9, "###0")
                    Printer.Print(SF1, SF2, SF3, SF5, SF6, SF7, SF4, SF8, SF9)
                End While

                Printer.EndDoc()
                Msg = "Finished SOA Print"
                Style = CStr(MsgBoxStyle.OKOnly)
                Title = "Print Proc"
                Response = CStr(MsgBox(Msg, CDbl(Style), Title))
            End If
        End If
        FileClose(12)
    End Sub

    Private Sub optTypeProc_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optTypeProc.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = optTypeProc.GetIndex(eventSender)

            FileOpen(3, Map_Filename, OpenMode.Input)
            FileOpen(11, Rej_Filename, OpenMode.Output)
            FileOpen(22, Tmp_Filename, OpenMode.Output)
            '
            Do While Not EOF(3)
                Input(3, Pnt)
                Input(3, iX)
                Input(3, iY)
                Input(3, iZ)
                Input(3, Desc)
                If optTypeProc(6).AutoCheck = True Then
                    If Mid(Desc, 1, 3) = "CBN" Or Mid(Desc, 1, 2) = "DI" Or Mid(Desc, 1, 3) = "MHD" Or Mid(Desc, 1, 3) = "MHS" Or Mid(Desc, 1, 3) = "ODL" Or Mid(Desc, 1, 2) = "P " Or Mid(Desc, 1, 2) = "PA" Or Mid(Desc, 1, 2) = "PB" Or Mid(Desc, 1, 3) = "P1A" Or Mid(Desc, 1, 3) = "P1B" Or Mid(Desc, 1, 3) = "P2A" Or Mid(Desc, 1, 3) = "P2B" Or Mid(Desc, 1, 3) = "P3A" Or Mid(Desc, 1, 3) = "P3B" Or Mid(Desc, 1, 3) = "P4A" Or Mid(Desc, 1, 3) = "P4B" Or Mid(Desc, 1, 3) = "BRC" Or Mid(Desc, 1, 3) = "BRW" Or Mid(Desc, 1, 3) = "CUL" Or Mid(Desc, 1, 2) = "HW" Or Mid(Desc, 1, 2) = "WW" Or Mid(Desc, 1, 2) = "JB" Then
                        WriteLine(11, Pnt, iX, iY, iZ, Desc)
                    ElseIf Mid(Desc, 1, 4) = "*CBN" Or Mid(Desc, 1, 3) = "*DI" Or Mid(Desc, 1, 4) = "*MHD" Or Mid(Desc, 1, 4) = "*MHS" Or Mid(Desc, 1, 4) = "*ODL" Or Mid(Desc, 1, 3) = "*P " Or Mid(Desc, 1, 3) = "*PA" Or Mid(Desc, 1, 3) = "*PB" Or Mid(Desc, 1, 4) = "*P1A" Or Mid(Desc, 1, 4) = "*P1B" Or Mid(Desc, 1, 4) = "*P2A" Or Mid(Desc, 1, 4) = "*P2B" Or Mid(Desc, 1, 4) = "*P3A" Or Mid(Desc, 1, 4) = "*P3B" Or Mid(Desc, 1, 4) = "*P4A" Or Mid(Desc, 1, 4) = "*P4B" Or Mid(Desc, 1, 4) = "*BRC" Or Mid(Desc, 1, 4) = "*BRW" Or Mid(Desc, 1, 4) = "*CUL" Or Mid(Desc, 1, 3) = "*HW" Or Mid(Desc, 1, 3) = "*WW" Or Mid(Desc, 1, 3) = "*JB" Then
                        WriteLine(11, Pnt, iX, iY, iZ, Desc)
                    End If
                Else
                    If chkPnt.CheckState = False And IsNumeric(Pnt) And Mid(Desc, 1, 1) <> "*" Then
                        WriteLine(11, Pnt, iX, iY, iZ, Desc)
                    End If
                End If
            Loop

            FileClose(11)
            FileClose(3)
            '
            FileOpen(4, Aln_Filename, OpenMode.Input)
            '
            VB6.ShowForm(frmSoaTypeProcInp, VB6.FormShowConstants.Modal, Me)
            '
            FileClose(4)

            FileClose(12)

        End If
    End Sub

    Private Sub cmdQuit_Click()
        FileClose(3)
        FileClose(9)
        FileClose(12)
        FileClose(22)
        '        Me.FileClose()
    End Sub

    Private Sub cmdPrint_Click()
        wFont = CShort(txtFont.Text)
        wWidth = CShort(txtWidth.Text)
        wHight = CShort(txtHight.Text)
        Call Output()
    End Sub

    Private Sub cmdReplace_Click(sender As System.Object, e As System.EventArgs) Handles cmdReplace.Click
        If optType1.checked Then
            Call Desc_Proc()
            RC = "Y"
        ElseIf optType2.checked Then
            Call Line_Proc()
        ElseIf optType3.checked Then
            Call Curve_Proc()
        End If

        If RC = "Y" Then
            txtPnt1.Text = ""
            txtPnt2.Text = ""
            txtPnt3.Text = ""
            txtPnt4.Text = ""
            Entry = RecType & "* " & Col1 & "* " & Col2 & "* " & Col3 & "* " & Col4 & "*"
            lstSOAData.Items.Remove(lstSOAData.SelectedItem)
            lstSOAData.Items.Add(Entry(lstIndex))
            Col1 = ""
            Col2 = ""
            Col3 = ""
            Col4 = ""

            frameType.Visible = True
            optType1.AutoCheck = False
            optType2.AutoCheck = False
            optType3.AutoCheck = False
            optType1.Visible = True
            optType2.Visible = True
            optType3.Visible = True

            lstSASData.Refresh()
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


    Private Sub cmdDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelete.Click
        lstSOAData.Items.Remove(lstSOAData.SelectedItem)
        lstSOAData.Refresh()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim I As Integer
        FileOpen(30, "..\tmp.dat", OpenMode.Output)
        For I = 0 To lstSOAData.Items.Count - 1
            sList = lstSOAData.Items(I)
            Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
            Write(30, RecType, Col1, Col2, Col3, Col4)
        Next I
        FileClose(30)

        FileOpen(1, Alg_Filename, OpenMode.Output)
        FileOpen(30, "..\tmp.dat", OpenMode.Input)
        Input(30, RecType, Col1, Col2, Col3, Col4)
        While Not EOF(30)
            Write(1, RecType, Col1, Col2, Col3, Col4)
            Input(30, RecType, Col1, Col2, Col3, Col4)
        End While
        ' write last record...
        Write(1, RecType, Col1, Col2, Col3, Col4)
        FileClose(1)
        FileClose(30)
        Kill("..\tmp.dat")
        Save_Flag = "N"
    End Sub

    Private Sub lstSOAData_Click()
        cmdReplace.Visible = True
        cmdNewAlign.Visible = False

        sList = lstSOAData.SelectedIndex
        lstIndex = lstSASData.ListIndex
        Dim tmpStr = sList
        Pos1 = InStr(1, sList, "* ", 0)

        RecType = Mid(sList, 1, (Pos1 - 1))
        If RecType = "D" Then
            optType1.AutoCheck = True

            Pos2 = InStr(Pos1 + 2, tmpStr, "* ", 0)
            Pos3 = InStr(Pos2 + 2, tmpStr, "* ", 0)
            Pos4 = InStr(Pos3 + 2, tmpStr, "* ", 0)
            Pos5 = InStr(Pos4 + 2, tmpStr, "*", 0)
            Description = Mid(tmpStr, Pos1 + 2, (Pos2 - Pos1 - 2))
            DAlignment = Mid(tmpStr, Pos2 + 2, (Pos3 - Pos2 - 2))
            Station = Mid(tmpStr, Pos3 + 2, (Pos4 - Pos3 - 2))
            Units = Mid(tmpStr, Pos4 + 2, (Pos5 - Pos4 - 2))
            txtDescription.Text = Description
            txtDescription.Enabled = True
            txtAlignment.Text = DAlignment
            txtAlignment.Enabled = True
            txtStation.Text = Station
            txtStation.Enabled = True
            comboUnits.Text = Units
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

            frameCurve.Visible = False
            optCurve1.Visible = False
            optCurve2.Visible = False
            optCurve3.Visible = False

            Pos2 = InStr(Pos1 + 2, sList, "* ", 0)
            Pos3 = InStr(Pos2 + 2, sList, "* ", 0)
            Pnt1 = Mid(sList, Pos1 + 2, (Pos2 - Pos1 - 2))
            txtPnt1.Text = Pnt1
            Pnt2 = Mid(sList, Pos2 + 2, (Pos3 - Pos2 - 2))
            txtPnt2.Text = Pnt2
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
            Pnt1 = Mid(sList, Pos1 + 2, (Pos2 - Pos1 - 2))
            Pnt2 = Mid(sList, Pos2 + 2, (Pos3 - Pos2 - 2))
            Pnt3 = Mid(sList, Pos3 + 2, (Pos4 - Pos3 - 2))
            Pnt4 = Mid(sList, Pos4 + 2, (Pos5 - Pos4 - 2))
            txtPnt1.Text = Pnt1
            txtPnt2.Text = Pnt2
            txtPnt2.Text = Pnt3
            txtPnt4.Text = Pnt4
        End If
    End Sub

    Private Sub RunAlignmentToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RunAlignmentToolStripMenuItem1.Click
        For I = 0 To lstSOAData.Items.Count - 1
            sList = lstSOAData.Items(I)
            If Mid(sList, 1, 1) = "D" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                Desc = Col1
                bsta = Str(Col3)
                ESta = bsta
                Align = Str(Col2)
                Write(6, "", "", "", "", "", "")
                Write(6, "", "", "", "", "", "")
                Write(6, "", "", "", "", "", "")
                Write(6, "Description of Alignment", Align, Desc, "", "", "")
                Write(6, "", "", "", "", "", "")
            ElseIf Mid(sList, 1, 1) = "L" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                NPT = 2
                LDesc(1) = "BP"
                LDesc(2) = "EP"
                IPN(1) = Str(Col1)
                IPN(2) = Str(Col2)
                Call Find_XYZ(IPN, x, y, z, NPT)
                sta(1) = ESta
                sta(2) = sta(1) + Dist(x(1), y(1), x(2), y(2))
                ESta = sta(2)
                dY = y(2) - y(1)
                dX = x(2) - x(1)

                CC(1) = dY
                CC(1) = Format(CC(1), "#####0.000")
                CC(2) = -dX
                CC(2) = Format(CC(2), "#####0.000")
                CC(3) = -dY * x(1) + dX * y(1)
                CC(3) = Format(CC(3), "#####0.000")

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
                Write(6, "", "", "", "", "", "")
                Write(6, "LINE ELEMENT", "", "", "", "", "")
                Write(6, "", "", "", "", "", "")
                Write(6, "Point", "X", "Y", "Z", "STA", "")
                For K = 1 To NPT
                    x(K) = Format(x(K), "#####0.000")
                    y(K) = Format(y(K), "#####0.000")
                    z(K) = Format(z(K), "#####0.000")
                    sta(K) = Format(sta(K), "#####0.000")
                    Write(6, LDesc(K), x(K), y(K), z(K), sta(K), "")
                Next K
                '
                Write(4, Align, ElemArray(NumElem), Desc, _
                   x(1), y(1), x(2), y(2), x(3), y(3), _
                   sta(1), sta(2), sta(3), _
                   CC(1), CC(2), CC(3), _
                   DirArray(NumElem))
                '
                Length = Format(Length, "#####0.000")
                Bearing = Format(Bearing, "#####0.000")
                Write(6, "Length=", Length, "Bearing=", Bearing, "", "")
                '
            ElseIf Mid(sList, 1, 1) = "C" Then
                Call ReformData(sList, RecType, Col1, Col2, Col3, Col4)
                IPN(1) = Str(Col1)
                IPN(2) = Str(Col2)
                IPN(3) = Str(Col3)
                LDesc(1) = "PC"
                LDesc(2) = "PI"
                LDesc(3) = "PT"
                LDesc(4) = "CC"
                bsta = ESta
                ' process curve with PC,PI, PT
                If Mid(sList, 2, 1) = "0" Then
                    NPT = 3
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, Dir, rad)
                    ' process curve with PC,POC, PT
                ElseIf Mid(sList, 2, 1) = "1" Then
                    NPT = 3
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_PI_CC(IPN, x, y, NPT, xPI, yPI, Ang, Dir, rad)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, Dir, rad)
                    ' process curve with PC,POST, POST, PT
                ElseIf Mid(sList, 2, 1) = "2" Then
                    IPN(4) = Str(Col4)
                    NPT = 4
                    Call Find_XYZ(IPN, x, y, z, NPT)
                    Call Find_PI(IPN, x, y)
                    Call Find_POC(IPN, x, y, NPT, x0, y0, Ang, Dir, rad)
                End If
                TanLen = Dist(x(1), y(1), x(2), y(2))
                TanLen = Format(TanLen, "#####0.000")
                ChdLen = Dist(x(1), y(1), x(3), y(3))
                ChdLen = Format(ChdLen, "#####0.000")
                ExtLen = Dist(x0, y0, x(2), y(2)) - rad
                ExtLen = Format(ExtLen, "#####0.000")
                curveLength = rad * Ang
                curveLength = Format(curveLength, "#####0.000")
                Angle = Rad2Deg(Ang)
                Call DdmmssConv(Angle, Delta)
                sta(1) = ESta
                sta(2) = ESta + Dist(x(1), y(1), x(2), y(2))
                sta(3) = ESta + curveLength
                ESta = sta(3)

                CC(1) = x0
                CC(1) = Format(CC(1), "#####0.000")
                CC(2) = y0
                CC(2) = Format(CC(2), "#####0.000")
                CC(3) = rad
                CC(3) = Format(CC(3), "#####0.000")

                Angle = 5729.578 / rad
                Call DdmmssConv(Angle, Degree)
                Call Find_Bearing(x(1), y(1), x(2), y(2), Back)
                Call Find_Bearing(x(2), y(2), x(3), y(3), Ahead)

                NumElem = NumElem + 1
                TotElem = TotElem + 1
                AlignArray(NumElem) = Align
                ElemArray(NumElem) = "C"
                DirArray(NumElem) = Dir()
                For J = 1 To 3
                    XArray(NumElem, J) = x(J)
                    YArray(NumElem, J) = y(J)
                    CArray(NumElem, J) = CC(J)
                    StaArray(NumElem, J) = sta(J)
                Next J
                '
                ' write out data to report here.
                Write(6, "", "", "", "", "", "")
                Write(6, "CURVE ELEMENT", "", "", "", "", "")
                Write(6, "", "", "", "", "", "")
                Write(6, "Point", "X", "Y", "Z", "STA", "")
                For K = 1 To NPT
                    x(K) = Format(x(K), "#####0.000")
                    y(K) = Format(y(K), "#####0.000")
                    z(K) = Format(z(K), "#####0.000")
                    sta(K) = Format(sta(K), "#####0.000")
                    Write(6, LDesc(K), x(K), y(K), z(K), sta(K), "")
                Next K
                '
                Write(4, Align, ElemArray(NumElem), Desc, _
                x(1), y(1), x(2), y(2), x(3), y(3), _
                sta(1), sta(2), sta(3), _
                CC(1), CC(2), CC(3), _
                DirArray(NumElem))
                '
                Write(6, "", "", "", "", "", "")
                Write(6, "Radius=", CC(3), " Delta=", Delta, "", "")
                Write(6, "Length=", curveLength, " Degree=", Degree, "", "")
                Write(6, "Back=", Back, " Ahead=", Ahead, "", "")
                Write(6, "Tangent=", TanLen, " Chord=", ChdLen, "", "")
                Write(6, "External=", ExtLen, "", "", "", "")
                '
            End If
        Next I
        Msg = "Successfully completed"
        Style = vbOK
        Title = "Alignment Processing"
        Response = MsgBox(Msg, Style, Title)
        FileClose(6)
        mnuWithSOE.Visible = True
        mnuSOEPrint.Visible = True
    End Sub

    Private Sub mnuWithSOE_Click(sender As System.Object, e As System.EventArgs) Handles mnuWithSOE.Click

        Dim IReturn As Integer

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
        lstSOAData.Visible = False
        frameType.Visible = False
        frameCurve.Visible = False

        txtBegAlign.Visible = True
        lblBegAlign.Visible = True
        txtGP3Cnt.Visible = True
        lblGP3Cnt.Visible = True
        cmdProcess.Visible = True
        txtBegAlign.Focus()

        IReturn = Shell("c:\soesort.bat" & " " & SOE_Filename & " " & " " & SOR_Filename)

    End Sub

    Private Sub cmdProcess_Click()
        '
        FileOpen(6, SasRpt_Filename, OpenMode.Append)
        FileOpen(7, XYZ_Filename, OpenMode.Output)
        FileOpen(20, GP3_Filename, OpenMode.Output)
        FileOpen(10, SO1_Filename, OpenMode.Output)
        FileOpen(14, SOR_Filename, OpenMode.Output)

        Write(6, "", "", "", "", "", "")
        Write(6, "", "", "", "", "", "")
        Write(6, "XYZ Conversion Report", "", "", "", "", "")
        Write(6, "X Coord", "Y Coord", "Z Coord", "Station", "Offset", "Elevation ")

        If txtGP3Cnt.Text = "" Then
            GP3Cnt = 1000
        Else
            GP3Cnt = Val(txtGP3Cnt)
        End If
        For Cnt = 1 To TotElem
            If Val(txtBegAlign) = AlignArray(Cnt) Then
                IC = Cnt
                While Not EOF(14)
                    LineInput(14, Record)
                    If Mid(Record, 1, 1) <> "*" Then
                        '
                        Pos1 = InStr(1, Record, ",", 0)
                        Pos2 = InStr(Pos1 + 1, Record, ",", 0)
                        Pos3 = InStr(Pos2 + 1, Record, ",", 0)
                        Pos4 = InStr(Pos3 + 1, Record, ",", 0)

                        SoePnt = Mid(Record, 1, Pos1 - 1)
                        SoeSta = Mid(Record, Pos1 + 1, Pos2 - Pos1 - 1)
                        SoeOff = Mid(Record, Pos2 + 1, Pos3 - Pos2 - 1)
                        SoeElv = Mid(Record, Pos3 + 1, Pos4 - Pos3 - 1)
                        SoeDesc = Mid(Record, Pos4 + 1, Len(Record) - Pos4)
                        '
200:                    If ElemArray(IC) = "C" Then
                            StaDist = StaArray(IC, 3) - SoeSta
                            If StaArray(IC, 3) > SoeSta Or Abs(StaDist) <= 1 Then
                                If SoeOff = 0 Then
                                    CenterElev = SoeElv
                                    Call curveStat(CArray(IC, 1), CArray(IC, 2), XArray(IC, 1), YArray(IC, 1), _
                                       StaArray(IC, 1), SoeSta, DirArray(IC), CArray(IC, 3), xc, yc)
                                End If
                                Call xyzCoord(xc, yc, CenterElev, CArray(IC, 1), CArray(IC, 2), _
                                   XArray(IC, 2), YArray(IC, 2), offset, elev, ElemArray(IC), _
                                   DirArray(IC), xx, yy, zz)
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
                            If StaArray(IC, 2) > SoeSta Or Abs(StaDist) <= 1 Then
                                If SoeOff = 0 Then
                                    CenterElev = SoeElv
                                    Call lineStat(XArray(IC, 1), XArray(IC, 2), YArray(IC, 1), YArray(IC, 2), _
                                       StaArray(IC, 1), SoeSta, xs, ys)
                                End If
                                Call xyzCoord(xs, ys, CenterElev, XArray(IC, 1), YArray(IC, 1), _
                                   XArray(IC, 2), YArray(IC, 2), SoeOff, SoeElv, ElemArray(IC), _
                                   DirArray(IC), xx, yy, zz)
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

        Close #6
        Close #10
        Close #14
    End Sub


    Private Sub mnuSOEPrint_Click(sender As System.Object, e As System.EventArgs) Handles mnuSOEPrint.Click

        Msg = "Continue Printing"
        Style = vbYesNo
        Title = "Print Proc"
        Response = MsgBox(Msg, Style, Title)

        FileOpen(6, SasRpt_Filename, OpenMode.Input)

        If Response = vbNo Then
            Printer.KillDoc() ' Terminate print job abruptly.
            Printer.EndDoc()
        Else
            If Response = vbYes Then
                Printer.Orientation = 1       ' Portrait orientation
                Printer.FontSize = 10
                Printer.FontName = Screen.Fonts(12)
                Printer.FontSize = 10
                Page = 1
                Call Header(Page)

                IRow = 9
                xyzSwitch = "N"
                While Not EOF(6)
                    Input(6, F1, F2, F3, F4, F5, F6)
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
                Style = vbOKOnly
                Title = "Print Proc"
                Response = MsgBox(Msg, Style, Title)
            End If
        End If

    End Sub
    '    Private Sub Header(Page)
    '
    '        MyDate = "Date:" & Now
    '        MyPage = "Page:" & Page
    '        Printer.Print "                                                                                "; MyPage
    '        Printer.FontBold = True
    '        Printer.Print("")
    '        Printer.Print("                            SOUTH CAROLINA DEPARTMENT OF TRANSPORTATION")
    '        Printer.Print("")
    '        Printer.Print("                                     SURVEY AUTOMATION SYSTEM")
    '        Printer.Print("")
    '        Printer.Print "                         VERSION:WIN/NT 2.0                         "; MyDate
    '        Printer.Print("")
    '        Printer.FontBold = False
    '        Printer.Print("====================================================================================================")
    '    End Sub

    Private Sub Header(Page)
        Dim Printer As New Printer

        MyDate = "Date:" & Now
        MyPage = "Page:" & Page
        Printer.FontBold = True
        Printer.Print("")
        Printer.Print("     " & MyDate & "                                                                                                           " & MyPage)
        Printer.Print("")
        Printer.Print("                                                  SOUTH CAROLINA DEPARTMENT OF TRANSPORTATION")
        Printer.Print("")
        Printer.Print("                                                      ALIGNMENT, STATION AND OFFSET REPORT")
        Printer.Print("")
        Printer.Print("                                                                VERSION:WIN/NT 2.0")
        Printer.Print("")
        Printer.FontBold = False
        F1a = "PNT NO."
        F2a = "X-COORD"
        F3a = "Y-COORD"
        F3a = "Z-COORD"
        F4a = "DESCRIPTION                "
        F5a = "STATION"
        F6a = "OFFSET"
        F7a = "ELEVATION"
        F8a = "ALIGN NO."
        F9a = "ALIGNMENT DESC."
        Printer.Print(F1a, F2a, F3a, F4a, F5a, F6a, F7a, F8a, F9a)
        Printer.Print("_____________________________________________________________________________________________________________________________________________")
    End Sub

    Private Sub ReformData(sList, RecType, Col1, Col2, Col3, Col4)
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

    Private Sub Input(p1 As Integer, RecType As String, Col1 As String, Col2 As String, Col3 As String, Col4 As String)
        Throw New NotImplementedException
    End Sub

    Private Sub Input(p1 As Integer, SF1 As Short)
        Throw New NotImplementedException
    End Sub

    Private Sub Input(p1 As Integer, sta As Double())
        Throw New NotImplementedException
    End Sub

End Class