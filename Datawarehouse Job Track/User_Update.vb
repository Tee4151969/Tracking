Imports System.Net
Imports System.IO

Public Class User_Update


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

    Sub New(inUser As String)
        Dim blobImage As Byte() = Nothing
        Dim fs As IO.FileStream = Nothing
        Dim objPicture As Panel = Nothing
        Dim obj_DatatablePicture As DataTable = Nothing
        Dim sSQLSelect As String = String.Empty
        Dim sFormat As String = "http://truehrsh/empimg/{0}.jpg"
        ' This call is required by the designer.
        InitializeComponent()
        Me.Tag = inUser
        sSQLSelect = "SELECT IMAGE FROM DWH_CONFIG_USER WHERE N_USERID= '{0}'"
        Load_Config()
        ' Add any initialization after the InitializeComponent() call.
        Try
            obj_DatatablePicture = Code_Application.ReturnValueToDatatable(String.Format(sSQLSelect, inUser.ToUpper), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            If Not obj_DatatablePicture Is Nothing Then
                If obj_DatatablePicture.Rows.Count > 0 Then
                    If Not obj_DatatablePicture.Rows(0)("IMAGE") Is DBNull.Value Then blobImage = CType(obj_DatatablePicture.Rows(0)("IMAGE"), Byte())
                    If Not blobImage Is Nothing Then
                        fs = New IO.FileStream(Guid.NewGuid.ToString, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                        fs.Write(blobImage, 0, blobImage.Length)
                    End If
                    If Not fs Is Nothing Then
                        Dim img = Image.FromStream(fs)
                        PictureBox1.Image = img
                    End If
                End If
                If fs Is Nothing Then
                    Try
                        Dim tClient As WebClient = New WebClient
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(String.Format(sFormat, inUser))))
                        PictureBox1.Image = tImage
                    Catch ex As Exception
                        PictureBox1.Image = My.Resources.Notify
                    End Try
                End If
            End If
        Catch exx As Exception
            Dim ee As String = exx.Message
            PictureBox1.Image = My.Resources.Notify
        Finally
            blobImage = Nothing
            fs = Nothing
        End Try
    End Sub

    Private Sub User_Update_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub


    Private Sub PictureBox1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragDrop
        Dim sSQLUpdateBlob As String = "UPDATE DWH_CONFIG_USER SET  IMAGE=:IMAGE WHERE N_USERID=:N_USERID"
        Dim sConnection As String = String.Format(cConnecton_string.Replace("$Datasource", cConnecton_Login), cUser_Login, cPassword_Login)
        'Dim oraConnection As New Oracle.DataAccess.Client.OracleConnection(sConnection)
        'Dim oraCleCommand As Oracle.DataAccess.Client.OracleCommand = Nothing

        Dim iResult As Integer = 0
        Dim sValueKey As String = String.Empty
        Dim strDarg As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        Dim objPicture As PictureBox = Nothing
        Dim fs As Byte() = Nothing
        Dim sResult As String = String.Empty
        Dim arrayParam() As Public_Service.ParamOracle = Nothing
        Try
            If TypeOf sender Is PictureBox Then
                objPicture = CType(sender, PictureBox)
            End If
            If Not objPicture Is Nothing Then
                    sValueKey = Me.Tag
                    For Each filelocation As String In strDarg
                        objPicture.ImageLocation = filelocation
                    Next
                    If Not objPicture.ImageLocation Is Nothing Then
                        fs = (IO.File.ReadAllBytes(objPicture.ImageLocation))
                        If Not fs Is Nothing Then
                            ReDim arrayParam(1)

                        arrayParam(0) = New Public_Service.ParamOracle
                            arrayParam(0).Key = "IMAGE"
                            arrayParam(0).Value = fs
                            arrayParam(0).Type = Public_Service.OracleDbType.Blob

                        arrayParam(1) = New Public_Service.ParamOracle
                            arrayParam(1).Key = "N_USERID"
                            arrayParam(1).Value = sValueKey
                            arrayParam(1).Type = Public_Service.OracleDbType.Varchar2

                            sResult = (Code_Application.ExecuteWithBlob(sConnection, sSQLUpdateBlob, arrayParam))

                    End If
                End If
            End If

        Catch ex As Exception
            Dim sMessage As String = ex.Message
        Finally
            objPicture = Nothing
            strDarg = Nothing
            fs = Nothing
            arrayParam = Nothing
        End Try
    End Sub

  
    Private Sub User_Update_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.AllowDrop = True
        PictureBox1.AllowDrop = True
    End Sub

    Private Sub PictureBox1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class