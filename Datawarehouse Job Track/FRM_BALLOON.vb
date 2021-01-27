Imports System.Net
Imports System.IO
Imports System.Text

Public Class FRM_BALLOON
    Dim shakeCount As Integer = 0
    Dim limitshare As Integer = 3000
    Dim iShake As Integer = 0
    Sub New(inUser As String, sMessageQTY As String, sMessageText As String, insize As Integer, iIDSend As String, Optional iCall As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()
        Dim isCheckText As Boolean = False
        Dim isCheckList As Boolean = False
        Dim sValue As String = String.Empty
        LBL_USER.Text = inUser
        If Not String.IsNullOrEmpty(iIDSend) Then
            LoadPictureBOx(iIDSend)
        End If
        iShake = iCall
        If Not String.IsNullOrEmpty(sMessageQTY) Then
            RichTextBox1.Text = sMessageQTY + " << Click >> " + sMessageText
            RichTextBox1.Visible = True
            isCheckText = True
        Else
            RichTextBox1.Visible = False
        End If
        If insize = 1 Then Maximized_Size()
      
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()

    End Sub

    Private Sub FRM_BALLOON_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FRM_BALLOON_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If iShake = 1 Then
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub FRM_BALLOON_MouseHover(sender As Object, e As System.EventArgs) Handles Me.MouseHover
        Timer1.Enabled = False
    End Sub

    Private Sub FRM_BALLOON_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Timer1.Enabled = True
    End Sub

    Private Sub txt_message_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Timer1.Enabled = True
    End Sub

    Private Sub ListView1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Timer1.Enabled = True
    End Sub

    Private Sub FRM_BALLOON_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim TheControl As Control = Nothing
        Dim oRAngle As Rectangle = Nothing
        Dim oGradientBrush As Brush = Nothing
        Try
            TheControl = CType(sender, Control)
            oRAngle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
            oGradientBrush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.LightBlue, Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        Catch ex As Exception
        Finally
            TheControl = Nothing
            oRAngle = Nothing
            oGradientBrush = Nothing
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PIC_CLOSE.Click
        Me.Close()
    End Sub
    Private Sub Minimized_Size()
        Dim x As Integer = 0
        Dim Y As Integer = 0
        Dim Point As Point = Nothing
        Dim xSize As Integer = 350
        Dim ySize As Integer = 0
        Dim ySizeMinimize As Integer = 23 + 23
        Dim xSizePicture As Integer = 19
        Dim ySizePicture As Integer = 0
        Try
            If String.IsNullOrEmpty(Me.Tag) Then Me.Tag = 0
            ySize = ySizeMinimize
            PIC_SIZE.Image = My.Resources.maximize_03
            Me.Tag = 0
            PictureBoxID.Size = New Size(xSizePicture, ySizePicture)

            Me.Size = New Size(xSize, ySize)
            x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            Y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
            Point = New Point(x, Y)
            Me.RichTextBox1.Text = Me.RichTextBox1.Text.Replace(" << Click >> ", "")
            Me.Location = Point
            Me.StartPosition = FormStartPosition.Manual
            Me.Activate()
        Catch ex As Exception

        End Try


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
    Private Sub LoadPictureBOx(inEmp As String)



        Dim blobImage As Byte() = Nothing
        Dim fs As IO.FileStream = Nothing
        Dim objPicture As Panel = Nothing
        Dim obj_DatatablePicture As DataTable = Nothing
        Dim sSQLSelect As String = String.Empty
        Dim sFormat As String = "http://truehrsh/empimg/{0}.jpg"
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
                        PictureBoxID.Image = img
                    End If
                End If
                If fs Is Nothing Then
                    Try
                        Dim tClient As WebClient = New WebClient
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(String.Format(sFormat, inEmp))))
                        PictureBoxID.Image = tImage
                    Catch ex As Exception
                        PictureBoxID.Image = My.Resources.Notify
                    End Try
                End If
            End If
        Catch exx As Exception
            Dim ee As String = exx.Message
        Finally
            blobImage = Nothing
            fs = Nothing
        End Try


    End Sub

    Private Sub Maximized_Size()
        Dim x As Integer = 0
        Dim Y As Integer = 0
        Dim Point As Point = Nothing
        Dim xSize As Integer = 350
        Dim ySize As Integer = 0
        Dim ySizeMaximize As Integer = 200
        Dim xSizePicture As Integer = 125
        Dim ySizePicture As Integer = 0
        Try
            If String.IsNullOrEmpty(Me.Tag) Then Me.Tag = 0

            ySize = ySizeMaximize
            PIC_SIZE.Image = My.Resources.Minimize_U
            Me.Tag = 1
            PictureBoxID.Size = New Size(xSizePicture, ySizePicture)

            Me.Size = New Size(xSize, ySize)
            x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            Y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
            Me.RichTextBox1.Text = Me.RichTextBox1.Text.Replace(" << Click >> ", "")
            Point = New Point(x, Y)
            Me.Location = Point
            Me.StartPosition = FormStartPosition.Manual
            Me.Activate()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PIC_SIZE.Click
        Dim x As Integer = 0
        Dim Y As Integer = 0
        Dim Point As Point = Nothing
        Dim xSize As Integer = 350
        Dim ySize As Integer = 0
        Dim ySizeMaximize As Integer = 200
        Dim ySizeMinimize As Integer = 23 + 23

        Dim xSizePicture As Integer = 0
        Dim ySizePicture As Integer = 0

        Try
            If String.IsNullOrEmpty(Me.Tag) Then Me.Tag = 0
            If Me.Tag = 1 Then
                ySize = ySizeMinimize
                PIC_SIZE.Image = My.Resources.maximize_03
                Me.Tag = 0
                xSizePicture = 19
            Else
                ySize = ySizeMaximize
                PIC_SIZE.Image = My.Resources.Minimize_U
                Me.Tag = 1
                xSizePicture = 125
            End If
            Me.Size = New Size(xSize, ySize)
            PictureBoxID.Size = New Size(xSizePicture, ySizePicture)
            x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            Y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
            Point = New Point(x, Y)
            Me.RichTextBox1.Text = Me.RichTextBox1.Text.Replace(" << Click >> ", "")
            Me.Location = Point
            Me.StartPosition = FormStartPosition.Manual
            Me.Activate()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As System.EventArgs) Handles Panel1.DoubleClick
        PictureBox2_Click(sender, e)

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim TheControl As Control = Nothing
        Dim oRAngle As Rectangle = Nothing
        Dim oGradientBrush As Brush = Nothing
        Try
            TheControl = CType(sender, Control)
            oRAngle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
            oGradientBrush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.Black, Color.LightBlue, Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        Catch ex As Exception
        Finally
            TheControl = Nothing
            oRAngle = Nothing
            oGradientBrush = Nothing
        End Try
    End Sub

    Private Sub TXT_MESSAGE_Click(sender As System.Object, e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LBL_USER_DoubleClick(sender As Object, e As System.EventArgs) Handles LBL_USER.DoubleClick
        PictureBox2_Click(sender, e)
    End Sub

    Private Sub LBL_USER_MouseHover(sender As Object, e As System.EventArgs) Handles LBL_USER.MouseHover
        Timer1.Enabled = False
    End Sub

    Private Sub TXT_MESSAGE_MouseHover(sender As Object, e As System.EventArgs)
        Timer1.Enabled = False
    End Sub

    Private Sub PIC_SIZE_MouseHover(sender As Object, e As System.EventArgs) Handles PIC_SIZE.MouseHover
        Timer1.Enabled = False
    End Sub

    Private Sub PIC_CLOSE_MouseHover(sender As Object, e As System.EventArgs) Handles PIC_CLOSE.MouseHover
        Timer1.Enabled = False
    End Sub
    Private Sub PictureBoxID_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxID.Click
        Timer1.Enabled = False
        If shakeCount >= limitshare Then shakeCount = 0
        Do Until shakeCount = limitshare
            Me.Left -= 10
            Me.Left += 10
            shakeCount += 1
        Loop
        Timer1.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        PictureBoxID_Click(sender, e)
        Timer2.Enabled = False
    End Sub
     
End Class