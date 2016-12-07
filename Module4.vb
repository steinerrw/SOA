Option Strict Off
Option Explicit Off
Module Soa

    Public Sub CreateMap()

        FileOpen(2, New_Filename, OpenMode.Append)
        FileOpen(3, Map_Filename, OpenMode.Output)
        MySize = LOF(2)
        FileClose(2)
        If MySize = 0 Then
            Msg = "Missing New File"
            Style = CStr(MsgBoxResult.Ok)
            Title = "Critical Error"
            Response = CStr(MsgBox(Msg, CDbl(Style), Title))
            '            frmSoaInp.FileClose()
        Else
            FileOpen(2, New_Filename, OpenMode.Input)
            Record = LineInput(2)

            While Not EOF(2)
                If Mid(Record, 1, 1) <> "*" And Mid(Record, 2, 1) <> "*" And Mid(Record, 1, 5) <> "     " Then
                    Pnt = CShort(Str(CDbl(Mid(Record, 1, 5))))
                    iY = CDbl(Str(CDbl(Mid(Record, 7, 13))))
                    iX = CDbl(Str(CDbl(Mid(Record, 21, 13))))
                    iZ = CDbl(Str(CDbl(Mid(Record, 35, 13))))
                    Desc = Mid(Record, 49, 20)

                    'write  #3 .map File
                    If Mid(Desc, 1, 2) = "CL" Or Mid(Desc, 1, 3) = "X" Then
                    Else
                        WriteLine(3, Pnt, iX, iY, iZ, Desc)
                    End If
                End If
                Record = LineInput(2)
            End While
            'last record
            If Mid(Record, 1, 1) <> "*" And Mid(Record, 2, 1) <> "*" And Mid(Record, 1, 5) <> "     " Then
                Pnt = CShort(Str(CDbl(Mid(Record, 1, 5))))
                iY = CDbl(Str(CDbl(Mid(Record, 7, 13))))
                iX = CDbl(Str(CDbl(Mid(Record, 21, 13))))
                iZ = CDbl(Str(CDbl(Mid(Record, 35, 13))))
                Desc = Mid(Record, 49, 20)

                'write  #3 .map File
                If Mid(Desc, 1, 2) = "CL" Or Mid(Desc, 1, 3) = "X" Then
                Else
                    WriteLine(3, Pnt, iX, iY, iZ, Desc)
                End If
            End If
            Msg = "Map File created"
            Style = CStr(MsgBoxResult.Ok)
            Title = "Create Map"
            Response = CStr(MsgBox(Msg, CDbl(Style), Title))
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
        Record = LineInput(2)
        While Not EOF(2)
            If Mid(Record, 1, 1) <> "*" Then
                Pnt = CShort(Str(CDbl(Mid(Record, 1, 5))))
                Desc = Mid(Record, 49, 20)
                iY = CDbl(Str(CDbl(Mid(Record, 7, 13))))
                iX = CDbl(Str(CDbl(Mid(Record, 21, 13))))
                iZ = CDbl(Str(CDbl(Mid(Record, 35, 13))))

                'load array from .pnt File
                If Mid(Record, 49, 3) = "POT" Or Mid(Record, 49, 4) = "POST" Or Mid(Record, 49, 2) = "PC" Or Mid(Record, 49, 3) = "POC" Or Mid(Record, 49, 2) = "PI" Or Mid(Record, 49, 2) = "PT" Or Mid(Record, 49, 2) = "RP" Or Mid(Record, 49, 3) = "PRC" Or Mid(Record, 49, 2) = "CP" Or Mid(Record, 49, 2) = "BM" Or Mid(Record, 49, 3) = "ICL" Or Mid(Record, 49, 2) = "CP" Or Mid(Record, 49, 3) = "ODL" Or Mid(Record, 49, 4) = "ODLA" Or Mid(Record, 49, 4) = "ODLB" Or Mid(Record, 49, 2) = "BM" And Pnt > 0 Then

                    idxCnt = idxCnt + 1
                    idx_Pnt(idxCnt) = Pnt
                    idx_X(idxCnt) = iX
                    idx_Y(idxCnt) = iY
                    idx_Z(idxCnt) = iZ
                    WriteLine(9, Pnt, iX, iY, iZ, Desc, "")
                End If
            End If
            Record = LineInput(2)
        End While
        FileClose(2)
    End Sub

    Public Sub SoaLine(ByRef x1 As Object, ByRef y1 As Object, ByRef X2 As Object, ByRef Y2 As Object, ByRef A As Object, ByRef B As Object, ByRef C As Object, ByRef bsta As Object, ByRef LOff As Object, ByRef ROff As Object, ByRef BegPnt As Object, ByRef EndPnt As Object, ByRef BegSta As Object, ByRef EndSta As Object, ByRef AlignNum As Object, ByRef AlignDesc As Object)
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
            If CDbl(swCase) = 1 Then
                lineX(I) = rejX(I)
                lineY(I) = -(C / B)
            ElseIf CDbl(swCase) = 2 Then
                lineX(I) = -(C / A)
                lineY(I) = rejY(I)
            Else
                lineX(I) = ((B / A) * rejX(I) - rejY(I) - (C / B)) / (A / B + B / A)
                lineY(I) = -(C / B) - (A / B) * lineX(I)
            End If

            result1 = x1
            If X2 < x1 Then ' Min processing
                result1 = X2
            End If

            result2 = x1
            If X2 > x1 Then ' Max processing
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
            WriteLine(12, rejPnt(I), rejX(I), rejY(I), rejZ(I), rejDesc(I), OffSta(I), Off(I), AlignNum, AlignDesc)
49:         If validPnt(I) = "N" Then
                WriteLine(22, rejPnt(pntCnt), rejY(pntCnt), rejX(pntCnt), rejZ(pntCnt), rejDesc(pntCnt))
            End If
        Next I
        pntCnt = 0

    End Sub

    Public Sub SoaCurve(ByRef x1 As Object, ByRef y1 As Object, ByRef X3 As Object, ByRef Y3 As Object, ByRef bsta As Object, ByRef C1 As Object, ByRef C2 As Object, ByRef Radius As Object, ByRef dir_Renamed As Object, ByRef LOff As Object, ByRef ROff As Object, ByRef BegPnt As Object, ByRef EndPnt As Object, ByRef BegSta As Object, ByRef EndSta As Object, ByRef AlignNum As Object, ByRef AlignDesc As Object)

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
            validPnt(I) = CStr(0)
        Next I

        Call curveDir(x1, y1, C1, C2, rejX(I), rejY(I), theta, TDir)
        theta1 = theta
        dir_Renamed = TDir

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

            If Theta4(I) <= theta1 And TDir4(I) = dir_Renamed Then
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
            WriteLine(12, rejPnt(I), rejX(I), rejY(I), rejZ(I), rejDesc(I), OffSta(I), Off(I), AlignNum, AlignDesc)
49:         If validPnt(I) = "N" Then
                WriteLine(22, rejPnt(pntCnt), rejY(pntCnt), rejX(pntCnt), rejZ(pntCnt), rejDesc(pntCnt))
            End If
        Next I
        pntCnt = 0
    End Sub


    Private Sub curveDir(ByRef x1 As Object, ByRef y1 As Object, ByRef C1 As Object, ByRef C2 As Object, ByRef rejX As Object, ByRef rejY As Object, ByRef theta As Object, ByRef TDir As Object)
        oa = (x1 - C1) * (rejX - C1)
        ob = (y1 - C2) * (rejY - C2)
        doa = Dist(x1, y1, C1, C2)
        dob = Dist(C1, C2, rejX, rejY)
        If doa = 0 Or dob = 0 Then
            theta = 0
        Else
            arg = (oa + ob) / (doa * dob)
            If System.Math.Abs(1 - arg) < 0.000001 Then
                arg = 1
            End If
            If arg = 1 Then
                theta = 0
            Else
                theta = PI / 2 - System.Math.Atan(arg / System.Math.Sqrt(1 - arg ^ 2))
            End If
        End If
        dir_Renamed = dirLR(x1, y1, C1, C2, rejX, rejY)
        If CDbl(dir_Renamed) > 0 Then
            TDir = "L"
        Else
            TDir = "R"
        End If
    End Sub

    Public Function dirLR(ByRef x1 As Object, ByRef y1 As Object, ByRef X2 As Object, ByRef Y2 As Object, ByRef X3 As Object, ByRef Y3 As Object) As Object
        AXB = ((x1 - X2) * (Y3 - Y2)) - ((X3 - X2) * (y1 - Y2))
        If AXB = 0 Then
            dirLR = 0
        Else
            dirLR = -1 * (AXB / System.Math.Abs(AXB))
        End If
    End Function

    Public Sub Output()

        FileOpen(12, Vld_Filename, OpenMode.Input)
        FileOpen(24, Rt_Filename, OpenMode.Output)
        FileOpen(25, Lt_Filename, OpenMode.Output)
        '
        ' list box used to sort File by align no. station then offset.
        '
        While Not EOF(12)
            Input(12, Pnt)
            Input(12, X3)
            Input(12, Y3)
            Input(12, Z3)
            Input(12, Desc)
            Input(12, SoeSta)
            Input(12, offset)
            Input(12, Align)
            Input(12, AlignDesc)
            If offset < 0 Then
                offset = offset + 500000000
            ElseIf offset = 0 Then
                offset = 100000000
            ElseIf offset > 0 Then
                offset = offset + 200000000
            End If
            Entry = Align & "*" & offset & "*" & SoeSta & "*" & Pnt & "*" & X3 & "*" & Y3 & "*" & Z3 & "*" & Desc & "*" & AlignDesc & "*"
            frmSoaInp.lstSoaSort.Items.Add(Entry)
        End While
        FileClose(12)
        For Cnt = 0 To frmSoaInp.lstSoaSort.Items.Count - 1
            sList = GetItemText(frmSoaInp.lstSoaSort)
            Pos1 = InStr(1, sList, "*", 0)
            Pos2 = InStr(Pos1 + 1, sList, "*", 0)
            Pos3 = InStr(Pos2 + 1, sList, "*", 0)
            Pos4 = InStr(Pos3 + 1, sList, "*", 0)
            Pos5 = InStr(Pos4 + 1, sList, "*", 0)
            Pos6 = InStr(Pos5 + 1, sList, "*", 0)
            Pos7 = InStr(Pos6 + 1, sList, "*", 0)
            Pos8 = InStr(Pos7 + 1, sList, "*", 0)
            Pos9 = InStr(Pos8 + 1, sList, "*", 0)

            Align = CShort(Mid(sList, 1, Pos1 - 1))
            SoeOff = CDbl(Mid(sList, Pos1 + 1, Pos2 - Pos1 - 1))
            SoeSta = CDbl(Mid(sList, Pos2 + 1, Pos3 - Pos2 - 1))

            If SoeOff > 400000000 And SoeOff < 500000000 Then
                SoeOff = SoeOff - 500000000
            ElseIf SoeOff = 100000000 Then
                SoeOff = 0
            ElseIf SoeOff > 200000000 And SoeOff < 300000000 Then
                SoeOff = SoeOff - 200000000
            End If
            String.Format("{0:#####0.000}", SoeOff)

            Pnt = CShort(Mid(sList, Pos3 + 1, Pos4 - Pos3 - 1))
            X3 = CDbl(Mid(sList, Pos4 + 1, Pos5 - Pos4 - 1))
            Y3 = CDbl(Mid(sList, Pos5 + 1, Pos6 - Pos5 - 1))
            Z3 = CDbl(Mid(sList, Pos6 + 1, Pos7 - Pos6 - 1))
            Desc = Mid(sList, Pos7 + 1, Pos8 - Pos7 - 1)
            AlignDesc = Mid(sList, Pos8 + 1, Pos9 - Pos8 - 1)
            If SoeOff < 0 Then
                WriteLine(25, SoeSta, SoeOff, Desc, Align, AlignDesc)
            ElseIf SoeOff > 0 Then
                WriteLine(24, SoeSta, SoeOff, Desc, Align, AlignDesc)
            End If
        Next Cnt
        FileClose(24)
        FileClose(25)
        '
        frmSoaInp.lstSoaSort.Items.Clear()
        '
        FileOpen(24, Rt_Filename, OpenMode.Input)
        FileOpen(34, DgnRt_Filename, OpenMode.Output)
        While Not EOF(24)
            Input(24, SoeSta)
            Input(24, SoeOff)
            Input(24, Desc)
            Input(24, Align)
            Input(24, AlignDesc)
            Entry = Align & "*" & String.Format("{0:#####0.000}", SoeSta) & "*" & SoeOff & "*" & Desc & "*" & AlignDesc & "*"
            frmSoaInp.lstSoaSort.Items.Add(Entry)
        End While
        FileClose(24)
        '
        PrintLine(34, ".LV=", 24)
        PrintLine(34, ".TH=", wHight)
        PrintLine(34, ".TW=", wWidth)
        PrintLine(34, ".FT=", wFont)
        PrintLine(34, ".LS=", 1.5)
        PrintLine(34, ".CO=", 1)
        PrintLine(34, "")
        '
        prevAlign = 0
        For Cnt = 0 To frmSoaInp.lstSoaSort.Items.Count - 1
            sList = GetItemString(frmSoaInp.lstSoaSort)
            Pos1 = InStr(1, sList, "*", 0)
            Pos2 = InStr(Pos1 + 1, sList, "*", 0)
            Pos3 = InStr(Pos2 + 1, sList, "*", 0)
            Pos4 = InStr(Pos3 + 1, sList, "*", 0)
            Pos5 = InStr(Pos4 + 1, sList, "*", 0)

            Align = CShort(Mid(sList, 1, Pos1 - 1))
            SoeSta = CDbl(Mid(sList, Pos1 + 1, Pos2 - Pos1 - 1))
            SoeOff = CDbl(Mid(sList, Pos2 + 1, Pos3 - Pos2 - 1))
            Desc = Mid(sList, Pos3 + 1, Pos4 - Pos3 - 1)
            AlignDesc = Mid(sList, Pos4 + 1, Pos5 - Pos4 - 1)
            If prevAlign <> Align Then
                PrintLine(34, ".GG")
                PrintLine(34, "           RIGHT        ")
                PrintLine(34, AlignDesc)
                PrintLine(34, " Station-Offset   Description")
                PrintLine(34, "------------------------------")
                PrintLine(34, ".TH=", wHight)
                PrintLine(34, ".TW=", wWidth)
                PrintLine(34, ".FT=", wFont)
                PrintLine(34, ".LS=", 1)
            End If
            If Units = "Metric" Then
                CSta = Int(SoeSta) & "+" & String.Format("{0:#####0.000}", SoeSta - Int(SoeSta)) & "-" & SoeOff & "m" & " " & Desc
            Else
                CSta = Int(SoeSta) & "+" & String.Format("{0:#####0.000}", SoeSta - Int(SoeSta)) & "-" & SoeOff & "'" & " " & Desc
            End If
            PrintLine(34, CSta)
            prevAlign = Align
        Next Cnt
        FileClose(34)
        '
        frmSoaInp.lstSoaSort.Items.Clear()
        FileOpen(25, Lt_Filename, OpenMode.Input)
        FileOpen(35, DgnLt_Filename, OpenMode.Output)
        While Not EOF(25)
            Input(25, SoeSta)
            Input(25, SoeOff)
            Input(25, Desc)
            Input(25, Align)
            Input(25, AlignDesc)
            Entry = Align & "*" & String.Format("{0:#####0.000}", SoeSta) & "*" & SoeOff & "*" & Desc & "*" & AlignDesc & "*"
            frmSoaInp.lstSoaSort.Items.Add(Entry)
        End While
        FileClose(25)
        '
        PrintLine(35, ".LV=", 24)
        PrintLine(35, ".TH=", wHight)
        PrintLine(35, ".TW=", wWidth)
        PrintLine(35, ".FT=", wFont)
        PrintLine(35, ".LS=", 1.5)
        PrintLine(35, ".CO=", 1)
        PrintLine(35, "")
        '
        prevAlign = 0
        For Cnt = 0 To frmSoaInp.lstSoaSort.Items.Count - 1
            sList = GetItemString(frmSoaInp.lstSoaSort)
            Pos1 = InStr(1, sList, "*", 0)
            Pos2 = InStr(Pos1 + 1, sList, "*", 0)
            Pos3 = InStr(Pos2 + 1, sList, "*", 0)
            Pos4 = InStr(Pos3 + 1, sList, "*", 0)
            Pos5 = InStr(Pos4 + 1, sList, "*", 0)

            Align = CShort(Mid(sList, 1, Pos1 - 1))
            SoeSta = CDbl(Mid(sList, Pos1 + 1, Pos2 - Pos1 - 1))
            SoeOff = CDbl(Mid(sList, Pos2 + 1, Pos3 - Pos2 - 1))
            Desc = Mid(sList, Pos3 + 1, Pos4 - Pos3 - 1)
            AlignDesc = Mid(sList, Pos4 + 1, Pos5 - Pos4 - 1)
            If prevAlign <> Align Then
                PrintLine(35, ".GG")
                PrintLine(35, "           LEFT           ")
                PrintLine(35, AlignDesc)
                PrintLine(35, " Station-Offset   Description")
                PrintLine(35, "------------------------------")
                PrintLine(35, ".TH=", wHight)
                PrintLine(35, ".TW=", wWidth)
                PrintLine(35, ".FT=", wFont)
                PrintLine(35, ".LS=", 1)
            End If
            If Units = "Metric" Then
                CSta = Int(SoeSta) & "+" & String.Format("{0:#####0.000}", SoeSta - Int(SoeSta)) & "-" & (SoeOff * -1) & "m" & " " & Desc
            Else
                CSta = Int(SoeSta) & "+" & String.Format("{0:#####0.000}", SoeSta - Int(SoeSta)) & "-" & (SoeOff * -1) & "'" & " " & Desc
            End If
            PrintLine(35, CSta)
            prevAlign = Align
        Next Cnt
        FileClose(35)
        '
        Kill(Rt_Filename)
        Kill(Lt_Filename)
        '
        Msg = "Finished Creating DGN Files"
        Style = CStr(MsgBoxStyle.OkOnly)
        Title = "Print Proc"
        Response = CStr(MsgBox(Msg, CDbl(Style), Title))
        frmSoaInp.mnuPrint.Enabled = True
    End Sub

    Private Function GetItemText(listBox As ListBox) As String
        Throw New NotImplementedException
    End Function

    Private Function GetItemString(listBox As ListBox) As String
        Throw New NotImplementedException
    End Function

End Module