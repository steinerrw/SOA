Option Strict Off
Option Explicit Off
Module Initialization
	
	'******FILENAMES*************
	Public Sfile As String 'SAS  SOA
	Public Alg_filename As String '1     1
	Public Aln_filename As String '4     4
	Public Cla_filename As String '11
	Public Clp_filename As String '?     ?
	Public GP3_filename As String '20
	Public Map_filename As String '      3
	Public New_filename As String '2     2
	Public Pnt_filename As String '5
	Public Rej_filename As String '     13
	Public SasRpt_filename As String '6
	Public SoaRpt_filename As String '      9
	Public SOE_filename As String '8
	Public SOR_filename As String '14
	Public SO1_filename As String '10
	Public Tmp_filename As String '     22
	Public Vld_filename As String '12
	Public XYZ_filename As String '7
	Public Rt_filename As String
	Public Lt_filename As String
	Public DgnRt_filename As String
	Public DgnLt_filename As String
	
	'*********************
	Public IPos As Short
	
	Public swCase As String
	Public chk1X As String
	Public chk1Y As String
	Public chk2 As String
	
	'******FLAGS***********
	Public pntFlag As String
	Public staFlag As String
	Public OffFlag As Short
	Public Focus_Flag As String
	Public Save_Flag As String
	
	'******REPORT***********
	Public MyDate As String
	Public MyPage As String
	
	Public Pos1 As Short
	Public Pos2 As Short
	Public Pos3 As Short
	Public Pos4 As Short
	Public Pos5 As Short
	Public Pos6 As Short
	Public Pos7 As Short
	Public Pos8 As Short
	Public Pos9 As Short
	Public Pos10 As Short
	
	Public Col1 As String
	Public Col2 As String
	Public Col3 As String
	Public Col4 As String
	
	Public wFont As Short
	Public wHight As Short
	Public wWidth As Short
	
	'*******COUNTERS*********
	Public I As Short
	Public J As Short
	Public K As Short
	
	Public Pnt As Short
	Public pntCnt As Short
	Public Cnt As Short
	Public GP3Cnt As Short
	
	'*******OFFSETS**********
	Public SoePnt As Short
	Public SoeSta As Double
	Public SoeOff As Double
	Public SoeOff1 As Double
	Public SoeElv As Double
	Public SoeDesc As String
	
	'*******ARRAYS**********
	Public AlignNM(200) As Short
	
	Public ElemTyp(200) As String
	Public AlgDesc(200) As String
	
	Public rejPnt(1000) As Short
	Public rejX(1000) As Double
	Public rejY(1000) As Double
	Public rejZ(1000) As Double
	Public rejDesc(1000) As String
	
	Public validPnt(1000) As String
	
	Public lineX(1000) As Double
	Public lineY(1000) As Double
	Public lineZ(1000) As Double
	
	Public Off(1000) As Double
	
	Public ProjDist(1000) As Double
	Public OffSta(1000) As Double
	
	Public Theta4(1000) As Double
	Public TDir4(1000) As Double
	Public ChkOff(1000) As Double
	
	Public idx_Pnt(1000) As Double
	Public idx_X(1000) As Double
	Public idx_Y(1000) As Double
	Public idx_Z(1000) As Double
	
	Public XArray(1000, 3) As Double
	Public YArray(1000, 3) As Double
	Public CArray(1000, 3) As Double
	Public StaArray(1000, 3) As Double
	Public AlignArray(1000) As Short
	Public ElemArray(1000) As String
	Public DirArray(1000) As String
	
	'*********************
	Public F1 As String
	Public F2 As String
	Public F3 As String
	Public F4 As String
	Public F5 As String
	Public F6 As String
	Public F7 As String
	Public F8 As String
	Public F9 As String
	
	Public SF1 As Short
	Public SF2 As Double
	Public SF3 As Double
	Public SF4 As Double
	Public SF5 As String
	Public SF6 As String
	Public SF7 As Double
	Public SF8 As Short
	Public SF9 As String
	
	Public F1a As String
	Public F2a As String
	Public F3a As String
	Public F4a As String
	Public F5a As String
	Public F6a As String
	Public F7a As String
	Public F8a As String
	Public F9a As String
	Public xyzSwitch As String
	Public IRow As Short
	Public Page As Short
	
	'*********************
	Public BegAlign As Short
	Public IC As Short
	Public iReturnValue As Short
	Public Sortcmd As String
	Public StaDist As Double
	Public CenterElev As Double
	Public xc As Double
	Public yc As Double
	Public xx As Double
	Public yy As Double
	Public zz As Double
	
	Public iX As Double
	Public iY As Double
	Public iZ As Double
	
	Public Units As String
	
	Public CSta As String
	Public CEsta As String
	Public bsta As Double
	Public ESta As Double
	Public Length As Double
	Public LDesc(4) As String
	Public Desc As String
	Public sList As String
	
	
	Public MySize As Double
	Public Record As String
	
	Public LOff As Short
	Public ROff As Short
	Public A As Double
	Public B As Double
	Public C As Double
	Public BegPnt As Short
	Public EndPnt As Short
	Public BegSta As Double
	Public EndSta As Double
	Public AlignNum As Short
	Public Align_Num As Short
	Public Align_nr As Short
	'Public Alg_Desc As String
	Public AlignDesc As String
	Public AlnCntr As Short
	Public Cnta As Short
	Public ElemType As String
	Public Radius As Double
	
	
	Public theta As Double
	Public theta1 As Double
	Public TDir As Double
	
	
	Public wUnits As String
	Public lstIndex As Short
	
	Public Msg As String
	Public Style As String
	Public Title As String
	Public Response As String
	
	Public Entry As String
	
	Public xPnt As String
	Public yPnt As String
	Public zPnt As String
	Public StaPnt As String
	Public MyString As String
	
	
	Public x(5) As Double
	Public y(5) As Double
	Public z(5) As Double
	Public IPN(5) As Short
	Public sta(3) As Double
	Public CC(3) As Double
	Public NPT As Short
	
	Public Bearing As String
	Public Back As String
	Public Ahead As String
	Public dX As Double
	Public dY As Double
	
	Public Const PI As Double = 3.141592654
	Public DAng As Double
	
	Public Deg As Double
	Public Min1 As Double
	Public iMin As Short
	Public rMin As Double
	Public rSec As Double
	Public DMS As String
	Public Delta As String
	Public Degree As String
	Public D As Double
	Public Angle As Double
	Public idxCnt As Short
	
	Public Align As Short
	Public prevAlign As Short
	Public NumElem As Short
	Public TotElem As Short
	
	
	Public RecType As String
	
	'UPGRADE_NOTE: dir was upgraded to dir_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public dir_Renamed As String
	Public xPI As Double
	Public yPI As Double
	Public Ang As Double
	Public Ang1 As Double
	Public rad As Double
	
	Public xs As Double
	Public x0 As Double
	Public x1 As Double
	Public X2 As Double
	Public X3 As Double
	
	Public ys As Double
	Public y0 As Double
	Public y1 As Double
	Public Y2 As Double
	Public Y3 As Double
	
	Public ZS As Double
	Public Z0 As Double
	Public Z1 As Double
	Public Z2 As Double
	Public Z3 As Double
	
	Public A1 As Double
	Public A2 As Double
	
	Public B1 As Double
	Public B2 As Double
	
	Public C1 As Double
	Public C2 As Double
	
	Public AXB As Double
	Public TanLen As Double
	Public ChdLen As Double
	Public ExtLen As Double
	Public curveLength As Double
	Public Tmp As Double
	Public Tmp2 As Double
	
	Public RC As String
	Public Point As Double
	
	Public offset As Double
	Public elev As Double
	
	Public result1 As Double
	Public result2 As Double
	Public res1 As Double
	Public res2 As Double
	
	Public prev_align As Short
	
	Public oa As Double
	Public ob As Double
	Public doa As Double
	Public dob As Double
	Public arg As Double
End Module