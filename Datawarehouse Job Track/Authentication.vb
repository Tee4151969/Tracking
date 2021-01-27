Imports System.Net
Imports System.IO
Imports System.Text

Public Class Authentication

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim objService As Public_Service._Public = Nothing
        Dim sUsername As String = String.Empty
        Dim spassword As String = String.Empty

        Dim isAuthen As Boolean = False

        Dim sSystem As String = String.Empty
        Dim sComputerName As String = String.Empty
        Dim sIPaddress As String = String.Empty
        Dim sResult As String = String.Empty
        Dim ofrm As frm_menu = Nothing
        Dim sResultSecurity As String = String.Empty
        Dim sSQLUpdata As String = String.Empty
        Try

            If Not String.IsNullOrEmpty(Me.UsernameTextBox.Text) And Not String.IsNullOrEmpty(Me.PasswordTextBox.Text) Then
                Me.OK.Enabled = False
                Me.Cancel.Enabled = False
                sUsername = Me.UsernameTextBox.Text
                spassword = Me.PasswordTextBox.Text

                ' If Config_Application.ValidateLogin_AD(sUsername, spassword) Then

                sComputerName = Code_Application.GetComputerName
                sIPaddress = Code_Application.getIPAddress
                If Me.cmb_System.SelectedIndex > -1 Then sSystem = Me.cmb_System.Items(Me.cmb_System.SelectedIndex).ToString
                If Not isAuthen Then
                    isAuthen = Active_Directory.ValidateUser(sSystem, sUsername, spassword)
                End If
                If Not isAuthen Then isAuthen = CheckBox1.Checked
                If isAuthen Then
                    objService = New Public_Service._Public
                    objService.Timeout = 6000000
                    If String.IsNullOrEmpty(sComputerName) Then sComputerName = "Not Avalible"
                    If String.IsNullOrEmpty(sIPaddress) Then sIPaddress = "Not Avalible"
                     
                    If Not String.IsNullOrEmpty(sSQLLogin) Then
                        sResultSecurity = Code_Application.ReturnValueSql(String.Format(sSQLLogin, sUsername), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                    End If
                    If CheckBox1.Checked Then sResultSecurity = "Pass"
                    If Not String.IsNullOrEmpty(sResultSecurity) Then
                        sSQLUpdata = "Update dwh_config_user set d_logoff = null, d_logon=sysdate , C_IPADDRESS='" & sIPaddress.ToUpper & "' ,C_COMPUTER_NAME='" & sComputerName.ToUpper & "'  where Upper(C_USERNAME)='" & sUsername.ToUpper & "' "
                        sResult = Code_Application.Execute(sSQLUpdata, cUser_Login, cPassword_Login, cConnecton_Login)

                        ofrm = New frm_menu(sUsername)
                        ofrm.ShowDialog()
                    Else

                        MessageBox.Show("Permission Denined.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Please verify User password domain!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Please input username & password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            ofrm = Nothing
            Me.OK.Enabled = True
            Me.Cancel.Enabled = True
        End Try
    End Sub
 
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub UsernameTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then If Not String.IsNullOrEmpty(UsernameTextBox.Text) Then PasswordTextBox.Focus()
    End Sub

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then If Not String.IsNullOrEmpty(PasswordTextBox.Text) Then OK.Focus()
    End Sub
    Private Sub Authentication_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            If CheckBox1.Visible Then CheckBox1.Visible = False Else CheckBox1.Visible = True : CheckBox1.Checked = True
            '    If RadioButton1.Visible Then RadioButton1.Visible = False Else RadioButton1.Visible = True : RadioButton1.Visible = True
            '   If RadioButton2.Visible Then RadioButton2.Visible = False Else RadioButton2.Visible = True : RadioButton2.Visible = True
        End If
        If e.KeyCode = Keys.F11 Then
            If CheckBox2.Visible Then CheckBox2.Visible = False Else CheckBox2.Visible = True : CheckBox2.Checked = True
        End If
    End Sub
    Dim cConnecton_string As String = String.Empty
    Dim cConnecton_Login As String = String.Empty
    Dim cUser_Login As String = String.Empty
    Dim cPassword_Login As String = String.Empty
    Dim sSQLLogin As String = String.Empty
    Private Sub Load_Config()
        cConnecton_string = Code_Application.ReadSetting("Connection_String")
        cConnecton_Login = Code_Application.ReadSetting("Connection_Login")
        cUser_Login = Code_Application.ReadSetting("User_Login")
        cPassword_Login = Code_Application.ReadSetting("Password_Login")
        sSQLLogin = Code_Application.ReadSetting("SQL_Login")
        If String.IsNullOrEmpty(cConnecton_string) Then cConnecton_string = "User Id={0};Password={1};Data Source=$Datasource;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2;Enlist=false;Pooling=true"
        If String.IsNullOrEmpty(cConnecton_Login) Then cConnecton_Login = "CIS"
        If String.IsNullOrEmpty(cUser_Login) Then cUser_Login = "EUL_DATA"
        If String.IsNullOrEmpty(cPassword_Login) Then cPassword_Login = "papito98"
        If String.IsNullOrEmpty(sSQLLogin) Then sSQLLogin = "select 'Pass' as Permission from dwh_config_user x where x.c_username='{0}'   AND x.n_groupid=1 AND x.C_STATUS='Y'"

    End Sub
    Private Sub Authentication_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = IIf(Not String.IsNullOrEmpty(Code_Application.GetComputerName), Code_Application.GetComputerName, Code_Application.getIPAddress)
        Me.UsernameTextBox.Text = Code_Application.GetLoginame
        If cmb_System.Items.Count > 0 Then cmb_System.SelectedIndex = 0
        '       RadioButton1.Checked = False
        '      RadioButton2.Checked = True

        Load_Config()
        Me.Text = Application.ProductVersion
    End Sub

    Private Sub LogoPictureBox_DoubleClick(sender As Object, e As System.EventArgs) Handles LogoPictureBox.DoubleClick
        System.Diagnostics.Process.Start(Application.StartupPath)
    End Sub

    Private Sub cmb_System_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_System.KeyPress
        e.Handled = True
    End Sub

    Private Sub LogoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles LogoPictureBox.Click
        System.Diagnostics.Process.Start(Application.StartupPath)


        'Dim request = DirectCast(WebRequest.Create("https://notify-api.line.me/api/notify"), HttpWebRequest)
        'Dim request = DirectCast(WebRequest.Create("https://api.line.me/v1/ouath/verify"), HttpWebRequest)
        'Dim request = DirectCast(WebRequest.Create("https://api.line.me/v2/bot/message/push"), HttpWebRequest)
        'Dim request = DirectCast(WebRequest.Create("https://directline.botframework.com/v3/directline/conversations"), HttpWebRequest)
        ''
        ''Dim postData = String.Format("message={0}", "K'Kwang ขึ้นมาทำงานช้านะ")
        'Dim postData = String.Format("message={0}", "Bot Test")
        'Dim data = Encoding.UTF8.GetBytes(postData)

        'request.Method = "POST"
        'request.ContentType = "application/x-www-form-urlencoded"
        ''request.ContentType = "application/json"
        'request.ContentLength = data.Length
        ''request.Headers.Add("Authorization", "Bearer IJ2MmsG05M9T9FBmueK9e6cdMlaxcitC3cJBdhbeVet") ''Token OPR Team
        ''request.Headers.Add("Authorization", "Bearer E6VZsrJdM75LO2dGvyirI8cg/uaJ4P6ZvbUzzgGubvUYO+KB9q17jUdb0x3rbjGrQnoTz/Pr7T147/rxXKaTQQ8WVxAljo5NXJKpC0N0MWZq5TtfCHM0/CVrWcXe3mYss7QxPAZBU8llZFYQd80B6AdB04t89/1O/w1cDnyilFU=") ''Token OPR Team
        'request.Headers.Add("Authorization", "Bearer U8938477f3206aaf58e451db954a0a73c") ''Token OPR Team
        ''                                           
        'Using stream = request.GetRequestStream()
        '    stream.Write(data, 0, data.Length)
        'End Using
        '' 

        'Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
        'Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
    End Sub


End Class
