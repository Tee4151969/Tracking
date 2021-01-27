Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports System.Net
Imports System.IO

Public Class frm_menu
    Private Sub RefreshNotify(inUser As String)
        Dim oDatatable As DataTable = Nothing
        Dim sQTY As String = String.Empty
        Dim sQTYReponse As String = String.Empty
        Dim sUserID As String = String.Empty
        Dim sUserFullname As String = String.Empty
        Dim sSQL As String = String.Empty
        Dim sDefectNo As String = String.Empty
        Dim sDefectName As String = String.Empty
        Dim sRemark As String = String.Empty
        Dim sPPNBY As String = String.Empty
        Dim popUpAlert As RadDesktopAlert = Nothing
        Dim sFormatCaption As String = "{0} : {1}"
        Dim sFormatCaptionDefectNo As String = "{0} : {1}"
        Dim sFormat As String = "Job ({0}/{1})"
        sSQL = "Select N_USERID,C_FULLNAME"
        sSQL &= vbCrLf & " ,(select Nvl(count(distinct x.Defect_No),0) "
        sSQL &= vbCrLf & " from  dwh_job_track x "
        sSQL &= vbCrLf & " where upper(x.n_cr_by) = upper(N_USERID)"
        sSQL &= vbCrLf & " and  x.DEFECT_NO_PARENT is null "
        sSQL &= vbCrLf & " and Upper(x.defect_status) in   ('OPEN', 'NEW', 'RENEW', 'KNOW', 'HOWTO')) as QTY_OWNER"
        sSQL &= vbCrLf & " ,(select Nvl(count(distinct x.Defect_No),0) "
        sSQL &= vbCrLf & " from  dwh_job_track x "
        sSQL &= vbCrLf & " where upper(x.n_cr_by) = upper(N_USERID)"
        sSQL &= vbCrLf & " and  x.DEFECT_NO_PARENT is null "
        sSQL &= vbCrLf & " and not Upper(x.defect_status) in   ('OPEN', 'NEW', 'RENEW', 'KNOW', 'HOWTO')) as QTY_RESPONSE "
        sSQL &= vbCrLf & " ,   (select max(x.Defect_No) "
        sSQL &= vbCrLf & "      from  dwh_job_track x "
        sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
        sSQL &= vbCrLf & "      ) as defect_no"
        sSQL &= vbCrLf & " ,(select nvl(Max(DEFECT_NAME),'-') "
        sSQL &= vbCrLf & " from  dwh_job_track x "
        sSQL &= vbCrLf & " where x.defect_no =  "
        sSQL &= vbCrLf & "      (select max(x.Defect_No) "
        sSQL &= vbCrLf & "      from  dwh_job_track x "
        sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
        sSQL &= vbCrLf & "      )) as DEFECT_NAME"
        sSQL &= vbCrLf & " ,(select nvl(Max(REMARK),'-') "
        sSQL &= vbCrLf & " from  dwh_job_track x "
        sSQL &= vbCrLf & " where x.defect_no =  "
        sSQL &= vbCrLf & "      (select max(x.Defect_No) "
        sSQL &= vbCrLf & "      from  dwh_job_track x "
        sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
        sSQL &= vbCrLf & "      )) as REMARK"
        sSQL &= vbCrLf & " ,(select nvl(Max(N_CR_BY),'01067499') "
        sSQL &= vbCrLf & " from  dwh_job_track x "
        sSQL &= vbCrLf & " where x.defect_no =  "
        sSQL &= vbCrLf & "      (select max(x.Defect_No) "
        sSQL &= vbCrLf & "      from  dwh_job_track x "
        sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username)  and x.n_cr_by<>N_USERID "
        sSQL &= vbCrLf & "      )) as PPN_SEND_BY"
        sSQL &= vbCrLf & " from dwh_config_user where upper(c_username)='" & inUser.ToUpper & "'"

        oDatatable = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
        If Not oDatatable Is Nothing Then
            If oDatatable.Rows.Count > 0 Then
                If Not oDatatable.Rows(0)("N_USERID") Is DBNull.Value Then sUserID = oDatatable.Rows(0)("N_USERID")
                If Not oDatatable.Rows(0)("C_FULLNAME") Is DBNull.Value Then sUserFullname = oDatatable.Rows(0)("C_FULLNAME")
                If Not oDatatable.Rows(0)("QTY_OWNER") Is DBNull.Value Then sQTY = oDatatable.Rows(0)("QTY_OWNER")
                If Not oDatatable.Rows(0)("QTY_RESPONSE") Is DBNull.Value Then sQTYReponse = oDatatable.Rows(0)("QTY_RESPONSE")
                If Not oDatatable.Rows(0)("DEFECT_NO") Is DBNull.Value Then sDefectNo = oDatatable.Rows(0)("DEFECT_NO")
                If Not oDatatable.Rows(0)("DEFECT_NAME") Is DBNull.Value Then sDefectName = oDatatable.Rows(0)("DEFECT_NAME")
                If Not oDatatable.Rows(0)("REMARK") Is DBNull.Value Then sRemark = oDatatable.Rows(0)("REMARK")
                If Not oDatatable.Rows(0)("PPN_SEND_BY") Is DBNull.Value Then sPPNBY = oDatatable.Rows(0)("PPN_SEND_BY")
                If String.IsNullOrEmpty(sQTY) Then sQTY = "0"
                If String.IsNullOrEmpty(sQTYReponse) Then sQTYReponse = "0"
                ToolStripUserID.Text = sUserID
                ToolStripUserName.Text = sUserFullname
                ToolStripDefect.AccessibleName = sPPNBY
                ToolStripDefect.Text = String.Format(sFormat, sQTY, sQTYReponse)
                ToolStripDefect.Tag = " Description : " & sDefectName & " /  Remark : " & sRemark


                'sSQL = "Select N_USERID,C_FULLNAME"
                'sSQL &= vbCrLf & " ,(select Nvl(count(distinct x.Defect_No),0) "
                'sSQL &= vbCrLf & " from  dwh_job_track x "
                'sSQL &= vbCrLf & " where upper(x.n_cr_by) = upper(N_USERID)"
                'sSQL &= vbCrLf & " and  x.DEFECT_NO_PARENT is null "
                'sSQL &= vbCrLf & " and Upper(x.defect_status) in   ('OPEN', 'NEW', 'RENEW', 'KNOW', 'HOWTO')) as QTY_OWNER"
                'sSQL &= vbCrLf & " ,(select Nvl(count(distinct x.Defect_No),0) "
                'sSQL &= vbCrLf & " from  dwh_job_track x "
                'sSQL &= vbCrLf & " where upper(x.n_cr_by) = upper(N_USERID)"
                'sSQL &= vbCrLf & " and  x.DEFECT_NO_PARENT is null "
                'sSQL &= vbCrLf & " and not Upper(x.defect_status) in   ('OPEN', 'NEW', 'RENEW', 'KNOW', 'HOWTO')) as QTY_RESPONSE "
                'sSQL &= vbCrLf & "      ,(select max(x.Defect_No) "
                'sSQL &= vbCrLf & "      from  dwh_job_track x "
                'sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
                'sSQL &= vbCrLf & "      ) as Defect_No"
                'sSQL &= vbCrLf & " ,(select nvl(Max(DEFECT_NAME),'-') "
                'sSQL &= vbCrLf & " from  dwh_job_track x "
                'sSQL &= vbCrLf & " where x.defect_no =  "
                'sSQL &= vbCrLf & "      (select max(x.Defect_No) "
                'sSQL &= vbCrLf & "      from  dwh_job_track x "
                'sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
                'sSQL &= vbCrLf & "      )) as DEFECT_NAME"
                'sSQL &= vbCrLf & " ,(select nvl(Max(REMARK),'-') "
                'sSQL &= vbCrLf & " from  dwh_job_track x "
                'sSQL &= vbCrLf & " where x.defect_no =  "
                'sSQL &= vbCrLf & "      (select max(x.Defect_No) "
                'sSQL &= vbCrLf & "      from  dwh_job_track x "
                'sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) "
                'sSQL &= vbCrLf & "      )) as REMARK"
                'sSQL &= vbCrLf & " ,(select nvl(Max(N_CR_BY),'01067499') "
                'sSQL &= vbCrLf & " from  dwh_job_track x "
                'sSQL &= vbCrLf & " where x.defect_no =  "
                'sSQL &= vbCrLf & "      (select max(x.Defect_No) "
                'sSQL &= vbCrLf & "      from  dwh_job_track x "
                'sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username)  and x.n_cr_by<>N_USERID "
                'sSQL &= vbCrLf & "      )) as PPN_SEND_BY"
                'sSQL &= vbCrLf & " from dwh_config_user where upper(c_username)='" & inUser.ToUpper & "'"


 
              

                sSQL = " WITH T_1 as ("
                sSQL &= vbCrLf & "  select *"
                sSQL &= vbCrLf & "  from (Select 1 as SEQ,"
                sSQL &= vbCrLf & "    a.N_USERID,"
                sSQL &= vbCrLf & "      a.C_FULLNAME,"
                sSQL &= vbCrLf & "        b.defect_no,"
                sSQL &= vbCrLf & "       b.defect_name,"
                sSQL &= vbCrLf & "       nvl((SELECT BB.DEFECT_STATUS"
                sSQL &= vbCrLf & "             FROM DWH_JOB_TRACK BB"
                sSQL &= vbCrLf & "           WHERE BB.DEFECT_NO IN"
                sSQL &= vbCrLf & "                (SELECT MAX(AA.DEFECT_NO)"
                sSQL &= vbCrLf & "                   FROM DWH_JOB_TRACK AA"
                sSQL &= vbCrLf & "                 WHERE AA.DEFECT_NO_PARENT = b.defect_no)),"
                sSQL &= vbCrLf & "        b.defect_status) as defect_status,"
                sSQL &= vbCrLf & "        nvl((SELECT BB.remark  FROM DWH_JOB_TRACK BB  WHERE BB.DEFECT_NO IN  (SELECT MAX(AA.DEFECT_NO) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = b.defect_no)),b.remark) as  remark,"
                sSQL &= vbCrLf & "     b.n_cr_by,"
                sSQL &= vbCrLf & "      c.c_fullname as PPN_SEND_BY"
                sSQL &= vbCrLf & "    from dwh_config_user a, dwh_job_track b, dwh_config_user c"
                sSQL &= vbCrLf & "   where upper(a.c_username) = '" & inUser.ToUpper & "'"
                sSQL &= vbCrLf & "         and upper(a.C_FULLNAME) <> Upper(c.c_fullname)"
                sSQL &= vbCrLf & "        and upper(b.owner) <> 'ALL'"
                sSQL &= vbCrLf & "       and b.n_cr_by = c.n_userid(+)"
                sSQL &= vbCrLf & "     order by defect_no desc)"
                sSQL &= vbCrLf & "   WHERE NOT UPPER(DEFECT_STATUS) IN ('CLOSE', 'FIX')"
                sSQL &= vbCrLf & "    and rownum = 1"
                sSQL &= vbCrLf & "  ), T_2 as ("
                sSQL &= vbCrLf & "  select *"
                sSQL &= vbCrLf & "   from (Select 2 as SEQ,"
                sSQL &= vbCrLf & "              a.N_USERID,"
                sSQL &= vbCrLf & "               a.C_FULLNAME,"
                sSQL &= vbCrLf & "              b.defect_no,"
                sSQL &= vbCrLf & "               b.defect_name,"
                sSQL &= vbCrLf & "             nvl((SELECT BB.DEFECT_STATUS"
                sSQL &= vbCrLf & "                  FROM DWH_JOB_TRACK BB"
                sSQL &= vbCrLf & "                WHERE BB.DEFECT_NO IN"
                sSQL &= vbCrLf & "                      (SELECT MAX(AA.DEFECT_NO)"
                sSQL &= vbCrLf & "                    FROM DWH_JOB_TRACK AA"
                sSQL &= vbCrLf & "                      WHERE AA.DEFECT_NO_PARENT = b.defect_no)),"
                sSQL &= vbCrLf & "         b.defect_status) as defect_status,"
                sSQL &= vbCrLf & "          nvl((SELECT BB.remark  FROM DWH_JOB_TRACK BB  WHERE BB.DEFECT_NO IN  (SELECT MAX(AA.DEFECT_NO) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = b.defect_no)),b.remark) as  remark,"
                sSQL &= vbCrLf & "     b.n_cr_by,"
                sSQL &= vbCrLf & "        c.c_fullname as PPN_SEND_BY"
                sSQL &= vbCrLf & "     from dwh_config_user a, dwh_job_track b, dwh_config_user c"
                sSQL &= vbCrLf & "   where upper(a.c_username) = '" & inUser.ToUpper & "'"
                sSQL &= vbCrLf & "        and upper(b.owner) = 'ALL'"
                sSQL &= vbCrLf & "        and b.n_cr_by = c.n_userid(+)"
                sSQL &= vbCrLf & "     order by defect_no desc)"
                sSQL &= vbCrLf & "  WHERE NOT UPPER(DEFECT_STATUS) IN ('CLOSE', 'FIX')"
                sSQL &= vbCrLf & "    and rownum = 1"
                sSQL &= vbCrLf & "  )"
                sSQL &= vbCrLf & "  ,T_3 as (select *"
                sSQL &= vbCrLf & "           from (Select 3 as SEQ,"
                sSQL &= vbCrLf & "                            a.N_USERID,"
                sSQL &= vbCrLf & "           a.C_FULLNAME,"
                sSQL &= vbCrLf & "          b.defect_no,"
                sSQL &= vbCrLf & "          b.defect_name,"
                sSQL &= vbCrLf & "              nvl((SELECT BB.DEFECT_STATUS"
                sSQL &= vbCrLf & "                FROM DWH_JOB_TRACK BB"
                sSQL &= vbCrLf & "                  WHERE BB.DEFECT_NO IN"
                sSQL &= vbCrLf & "                (SELECT MAX(AA.DEFECT_NO)"
                sSQL &= vbCrLf & "                 FROM DWH_JOB_TRACK AA"
                sSQL &= vbCrLf & "             WHERE AA.DEFECT_NO_PARENT ="
                sSQL &= vbCrLf & "                     b.defect_no)),"
                sSQL &= vbCrLf & "       b.defect_status) as defect_status,"
                sSQL &= vbCrLf & "         nvl((SELECT BB.remark  FROM DWH_JOB_TRACK BB  WHERE BB.DEFECT_NO IN  (SELECT MAX(AA.DEFECT_NO) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = b.defect_no)),b.remark) as  remark,"
                sSQL &= vbCrLf & "        b.n_cr_by,"
                sSQL &= vbCrLf & "          c.c_fullname as PPN_SEND_BY"
                sSQL &= vbCrLf & "      from dwh_config_user a,"
                sSQL &= vbCrLf & "           dwh_job_track   b,"
                sSQL &= vbCrLf & "            dwh_config_user c"
                sSQL &= vbCrLf & "   where upper(a.c_username) = '" & inUser.ToUpper & "'"
                sSQL &= vbCrLf & "          and upper(a.C_FULLNAME) <>"
                sSQL &= vbCrLf & "            Upper(c.c_fullname)"
                sSQL &= vbCrLf & "         and upper(a.c_username) ="
                sSQL &= vbCrLf & "              upper(b.owner)"
                sSQL &= vbCrLf & "        and b.n_cr_by ="
                sSQL &= vbCrLf & "           c.n_userid(+)"
                sSQL &= vbCrLf & "      order by defect_no desc)"
                sSQL &= vbCrLf & "      WHERE NOT UPPER(DEFECT_STATUS) IN"
                sSQL &= vbCrLf & "           ('CLOSE', 'FIX')"
                sSQL &= vbCrLf & "        and rownum <= 10)"
                sSQL &= vbCrLf & "  select * from t_1"
                sSQL &= vbCrLf & "  union"
                sSQL &= vbCrLf & "  select * from t_2"
                sSQL &= vbCrLf & "  union"
                sSQL &= vbCrLf & "  select * from t_3"
                sSQL &= vbCrLf & "  where not t_3.defect_no in (select defect_no from t_1)"
                sSQL &= vbCrLf & "  and   not t_3.defect_no in (select defect_no from t_2)"

                oDatatable = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                If Not oDatatable Is Nothing Then
                    If oDatatable.Rows.Count > 0 Then
                        For iShow As Integer = 0 To oDatatable.Rows.Count - 1
                            If iShow > 3 Then Exit For
                            If Not oDatatable.Rows(iShow)("N_USERID") Is DBNull.Value Then sUserID = oDatatable.Rows(iShow)("N_USERID")
                            If Not oDatatable.Rows(iShow)("C_FULLNAME") Is DBNull.Value Then sUserFullname = oDatatable.Rows(iShow)("C_FULLNAME")
                            'If Not oDatatable.Rows(0)("QTY_OWNER") Is DBNull.Value Then sQTY = oDatatable.Rows(0)("QTY_OWNER")
                            'If Not oDatatable.Rows(0)("QTY_RESPONSE") Is DBNull.Value Then sQTYReponse = oDatatable.Rows(0)("QTY_RESPONSE")
                            If Not oDatatable.Rows(iShow)("DEFECT_NO") Is DBNull.Value Then sDefectNo = oDatatable.Rows(iShow)("DEFECT_NO")
                            If Not oDatatable.Rows(iShow)("DEFECT_NAME") Is DBNull.Value Then sDefectName = oDatatable.Rows(iShow)("DEFECT_NAME")
                            If Not oDatatable.Rows(iShow)("REMARK") Is DBNull.Value Then sRemark = oDatatable.Rows(iShow)("REMARK")
                            If Not oDatatable.Rows(iShow)("n_cr_by") Is DBNull.Value Then sPPNBY = oDatatable.Rows(iShow)("n_cr_by")
                            If String.IsNullOrEmpty(sQTY) Then sQTY = "0"
                            If String.IsNullOrEmpty(sQTYReponse) Then sQTYReponse = "0"
                            ToolStripUserID.Text = sUserID
                            ToolStripUserName.Text = sUserFullname
                            ToolStripDefect.AccessibleName = sPPNBY
                            ToolStripDefect.Text = String.Format(sFormat, sQTY, sQTYReponse)
                            ToolStripDefect.Tag = " Description : " & sDefectName & " /  Remark : " & sRemark
                            If iShow = 0 Then
                                popup_Alert.CaptionText = String.Format(sFormatCaption, sUserFullname, String.Format(sFormat, sQTY, sQTYReponse))
                                popup_Alert.ContentText = "<html><p><b><span><color=Blue>  " & sDefectName & "  </span></b></p><br><span><i> " & sRemark & " </i></span></html>"
                                popup_Alert.ScreenPosition = AlertScreenPosition.BottomRight
                                popup_Alert.ContentImage = ContentIMage(sPPNBY, sUserID)
                                popup_Alert.Show()

                                popupDefect.Tag = sDefectNo
                                popupDefect.ToolTipText = sDefectNo

                            Else
                                popUpAlert = New RadDesktopAlert
                                popUpAlert.FixedSize = New Size(350, 170)
                                popUpAlert.CaptionText = String.Format(sFormatCaptionDefectNo, sDefectNo, sUserFullname)
                                popUpAlert.ContentText = "<html><p><b><span><color=Blue>  " & sDefectName & "  </span></b></p><br><span><i> " & sRemark & " </i></span></html>"
                                popUpAlert.ContentImage = ContentIMage(sPPNBY, sUserID)
                                popUpAlert.ScreenPosition = AlertScreenPosition.BottomRight
                                popUpAlert.Show()

                                popUpAlert = Nothing
                            End If

                        Next
                    End If
                End If

            

            End If
        End If

    End Sub
    Sub New(ByVal inUser As String)
        ' This call is required by the designer.
        InitializeComponent()
        Load_Config()
        Me.Tag = inUser
        ' Add any initialization after the InitializeComponent() call.
        RefreshNotify(inUser)
    End Sub
    Dim cConnecton_string As String = String.Empty
    Dim cConnecton_Login As String = String.Empty
    Dim cUser_Login As String = String.Empty
    Dim cPassword_Login As String = String.Empty
    Dim isModeNewEdit As Boolean = False
    Private Sub Load_Config()
        cConnecton_string = Code_Application.ReadSetting("Connection_String")
        cConnecton_Login = Code_Application.ReadSetting("Connection_Login")
        cUser_Login = Code_Application.ReadSetting("User_Login")
        cPassword_Login = Code_Application.ReadSetting("Password_Login")
        If String.IsNullOrEmpty(cConnecton_string) Then cConnecton_string = "User Id={0};Password={1};Data Source=$Datasource;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2;Enlist=false;Pooling=true"
        If String.IsNullOrEmpty(cConnecton_Login) Then cConnecton_Login = "CIS"
        If String.IsNullOrEmpty(cUser_Login) Then cUser_Login = "EUL_DATA"
        If String.IsNullOrEmpty(cPassword_Login) Then cPassword_Login = "papito98"

    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub TrackMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If xFRM_MAIN Is Nothing Then
                xFRM_MAIN = New FRM_MAIN(Me.Tag)
                xFRM_MAIN.MdiParent = Me
                xFRM_MAIN.WindowState = FormWindowState.Normal
                xFRM_MAIN.Show()
            Else
                xFRM_MAIN.MdiParent = Me
                xFRM_MAIN.WindowState = FormWindowState.Normal
                xFRM_MAIN.Show()
                xFRM_MAIN.Activate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub TrackMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackMenu.Click
        TrackMenuItem_Click(sender, e)
    End Sub

    Private Sub LoginMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As Authentication = Nothing
        Try
            ChildForm = New Authentication
            ChildForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            ChildForm = Nothing
        End Try
    End Sub
    Private Function ContentIMage(ByVal inEmp As String, ByVal inOwner As String) As Image
        Dim imgResult As Image = Nothing
        Dim blobImage As Byte() = Nothing
        Dim fs As IO.FileStream = Nothing
        Dim objPicture As Panel = Nothing
        Dim obj_DatatablePicture As DataTable = Nothing
        Dim sSQLSelect As String = String.Empty
        Dim Width As Integer = 100
        Dim Height As Integer = 100
        Dim sFormat As String = "http://truehrsh/empimg/{0}.jpg"
        Dim bm_source As Bitmap = Nothing
        Dim bm_dest As Bitmap = Nothing
        Dim gr_dest As Graphics = Nothing

        ' This call is required by the designer.
        sSQLSelect = "SELECT IMAGE FROM DWH_CONFIG_USER WHERE N_USERID= '{0}'"
        ' Add any initialization after the InitializeComponent() call.
        Try
            Load_Config()
            obj_DatatablePicture = Code_Application.ReturnValueToDatatable(String.Format(sSQLSelect, inEmp.ToUpper), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            If Not obj_DatatablePicture Is Nothing Then
                If obj_DatatablePicture.Rows.Count > 0 Then
                    If Not obj_DatatablePicture.Rows(0)("IMAGE") Is DBNull.Value Then blobImage = CType(obj_DatatablePicture.Rows(0)("IMAGE"), Byte())
                    If Not blobImage Is Nothing Then
                        fs = New IO.FileStream(Guid.NewGuid.ToString, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                        fs.Write(blobImage, 0, blobImage.Length)
                    End If
                    If Not fs Is Nothing Then
                        Dim img = Image.FromStream(fs)
                        imgResult = img
                    End If
                End If
                If fs Is Nothing Then
                    Try
                        Dim tClient As WebClient = New WebClient
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(String.Format(sFormat, inEmp))))
                        imgResult = tImage
                    Catch ex As Exception
                        Try
                            Dim tClient As WebClient = New WebClient
                            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(String.Format(sFormat, inOwner))))
                            imgResult = tImage
                        Catch exx As Exception
                            imgResult = My.Resources.Notify
                        End Try
                    End Try
                End If
            End If

            If Not imgResult Is Nothing Then
                bm_source = New Bitmap(imgResult)
                ' Make a bitmap for the result.
                bm_dest = New Bitmap(imgResult, Width, Height)
                ' Make a Graphics object for the result Bitmap.
                gr_dest = Graphics.FromImage(bm_dest)
                ' Copy the source image into the destination bitmap.
                gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)


            End If
        Catch exx As Exception
            bm_dest = Nothing
            Dim ee As String = exx.Message
        Finally
            blobImage = Nothing
            gr_dest = Nothing
            bm_source = Nothing
            imgResult = Nothing
            fs = Nothing
        End Try
        If bm_dest Is Nothing Then bm_dest = My.Resources.Notify
        Return bm_dest
    End Function
    Private Sub NotifyMenu_Click(sender As System.Object, e As System.EventArgs) Handles NotifyMenu.Click
         
        Try
            RefreshNotify(Me.Tag)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frm_menu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frm_menu_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sSQLUpdata As String = String.Empty
        Dim sResult As String = String.Empty
        Try
            If TypeOf Me.Tag Is String Then
                If Not String.IsNullOrEmpty(Me.Tag) Then
                    sSQLUpdata = "Update dwh_config_user set d_logoff = sysdate where Upper(C_USERNAME)='" & Me.Tag.ToString.ToUpper & "'"
                    sResult = Code_Application.Execute(sSQLUpdata, cUser_Login, cPassword_Login, cConnecton_Login)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_menu_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    End Sub
    Private Sub buttonElement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iDefectNo As Integer = 0
        If Not (CType(sender, RadButtonElement).Tag) Is Nothing Then
            If IsNumeric(CType(sender, RadButtonElement).Tag) Then
                iDefectNo = CType(sender, RadButtonElement).Tag
                If xFRM_MAIN Is Nothing Then
                    xFRM_MAIN = New FRM_MAIN(Me.Tag)
                    xFRM_MAIN.inPubDefectNo = iDefectNo
                    xFRM_MAIN.MdiParent = Me
                    xFRM_MAIN.WindowState = FormWindowState.Normal
                    xFRM_MAIN.Show()
                Else
                    xFRM_MAIN.MdiParent = Me
                    xFRM_MAIN.inPubDefectNo = iDefectNo
                    xFRM_MAIN.WindowState = FormWindowState.Normal
                    xFRM_MAIN.Show()
                    xFRM_MAIN.Activate()
                End If
            End If
        End If
    End Sub
    Private Sub frm_menu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NotifyMenu_Click(sender, e)

        AddHandler popupDefect.Click, AddressOf buttonElement_Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim ofrm As AboutBox
        ofrm = New AboutBox
        ofrm.Show()
        ofrm = Nothing

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles NotifyMenuItem.Click
        If NotifyMenuItem.Text = "Notify" Then
            NotifyMenuItem.Text = "No Notify"
            NotifyMenuItem.Image = My.Resources.NoNotify
        Else
            NotifyMenuItem.Text = "Notify"
            NotifyMenuItem.Image = My.Resources.Notify
        End If
        If NotifyMenuItem.Text = "Notify" Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        TrackMenu_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim iTime As Integer = 0
        Dim sText As String = String.Empty
        Try
            sText = InputBox("Setting time notify (x) Minute", Me.Text, "10")
            If Not String.IsNullOrEmpty(sText) Then
                If IsNumeric(sText) Then iTime = sText * 6000
                Timer1.Interval = iTime
            End If

            NotifyMenu_Click(sender, e)
        Catch ex As Exception
            Timer1.Interval = 600000
        End Try
    End Sub

    Private Sub NoitfySizeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NoitfySizeMenuItem.Click
        If NoitfySizeMenuItem.Text = "Notify Minimized" Then
            NoitfySizeMenuItem.Text = "Notify Maximized"
            NoitfySizeMenuItem.Tag = 0
            NoitfySizeMenuItem.Image = My.Resources.Minimize_U
        Else
            NoitfySizeMenuItem.Text = "Notify Minimized"
            NoitfySizeMenuItem.Tag = 1
            NoitfySizeMenuItem.Image = My.Resources.maximize_03
        End If
    End Sub

    Private Sub ProfileMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProfileMenuItem.Click
        Dim ofrm As User_Active = Nothing
        Try
            ofrm = New User_Active(IIf(Me.Tag.ToString.ToUpper = "PORNC25", "", Me.Tag))
            ofrm.ShowDialog()
        Catch ex As Exception
        Finally
            ofrm = Nothing
        End Try
    End Sub

    Private Sub ShakeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShakeMenuItem.Click
        If ShakeMenuItem.Tag = 0 Then
            ShakeMenuItem.Tag = 1
            ShakeMenuItem.Text = "Shake"
            ShakeMenuItem.Image = My.Resources.Shake
            NotifyMenu_Click(sender, e)
        Else
            ShakeMenuItem.Tag = 0
            ShakeMenuItem.Text = "No Shake"
            ShakeMenuItem.Image = My.Resources.Close_Red
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        NotifyMenu_Click(sender, e)
    End Sub
End Class
