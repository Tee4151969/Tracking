<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menu))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoitfySizeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShakeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProfileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TrackMenu = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyMenu = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDefect = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.popup_Alert = New Telerik.WinControls.UI.RadDesktopAlert(Me.components)
        Me.popupDefect = New Telerik.WinControls.UI.RadButtonElement()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ViewMenu, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripSeparator3, Me.NotifyMenuItem, Me.NoitfySizeMenuItem, Me.ShakeMenuItem, Me.ToolStripSeparator5, Me.ProfileMenuItem, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.if_f_bug_256_282466
        Me.ToolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem2.ShowShortcutKeys = False
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.ToolStripMenuItem2.Text = "&Track"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(156, 6)
        Me.ToolStripSeparator3.Visible = False
        '
        'NotifyMenuItem
        '
        Me.NotifyMenuItem.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.Notify
        Me.NotifyMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NotifyMenuItem.Name = "NotifyMenuItem"
        Me.NotifyMenuItem.ShowShortcutKeys = False
        Me.NotifyMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NotifyMenuItem.Text = "Notify"
        '
        'NoitfySizeMenuItem
        '
        Me.NoitfySizeMenuItem.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.Minimize_U
        Me.NoitfySizeMenuItem.Name = "NoitfySizeMenuItem"
        Me.NoitfySizeMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NoitfySizeMenuItem.Tag = "0"
        Me.NoitfySizeMenuItem.Text = "Notify Minimize"
        Me.NoitfySizeMenuItem.Visible = False
        '
        'ShakeMenuItem
        '
        Me.ShakeMenuItem.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.Close_Red
        Me.ShakeMenuItem.Name = "ShakeMenuItem"
        Me.ShakeMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ShakeMenuItem.Tag = "0"
        Me.ShakeMenuItem.Text = "Shake"
        Me.ShakeMenuItem.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(156, 6)
        '
        'ProfileMenuItem
        '
        Me.ProfileMenuItem.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.Status
        Me.ProfileMenuItem.Name = "ProfileMenuItem"
        Me.ProfileMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ProfileMenuItem.Text = "&Profile"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Checked = True
        Me.ExitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExitToolStripMenuItem.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.if_setting_tools_64639
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBarToolStripMenuItem, Me.StatusBarToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(44, 20)
        Me.ViewMenu.Text = "&View"
        '
        'ToolBarToolStripMenuItem
        '
        Me.ToolBarToolStripMenuItem.Checked = True
        Me.ToolBarToolStripMenuItem.CheckOnClick = True
        Me.ToolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolBarToolStripMenuItem.Name = "ToolBarToolStripMenuItem"
        Me.ToolBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ToolBarToolStripMenuItem.Text = "&Toolbar"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.StatusBarToolStripMenuItem.Text = "&Status Bar"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(47, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(68, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.NewWindowToolStripMenuItem.Text = "&New Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(165, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrackMenu, Me.ToolStripSeparator1, Me.NotifyMenu, Me.ToolStripSeparator2, Me.ToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(632, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'TrackMenu
        '
        Me.TrackMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TrackMenu.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.if_f_bug_256_282466
        Me.TrackMenu.ImageTransparentColor = System.Drawing.Color.Black
        Me.TrackMenu.Name = "TrackMenu"
        Me.TrackMenu.Size = New System.Drawing.Size(23, 22)
        Me.TrackMenu.Text = "Track"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NotifyMenu
        '
        Me.NotifyMenu.AccessibleName = ""
        Me.NotifyMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NotifyMenu.Image = CType(resources.GetObject("NotifyMenu.Image"), System.Drawing.Image)
        Me.NotifyMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NotifyMenu.Name = "NotifyMenu"
        Me.NotifyMenu.Size = New System.Drawing.Size(23, 22)
        Me.NotifyMenu.ToolTipText = "Notify"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.if_advantage_speed_1034366
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "set time notify"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripUserID, Me.ToolStripStatusLabel2, Me.ToolStripUserName, Me.ToolStripStatusLabel3, Me.ToolStripDefect})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.ToolStripStatusLabel1.Text = "User Log in : "
        '
        'ToolStripUserID
        '
        Me.ToolStripUserID.BackColor = System.Drawing.Color.Khaki
        Me.ToolStripUserID.Name = "ToolStripUserID"
        Me.ToolStripUserID.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripUserID.Text = "010xxxxxx"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "User Name : "
        '
        'ToolStripUserName
        '
        Me.ToolStripUserName.BackColor = System.Drawing.Color.Khaki
        Me.ToolStripUserName.Name = "ToolStripUserName"
        Me.ToolStripUserName.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripUserName.Text = "xxxx xxxxx"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel3.Text = "Defect : "
        '
        'ToolStripDefect
        '
        Me.ToolStripDefect.BackColor = System.Drawing.Color.Khaki
        Me.ToolStripDefect.Name = "ToolStripDefect"
        Me.ToolStripDefect.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripDefect.Text = "0"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 600000
        '
        'popup_Alert
        '
        Me.popup_Alert.ButtonItems.AddRange(New Telerik.WinControls.RadItem() {Me.popupDefect})
        Me.popup_Alert.FixedSize = New System.Drawing.Size(350, 170)
        Me.popup_Alert.Opacity = 1.0!
        Me.popup_Alert.PopupAnimationFrames = 3
        Me.popup_Alert.ScreenPosition = Telerik.WinControls.UI.AlertScreenPosition.BottomLeft
        '
        'popupDefect
        '
        Me.popupDefect.Alignment = System.Drawing.ContentAlignment.BottomRight
        Me.popupDefect.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.[Auto]
        Me.popupDefect.AutoToolTip = True
        Me.popupDefect.ClickMode = Telerik.WinControls.ClickMode.Press
        Me.popupDefect.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.popupDefect.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentBounds
        Me.popupDefect.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.maximize_03
        Me.popupDefect.ImageAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.popupDefect.Name = "popupDefect"
        Me.popupDefect.Text = ""
        CType(Me.popupDefect.GetChildAt(1).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.popupDefect.GetChildAt(1).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frm_menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Track Job"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents TrackMenu As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyMenu As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDefect As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NoitfySizeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProfileMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShakeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents popup_Alert As Telerik.WinControls.UI.RadDesktopAlert
    Friend WithEvents popupDefect As Telerik.WinControls.UI.RadButtonElement

End Class
