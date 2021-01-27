<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_BALLOON
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_BALLOON))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PIC_SIZE = New System.Windows.Forms.PictureBox()
        Me.PIC_CLOSE = New System.Windows.Forms.PictureBox()
        Me.LBL_USER = New System.Windows.Forms.Label()
        Me.pnDescription = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.Label()
        Me.PictureBoxID = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_SIZE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIC_CLOSE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDescription.SuspendLayout()
        CType(Me.PictureBoxID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "You have new track"
        Me.NotifyIcon1.BalloonTipTitle = "Datawarehouse job Track"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "You have new track"
        Me.NotifyIcon1.Visible = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PIC_SIZE)
        Me.Panel1.Controls.Add(Me.PIC_CLOSE)
        Me.Panel1.Controls.Add(Me.LBL_USER)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 24)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.Notify
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'PIC_SIZE
        '
        Me.PIC_SIZE.BackColor = System.Drawing.Color.Transparent
        Me.PIC_SIZE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PIC_SIZE.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.maximize_03
        Me.PIC_SIZE.Location = New System.Drawing.Point(304, 2)
        Me.PIC_SIZE.Name = "PIC_SIZE"
        Me.PIC_SIZE.Size = New System.Drawing.Size(17, 19)
        Me.PIC_SIZE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIC_SIZE.TabIndex = 14
        Me.PIC_SIZE.TabStop = False
        '
        'PIC_CLOSE
        '
        Me.PIC_CLOSE.BackColor = System.Drawing.Color.Transparent
        Me.PIC_CLOSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PIC_CLOSE.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources._1496835913_cross
        Me.PIC_CLOSE.Location = New System.Drawing.Point(323, 2)
        Me.PIC_CLOSE.Name = "PIC_CLOSE"
        Me.PIC_CLOSE.Size = New System.Drawing.Size(17, 19)
        Me.PIC_CLOSE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIC_CLOSE.TabIndex = 13
        Me.PIC_CLOSE.TabStop = False
        '
        'LBL_USER
        '
        Me.LBL_USER.BackColor = System.Drawing.Color.Transparent
        Me.LBL_USER.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LBL_USER.ForeColor = System.Drawing.Color.White
        Me.LBL_USER.Location = New System.Drawing.Point(23, 5)
        Me.LBL_USER.Name = "LBL_USER"
        Me.LBL_USER.Size = New System.Drawing.Size(267, 14)
        Me.LBL_USER.TabIndex = 12
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.RichTextBox1)
        Me.pnDescription.Controls.Add(Me.PictureBoxID)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDescription.Location = New System.Drawing.Point(0, 24)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(350, 22)
        Me.pnDescription.TabIndex = 6
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(19, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(331, 22)
        Me.RichTextBox1.TabIndex = 7
        '
        'PictureBoxID
        '
        Me.PictureBoxID.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBoxID.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxID.Name = "PictureBoxID"
        Me.PictureBoxID.Size = New System.Drawing.Size(19, 22)
        Me.PictureBoxID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxID.TabIndex = 6
        Me.PictureBoxID.TabStop = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'FRM_BALLOON
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(350, 46)
        Me.Controls.Add(Me.pnDescription)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_BALLOON"
        Me.Opacity = 0.85R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Notify"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_SIZE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIC_CLOSE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDescription.ResumeLayout(False)
        CType(Me.PictureBoxID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PIC_SIZE As System.Windows.Forms.PictureBox
    Friend WithEvents PIC_CLOSE As System.Windows.Forms.PictureBox
    Friend WithEvents LBL_USER As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxID As System.Windows.Forms.PictureBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
