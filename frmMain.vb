Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form

    Private Property vbWindowBackground As Color

	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '        mnuSoa.Visible = False
        '		mnuSas.Visible = False
	End Sub
	

    Private Sub SASToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SASToolStripMenuItem.Click
        frmSasInp.optType1.AutoCheck = False
        frmSasInp.optType2.AutoCheck = False
        frmSasInp.optType3.AutoCheck = False

        frmSasInp.cmdNewAlign.Visible = False

        frmSasInp.txtAlignment.Visible = False
        frmSasInp.txtDescription.Visible = False
        frmSasInp.txtStation.Visible = False
        frmSasInp.lblAlign.Visible = False
        frmSasInp.lblDesc.Visible = False
        frmSasInp.lblStation.Visible = False

        frmSasInp.lblUnits.Visible = False
        frmSasInp.comboUnits.Visible = False

        frmSasInp.txtPnt1.Visible = False
        frmSasInp.txtPnt2.Visible = False
        frmSasInp.txtPnt3.Visible = False
        frmSasInp.txtPnt4.Visible = False
        frmSasInp.lblPnt1.Visible = False
        frmSasInp.lblPnt2.Visible = False
        frmSasInp.lblPnt3.Visible = False
        frmSasInp.lblPnt4.Visible = False

        frmSasInp.optCurve.Visible = False

        frmSasInp.optCurve1.Visible = True
        frmSasInp.optCurve2.Visible = True
        frmSasInp.optCurve3.Visible = True

        frmSasInp.ShowDialog()

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click

        With OpenFileDialog1
            '            .Flags = cdlOFNHideReadOnly
            .Filter = "Survey Files (*.Alg)|*.Alg"
            .FilterIndex = 2
            '            .ShowFileOpen()
            SFile = .FileName

            IPos = InStr(1, OpenFileDialog1.FileName, ".", 0)

            Alg_Filename = Mid(SFile, 1, IPos) & "Alg"
            Aln_Filename = Mid(SFile, 1, IPos) & "Aln"
            Cla_Filename = Mid(SFile, 1, IPos) & "Cla"
            Clp_Filename = Mid(SFile, 1, IPos) & "Clp"
            GP3_Filename = Mid(SFile, 1, IPos) & "Gp3"
            Map_Filename = Mid(SFile, 1, IPos) & "Map"
            New_Filename = Mid(SFile, 1, IPos) & "New"
            Pnt_Filename = Mid(SFile, 1, IPos) & "Pnt"
            Rej_Filename = Mid(SFile, 1, IPos) & "Rej"
            SasRpt_Filename = "Sas.txt"
            SoaRpt_Filename = "Soa.txt"
            SOE_Filename = Mid(SFile, 1, IPos) & "Soe"
            SOR_Filename = Mid(SFile, 1, IPos) & "Sor"
            Tmp_Filename = Mid(SFile, 1, IPos) & "Tmp"
            SO1_Filename = Mid(SFile, 1, IPos) & "So1"
            Vld_Filename = Mid(SFile, 1, IPos) & "Vld"
            XYZ_Filename = Mid(SFile, 1, IPos) & "Xyz"

            Rt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.tmp"
            Lt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.txt"
            DgnLt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True
    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileOpenToolStripMenuItem.Click

        With OpenFileDialog1
            .Filter = "Survey Files (*.Alg)|*.Alg|Map Files (*.Map)|*.Map"
            .FilterIndex = 1
            '            .ShowFileOpen()
            SFile = .FileName

            IPos = InStr(1, OpenFileDialog1.FileName, ".", 0)

            Alg_Filename = Mid(SFile, 1, IPos) & "Alg"
            Aln_Filename = Mid(SFile, 1, IPos) & "Aln"
            Cla_Filename = Mid(SFile, 1, IPos) & "Cla"
            Clp_Filename = Mid(SFile, 1, IPos) & "Clp"
            GP3_Filename = Mid(SFile, 1, IPos) & "Gp3"
            Map_Filename = Mid(SFile, 1, IPos) & "Map"
            New_Filename = Mid(SFile, 1, IPos) & "New"
            Pnt_Filename = Mid(SFile, 1, IPos) & "Pnt"
            Rej_Filename = Mid(SFile, 1, IPos) & "Rej"
            SasRpt_Filename = "Sas.txt"
            SoaRpt_Filename = "Soa.txt"
            SOE_Filename = Mid(SFile, 1, IPos) & "Soe"
            SOR_Filename = Mid(SFile, 1, IPos) & "Sor"
            Tmp_Filename = Mid(SFile, 1, IPos) & "Tmp"
            SO1_Filename = Mid(SFile, 1, IPos) & "So1"
            Vld_Filename = Mid(SFile, 1, IPos) & "Vld"
            XYZ_Filename = Mid(SFile, 1, IPos) & "Xyz"

            Rt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.tmp"
            Lt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.txt"
            DgnLt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub frmNew_Click(sender As System.Object, e As System.EventArgs) Handles frmNew.Click

        With OpenFileDialog1
            '            .Flags = cdlOFNHideReadOnly
            .Filter = "Survey Files (*.Alg)|*.Alg"
            .FilterIndex = 2
            '            .ShowOpen()
            SFile = .FileName

            IPos = InStr(1, OpenFileDialog1.FileName, ".", 0)

            Alg_Filename = Mid(SFile, 1, IPos) & "Alg"
            Aln_Filename = Mid(SFile, 1, IPos) & "Aln"
            Cla_Filename = Mid(SFile, 1, IPos) & "Cla"
            Clp_Filename = Mid(SFile, 1, IPos) & "Clp"
            GP3_Filename = Mid(SFile, 1, IPos) & "Gp3"
            Map_Filename = Mid(SFile, 1, IPos) & "Map"
            New_Filename = Mid(SFile, 1, IPos) & "New"
            Pnt_Filename = Mid(SFile, 1, IPos) & "Pnt"
            Rej_Filename = Mid(SFile, 1, IPos) & "Rej"
            SasRpt_Filename = "Sas.txt"
            SoaRpt_Filename = "Soa.txt"
            SOE_Filename = Mid(SFile, 1, IPos) & "Soe"
            SOR_Filename = Mid(SFile, 1, IPos) & "Sor"
            Tmp_Filename = Mid(SFile, 1, IPos) & "Tmp"
            SO1_Filename = Mid(SFile, 1, IPos) & "So1"
            Vld_Filename = Mid(SFile, 1, IPos) & "Vld"
            XYZ_Filename = Mid(SFile, 1, IPos) & "Xyz"

            Rt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.tmp"
            Lt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.txt"
            DgnLt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True

    End Sub

    Private Sub frmOpen_Click(sender As System.Object, e As System.EventArgs) Handles frmOpen.Click

        With OpenFileDialog1
            .Filter = "Survey Files (*.Alg)|*.Alg|Map Files (*.Map)|*.Map"
            .FilterIndex = 1
            '            .ShowOpen()
            SFile = .FileName

            IPos = InStr(1, OpenFileDialog1.FileName, ".", 0)

            Alg_Filename = Mid(SFile, 1, IPos) & "Alg"
            Aln_Filename = Mid(SFile, 1, IPos) & "Aln"
            Cla_Filename = Mid(SFile, 1, IPos) & "Cla"
            Clp_Filename = Mid(SFile, 1, IPos) & "Clp"
            GP3_Filename = Mid(SFile, 1, IPos) & "Gp3"
            Map_Filename = Mid(SFile, 1, IPos) & "Map"
            New_Filename = Mid(SFile, 1, IPos) & "New"
            Pnt_Filename = Mid(SFile, 1, IPos) & "Pnt"
            Rej_Filename = Mid(SFile, 1, IPos) & "Rej"
            SasRpt_Filename = "Sas.txt"
            SoaRpt_Filename = "Soa.txt"
            SOE_Filename = Mid(SFile, 1, IPos) & "Soe"
            SOR_Filename = Mid(SFile, 1, IPos) & "Sor"
            Tmp_Filename = Mid(SFile, 1, IPos) & "Tmp"
            SO1_Filename = Mid(SFile, 1, IPos) & "So1"
            Vld_Filename = Mid(SFile, 1, IPos) & "Vld"
            XYZ_Filename = Mid(SFile, 1, IPos) & "Xyz"

            Rt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.tmp"
            Lt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.tmp"
            DgnRt_Filename = Mid(SFile, 1, IPos - 1) & "Rt.txt"
            DgnLt_Filename = Mid(SFile, 1, IPos - 1) & "Lt.txt"
        End With
        mnuSoa.Visible = True
        mnuSas.Visible = True
    End Sub

    Private Sub frmExit_Click(sender As System.Object, e As System.EventArgs) Handles frmExit.Click
        End
    End Sub

    Private Sub frmSoa_Click(sender As System.Object, e As System.EventArgs) Handles frmSoa.Click
        frmSoaInp.ShowDialog()
    End Sub

    Private Sub frmSAS_Click(sender As System.Object, e As System.EventArgs) Handles frmSAS.Click
        frmSasInp.ShowDialog()
    End Sub
End Class