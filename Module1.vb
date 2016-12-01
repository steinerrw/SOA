Option Strict Off
Option Explicit Off
Module Alignment
	
    Declare Function OSWinHelp Lib "user32" Alias "WinHelpA" (ByVal hwnd As Integer, ByVal HelpFile As String, ByVal wCommand As Short, ByRef dwData As Object) As Short
	
	Public Sub Point_Check(ByRef Point As Object, ByRef RC As Object, ByRef idx_Pnt As Object, ByRef idxCnt As Object)
		Dim IC As Short
        RC = "N"
        For IC = 1 To idxCnt
            If idx_Pnt(IC) = Point Then
                RC = "Y"
                Exit For
            End If
        Next IC
        If RC = "N" Then
            Msg = "Invalid Point # " & Point & " idx=" & idx_Pnt(IC)
            Style = CStr(MsgBoxResult.Ok)
            Title = "Point Check"
            Response = CStr(MsgBox(Msg, CDbl(Style), Title))
        End If
	End Sub
	
    Public Sub Find_PI_CC(ByRef IPN As Object, ByRef x As Object, ByRef y As Object, ByRef NPT As Object, ByRef xPI As Object, ByRef yPI As Object, ByRef Ang As Object, ByRef dir_Renamed As Object, ByRef rad As Object)
        A1 = x(2) - x(1)
        B1 = y(2) - y(1)
        C1 = A1 * x(1) + B1 * y(1)
        A2 = x(2) - x(3)
        B2 = y(2) - y(3)
        C2 = A1 * x(3) + B1 * y(3)
        D = A1 * B2 - B1 * A2
        If D <> 0 Then
            xPI = (C1 * B2 - B1 * C2) / D
            String.Format("{0:#####0.000}", xPI)
            yPI = (A1 * C2 - A2 * C1) / D
            String.Format("{0:#####0.000}", yPI)
        Else
            ' process for illegal pc, pi or poc x-y coordinates.
        End If
        rad = Dist(x(1), y(1), x(2), y(2))
        ' find deflection angle
        Tmp = (x(1) - x(2)) * (x(3) - x(2)) + (y(1) - y(2)) * (y(3) - y(2))
        Tmp2 = Dist(x(2), y(2), x(1), y(2)) ^ 2
        Tmp = Tmp / Tmp2

        Ang = PI / 2 - System.Math.Atan(Tmp / System.Math.Sqrt(1 - Tmp ^ 2))
        AXB = (x(1) - x(2)) * (y(3) - y(2)) - (y(1) - y(2)) * (x(3) - x(2))
        If AXB > 0 Then
            dir_Renamed = "L"
        Else
            dir_Renamed = "R"
        End If
    End Sub
	
	'Public Sub Find_POC(IPN As Variant, x As Variant, y As Variant, NPT, x0, y0, Ang, dir, rad)
    Public Sub Find_POC(ByRef IPN As Object, ByRef x As Object, ByRef y As Object, ByRef NPT As Object, ByRef x0 As Object, ByRef y0 As Object, ByRef Ang As Object, ByRef dir_Renamed As Object, ByRef rad As Object)
        A1 = x(2) - x(1)
        B1 = y(2) - y(1)
        C1 = A1 * x(1) + B1 * y(1)
        A2 = x(2) - x(3)
        B2 = y(2) - y(3)
        C2 = A2 * x(3) + B2 * y(3)
        D = A1 * B2 - B1 * A2
        If D <> 0 Then
            x0 = (C1 * B2 - B1 * C2) / D
            String.Format("{0:#####0.000}", x0)
            y0 = (A1 * C2 - A2 * C1) / D
            String.Format("{0:#####0.000}", y0)
            '   Else
            ' process for illegal pc, pi or poc x-y coordinates.
            '      Debug.Print "Illegal PC="; IPN(1), " PI="; IPN(2), " PT="; IPN(3)
            '
            ' move endif to end of subroutine
            '   End If
            '
            rad = Dist(x(1), y(1), x0, y0)
            ' find deflection angle
            Tmp = ((x(1) - x0) * (x(3) - x0) + (y(1) - y0) * (y(3) - y0)) / (Dist(x0, y0, x(1), y(1))) ^ 2
            Ang = PI / 2 - System.Math.Atan(Tmp / System.Math.Sqrt(1 - Tmp ^ 2))
            ' end deflection angle

            '   AXB = (x(1) - x(2)) * (y(3) - y(2)) - (y(1) - y(2)) * (x(3) - x(2))
            AXB = (x(1) - x0) * (y(3) - y0) - (y(1) - y0) * (x(3) - x0)

            If AXB > 0 Then
                dir_Renamed = "L"
            Else
                dir_Renamed = "R"
            End If
        End If
    End Sub
	
	Public Function Dist(ByRef x1 As Object, ByRef y1 As Object, ByRef X2 As Object, ByRef Y2 As Object) As Object
        Dist = System.Math.Sqrt((X2 - x1) ^ 2 + (Y2 - y1) ^ 2)
        String.Format("{0:#####0.000}", Dist)
    End Function
	
	Public Sub Find_XYZ(ByRef IPN As Object, ByRef x As Object, ByRef y As Object, ByRef z As Object, ByRef NPT As Object)
		Dim I As Short
		Dim J As Short
        For I = 1 To NPT
            x(I) = 0
            y(I) = 0
            z(I) = 0
            For J = 1 To idxCnt + 1
                If IPN(I) = idx_Pnt(J) Then
                    x(I) = idx_X(J)
                    y(I) = idx_Y(J)
                    z(I) = idx_Z(J)
                End If
            Next J
        Next I
	End Sub
	
	Public Sub Find_PI(ByRef IPN As Object, ByRef x As Object, ByRef y As Object)
        A1 = y(4) - y(1)
        B1 = x(1) - x(4)
        C1 = A1 * x(1) + B1 * y(1)
        A2 = y(5) - y(3)
        B2 = x(3) - x(5)
        C2 = A2 * x(3) + B2 * y(3)
		D = A1 * B2 - B1 * A2
		If D <> 0 Then
            x(2) = (C1 * B2 - B1 * C2) / D
            String.Format("{0:#####0.000}", x(2))
            y(2) = (A1 * C2 - A2 * C1) / D
            String.Format("{0:#####0.000}", y(2))
        Else
            ' process for illegal pc, pi or poc x-y coordinates.
		End If
	End Sub
	
	Public Sub Find_Bearing(ByRef x1 As Object, ByRef y1 As Object, ByRef X2 As Object, ByRef Y2 As Object, ByRef Bearing As Object)
		Dim longitude As String
		Dim latitude As String
        '        Dim Bearing As Double
        longitude = "N"
        latitude = "E"
        Call GetAng(x1, y1, X2, Y2, Ang)
		If Ang < 90 Then
			longitude = "N"
			latitude = "E"
			Angle = 90 - Ang
		ElseIf Ang < 180 Then 
			longitude = "N"
			latitude = "W"
			Angle = Ang - 90
		ElseIf Ang < 270 Then 
			longitude = "S"
			latitude = "W"
			Angle = 270 - Ang
		ElseIf Ang < 360 Then 
			longitude = "S"
			latitude = "E"
			Angle = Ang - 270
		End If
		Call DdmmssConv(Angle, DMS)
        Bearing = longitude & DMS & latitude
	End Sub
	
	Public Sub DdmmssConv(ByRef Angle As Object, ByRef DMS As String)
		Deg = Int(CDbl(Angle))
        Min1 = (Angle - Deg) * 60
		iMin = Int(Min1)
		rMin = iMin
		rSec = (Min1 - rMin) * 60
        String.Format("{0:#####0.000}", rSec)
        DMS = Deg & "^" & iMin & "''" & rSec
	End Sub
	
	Public Sub GetAng(ByRef x1 As Object, ByRef y1 As Object, ByRef X2 As Object, ByRef Y2 As Object, ByRef Ang As Object)
        dX = X2 - x1
        dY = Y2 - y1
		If System.Math.Abs(dX) <= 0.0001 Then
			dX = 0
		End If
		If System.Math.Abs(dY) <= 0.0001 Then
			dY = 0
		End If
		If dX = 0 Then
			If dY = 0 Then
				DAng = 0
			ElseIf dY > 0 Then 
				DAng = PI / 2
			Else
				DAng = PI + PI / 2
			End If
		ElseIf dX > 0 Then 
			If dY = 0 Then
				DAng = 0
			ElseIf dY > 0 Then 
				DAng = System.Math.Atan(dY / dX)
			Else
				DAng = 2 * PI + System.Math.Atan(dY / dX)
			End If
		Else
			If dY = 0 Then
				DAng = PI
			Else
				DAng = PI + System.Math.Atan(dY / dX)
			End If
		End If
        Ang = Rad2Deg(DAng)
	End Sub
	
	Public Function Rad2Deg(ByRef Radian As Object) As Object
        Rad2Deg = Radian * 180 / PI
	End Function
End Module