Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form

    '    Dim ScaleHeight As Integer
    '    Dim ScaleWidth As Integer
    '    Dim Cursor.Current As Integer
    '    Dim ScaleMode As Integer

    Private Property vbWindowBackground As Color

	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        mnuSoa.Visible = False
		mnuSas.Visible = False
	End Sub
	

    Private Sub SASToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SASToolStripMenuItem.Click
        frmSasInp.optType1 = False
        frmSasInp.optType2 = False
        frmSasInp.optType3 = False

        frmSasOptions.cmdNewAlign.Visible = False

        frmSasOptions.txtAlignment.Visible = False
        frmSasOptions.txtDescription.Visible = False
        frmSasOptions.txtStation.Visible = False
        frmSasOptions.lblAlign.Visible = False
        frmSasOptions.lblDesc.Visible = False
        frmSasOptions.lblStation.Visible = False

        frmSasOptions.lblUnits.Visible = False
        frmSasOptions.comboUnits.Visible = False

        frmSasOptions.txtPnt1.Visible = False
        frmSasOptions.txtPnt2.Visible = False
        frmSasOptions.txtPnt3.Visible = False
        frmSasOptions.txtPnt4.Visible = False
        frmSasOptions.lblPnt1.Visible = False
        frmSasOptions.lblPnt2.Visible = False
        frmSasOptions.lblPnt3.Visible = False
        frmSasOptions.lblPnt4.Visible = False

        frmSasOptions.frameCurve.Visible = False

        frmSasInp.optCurve1.Visible = True
        frmSasInp.optCurve2.Visible = True
        frmSasInp.optCurve3.Visible = True

        frmSasInp.Show(vbModal, Me)

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click

        With dlg1
            .Flags = cdlOFNHideReadOnly
            .Filter = "Survey Files (*.Alg)|*.Alg"
            .FilterIndex = 2
            .ShowOpen()
            Sfile = .FileName

            IPos = InStr(1, frmMain.dlg1.FileName, ".", 0)

            Alg_filename = Mid(Sfile, 1, IPos) & "Alg"
            Aln_filename = Mid(Sfile, 1, IPos) & "Aln"
            Cla_filename = Mid(Sfile, 1, IPos) & "Cla"
            Clp_filename = Mid(Sfile, 1, IPos) & "Clp"
            GP3_filename = Mid(Sfile, 1, IPos) & "Gp3"
            Map_filename = Mid(Sfile, 1, IPos) & "Map"
            New_filename = Mid(Sfile, 1, IPos) & "New"
            Pnt_filename = Mid(Sfile, 1, IPos) & "Pnt"
            Rej_filename = Mid(Sfile, 1, IPos) & "Rej"
            SasRpt_filename = "Sas.txt"
            SoaRpt_filename = "Soa.txt"
            SOE_filename = Mid(Sfile, 1, IPos) & "Soe"
            SOR_filename = Mid(Sfile, 1, IPos) & "Sor"
            Tmp_filename = Mid(Sfile, 1, IPos) & "Tmp"
            SO1_filename = Mid(Sfile, 1, IPos) & "So1"
            Vld_filename = Mid(Sfile, 1, IPos) & "Vld"
            XYZ_filename = Mid(Sfile, 1, IPos) & "Xyz"

            Rt_filename = Mid(Sfile, 1, IPos - 1) & "Rt.tmp"
            Lt_filename = Mid(Sfile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_filename = Mid(Sfile, 1, IPos - 1) & "Rt.txt"
            DgnLt_filename = Mid(Sfile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        With dlg1
            .Filter = "Survey Files (*.Alg)|*.Alg|Map Files (*.Map)|*.Map"
            .FilterIndex = 1
            .ShowOpen()
            Sfile = .FileName

            IPos = InStr(1, frmMain.dlg1.FileName, ".", 0)

            Alg_filename = Mid(Sfile, 1, IPos) & "Alg"
            Aln_filename = Mid(Sfile, 1, IPos) & "Aln"
            Cla_filename = Mid(Sfile, 1, IPos) & "Cla"
            Clp_filename = Mid(Sfile, 1, IPos) & "Clp"
            GP3_filename = Mid(Sfile, 1, IPos) & "Gp3"
            Map_filename = Mid(Sfile, 1, IPos) & "Map"
            New_filename = Mid(Sfile, 1, IPos) & "New"
            Pnt_filename = Mid(Sfile, 1, IPos) & "Pnt"
            Rej_filename = Mid(Sfile, 1, IPos) & "Rej"
            SasRpt_filename = "Sas.txt"
            SoaRpt_filename = "Soa.txt"
            SOE_filename = Mid(Sfile, 1, IPos) & "Soe"
            SOR_filename = Mid(Sfile, 1, IPos) & "Sor"
            Tmp_filename = Mid(Sfile, 1, IPos) & "Tmp"
            SO1_filename = Mid(Sfile, 1, IPos) & "So1"
            Vld_filename = Mid(Sfile, 1, IPos) & "Vld"
            XYZ_filename = Mid(Sfile, 1, IPos) & "Xyz"

            Rt_filename = Mid(Sfile, 1, IPos - 1) & "Rt.tmp"
            Lt_filename = Mid(Sfile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_filename = Mid(Sfile, 1, IPos - 1) & "Rt.txt"
            DgnLt_filename = Mid(Sfile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SOAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SOAToolStripMenuItem.Click
        frmSoaInp.Show(vbModal, Me)
    End Sub
End Class