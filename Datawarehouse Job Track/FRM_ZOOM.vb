Public Class FRM_ZOOM
    Sub New(inImage As Image)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not inImage Is Nothing Then
            PictureBox1.Image = inImage
        End If
    End Sub

    Private Sub FRM_ZOOM_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FRM_ZOOM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
     

    Private Sub PictureBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Not PictureBox1.Image Is Nothing Then
            Dim SaveFileDialog As New SaveFileDialog
            SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            SaveFileDialog.Filter = "All Files (*.*)|*.*"

            If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Dim FileName As String = SaveFileDialog.FileName
                PictureBox1.Image.Save(FileName)
                ' TODO: Add code here to save the current contents of the form to a file.
                System.Diagnostics.Process.Start(FileName)
            End If

            SaveFileDialog = Nothing
        End If
    End Sub
End Class