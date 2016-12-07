Option Strict Off
Option Explicit On
Imports System.Math
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class frmSoaInp
    Inherits System.Windows.Forms.Form

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
            Msg = "Missing ALG file. Please run the SAS option to create file."
            Style = CStr(MsgBoxResult.Ok)
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
            Msg = "Missing ALN file. Please run the SAS option to create file."
            Style = CStr(MsgBoxResult.Ok)
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
                    Style = CStr(MsgBoxResult.Ok)
                    Title = "Critical Error-Alignment Processing"
                    Response = CStr(MsgBox(Msg, CDbl(Style), Title))
                    Me.Close()
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
                    SF1 = CShort(VB6.Format(SF1, "####0"))
                    SF2 = CDbl(VB6.Format(SF2, "###0.00"))
                    SF3 = CDbl(VB6.Format(SF3, "###0.00"))
                    '            SF4 = Format(SF4, "###0.00")
                    SF5 = VB6.Format(SF5, "###0.00")
                    SF6 = VB6.Format(SF6, "###0.00")
                    SF7 = CDbl(VB6.Format(SF7, "###0.00"))
                    SF8 = CShort(VB6.Format(SF8, "###0"))
                    '            SF9 = Format(SF9, "###0")
                    WriteLine(12, SF1, SF2, SF3, SF5, SF6, SF7, SF4, SF8, SF9)
                End While

                Printer.EndDoc()
                Msg = "Finished SOA Print"
                Style = CStr(MsgBoxStyle.OkOnly)
                Title = "Print Proc"
                Response = CStr(MsgBox(Msg, CDbl(Style), Title))
            End If
        End If
        FileClose(12)
    End Sub

    Private Sub Header(Page As Integer)
        Dim Printer As New Printer

        MyDate = "Date:" & Now
        MyPage = "Page:" & Page
        WriteLine(12, "")
        WriteLine(12, "     " & MyDate & "                                                                                                           " & MyPage)
        WriteLine(12, "")
        WriteLine(12, "                                                  SOUTH CAROLINA DEPARTMENT OF TRANSPORTATION")
        WriteLine(12, "")
        WriteLine(12, "                                                      ALIGNMENT, STATION AND OFFSET REPORT")
        WriteLine(12, "")
        WriteLine(12, "                                                                VERSION:WIN/NT 2.0")
        WriteLine(12, "")
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
        WriteLine(12, F1a, F2a, F3a, F4a, F5a, F6a, F7a, F8a, F9a)
        WriteLine(12, "_____________________________________________________________________________________________________________________________________________")
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
                If optTypeProc(6).Checked = True Then
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

    Public Sub CreateMap()

        FileOpen(2, New_Filename, OpenMode.Append)
        FileOpen(3, Map_Filename, OpenMode.Output)
        MySize = LOF(2)
        FileClose(2)
        If MySize = 0 Then
            Msg = "Missing New File"
            Style = vbOK
            Title = "Critical Error"
            Response = MsgBox(Msg, Style, Title)
            Dispose()
        Else
            FileOpen(2, New_Filename, OpenMode.Input)
            Input(2, Record)

            While Not EOF(2)
                If Mid(Record, 1, 1) <> "*" And _
                   Mid(Record, 2, 1) <> "*" And _
                   Mid(Record, 1, 5) <> "     " Then
                    Pnt = Str(Mid(Record, 1, 5))
                    iY = Str(Mid(Record, 7, 13))
                    iX = Str(Mid(Record, 21, 13))
                    iZ = Str(Mid(Record, 35, 13))
                    Desc = Mid(Record, 49, 20)

                    'write  #3 .map file
                    If Mid(Desc, 1, 2) = "CL" Or _
                       Mid(Desc, 1, 3) = "X" Then
                    Else
                        Write(3, Pnt, iX, iY, iZ, Desc)
                    End If
                End If
                Input(2, Record)
            End While
            'last record
            If Mid(Record, 1, 1) <> "*" And _
               Mid(Record, 2, 1) <> "*" And _
               Mid(Record, 1, 5) <> "     " Then
                Pnt = Str(Mid(Record, 1, 5))
                iY = Str(Mid(Record, 7, 13))
                iX = Str(Mid(Record, 21, 13))
                iZ = Str(Mid(Record, 35, 13))
                Desc = Mid(Record, 49, 20)

                'write  #3 .map file
                If Mid(Desc, 1, 2) = "CL" Or _
                   Mid(Desc, 1, 3) = "X" Then
                Else
                    Write(3, Pnt, iX, iY, iZ, Desc)
                End If
            End If
            Msg = "Map file created"
            Style = vbOK
            Title = "Create Map"
            Response = MsgBox(Msg, Style, Title)
            FileClose(2)
            FileClose(3)
        End If
    End Sub

    Public Sub CreateIdx()

        For I = 1 To 1000
            idx_Pnt(idxCnt) = Pnt
            idx_X(idxCnt) = 0
            idx_Y(idxCnt) = 0
            idx_Z(idxCnt) = 0
        Next I
        FileOpen(2, New_Filename, OpenMode.Input)
        Input(2, Record)
        While Not EOF(2)
            If Mid(Record, 1, 1) <> "*" Then
                Pnt = Str(Mid(Record, 1, 5))
                Desc = Mid(Record, 49, 20)
                iY = Str(Mid(Record, 7, 13))
                iX = Str(Mid(Record, 21, 13))
                iZ = Str(Mid(Record, 35, 13))

                'load array from .pnt file
                If Mid(Record, 49, 3) = "POT" Or _
                   Mid(Record, 49, 4) = "POST" Or _
                   Mid(Record, 49, 2) = "PC" Or _
                   Mid(Record, 49, 3) = "POC" Or _
                   Mid(Record, 49, 2) = "PI" Or _
                   Mid(Record, 49, 2) = "PT" Or _
                   Mid(Record, 49, 2) = "RP" Or _
                   Mid(Record, 49, 3) = "PRC" Or _
                   Mid(Record, 49, 2) = "CP" Or _
                   Mid(Record, 49, 2) = "BM" Or _
                   Mid(Record, 49, 3) = "ICL" Or _
                   Mid(Record, 49, 2) = "CP" Or _
                   Mid(Record, 49, 3) = "ODL" Or _
                   Mid(Record, 49, 4) = "ODLA" Or _
                   Mid(Record, 49, 4) = "ODLB" Or _
                   Mid(Record, 49, 2) = "BM" And _
                   Pnt > 0 Then

                    idxCnt = idxCnt + 1
                    idx_Pnt(idxCnt) = Pnt
                    idx_X(idxCnt) = iX
                    idx_Y(idxCnt) = iY
                    idx_Z(idxCnt) = iZ
                    Write(9, Pnt, iX, iY, iZ, Desc, "")
                End If
            End If
            Input(2, Record)
        End While
        FileClose(2)
    End Sub

    Public Sub SoaLine(x1, y1, X2, Y2, A, B, C, bsta, LOff, ROff, BegPnt, EndPnt, BegSta, _
                       EndSta, AlignNum, AlignDesc)
        Dim xx As Double
        Dim yy As Double
        Dim zz As Double
        pntFlag = "Y"
        staFlag = "Y"
        If BegPnt = 0 And EndPnt = 0 Then
            pntFlag = "N"
        End If
        If BegSta = 0 And EndSta = 0 Then
            staFlag = "N"
        End If
        If A = 0 Then
            swCase = "1"
        ElseIf B = 0 Then
            swCase = "2"
        Else
            swCase = "3"
        End If
        For I = 1 To 1000
            rejPnt(I) = 0
            rejY(I) = 0
            rejX(I) = 0
            rejZ(I) = 0
            rejDesc(I) = ""
        Next I
        FileOpen(11, Rej_Filename, OpenMode.Input)
        Do While Not EOF(11)
            pntCnt = pntCnt + 1
            validPnt(pntCnt) = "N"
            Input(11, Pnt)
            Input(11, yy)
            Input(11, xx)
            Input(11, zz)
            Input(11, Desc)
            rejPnt(pntCnt) = Pnt
            rejY(pntCnt) = yy
            rejX(pntCnt) = xx
            rejZ(pntCnt) = zz
            rejDesc(pntCnt) = Desc
        Loop
        FileClose(11)
        For I = 1 To pntCnt
            If pntFlag = "Y" Then
                If rejPnt(I) < BegPnt Or rejPnt(I) > EndPnt Then
                    GoTo 49
                End If
            End If
            chk1X = "N"
            chk1Y = "N"
            If swCase = 1 Then
                lineX(I) = rejX(I)
                lineY(I) = -(C / B)
            ElseIf swCase = 2 Then
                lineX(I) = -(C / A)
                lineY(I) = rejY(I)
            Else
                lineX(I) = ((B / A) * rejX(I) - rejY(I) - (C / B)) / (A / B + B / A)
                lineY(I) = -(C / B) - (A / B) * lineX(I)
            End If

            result1 = x1
            If X2 < x1 Then    ' Min processing
                result1 = X2
            End If

            result2 = x1
            If X2 > x1 Then    ' Max processing
                result2 = X2
            End If
            res1 = result1 - 0.1
            res2 = result2 + 0.1
            If res1 <= lineX(I) And lineX(I) <= res2 Then
                chk1X = "Y"
            End If

            result1 = y1
            If Y2 < y1 Then
                result1 = Y2
            End If
            result2 = y1
            If Y2 > y1 Then
                result2 = Y2
            End If
            res1 = result1 - 0.1
            res2 = result2 + 0.1
            If res1 <= lineY(I) And lineY(I) <= res2 Then
                chk1Y = "Y"
            End If

            If chk1X = "Y" And chk1Y = "Y" Then
                Off(I) = Dist(rejX(I), rejY(I), lineX(I), lineY(I))
            Else
                GoTo 49
            End If
            ProjDist(I) = Dist(x1, y1, lineX(I), lineY(I))
            OffFlag = dirLR(X2, Y2, x1, y1, rejX(I), rejY(I))
            Off(I) = OffFlag * Off(I)

            If Off(I) < (ROff + 0.1) And Off(I) > (LOff - 0.1) Then
                OffSta(I) = BegSta + ProjDist(I)
            Else
                GoTo 49
            End If
            If staFlag = "Y" Then
                If OffSta(I) < BegSta Or OffSta(I) > EndSta Then
                    GoTo 49
                End If
            End If
            validPnt(I) = "Y"
            Write(12, rejPnt(I), rejX(I), rejY(I), rejZ(I), rejDesc(I), _
                 OffSta(I), Off(I), AlignNum, AlignDesc)
49:         If validPnt(I) = "N" Then
                Write(22, rejPnt(pntCnt), rejY(pntCnt), rejX(pntCnt), rejZ(pntCnt), _
                   rejDesc(pntCnt))
            End If
        Next I
        pntCnt = 0

    End Sub

    Public Sub SoaCurve(x1, y1, X3, Y3, bsta, C1, C2, Radius, dir, LOff, ROff, BegPnt, _
                        EndPnt, BegSta, EndSta, AlignNum, AlignDesc)

        Dim xx As Double
        Dim yy As Double
        Dim zz As Double

        pntFlag = "Y"
        staFlag = "Y"
        If BegPnt = 0 And EndPnt = 0 Then
            pntFlag = "N"
        End If
        If BegSta = 0 And EndSta = 0 Then
            staFlag = "N"
        End If
        If A = 0 Then
            swCase = "1"
        ElseIf B = 0 Then
            swCase = "2"
        Else
            swCase = "3"
        End If
        For I = 1 To 1000
            rejPnt(I) = 0
            rejY(I) = 0
            rejX(I) = 0
            rejZ(I) = 0
            rejDesc(I) = ""
            validPnt(I) = 0
        Next I

        Call curveDir(x1, y1, C1, C2, rejX(I), rejY(I), theta, TDir)
        theta1 = theta
        dir = TDir

        FileOpen(11, Rej_Filename, OpenMode.Input)
        Do While Not EOF(11)
            pntCnt = pntCnt + 1
            validPnt(pntCnt) = "N"
            Input(11, Pnt)
            Input(11, yy)
            Input(11, xx)
            Input(11, zz)
            Input(11, Desc)
            rejPnt(pntCnt) = Pnt
            rejY(pntCnt) = yy
            rejX(pntCnt) = xx
            rejZ(pntCnt) = zz
            rejDesc(pntCnt) = Desc
        Loop
        FileClose(11)
        For I = 1 To pntCnt
            If pntFlag = "Y" Then
                If rejPnt(I) < BegPnt Or rejPnt(I) > EndPnt Then
                    If validPnt(I) = "N" Then
                        GoTo 49
                    End If
                End If
            End If

            ChkOff(I) = Dist(C1, C2, rejX(I), rejY(I))
            If ChkOff(I) > (ROff + 0.1) Or ChkOff(I) < (LOff - 0.1) Then
                ChkOff(I) = 0
                '         Call tmpWrite(I)
            End If

            Call curveDir(x1, y1, C1, C2, rejX(I), rejY(I), theta, TDir)

            Theta4(I) = theta
            TDir4(I) = TDir

            If Theta4(I) <= theta1 And TDir4(I) = dir Then
                Off(I) = Dist(C1, C2, rejX(I), rejY(I)) - Radius
            Else
                GoTo 49
            End If
            OffFlag = dirLR(X2, Y2, x1, y1, rejX(I), rejY(I))
            Off(I) = OffFlag * Off(I)

            If Off(I) < (ROff + 0.1) And Off(I) > (LOff - 0.1) Then
                ProjDist(I) = Radius * Theta4(I)
                OffSta(I) = BegSta + ProjDist(I)
            Else
                GoTo 49
            End If

            If staFlag = "Y" Then
                If OffSta(I) < BegSta Or OffSta(I) > EndSta Then
                    GoTo 49
                End If
            End If
            validPnt(I) = "Y"
            Write(12, rejPnt(I), rejX(I), rejY(I), rejZ(I), rejDesc(I), OffSta(I), _
                 Off(I), AlignNum, AlignDesc)
49:         If validPnt(I) = "N" Then
                Write(22, rejPnt(pntCnt), rejY(pntCnt), rejX(pntCnt), rejZ(pntCnt), _
                    rejDesc(pntCnt))
            End If
        Next I
        pntCnt = 0
    End Sub
    Private Sub curveDir(x1, y1, C1, C2, rejX, rejY, theta, TDir)
        oa = (x1 - C1) * (rejX - C1)
        ob = (y1 - C2) * (rejY - C2)
        doa = Dist(x1, y1, C1, C2)
        dob = Dist(C1, C2, rejX, rejY)
        If doa = 0 Or dob = 0 Then
            theta = 0
        Else
            arg = (oa + ob) / (doa * dob)
            If Abs(1 - arg) < 0.000001 Then
                arg = 1
            End If
            If arg = 1 Then
                theta = 0
            Else
                theta = PI / 2 - Atan(arg / Sqrt(1 - arg ^ 2))
            End If
        End If
        Call dirLR(x1, y1, C1, C2, rejX, rejY)
        If Dir() > 0 Then
            TDir = "L"
        Else
            TDir = "R"
        End If
    End Sub

    Public Function dirLR(x1 As Integer, y1 As Integer, X2 As Integer, Y2 As Integer, X3 As Integer, Y3 As Integer)
        AXB = ((x1 - X2) * (Y3 - Y2)) - ((X3 - X2) * (y1 - Y2))
        If AXB = 0 Then
            dirLR = 0
        Else
            dirLR = -1 * (AXB / Abs(AXB))
        End If
        Return dirLR
    End Function
End Class