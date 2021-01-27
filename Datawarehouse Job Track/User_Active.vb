Public Class User_Active
    Sub New(inUser As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Tag = inUser
        LoadData(inUser)
        ' Add any initialization after the InitializeComponent() call.

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

    Private Sub LoadData(inUser As String)
        Dim sSQL As String = String.Empty
        Dim LsvAdd As System.Windows.Forms.ListViewItem = Nothing
        Dim sUserID As String = String.Empty
        Dim sUserName As String = String.Empty
        Dim sUserFull As String = String.Empty
        Dim sUserTel As String = String.Empty
        Dim sStatus As String = String.Empty
        Dim oDatatable As DataTable = Nothing
        Try
            Load_Config()
            sSQL = "select t.n_userid,t.c_username,t.c_fullname,t.c_full_tel,case when (not  d_logon is null and  d_logoff is null) then 0 else 1 end as status "
            sSQL &= vbCrLf & " from dwh_config_user t"
            sSQL &= vbCrLf & " where 1=1 and t.c_status='Y' "
            If Not String.IsNullOrEmpty(inUser) Then
                sSQL &= vbCrLf & " and upper(t.c_username) ='" & inUser.ToUpper & "'"
            End If
            sSQL &= vbCrLf & " order by t.c_username "
            oDatatable = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            PictureBox1.Tag = oDatatable
            If Not oDatatable Is Nothing Then
                If oDatatable.Rows.Count > 0 Then

                    ListView1.Items.Clear()
                    For iRow As Integer = 0 To oDatatable.Rows.Count - 1
                        sUserID = String.Empty
                        sUserName = String.Empty
                        sUserFull = String.Empty
                        sUserTel = String.Empty
                        sStatus = 2
                        If Not oDatatable.Rows(iRow)("n_userid") Is DBNull.Value Then sUserID = oDatatable.Rows(iRow)("n_userid")
                        If Not oDatatable.Rows(iRow)("c_username") Is DBNull.Value Then sUserName = oDatatable.Rows(iRow)("c_username")
                        If Not oDatatable.Rows(iRow)("c_fullname") Is DBNull.Value Then sUserFull = oDatatable.Rows(iRow)("c_fullname")
                        If Not oDatatable.Rows(iRow)("c_full_tel") Is DBNull.Value Then sUserTel = oDatatable.Rows(iRow)("c_full_tel")
                        If Not oDatatable.Rows(iRow)("status") Is DBNull.Value Then sStatus = oDatatable.Rows(iRow)("status")
                        LsvAdd = New System.Windows.Forms.ListViewItem(New String() {"", sUserID, sUserName, sUserFull, sUserTel}, CInt(sStatus))
                        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {LsvAdd})
                    Next
                End If
            End If

        Catch ex As Exception
        Finally
            LsvAdd = Nothing
            oDatatable = Nothing

        End Try
    End Sub
    Private Sub LoadFilter(inSearch As String)
        Dim Otable As DataTable = Nothing
        Dim sUserID As String = String.Empty
        Dim sUserName As String = String.Empty
        Dim sUserFull As String = String.Empty
        Dim sStatus As String = String.Empty
        Dim sUserTel As String = String.Empty
        Dim oDatatable As DataTable = Nothing
        Dim oDataview As DataView = Nothing
        Dim LsvAdd As System.Windows.Forms.ListViewItem = Nothing
        Try

            If Not PictureBox1.Tag Is Nothing Then
                If TypeOf PictureBox1.Tag Is DataTable Then
                    Otable = CType(PictureBox1.Tag, DataTable)
                    oDataview = New DataView(Otable)
                    oDataview.RowFilter = String.Format(" n_userid like '%{0}%' or c_username like '%{0}%'  or c_fullname like '%{0}%'  or c_full_tel like '%{0}%' ", inSearch)
                    oDatatable = oDataview.ToTable
                    If Not oDatatable Is Nothing Then
                        If oDatatable.Rows.Count > 0 Then
                            ListView1.Items.Clear()
                            For iRow As Integer = 0 To oDatatable.Rows.Count - 1
                                sUserID = String.Empty
                                sUserName = String.Empty
                                sUserFull = String.Empty
                                sUserTel = String.Empty
                                sStatus = 2

                                If Not oDatatable.Rows(iRow)("n_userid") Is DBNull.Value Then sUserID = oDatatable.Rows(iRow)("n_userid")
                                If Not oDatatable.Rows(iRow)("c_username") Is DBNull.Value Then sUserName = oDatatable.Rows(iRow)("c_username")
                                If Not oDatatable.Rows(iRow)("c_fullname") Is DBNull.Value Then sUserFull = oDatatable.Rows(iRow)("c_fullname")
                                If Not oDatatable.Rows(iRow)("c_full_tel") Is DBNull.Value Then sUserTel = oDatatable.Rows(iRow)("c_full_tel")
                                If Not oDatatable.Rows(iRow)("status") Is DBNull.Value Then sStatus = oDatatable.Rows(iRow)("status")
                                LsvAdd = New System.Windows.Forms.ListViewItem(New String() {"", sUserID, sUserName, sUserFull, sUserTel}, CInt(sStatus))
                                Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {LsvAdd})
                            Next
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
        Finally
            oDatatable = Nothing
            oDataview = Nothing
            LsvAdd = Nothing
        End Try
    End Sub
    Private Sub Txt_Profile_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Txt_Profile.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(Txt_Profile.Text) Then
                LoadFilter(Txt_Profile.Text)
            End If
        End If
    End Sub

    Private Sub User_Active_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    
    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        LoadData(Me.Tag )

    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListView1.DoubleClick
        Dim sUserName As String = String.Empty
        Dim ofrm As User_Update = Nothing
        If ListView1.SelectedItems.Count > 0 Then
            sUserName = ListView1.SelectedItems(0).SubItems(1).Text
            If Not String.IsNullOrEmpty(sUserName) Then
                ofrm = New User_Update(sUserName)
                ofrm.ShowDialog()
                ofrm = Nothing
            End If
        End If
    End Sub
     
    Private Sub ImageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim sUserName As String = String.Empty
        Dim ofrm As User_Update = Nothing
        If ListView1.SelectedItems.Count > 0 Then
            sUserName = ListView1.SelectedItems(0).SubItems(1).Text
            If Not String.IsNullOrEmpty(sUserName) Then
                ofrm = New User_Update(sUserName)
                ofrm.ShowDialog()
                ofrm = Nothing
            End If
        End If
    End Sub
   
    Private Sub CallToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim sUSERID As String = String.Empty

        Dim x As Integer = 0
        Dim Y As Integer = 0
        Dim Point As Point = Nothing
        Dim oDatatable As DataTable = Nothing
        Dim sQTY As String = String.Empty
        Dim sQTYReponse As String = String.Empty
        Dim sUserFullname As String = String.Empty
        Dim sSQL As String = String.Empty
        Dim sDefectName As String = String.Empty
        Dim sRemark As String = String.Empty
        Dim sPPNBY As String = String.Empty
        Dim sFormat As String = "Track Owner ({0}) : Reponse ({1})"
        Dim inUser As String = String.Empty
        ' This call is required by the designer.
        Dim ofrm As FRM_BALLOON
        Try
            Load_Config()
            If ListView1.SelectedItems.Count > 0 Then inUser = ListView1.SelectedItems(0).SubItems(2).Text


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
            sSQL &= vbCrLf & "      where upper(x.owner)=upper(c_Username) and x.n_cr_by<>N_USERID"
            sSQL &= vbCrLf & "      )) as PPN_SEND_BY"
            sSQL &= vbCrLf & " from dwh_config_user where upper(c_username)='" & inUser.ToUpper & "'"

            oDatatable = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            If Not oDatatable Is Nothing Then
                If oDatatable.Rows.Count > 0 Then
                    If Not oDatatable.Rows(0)("N_USERID") Is DBNull.Value Then sUSERID = oDatatable.Rows(0)("N_USERID")
                    If Not oDatatable.Rows(0)("C_FULLNAME") Is DBNull.Value Then sUserFullname = oDatatable.Rows(0)("C_FULLNAME")
                    If Not oDatatable.Rows(0)("QTY_OWNER") Is DBNull.Value Then sQTY = oDatatable.Rows(0)("QTY_OWNER")
                    If Not oDatatable.Rows(0)("QTY_RESPONSE") Is DBNull.Value Then sQTYReponse = oDatatable.Rows(0)("QTY_RESPONSE")
                    If Not oDatatable.Rows(0)("DEFECT_NAME") Is DBNull.Value Then sDefectName = oDatatable.Rows(0)("DEFECT_NAME")
                    If Not oDatatable.Rows(0)("REMARK") Is DBNull.Value Then sRemark = oDatatable.Rows(0)("REMARK")
                    If Not oDatatable.Rows(0)("PPN_SEND_BY") Is DBNull.Value Then sPPNBY = oDatatable.Rows(0)("PPN_SEND_BY")
                    If String.IsNullOrEmpty(sQTY) Then sQTY = "0"
                    If String.IsNullOrEmpty(sQTYReponse) Then sQTYReponse = "0"
                End If
            End If

            ofrm = New FRM_BALLOON(inUser, String.Format(sFormat, sQTY, sQTYReponse), " Description : " & sDefectName & " /  Remark : " & sRemark, 1, sPPNBY, 1)
            x = Screen.PrimaryScreen.WorkingArea.Width - ofrm.Width
            Y = 0 'Screen.PrimaryScreen.WorkingArea.Height - ofrm.Height
            Point = New Point(x, Y)
            ofrm.Location = Point
            ofrm.StartPosition = FormStartPosition.Manual
            ofrm.Show()
        Catch ex As Exception
        Finally

        End Try
    End Sub
 
End Class