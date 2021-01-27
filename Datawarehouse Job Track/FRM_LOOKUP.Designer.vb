<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_LOOKUP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_LOOKUP))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_condition = New System.Windows.Forms.TextBox()
        Me.cmb_condition = New System.Windows.Forms.ComboBox()
        Me.cmb_column = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BTN_SEARCH = New System.Windows.Forms.Button()
        Me.BTN_CANCEL = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.bgProcess = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 45)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txt_condition)
        Me.Panel3.Controls.Add(Me.cmb_condition)
        Me.Panel3.Controls.Add(Me.cmb_column)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(628, 45)
        Me.Panel3.TabIndex = 9
        '
        'txt_condition
        '
        Me.txt_condition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_condition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_condition.Location = New System.Drawing.Point(307, 0)
        Me.txt_condition.MaxLength = 100
        Me.txt_condition.Name = "txt_condition"
        Me.txt_condition.Size = New System.Drawing.Size(321, 21)
        Me.txt_condition.TabIndex = 10
        '
        'cmb_condition
        '
        Me.cmb_condition.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmb_condition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_condition.FormattingEnabled = True
        Me.cmb_condition.Items.AddRange(New Object() {"=", "<>", "Like", "Not Like", ">", "<"})
        Me.cmb_condition.Location = New System.Drawing.Point(239, 0)
        Me.cmb_condition.Name = "cmb_condition"
        Me.cmb_condition.Size = New System.Drawing.Size(68, 21)
        Me.cmb_condition.TabIndex = 9
        '
        'cmb_column
        '
        Me.cmb_column.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmb_column.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_column.FormattingEnabled = True
        Me.cmb_column.Location = New System.Drawing.Point(92, 0)
        Me.cmb_column.Name = "cmb_column"
        Me.cmb_column.Size = New System.Drawing.Size(147, 21)
        Me.cmb_column.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 45)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "เงื่อนไข"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BTN_SEARCH)
        Me.Panel2.Controls.Add(Me.BTN_CANCEL)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(632, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 45)
        Me.Panel2.TabIndex = 8
        '
        'BTN_SEARCH
        '
        Me.BTN_SEARCH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BTN_SEARCH.Image = CType(resources.GetObject("BTN_SEARCH.Image"), System.Drawing.Image)
        Me.BTN_SEARCH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_SEARCH.Location = New System.Drawing.Point(2, 0)
        Me.BTN_SEARCH.Name = "BTN_SEARCH"
        Me.BTN_SEARCH.Size = New System.Drawing.Size(75, 45)
        Me.BTN_SEARCH.TabIndex = 3
        Me.BTN_SEARCH.Text = "ค้นหา"
        Me.BTN_SEARCH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SEARCH.UseVisualStyleBackColor = True
        '
        'BTN_CANCEL
        '
        Me.BTN_CANCEL.Dock = System.Windows.Forms.DockStyle.Right
        Me.BTN_CANCEL.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources._1496835913_cross
        Me.BTN_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CANCEL.Location = New System.Drawing.Point(77, 0)
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(75, 45)
        Me.BTN_CANCEL.TabIndex = 2
        Me.BTN_CANCEL.Text = "ยกเลิก"
        Me.BTN_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCEL.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.Info
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 45)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(784, 517)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'bgProcess
        '
        '
        'FRM_LOOKUP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_LOOKUP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ค้นหา"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_condition As System.Windows.Forms.TextBox
    Friend WithEvents cmb_condition As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_column As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BTN_SEARCH As System.Windows.Forms.Button
    Friend WithEvents BTN_CANCEL As System.Windows.Forms.Button
    Friend WithEvents bgProcess As System.ComponentModel.BackgroundWorker
End Class
