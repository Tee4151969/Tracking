<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MAIN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_MAIN))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Job Track", 3, 3)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBL_STATUS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Pn_Control = New System.Windows.Forms.Panel()
        Me.Pn_Picture = New System.Windows.Forms.Panel()
        Me.Pn_Toolbar = New System.Windows.Forms.Panel()
        Me.Pn_Status = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BTN_ADD = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LBL_CONFIG_NAME = New System.Windows.Forms.Label()
        Me.PIC_CONFIG = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BTN_NEW = New System.Windows.Forms.ToolStripButton()
        Me.BTN_EDIT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_SAVE = New System.Windows.Forms.ToolStripButton()
        Me.BTN_CANCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_SEARCH = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Pn_Toolbar.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PIC_CONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripUserID, Me.ToolStripStatusLabel2, Me.ToolStripUserName, Me.ToolStripStatusLabel3, Me.LBL_STATUS})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 537)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 25)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(75, 20)
        Me.ToolStripStatusLabel1.Text = "User Log in : "
        Me.ToolStripStatusLabel1.Visible = False
        '
        'ToolStripUserID
        '
        Me.ToolStripUserID.BackColor = System.Drawing.Color.Khaki
        Me.ToolStripUserID.Name = "ToolStripUserID"
        Me.ToolStripUserID.Size = New System.Drawing.Size(61, 20)
        Me.ToolStripUserID.Text = "010xxxxxx"
        Me.ToolStripUserID.Visible = False
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 20)
        Me.ToolStripStatusLabel2.Text = "User Name : "
        Me.ToolStripStatusLabel2.Visible = False
        '
        'ToolStripUserName
        '
        Me.ToolStripUserName.BackColor = System.Drawing.Color.Khaki
        Me.ToolStripUserName.Name = "ToolStripUserName"
        Me.ToolStripUserName.Size = New System.Drawing.Size(64, 20)
        Me.ToolStripUserName.Text = "xxxx xxxxx"
        Me.ToolStripUserName.Visible = False
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(62, 20)
        Me.ToolStripStatusLabel3.Text = "Message : "
        '
        'LBL_STATUS
        '
        Me.LBL_STATUS.AutoSize = False
        Me.LBL_STATUS.Name = "LBL_STATUS"
        Me.LBL_STATUS.Size = New System.Drawing.Size(500, 20)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Group User.png")
        Me.ImageList1.Images.SetKeyName(1, "Group.png")
        Me.ImageList1.Images.SetKeyName(2, "User.jpg")
        Me.ImageList1.Images.SetKeyName(3, "Application.png")
        Me.ImageList1.Images.SetKeyName(4, "Query.jpg")
        Me.ImageList1.Images.SetKeyName(5, "Column.png")
        Me.ImageList1.Images.SetKeyName(6, "Authorize.png")
        Me.ImageList1.Images.SetKeyName(7, "0.png")
        Me.ImageList1.Images.SetKeyName(8, "search.png")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 537)
        Me.SplitContainer1.SplitterDistance = 102
        Me.SplitContainer1.TabIndex = 5
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 25)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 3
        TreeNode1.Name = "DWH_JOB_TRACK"
        TreeNode1.SelectedImageIndex = 3
        TreeNode1.Tag = resources.GetString("TreeNode1.Tag")
        TreeNode1.Text = "Job Track"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(102, 512)
        Me.TreeView1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(102, 25)
        Me.Panel1.TabIndex = 3
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadioButton3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(101, 0)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(52, 25)
        Me.RadioButton3.TabIndex = 9
        Me.RadioButton3.Text = "Project"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadioButton2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(49, 0)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(52, 25)
        Me.RadioButton2.TabIndex = 8
        Me.RadioButton2.Text = "Owner"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(0, 0)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 25)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Status"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 59)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(678, 478)
        Me.TabControl.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Pn_Control)
        Me.TabPage1.Controls.Add(Me.Pn_Picture)
        Me.TabPage1.Controls.Add(Me.Pn_Toolbar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(670, 452)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Defect"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Pn_Control
        '
        Me.Pn_Control.AutoScroll = True
        Me.Pn_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Control.Location = New System.Drawing.Point(3, 130)
        Me.Pn_Control.Margin = New System.Windows.Forms.Padding(10)
        Me.Pn_Control.Name = "Pn_Control"
        Me.Pn_Control.Size = New System.Drawing.Size(664, 319)
        Me.Pn_Control.TabIndex = 7
        '
        'Pn_Picture
        '
        Me.Pn_Picture.AutoScroll = True
        Me.Pn_Picture.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Picture.Location = New System.Drawing.Point(3, 30)
        Me.Pn_Picture.Margin = New System.Windows.Forms.Padding(10)
        Me.Pn_Picture.Name = "Pn_Picture"
        Me.Pn_Picture.Size = New System.Drawing.Size(664, 100)
        Me.Pn_Picture.TabIndex = 6
        '
        'Pn_Toolbar
        '
        Me.Pn_Toolbar.Controls.Add(Me.Pn_Status)
        Me.Pn_Toolbar.Controls.Add(Me.ToolStrip2)
        Me.Pn_Toolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pn_Toolbar.Location = New System.Drawing.Point(3, 3)
        Me.Pn_Toolbar.Name = "Pn_Toolbar"
        Me.Pn_Toolbar.Size = New System.Drawing.Size(664, 27)
        Me.Pn_Toolbar.TabIndex = 4
        '
        'Pn_Status
        '
        Me.Pn_Status.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn_Status.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Status.Name = "Pn_Status"
        Me.Pn_Status.Size = New System.Drawing.Size(638, 27)
        Me.Pn_Status.TabIndex = 34
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.Black
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_ADD})
        Me.ToolStrip2.Location = New System.Drawing.Point(638, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip2.Size = New System.Drawing.Size(26, 27)
        Me.ToolStrip2.TabIndex = 33
        Me.ToolStrip2.Text = "..."
        '
        'BTN_ADD
        '
        Me.BTN_ADD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_ADD.Image = CType(resources.GetObject("BTN_ADD.Image"), System.Drawing.Image)
        Me.BTN_ADD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_ADD.Name = "BTN_ADD"
        Me.BTN_ADD.Size = New System.Drawing.Size(23, 20)
        Me.BTN_ADD.Tag = "Add Child Defect"
        Me.BTN_ADD.Text = "&Add Child Defect"
        Me.BTN_ADD.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.ToolStrip1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(678, 59)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.LBL_CONFIG_NAME)
        Me.Panel5.Controls.Add(Me.PIC_CONFIG)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(678, 34)
        Me.Panel5.TabIndex = 30
        '
        'LBL_CONFIG_NAME
        '
        Me.LBL_CONFIG_NAME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LBL_CONFIG_NAME.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LBL_CONFIG_NAME.Location = New System.Drawing.Point(37, 0)
        Me.LBL_CONFIG_NAME.Name = "LBL_CONFIG_NAME"
        Me.LBL_CONFIG_NAME.Size = New System.Drawing.Size(641, 34)
        Me.LBL_CONFIG_NAME.TabIndex = 4
        Me.LBL_CONFIG_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PIC_CONFIG
        '
        Me.PIC_CONFIG.Dock = System.Windows.Forms.DockStyle.Left
        Me.PIC_CONFIG.Location = New System.Drawing.Point(0, 0)
        Me.PIC_CONFIG.Name = "PIC_CONFIG"
        Me.PIC_CONFIG.Size = New System.Drawing.Size(37, 34)
        Me.PIC_CONFIG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PIC_CONFIG.TabIndex = 3
        Me.PIC_CONFIG.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_NEW, Me.BTN_EDIT, Me.ToolStripSeparator4, Me.BTN_SAVE, Me.BTN_CANCEL, Me.ToolStripSeparator1, Me.BTN_SEARCH})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(678, 25)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BTN_NEW
        '
        Me.BTN_NEW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_NEW.Image = CType(resources.GetObject("BTN_NEW.Image"), System.Drawing.Image)
        Me.BTN_NEW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_NEW.Name = "BTN_NEW"
        Me.BTN_NEW.Size = New System.Drawing.Size(23, 22)
        Me.BTN_NEW.Tag = "New"
        Me.BTN_NEW.Text = "&New"
        '
        'BTN_EDIT
        '
        Me.BTN_EDIT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_EDIT.Image = CType(resources.GetObject("BTN_EDIT.Image"), System.Drawing.Image)
        Me.BTN_EDIT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_EDIT.Name = "BTN_EDIT"
        Me.BTN_EDIT.Size = New System.Drawing.Size(23, 22)
        Me.BTN_EDIT.Tag = "Edit"
        Me.BTN_EDIT.Text = "&Edit"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_SAVE
        '
        Me.BTN_SAVE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_SAVE.Image = CType(resources.GetObject("BTN_SAVE.Image"), System.Drawing.Image)
        Me.BTN_SAVE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_SAVE.Name = "BTN_SAVE"
        Me.BTN_SAVE.Size = New System.Drawing.Size(23, 22)
        Me.BTN_SAVE.Tag = "Save"
        Me.BTN_SAVE.Text = "&Save"
        '
        'BTN_CANCEL
        '
        Me.BTN_CANCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_CANCEL.Image = CType(resources.GetObject("BTN_CANCEL.Image"), System.Drawing.Image)
        Me.BTN_CANCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(23, 22)
        Me.BTN_CANCEL.Tag = "Cancel"
        Me.BTN_CANCEL.Text = "&Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_SEARCH
        '
        Me.BTN_SEARCH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_SEARCH.Image = CType(resources.GetObject("BTN_SEARCH.Image"), System.Drawing.Image)
        Me.BTN_SEARCH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_SEARCH.Name = "BTN_SEARCH"
        Me.BTN_SEARCH.Size = New System.Drawing.Size(23, 22)
        Me.BTN_SEARCH.Tag = "Search"
        Me.BTN_SEARCH.Text = "&Search"
        '
        'FRM_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FRM_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Track"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Pn_Toolbar.ResumeLayout(False)
        Me.Pn_Toolbar.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PIC_CONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LBL_CONFIG_NAME As System.Windows.Forms.Label
    Friend WithEvents PIC_CONFIG As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BTN_NEW As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_EDIT As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BTN_SAVE As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_CANCEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BTN_SEARCH As System.Windows.Forms.ToolStripButton
    Friend WithEvents Pn_Toolbar As System.Windows.Forms.Panel
    Friend WithEvents Pn_Picture As System.Windows.Forms.Panel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBL_STATUS As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Pn_Status As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BTN_ADD As System.Windows.Forms.ToolStripButton
    Friend WithEvents Pn_Control As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
End Class
