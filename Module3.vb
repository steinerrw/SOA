Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Module Control
	Sub Pause(ByRef sngSeconds As Single)
		Dim sngStart As Single
		
		sngStart = VB.Timer()
		Do While VB.Timer() < sngStart + sngSeconds
			System.Windows.Forms.Application.DoEvents()
		Loop 
	End Sub
	
	Public Sub lineStat(ByRef x0 As Object, ByRef x1 As Object, ByRef y0 As Object, ByRef y1 As Object, ByRef bs As Object, ByRef os As Object, ByRef xs As Object, ByRef ys As Object)
		Dim dL As Double
		Dim s As Double
        dX = x1 - x0
        dY = y1 - y0
        dL = Dist(x1, y1, x0, y0)
        s = os - bs
        xs = x0 + (s * (dX / dL))
        ys = y0 + (s * (dY / dL))
	End Sub
	
    Public Sub xyzCoord(ByRef x As Object, ByRef y As Object, ByRef z As Object, ByRef x0 As Object, ByRef y0 As Object, ByRef x1 As Object, ByRef y1 As Object, ByRef offset As Object, ByRef elev As Object, ByRef elem As Object, ByRef dir_Renamed As Object, ByRef xx As Object, ByRef yy As Object, ByRef zz As Object)
        Dim dL As Double
        Dim IB As Double
        dX = x - x0
        dY = y - y0
        dL = Dist(x, y, x0, y0)
        If dL = 0 Then
            dX = x - x1
            dY = y - y1
            dL = Dist(x1, y1, x, y)
        End If
        If elem = "L" Then
            xx = x + (offset * (dY / dL))
            yy = y - (offset * (dX / dL))
        Else
            IB = -1
            If dir_Renamed = "L" Then
                IB = 1
            End If
            xx = x + (IB * offset * (dX / dL))
            yy = y + (IB * offset * (dY / dL))
        End If
        If offset = 0 Then
            zz = z
        Else
            zz = z + elev
        End If
    End Sub
	
	
	Public Sub writeRtn(ByRef xx As Object, ByRef yy As Object, ByRef zz As Object, ByRef sta As Object, ByRef offset As Object, ByRef elev As Object, ByRef icnt As Object)
		Dim gp3line As String
        String.Format("{0:#####0.000}", xx)
        String.Format("{0:#####0.000}", yy)
        String.Format("{0:#####0.000}", zz)
        String.Format("{0:#####0.000}", sta)
        String.Format("{0:#####0.000}", offset)
        String.Format("{0:#####0.000}", elev)
        WriteLine(6, xx, yy, zz, sta, offset, elev)
		WriteLine(7, xx, yy, zz)
		WriteLine(10, sta, offset, zz)
        String.Format("{0:#####0.000}", xx)
        String.Format("{0:#####0.000}", yy)
        String.Format("{0:#####0.000}", zz)
        String.Format("{0:#####0.000}", sta)
        gp3line = "   S" & "      " & icnt & "       " & yy & "       " & xx & "       " & zz & "  " & "$ X"
        PrintLine(20, gp3line, sta, offset, elev)
	End Sub
	
    Public Sub curveStat(ByRef x0 As Object, ByRef y0 As Object, ByRef x1 As Object, ByRef y1 As Object, ByRef bsta As Object, ByRef sta As Object, ByRef dir_Renamed As Object, ByRef rad As Object, ByRef xc As Object, ByRef yc As Object)
        Dim deltas As Double
        Dim theta1 As Double
        Dim theta2 As Double
        Dim theta As Double
        Dim xt As Double
        Dim yt As Double
        deltas = sta - bsta
        Call GetAng(x0, y0, x1, y1, Ang)
        theta1 = ((Ang / 180) * PI)
        theta2 = deltas / rad
        If dir_Renamed = "R" Then
            theta = theta1 - theta2
        Else
            theta = theta1 + theta2
        End If
        xt = System.Math.Cos(theta)
        yt = System.Math.Sin(theta)
        xc = x0 + rad * xt
        yc = y0 + rad * yt
    End Sub
End Module