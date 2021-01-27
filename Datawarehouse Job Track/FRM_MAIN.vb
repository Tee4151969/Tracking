Public Class FRM_MAIN
    Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As Integer) As Integer
    Public inPubDefectNo As Integer
    Sub New(ByVal inUser As String, Optional ByVal inDefectNo As Integer = 0)
        Dim oDatatable As DataTable = Nothing
        Dim sQTY As String = String.Empty
        Dim sUserID As String = String.Empty
        Dim sUserFullname As String = String.Empty
        Dim sFormatMessage As String = "{0} Track Defect"
        ' This call is required by the designer.
        InitializeComponent()
        Load_Config()

        ' Add any initialization after the InitializeComponent() call.
        oDatatable = Code_Application.ReturnValueToDatatable("Select N_USERID,C_FULLNAME,(select count(*) from  dwh_job_track x where upper(x.owner)=upper(c_Username) and initcap(x.defect_status) in  ('Open','New','Assign','Follow','Resolve')) as QTY from dwh_config_user where upper(c_username)='" & inUser.ToUpper & "'", cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
        If Not oDatatable Is Nothing Then
            If oDatatable.Rows.Count > 0 Then
                If Not oDatatable.Rows(0)("N_USERID") Is DBNull.Value Then sUserID = oDatatable.Rows(0)("N_USERID")
                If Not oDatatable.Rows(0)("C_FULLNAME") Is DBNull.Value Then sUserFullname = oDatatable.Rows(0)("C_FULLNAME")
                If Not oDatatable.Rows(0)("QTY") Is DBNull.Value Then sQTY = oDatatable.Rows(0)("QTY")
                If String.IsNullOrEmpty(sQTY) Then sQTY = "0"
                ToolStripUserID.Text = sUserID
                ToolStripUserName.Text = sUserFullname

            End If
        End If
        If inDefectNo > 0 Then
            LoadDefectNo(False, inDefectNo)
        End If

    End Sub

    Private Sub ReadonlyTextbox(ByVal ctrlContainer As Control, ByVal isMode As Boolean)
        For Each ctrl As Control In ctrlContainer.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = Not isMode
            Else
                ctrl.Enabled = isMode
            End If
            If ctrl.HasChildren Then
                ReadonlyTextbox(ctrl, isMode)
            End If
        Next
    End Sub


    Private Function PanelPictureBox(inDefectNo As String, inSeq As String, inImage As Image) As Panel
        Dim objLabelRight As Label = Nothing
        Dim PnBox As Panel = Nothing
        Dim PnBox_1 As Panel = Nothing
        Dim PictureItem As PictureBox = Nothing
        Dim PictureItemZoom As PictureBox = Nothing
        Dim PictureItemClose As PictureBox = Nothing
        Try
            PnBox = New System.Windows.Forms.Panel()
            PnBox_1 = New System.Windows.Forms.Panel()
            PictureItem = New System.Windows.Forms.PictureBox()
            PictureItemZoom = New System.Windows.Forms.PictureBox()
            PictureItemClose = New System.Windows.Forms.PictureBox()


            objLabelRight = New Label
            objLabelRight.Size = New Size(10, 25)
            objLabelRight.TextAlign = ContentAlignment.MiddleLeft
            objLabelRight.Dock = DockStyle.Left
            objLabelRight.Text = " "
            objLabelRight.AutoSize = False
            Pn_Picture.Controls.Add(objLabelRight)

            Pn_Picture.AutoScroll = True
            Pn_Picture.Dock = System.Windows.Forms.DockStyle.Top
            Pn_Picture.Location = New System.Drawing.Point(3, 30)
            Pn_Picture.Margin = New System.Windows.Forms.Padding(10)
            Pn_Picture.Name = "Pn_Picture"
            Pn_Picture.Size = New System.Drawing.Size(664, 100)
            Pn_Picture.TabIndex = 6

            '
            PnBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            PnBox.Controls.Add(PictureItem)
            PnBox.Controls.Add(PnBox_1)
            PnBox.Dock = System.Windows.Forms.DockStyle.Left
            PnBox.Location = New System.Drawing.Point(0, 0)
            PnBox.Name = inSeq
            PnBox.Size = New System.Drawing.Size(107, 100)
            PnBox.TabIndex = 1
            PnBox.Tag = inImage
            '

            '
            PnBox_1.Controls.Add(PictureItemZoom)
            PnBox_1.Controls.Add(PictureItemClose)
            PnBox_1.Dock = System.Windows.Forms.DockStyle.Top
            PnBox_1.Location = New System.Drawing.Point(0, 0)
            PnBox_1.Name = "PnBox_1"
            PnBox_1.Size = New System.Drawing.Size(105, 17)
            PnBox_1.TabIndex = 0
            '
            'PictureItem
            PictureItem.AllowDrop = True
            PictureItem.Dock = System.Windows.Forms.DockStyle.Fill
            PictureItem.Location = New System.Drawing.Point(0, 17)
            PictureItem.Name = inSeq
            PictureItem.Tag = inDefectNo
            PictureItem.Image = inImage
            PictureItem.Cursor = Cursors.Hand
            PictureItem.Size = New System.Drawing.Size(105, 81)
            PictureItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            PictureItem.TabIndex = 1
            PictureItem.TabStop = False
            AddHandler PictureItem.Click, AddressOf objPicture_Click
            AddHandler PictureItem.DragEnter, AddressOf objPicture_DragEnter
            AddHandler PictureItem.DragDrop, AddressOf objPicture_DragDrop
            '
            'PictureItemZoom
            '
            PictureItemZoom.Dock = System.Windows.Forms.DockStyle.Left
            PictureItemZoom.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources.search__2_
            PictureItemZoom.Location = New System.Drawing.Point(0, 0)
            PictureItemZoom.Size = New System.Drawing.Size(20, 17)
            PictureItemZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            PictureItemZoom.TabIndex = 222
            PictureItemZoom.TabStop = False
            PictureItemZoom.Name = inSeq
            PictureItemZoom.Tag = inImage
            AddHandler PictureItemZoom.Click, AddressOf objPicture_ZoomClick
            '
            'PictureItemClose
            '
            PictureItemClose.Dock = System.Windows.Forms.DockStyle.Right
            PictureItemClose.Image = Global.Datawarehouse_Job_Track.My.Resources.Resources._1496835913_cross
            PictureItemClose.Location = New System.Drawing.Point(85, 0)
            PictureItemClose.Size = New System.Drawing.Size(20, 17)
            PictureItemClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            PictureItemClose.TabIndex = 333
            PictureItemClose.Name = inSeq
            PictureItemClose.Tag = inDefectNo
            PictureItemClose.TabStop = False
            AddHandler PictureItemClose.Click, AddressOf objPicture_DeleteClick


            '

        Catch ex As Exception
            PnBox = Nothing
            Me.LBL_STATUS.Text = ex.Message
        Finally
            PnBox_1 = Nothing
            PictureItem = Nothing
            PictureItemZoom = Nothing
            PictureItemClose = Nothing
        End Try
        Return PnBox
    End Function




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
    Private Sub Load_Column_Table(inTableName As String)
        Dim obj_Datatable_Config As DataTable = Nothing
        Dim COLNO As Integer = 0
        Dim CNAME As String = String.Empty
        Dim LBLNAME As String = String.Empty
        Dim COLTYPE As String = String.Empty
        Dim WIDTH As Integer = 0
        Dim NULLS As String = String.Empty
        Dim sControl_Identify As String = String.Empty
        Dim iControl_Length As Integer = 0
        Dim isControl_Key As Boolean = False
        Dim iControl_Multiline As Boolean = False

        Dim sSQLConfig As String = "select b.*,nvl(a.comments,b.cname) comments from ALL_COL_COMMENTS a,COL b where a.table_name=b.tname and a.column_name=b.cname and upper(b.tname)='{0}' and not b.cname in (select bb.column_name  from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name) order by b.colno Desc"

        Dim sSQLFormatCombobox As String = "select {1} from {0} Where not {1} is null Group by {1} Order by 1"
        Dim obj_DataTable_Combobox As DataTable = Nothing
        Dim sSQLCombo As String = String.Empty
        Dim objPanel As Panel = Nothing
        Dim objPicture As Panel = Nothing

        Dim objLabel As Label = Nothing
        Dim objLabelRight As Label = Nothing
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objRichTextbox As RichTextBox = Nothing
        Dim sComboboxTag As String = String.Empty
        Dim sFormatCNAME As String = "{0}_" & TabControl.TabCount
        obj_Datatable_Config = Code_Application.ReturnValueToDatatable(String.Format(sSQLConfig, inTableName), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
        If Not obj_Datatable_Config Is Nothing Then
            If obj_Datatable_Config.Rows.Count > 0 Then
                Pn_Control.Controls.Clear()
                For i As Integer = 0 To obj_Datatable_Config.Rows.Count - 1
                    COLNO = 0
                    CNAME = String.Empty
                    COLTYPE = String.Empty
                    WIDTH = 0
                    NULLS = String.Empty
                    sControl_Identify = String.Empty
                    iControl_Length = 0
                    isControl_Key = False
                    sComboboxTag = String.Empty
                    If Not obj_Datatable_Config.Rows(i)("COLNO") Is DBNull.Value Then COLNO = obj_Datatable_Config.Rows(i)("COLNO")
                    If Not obj_Datatable_Config.Rows(i)("CNAME") Is DBNull.Value Then CNAME = obj_Datatable_Config.Rows(i)("CNAME")
                    If Not obj_Datatable_Config.Rows(i)("COMMENTS") Is DBNull.Value Then LBLNAME = obj_Datatable_Config.Rows(i)("COMMENTS")
                    If Not obj_Datatable_Config.Rows(i)("COLTYPE") Is DBNull.Value Then COLTYPE = obj_Datatable_Config.Rows(i)("COLTYPE")
                    If Not obj_Datatable_Config.Rows(i)("WIDTH") Is DBNull.Value Then WIDTH = obj_Datatable_Config.Rows(i)("WIDTH")
                    If Not obj_Datatable_Config.Rows(i)("NULLS") Is DBNull.Value Then NULLS = obj_Datatable_Config.Rows(i)("NULLS")

                    If COLTYPE = "NUMBER" And WIDTH > 1 And NULLS = "NULL" Then
                        sControl_Identify = "COMBOBOX"
                        iControl_Length = WIDTH
                    ElseIf COLTYPE = "VARCHAR2" And WIDTH = 8 Then
                        sControl_Identify = "COMBOBOX"
                        iControl_Length = WIDTH
                    ElseIf COLTYPE = "CHAR" And WIDTH = 1 Then
                        sControl_Identify = "CHECKBOX"
                        iControl_Length = WIDTH
                    ElseIf COLTYPE = "VARCHAR2" And WIDTH = 1 Then
                        sControl_Identify = "CHECKBOX"
                        iControl_Length = WIDTH
                    ElseIf COLTYPE = "VARCHAR2" And WIDTH > 1 Then
                        sControl_Identify = "TEXTBOX"
                        iControl_Length = WIDTH
                        If NULLS = "NOT NULL" Then isControl_Key = True
                        If WIDTH > 200 Then
                            sControl_Identify = "RICHTEXT"
                            iControl_Multiline = True
                        End If
                    ElseIf COLTYPE = "DATE" Then
                        sControl_Identify = "DATE"
                        iControl_Length = WIDTH
                    Else
                        sControl_Identify = "TEXTBOX"
                        iControl_Length = WIDTH
                        If NULLS = "NOT NULL" Then isControl_Key = True
                        If WIDTH > 200 Then
                            iControl_Multiline = True
                            sControl_Identify = "RICHTEXT"
                        End If
                    End If
                    If sControl_Identify = "COMBOBOX" Then
                        objPanel = New Panel
                        objPanel.Size = New Size(200, 25)

                        objLabelRight = New Label
                        objLabelRight.Size = New Size(10, 25)
                        objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                        objLabelRight.Dock = DockStyle.Right
                        objLabelRight.Text = " "
                        objLabelRight.AutoSize = False

                        objLabel = New Label
                        objLabel.Size = New Size(125, 25)
                        objLabel.Tag = "LBL_" & CNAME
                        objLabel.Text = LBLNAME
                        objLabel.AutoSize = False
                        objLabel.TextAlign = ContentAlignment.MiddleLeft
                        objLabel.Dock = DockStyle.Left
                        objCombobox = New ComboBox
                        objCombobox.Name = CNAME
                        objCombobox.Dock = DockStyle.Fill
                        sSQLCombo = String.Format(sSQLFormatCombobox, inTableName, CNAME)
                        obj_DataTable_Combobox = Code_Application.ReturnValueToDatatable(sSQLCombo, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                        If Not obj_DataTable_Combobox Is Nothing Then
                            For iCombo As Integer = 0 To obj_DataTable_Combobox.Rows.Count - 1
                                If Not obj_DataTable_Combobox.Rows(iCombo)(0) Is DBNull.Value Then
                                    If Not String.IsNullOrEmpty(sComboboxTag) Then sComboboxTag &= ","
                                    sComboboxTag &= obj_DataTable_Combobox.Rows(iCombo)(0)
                                    objCombobox.Items.Add(obj_DataTable_Combobox.Rows(iCombo)(0))
                                End If
                            Next
                        End If
                        If Not obj_DataTable_Combobox Is Nothing Then obj_DataTable_Combobox = Nothing
                        If objCombobox.Items.Count > 0 Then objCombobox.SelectedIndex = 0
                        objCombobox.Tag = sComboboxTag
                        objCombobox.MaxLength = iControl_Length

                        If COLTYPE = "NUMBER" Then AddHandler objCombobox.KeyPress, AddressOf Cmb_Number_KeyPress
                        objPanel.Controls.Add(objCombobox)
                        objPanel.Controls.Add(objLabelRight)
                        objPanel.Controls.Add(objLabel)
                        objPanel.Dock = DockStyle.Top
                        Pn_Control.Controls.Add(objPanel)
                    ElseIf sControl_Identify = "CHECKBOX" Then
                        objPanel = New Panel
                        objPanel.Size = New Size(200, 25)

                        objLabelRight = New Label
                        objLabelRight.Size = New Size(10, 25)
                        objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                        objLabelRight.Dock = DockStyle.Right
                        objLabelRight.Text = " "
                        objLabelRight.AutoSize = False

                        objLabel = New Label
                        objLabel.Size = New Size(125, 25)
                        objLabel.Tag = "LBL_" & CNAME
                        objLabel.Text = LBLNAME
                        objLabel.AutoSize = False
                        objLabel.TextAlign = ContentAlignment.MiddleLeft
                        objLabel.Dock = DockStyle.Left

                        objCheckbox = New CheckBox
                        objCheckbox.Name = CNAME
                        objCheckbox.Dock = DockStyle.Fill
                        objPanel.Controls.Add(objCheckbox)
                        objPanel.Controls.Add(objLabelRight)
                        objPanel.Controls.Add(objLabel)
                        objPanel.Dock = DockStyle.Top

                        Pn_Control.Controls.Add(objPanel)
                    ElseIf sControl_Identify = "DATE" Then
                        objPanel = New Panel
                        objPanel.Size = New Size(200, 25)

                        objLabelRight = New Label
                        objLabelRight.Size = New Size(10, 25)
                        objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                        objLabelRight.Dock = DockStyle.Right
                        objLabelRight.Text = " "
                        objLabelRight.AutoSize = False

                        objLabel = New Label
                        objLabel.Size = New Size(125, 25)
                        objLabel.Tag = "LBL_" & CNAME
                        objLabel.Text = LBLNAME
                        objLabel.AutoSize = False
                        objLabel.TextAlign = ContentAlignment.MiddleLeft
                        objLabel.Dock = DockStyle.Left

                        objDate = New DateTimePicker
                        objDate.Name = CNAME
                        objDate.Format = DateTimePickerFormat.Short
                        objDate.ShowCheckBox = True
                        objDate.Checked = True


                        objDate.Dock = DockStyle.Fill
                        objPanel.Controls.Add(objDate)
                        objPanel.Controls.Add(objLabelRight)
                        objPanel.Controls.Add(objLabel)
                        objPanel.Dock = DockStyle.Top

                        Pn_Control.Controls.Add(objPanel)
                    ElseIf sControl_Identify = "TEXTBOX" Then
                        objPanel = New Panel
                        objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                        objLabelRight = New Label
                        objLabelRight.Size = New Size(10, 25)
                        objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                        objLabelRight.Dock = DockStyle.Right
                        objLabelRight.Text = " "
                        objLabelRight.AutoSize = False

                        objLabel = New Label
                        objLabel.Size = New Size(125, 25)
                        objLabel.Tag = "LBL_" & CNAME
                        objLabel.Text = LBLNAME
                        objLabel.AutoSize = False
                        objLabel.TextAlign = ContentAlignment.MiddleLeft
                        objLabel.Dock = DockStyle.Left

                        objTextbox = New TextBox
                        objTextbox.Name = CNAME
                        If CNAME.ToUpper.IndexOf("PASSWORD") > 0 Or CNAME.ToUpper.IndexOf("PWD") > 0 Then objTextbox.PasswordChar = "*"
                        If CNAME.ToUpper.IndexOf("CR_BY") > 0 Or CNAME.ToUpper.IndexOf("CREATE_BY") > 0 Then objTextbox.Enabled = False
                        If CNAME.ToUpper.IndexOf("UPD_BY") > 0 Or CNAME.ToUpper.IndexOf("UPDATE_BY") > 0 Then objTextbox.Enabled = False
                        objTextbox.Dock = DockStyle.Fill
                        objTextbox.BackColor = Color.White
                        objTextbox.TextAlign = HorizontalAlignment.Left
                        objTextbox.MaxLength = iControl_Length
                        If isControl_Key Then
                            If COLTYPE = "NUMBER" Then
                                objTextbox.ReadOnly = True
                            Else
                                objTextbox.ReadOnly = False
                            End If
                            objTextbox.BackColor = Color.Khaki
                            objTextbox.TextAlign = HorizontalAlignment.Right
                        End If
                        If WIDTH > 200 Then
                            objTextbox.Multiline = True
                            objTextbox.AcceptsReturn = True
                            objTextbox.AcceptsTab = True
                            objTextbox.WordWrap = True
                            objTextbox.ScrollBars = ScrollBars.Both
                        End If
                        If COLTYPE = "NUMBER" Then AddHandler objTextbox.KeyPress, AddressOf Txt_Number_KeyPress
                        objPanel.Controls.Add(objTextbox)
                        objPanel.Controls.Add(objLabelRight)
                        objPanel.Controls.Add(objLabel)
                        objPanel.Dock = DockStyle.Top

                        Pn_Control.Controls.Add(objPanel)
                    ElseIf sControl_Identify = "RICHTEXT" Then
                        objPanel = New Panel
                        objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                        objLabelRight = New Label
                        objLabelRight.Size = New Size(10, 25)
                        objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                        objLabelRight.Dock = DockStyle.Right
                        objLabelRight.Text = " "
                        objLabelRight.AutoSize = False

                        objLabel = New Label
                        objLabel.Size = New Size(125, 25)
                        objLabel.Tag = "LBL_" & CNAME
                        objLabel.Text = LBLNAME
                        objLabel.AutoSize = False
                        objLabel.TextAlign = ContentAlignment.MiddleLeft
                        objLabel.Dock = DockStyle.Left

                        objRichTextbox = New RichTextBox
                        objRichTextbox.Name = CNAME
                        objRichTextbox.Dock = DockStyle.Fill
                        objRichTextbox.BackColor = Color.Khaki
                        objRichTextbox.MaxLength = iControl_Length
                        objPanel.Controls.Add(objRichTextbox)
                        objPanel.Controls.Add(objLabelRight)
                        objPanel.Controls.Add(objLabel)
                        objPanel.Dock = DockStyle.Top

                        Pn_Control.Controls.Add(objPanel)
                    End If
                    If Not objPanel Is Nothing Then objPanel = Nothing
                    If Not objLabel Is Nothing Then objLabel = Nothing
                    If Not objCombobox Is Nothing Then objCombobox = Nothing
                    If Not objCheckbox Is Nothing Then objCheckbox = Nothing
                    If Not objDate Is Nothing Then objDate = Nothing
                    If Not objTextbox Is Nothing Then objTextbox = Nothing
                    If Not objRichTextbox Is Nothing Then objTextbox = Nothing
                Next

                objPicture = PanelPictureBox(String.Empty, String.Empty, Nothing)
                Pn_Picture.Controls.Add(objPicture)


            End If
        End If
    End Sub
    Private Sub objPicture_DragEnter(sender As System.Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub objPicture_DragDrop(sender As System.Object, e As DragEventArgs)
        Dim sSQLInsertBlob As String = "INSERT INTO DWH_JOB_TRACK_IMAGE (DEFECT_NO,SEQ_NO,IMAGE) VALUES (:DEFECT_NO,:SEQ_NO,:IMAGE)"
        Dim sSQLUpdateBlob As String = "UPDATE DWH_JOB_TRACK_IMAGE SET  IMAGE=:IMAGE WHERE DEFECT_NO=:DEFECT_NO AND SEQ_NO=:SEQ_NO"
        Dim sSQL As String = String.Empty
        Dim sConnection As String = String.Format(cConnecton_string.Replace("$Datasource", cConnecton_Login), cUser_Login, cPassword_Login)
        'Dim oraConnection As New Oracle.DataAccess.Client.OracleConnection(sConnection)
        'Dim oraCleCommand As Oracle.DataAccess.Client.OracleCommand = Nothing

        Dim sValueKey As String = String.Empty
        Dim sSQLPK As String = "SELECT NVL(MAX(SEQ_NO),0)+1 AS MAX_NO FROM DWH_JOB_TRACK_IMAGE WHERE DEFECT_NO={0}"
        Dim sMaxSeq As String = String.Empty
        Dim iSeq As Integer = 0
        Dim iResult As Integer = 0
        Dim strDarg As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        Dim objPicture As PictureBox = Nothing
        Dim objPicturePanelHeader As Panel = Nothing
        Dim objPicturePanelTool As Panel = Nothing
        Dim fs As Byte() = Nothing
        Dim sResult As String = String.Empty
        Dim arrayParam() As Public_Service.ParamOracle = Nothing
        Try

            If TypeOf sender Is PictureBox Then
                objPicture = CType(sender, PictureBox)
            End If
            If Not objPicture Is Nothing Then
                If objPicture.Image Is Nothing Then
                    If String.IsNullOrEmpty(objPicture.Tag) Then Exit Sub
                    sValueKey = objPicture.Tag
                    Me.LBL_STATUS.Text = sValueKey
                    For Each filelocation As String In strDarg
                        objPicture.ImageLocation = filelocation
                        Me.LBL_STATUS.Text = filelocation
                    Next
                    If Not objPicture.ImageLocation Is Nothing Then
                        fs = (IO.File.ReadAllBytes(objPicture.ImageLocation))
                        If Not fs Is Nothing Then
                            iSeq = 1
                            If objPicture.Name = "" Then
                                sMaxSeq = Code_Application.ReturnValueSql(String.Format(sSQLPK, sValueKey), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                If Not String.IsNullOrEmpty(sMaxSeq) Then
                                    If IsNumeric(sMaxSeq) Then iSeq = Convert.ToInt16(sMaxSeq)
                                End If
                                objPicture.Name = sMaxSeq
                                sSQL = sSQLInsertBlob
                            Else
                                sMaxSeq = objPicture.Name
                                sSQL = sSQLUpdateBlob
                            End If
                            Me.LBL_STATUS.Text = sMaxSeq
                            ReDim arrayParam(2)
                            arrayParam(0) = New Public_Service.ParamOracle
                            arrayParam(0).Key = "DEFECT_NO"
                            arrayParam(0).Value = sValueKey
                            arrayParam(0).Type = Public_Service.OracleDbType.Int16

                            arrayParam(1) = New Public_Service.ParamOracle
                            arrayParam(1).Key = "SEQ_NO"
                            arrayParam(1).Value = iSeq
                            arrayParam(1).Type = Public_Service.OracleDbType.Int16

                            arrayParam(2) = New Public_Service.ParamOracle
                            arrayParam(2).Key = "IMAGE"
                            arrayParam(2).Value = fs
                            arrayParam(2).Type = Public_Service.OracleDbType.Blob

                            sResult = (Code_Application.ExecuteWithBlob(sConnection, sSQL, arrayParam))

                            'If Not oraConnection Is Nothing Then oraConnection.Open()
                            'oraCleCommand = New Oracle.DataAccess.Client.OracleCommand(sSQL, oraConnection)
                            'oraCleCommand.Parameters.Add("DEFECT_NO", Oracle.DataAccess.Client.OracleDbType.Int16, sValueKey, ParameterDirection.Input)
                            'oraCleCommand.Parameters.Add("SEQ_NO", Oracle.DataAccess.Client.OracleDbType.Int16, iSeq, ParameterDirection.Input)
                            'oraCleCommand.Parameters.Add("IMAGE", Oracle.DataAccess.Client.OracleDbType.Blob, fs, ParameterDirection.Input)
                            'iResult = oraCleCommand.ExecuteNonQuery()
                            'If Not oraConnection Is Nothing Then oraConnection.Close()
                            'If Not oraConnection Is Nothing Then oraConnection = Nothing
                            'If Not oraCleCommand Is Nothing Then oraCleCommand = Nothing
                        End If
                        If TypeOf objPicture.Parent Is Panel Then
                            objPicturePanelHeader = (CType(objPicture.Parent, Panel))
                            If Not objPicturePanelHeader Is Nothing Then
                                objPicturePanelHeader.Name = objPicture.Name
                                For Each objPanelTool As Control In objPicturePanelHeader.Controls
                                    If TypeOf objPanelTool Is Panel Then
                                        objPicturePanelTool = CType(objPanelTool, Panel)
                                        For Each toolPic As Control In objPicturePanelTool.Controls
                                            If TypeOf toolPic Is PictureBox Then

                                                If CType(toolPic, PictureBox).TabIndex = 222 Then
                                                    CType(toolPic, PictureBox).Tag = Image.FromFile(objPicture.ImageLocation)
                                                End If
                                                If CType(toolPic, PictureBox).TabIndex = 333 Then
                                                    CType(toolPic, PictureBox).Name = sMaxSeq
                                                    CType(toolPic, PictureBox).Tag = sValueKey
                                                End If
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Else
                            LBL_STATUS.Text = "No Image Parent Object"
                        End If
                    Else
                        LBL_STATUS.Text = "No Image Location"
                    End If
                Else
                    LBL_STATUS.Text = "No Image Save"
                End If
            Else
                LBL_STATUS.Text = "No Image Object"
            End If

        Catch ex As Exception
            Dim sMessage As String = ex.Message
            Me.LBL_STATUS.Text = sMessage
        Finally
            objPicturePanelHeader = Nothing
            objPicturePanelTool = Nothing
        End Try
    End Sub
    Private Sub objPicture_Click(sender As System.Object, e As System.EventArgs)
        Dim objPicture As Panel = Nothing
        Dim objPictureClick As PictureBox = Nothing
        Dim sDefectNo As String = String.Empty
        Dim sSeqNo As String = String.Empty
        If TypeOf sender Is PictureBox Then
            objPictureClick = CType(sender, PictureBox)
        End If
        If Not objPictureClick Is Nothing Then
            If String.IsNullOrEmpty(objPictureClick.Tag) Then Exit Sub
            sDefectNo = objPictureClick.Tag
            sSeqNo = objPictureClick.Name
            If TypeOf objPictureClick.Parent Is Panel Then
                objPicture = PanelPictureBox(sDefectNo, String.Empty, Nothing)
                Pn_Picture.Controls.Add(objPicture)
            End If
        End If
    End Sub
    Private Sub ClearNode()
        Dim sTag As String = String.Empty
        Dim sName As String = String.Empty
        Dim sText As String = String.Empty
        Dim oTree As TreeNode = Nothing
        Try
            LockWindowUpdate(TreeView1.Handle.ToInt32)

            TreeView1.Nodes.Clear()
            sName = "DWH_JOB_TRACK"
            sText = "Track Job"
            sTag = "Key=DEFECT_NO;Query=SELECT DEFECT_NO,  DEFECT_NAME,   PROJECT,    DEFECT_DATE,NVL((SELECT BB.DEFECT_STATUS FROM DWH_JOB_TRACK BB WHERE BB.DEFECT_NO IN (SELECT MAX(AA.DEFECT_NO) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO)),DEFECT_STATUS) AS DEFECT_STATUS, C_FULLNAME as DEFECT_CREATE_BY, OWNER, (SELECT COUNT(*)     FROM DWH_JOB_TRACK AA       WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO) AS TRACK_QTY FROM DWH_JOB_TRACK A LEFT JOIN DWH_CONFIG_USER B ON (A.N_CR_BY = B.N_USERID) WHERE DEFECT_NO_PARENT IS NULL Order by 1;Field=DEFECT_NO,DEFECT_NAME,PROJECT,DEFECT_DATE,DEFECT_STATUS,DEFECT_CREATE_BY,OWNER,TRACK_QTY;Label=Defect,Description,Project,Defect Date,Status,Create By,Owner,Track Qty;Width=100,200,150,75,75,100,75,85;Query Child=SELECT * FROM DWH_JOB_TRACK WHERE DEFECT_NO_PARENT = {0}  Order by 1;"
            oTree = New TreeNode
            oTree.Name = sName
            oTree.Text = sText
            oTree.Tag = sTag
            TreeView1.Nodes.Add(oTree)

        Catch ex As Exception
            LBL_STATUS.Text = ex.Message
        Finally
            oTree = Nothing
            LockWindowUpdate(0)
        End Try
    End Sub
    Private Sub AddStatus()
        Dim oDatatableStatus As DataTable = Nothing
        Dim oDatatableDetail As DataTable = Nothing
        Dim sSQLStatus As String = String.Empty
        Dim sSQLStatusDetail As String = String.Empty
        Dim oTreeHead As TreeNode = Nothing
        Dim oTreeDetail As TreeNode = Nothing
        Dim sDefectQty As String = String.Empty
        Dim sDefectStatus As String = String.Empty
        Dim sDefectNo As String = String.Empty
        Dim sDefectStatusDetail As String = String.Empty
        Dim sDefectDetail As String = String.Empty
        Dim sDefectTrack As String = String.Empty
        Dim sFormatStatus As String = "{0} ({1})"
        Dim sFormatDetail As String = "({0}) {1}"
        Try
            LockWindowUpdate(TreeView1.Handle.ToInt32)

            If RadioButton1.Checked Then
                sSQLStatusDetail = "SELECT DEFECT_NO,DEFECT_NAME,"
                sSQLStatusDetail &= "         NVL((SELECT BB.DEFECT_STATUS"
                sSQLStatusDetail &= "               FROM DWH_JOB_TRACK BB"
                sSQLStatusDetail &= "               WHERE BB.DEFECT_NO IN"
                sSQLStatusDetail &= "               (SELECT MAX(AA.DEFECT_NO)"
                sSQLStatusDetail &= "               FROM DWH_JOB_TRACK AA"
                sSQLStatusDetail &= "               WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO)),"
                sSQLStatusDetail &= "          DEFECT_STATUS) AS DEFECT_STATUS,"
                sSQLStatusDetail &= "       (SELECT COUNT(*) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO) AS TRACK_QTY"
                sSQLStatusDetail &= "  FROM DWH_JOB_TRACK A"
                sSQLStatusDetail &= "  LEFT JOIN DWH_CONFIG_USER B ON (A.N_CR_BY = B.N_USERID)"
                sSQLStatusDetail &= "  WHERE DEFECT_NO_PARENT IS NULL"

                sSQLStatus = " SELECT DEFECT_STATUS, COUNT(*) QTY"
                sSQLStatus &= "  FROM ( " & sSQLStatusDetail & " )"
                sSQLStatus &= "  GROUP BY DEFECT_STATUS"
                sSQLStatus &= "  ORDER BY 1"
            ElseIf RadioButton2.Checked Then
                sSQLStatusDetail = "SELECT DEFECT_NO,DEFECT_NAME,"
                sSQLStatusDetail &= "  C_FULLNAME AS DEFECT_STATUS,"
                sSQLStatusDetail &= "       (SELECT COUNT(*) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO) AS TRACK_QTY"
                sSQLStatusDetail &= "  FROM DWH_JOB_TRACK A"
                sSQLStatusDetail &= "  LEFT JOIN DWH_CONFIG_USER B ON (A.N_CR_BY = B.N_USERID)"
                sSQLStatusDetail &= "  WHERE DEFECT_NO_PARENT IS NULL"

                sSQLStatus = " SELECT DEFECT_STATUS, COUNT(*) QTY"
                sSQLStatus &= "  FROM ( " & sSQLStatusDetail & " )"
                sSQLStatus &= "  GROUP BY DEFECT_STATUS"
                sSQLStatus &= "  ORDER BY 1"
            ElseIf RadioButton3.Checked Then
                sSQLStatusDetail = "SELECT DEFECT_NO,DEFECT_NAME,"
                sSQLStatusDetail &= "  PROJECT AS DEFECT_STATUS,"
                sSQLStatusDetail &= "       (SELECT COUNT(*) FROM DWH_JOB_TRACK AA WHERE AA.DEFECT_NO_PARENT = A.DEFECT_NO) AS TRACK_QTY"
                sSQLStatusDetail &= "  FROM DWH_JOB_TRACK A"
                sSQLStatusDetail &= "  LEFT JOIN DWH_CONFIG_USER B ON (A.N_CR_BY = B.N_USERID)"
                sSQLStatusDetail &= "  WHERE DEFECT_NO_PARENT IS NULL"

                sSQLStatus = " SELECT DEFECT_STATUS, COUNT(*) QTY"
                sSQLStatus &= "  FROM ( " & sSQLStatusDetail & " )"
                sSQLStatus &= "  GROUP BY DEFECT_STATUS"
                sSQLStatus &= "  ORDER BY 1"
            End If
            oDatatableStatus = Code_Application.ReturnValueToDatatable(sSQLStatus, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            oDatatableDetail = Code_Application.ReturnValueToDatatable(sSQLStatusDetail, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
            If Not oDatatableStatus Is Nothing And Not oDatatableDetail Is Nothing Then
                If oDatatableStatus.Rows.Count > 0 And oDatatableDetail.Rows.Count > 0 Then
                    For i As Integer = 0 To oDatatableStatus.Rows.Count - 1
                        sDefectStatus = String.Empty
                        sDefectQty = "0"
                        If Not oDatatableStatus.Rows(i)("DEFECT_STATUS") Is DBNull.Value Then sDefectStatus = oDatatableStatus.Rows(i)("DEFECT_STATUS")
                        If Not oDatatableStatus.Rows(i)("QTY") Is DBNull.Value Then sDefectQty = oDatatableStatus.Rows(i)("QTY")
                        oTreeHead = New TreeNode(String.Format(sFormatStatus, sDefectStatus, sDefectQty))
                        For j As Integer = 0 To oDatatableDetail.Rows.Count - 1
                            sDefectStatusDetail = String.Empty
                            sDefectNo = String.Empty
                            sDefectDetail = String.Empty
                            sDefectTrack = "0"
                            If Not oDatatableDetail.Rows(j)("TRACK_QTY") Is DBNull.Value Then sDefectTrack = oDatatableDetail.Rows(j)("TRACK_QTY")
                            If IsNumeric(sDefectTrack) Then sDefectTrack = CInt(sDefectTrack) + 1
                            If Not oDatatableDetail.Rows(j)("DEFECT_NO") Is DBNull.Value Then sDefectNo = oDatatableDetail.Rows(j)("DEFECT_NO")
                            If Not oDatatableDetail.Rows(j)("DEFECT_STATUS") Is DBNull.Value Then sDefectStatusDetail = oDatatableDetail.Rows(j)("DEFECT_STATUS")
                            If sDefectStatus = sDefectStatusDetail Then
                                If Not oDatatableDetail.Rows(j)("DEFECT_NAME") Is DBNull.Value Then sDefectDetail = oDatatableDetail.Rows(j)("DEFECT_NAME")
                                oTreeDetail = New TreeNode(String.Format(sFormatDetail, sDefectTrack, sDefectDetail))
                                oTreeDetail.Tag = sDefectNo
                                oTreeDetail.Name = sDefectNo
                                If Not oTreeHead Is Nothing And Not oTreeDetail Is Nothing Then oTreeHead.Nodes.Add(oTreeDetail)
                                If Not oTreeDetail Is Nothing Then oTreeDetail = Nothing
                            End If
                        Next
                        If Not oTreeHead Is Nothing Then TreeView1.Nodes.Add(oTreeHead)
                        If Not oTreeHead Is Nothing Then oTreeHead = Nothing
                    Next
                End If
            End If

        Catch ex As Exception
            Me.LBL_STATUS.Text = ex.Message
        Finally
            LockWindowUpdate(0)
        End Try
    End Sub
    Private Sub DefaultView()
        Dim sPath As String = String.Empty
        Dim sSearch As String = String.Empty

        Try
            LockWindowUpdate(TreeView1.Handle.ToInt32)
            If Not TabControl Is Nothing Then
                For iClear As Integer = 0 To TabControl.TabPages.Count - 1
                    If iClear > 0 Then TabControl.TabPages.RemoveAt(TabControl.TabPages.Count - 1)
                Next
                If TabControl.TabPages.Count > 0 Then TabControl.TabPages(0).Text = "Defect {0}"
            End If
            If Not TreeView1.Nodes Is Nothing Then
                If TreeView1.Nodes.Count > 0 Then
                    If Not TreeView1.Nodes(0) Is Nothing Then
                        sSearch = TreeView1.Nodes(0).Tag
                        sPath = TreeView1.Nodes(0).Name
                        LBL_CONFIG_NAME.Text = TreeView1.Nodes(0).Text.ToString
                        LBL_CONFIG_NAME.Tag = TreeView1.Nodes(0).Name.ToString
                        Try
                            PIC_CONFIG.Image = ImageList1.Images(TreeView1.Nodes(0).ImageIndex)
                        Catch
                        End Try
                    End If
                    If Not String.IsNullOrEmpty(sPath) Then
                        Load_Column_Table(sPath) : Pn_Control.Tag = sSearch
                    End If
                    Mode_Button(True)
                    'ReadonlyTextbox(TabControl, True)
                End If
            End If

        Catch ex As Exception
            Me.LBL_STATUS.Text = ex.Message
        Finally
            LockWindowUpdate(0)

        End Try
    End Sub
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim oTreeNode As TreeNode = e.Node
        Dim objPicture As Panel = Nothing
        Dim sPath As String = String.Empty
        Dim sSearch As String = String.Empty
        Dim iDefectNo As Integer = 0
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Not oTreeNode Is Nothing Then
                If oTreeNode.Nodes.Count = 0 Then
                    sSearch = e.Node.Tag
                    If Not IsNumeric(sSearch) Then 'Master
                        If Not e.Node.Name Is Nothing Then
                            sPath = e.Node.Name
                            LBL_CONFIG_NAME.Text = e.Node.Text.ToString
                            LBL_CONFIG_NAME.Tag = e.Node.Name.ToString
                            Try
                                PIC_CONFIG.Image = ImageList1.Images(e.Node.ImageIndex)

                            Catch ex As Exception
                                PIC_CONFIG.Image = ImageList1.Images(3)

                            End Try
                        End If
                        If Not String.IsNullOrEmpty(sPath) Then
                            Load_Column_Table(sPath) : Pn_Control.Tag = sSearch
                            If Not TabControl Is Nothing Then
                                For iClear As Integer = 1 To TabControl.TabPages.Count - 1
                                    TabControl.TabPages.RemoveAt(TabControl.TabPages.Count - 1)
                                Next
                                If TabControl.TabPages.Count > 0 Then TabControl.TabPages(0).Text = "Defect {0}"
                            End If
                        End If
                        Pn_Picture.Controls.Clear()

                        objPicture = PanelPictureBox(String.Empty, String.Empty, Nothing)
                        Pn_Picture.Controls.Add(objPicture)
                        If Not objPicture Is Nothing Then objPicture = Nothing
                        Mode_Button(True)
                    Else 'Detail ID
                        iDefectNo = sSearch
                        LoadDefectNo(False, iDefectNo)
                    End If
                    'ReadonlyTextbox(TabControl, True)
                End If
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As String = e.Node.Text
            CType(sender, TreeView).SelectedNode = e.Node
        End If
    End Sub

    Private Sub FRM_MAIN_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        LoadDefectNo(False, inPubDefectNo)

    End Sub

    Private Sub FRM_MAIN_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub


    Private Sub Configuration_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Configuration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Mode_Button(True)
        'ReadonlyTextbox(TabControl, True)

        TreeView1.ExpandAll()
        DefaultView()
        AddStatus()

        LoadDefectNo(False, inPubDefectNo)
    End Sub

    Private Sub BTN_NEW_Click(sender As System.Object, e As System.EventArgs) Handles BTN_NEW.Click
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objPanel As Panel = Nothing
        Dim objPanelPicture As Panel = Nothing
        Dim sITem As String = String.Empty
        Dim spITem() As String = Nothing

        Dim sSQLPK As String = "SELECT NVL(MAX({1}),0)+1 AS MAX_NO FROM {0} "
        Dim sMaxPK As String = String.Empty
        Dim inTableName As String = String.Empty
        Dim inSearchFormat As String = String.Empty
        Dim spSearch() As String = Nothing
        Dim sKeySearch As String = String.Empty
        Dim objPicture As Panel = Nothing
        DefaultView()
        If Pn_Control.Controls.Count > 0 Then
            For iControl As Integer = 0 To Pn_Control.Controls.Count - 1
                If TypeOf Pn_Control.Controls(iControl) Is Panel Then
                    objPanel = CType(Pn_Control.Controls(iControl), Panel)
                    If Not objPanel Is Nothing Then
                        For iC As Integer = 0 To objPanel.Controls.Count - 1
                            If TypeOf objPanel.Controls(iC) Is ComboBox Then
                                objCombobox = CType(objPanel.Controls(iC), ComboBox)
                                If Not objCombobox Is Nothing Then
                                    objCombobox.Items.Clear()
                                    objCombobox.Text = String.Empty
                                    If Not objCombobox.Tag Is Nothing Then
                                        sITem = CType(objCombobox.Tag, String)
                                        If Not String.IsNullOrEmpty(sITem) Then
                                            spITem = sITem.Split(",")
                                            If Not spITem Is Nothing Then
                                                For iLoop As Integer = 0 To spITem.Length - 1
                                                    objCombobox.Items.Add(spITem(iLoop))
                                                Next
                                            End If
                                        End If
                                        If objCombobox.Items.Count > 0 Then objCombobox.SelectedIndex = 0
                                    End If
                                End If

                            ElseIf TypeOf objPanel.Controls(iC) Is CheckBox Then
                                objCheckbox = CType(objPanel.Controls(iC), CheckBox)
                                If Not objCheckbox Is Nothing Then
                                    objCheckbox.Checked = False
                                End If
                            ElseIf TypeOf objPanel.Controls(iC) Is DateTimePicker Then
                                objDate = CType(objPanel.Controls(iC), DateTimePicker)
                                If Not objDate Is Nothing Then
                                    objDate.Checked = False
                                    objDate.Value = Now
                                End If
                            ElseIf TypeOf objPanel.Controls(iC) Is TextBox Then
                                objTextbox = CType(objPanel.Controls(iC), TextBox)
                                If Not objTextbox Is Nothing Then

                                    If objTextbox.ReadOnly Then
                                        inTableName = LBL_CONFIG_NAME.Tag
                                        inSearchFormat = Pn_Control.Tag
                                        If Not String.IsNullOrEmpty(inSearchFormat) Then
                                            spSearch = inSearchFormat.Split(";")
                                            If Not spSearch Is Nothing Then
                                                For ilength As Integer = 0 To spSearch.Length - 1
                                                    If spSearch(ilength).IndexOf("Key=") > -1 Then
                                                        sKeySearch = spSearch(ilength).Replace("Key=", "").Trim
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                        End If
                                        If objTextbox.Name.ToUpper = sKeySearch.ToUpper Then
                                            sMaxPK = Code_Application.ReturnValueSql(String.Format(sSQLPK, inTableName, sKeySearch), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                            If Not String.IsNullOrEmpty(sMaxPK) Then
                                                objTextbox.Text = sMaxPK
                                                If TabControl.TabPages.Count > 0 Then TabControl.TabPages(0).Text = String.Format("Defect {0}", sMaxPK) : BTN_ADD.Visible = False
                                            End If
                                        End If
                                    ElseIf Not objTextbox.ReadOnly Then
                                        objTextbox.Text = String.Empty
                                        If objTextbox.Name.ToUpper.IndexOf("CR_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("CREATE_BY") > 0 Then objTextbox.Text = ToolStripUserID.Text
                                        If objTextbox.Name.ToUpper.IndexOf("UPD_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("UPDATE_BY") > 0 Then objTextbox.Text = ToolStripUserID.Text
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            Pn_Picture.Controls.Clear()
            Pn_Status.Controls.Clear()
            isModeNewEdit = False
            Mode_Button(False)
            'ReadonlyTextbox(TabControl, False)
        Else
            MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BTN_EDIT_Click(sender As System.Object, e As System.EventArgs) Handles BTN_EDIT.Click
        Dim objPanel As Panel = Nothing
        Dim isSearch As Boolean = False
        Dim objTextbox As TextBox = Nothing
        If Pn_Control.Controls.Count > 0 Then
            For iControlx As Integer = 0 To Pn_Control.Controls.Count - 1
                If TypeOf Pn_Control.Controls(iControlx) Is Panel Then
                    objPanel = CType(Pn_Control.Controls(iControlx), Panel)
                    If Not objPanel Is Nothing Then
                        For iC As Integer = 0 To objPanel.Controls.Count - 1
                            If TypeOf objPanel.Controls(iC) Is TextBox Then
                                objTextbox = CType(objPanel.Controls(iC), TextBox)
                                If Not objTextbox Is Nothing Then
                                    If Not String.IsNullOrEmpty(objTextbox.Text) Then
                                        isSearch = True
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            If isSearch Then
                isModeNewEdit = True
                BTN_ADD.Visible = False
                Mode_Button(False)
                'ReadonlyTextbox(TabControl, False)

            Else
                MessageBox.Show("Please Search Data Before Copy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub BTN_SAVE_Click(sender As System.Object, e As System.EventArgs) Handles BTN_SAVE.Click
        Dim inTableName As String = String.Empty
        Dim sSQLColInsertWithFK As String = "select b.* from  COL b where upper(b.tname)='{0}'  order by b.colno Desc"
        Dim sSQLColInsert As String = "select b.* from  COL b where upper(b.tname)='{0}' AND  not b.cname in (select bb.column_name  from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name) order by b.colno Desc"
        Dim sSQL As String = String.Empty
        Dim obj_Datatable_ColInsert As DataTable = Nothing
        Dim objPanel As Panel = Nothing
        Dim objPanelPicture As Panel = Nothing
        Dim PictureBox As PictureBox = Nothing
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objRichTextbox As RichTextBox = Nothing
        Dim sITem As String = String.Empty
        Dim spItem() As String = Nothing
        Dim sColName As String = String.Empty

        Dim COLNO As String = String.Empty
        Dim CNAME As String = String.Empty
        Dim LBLNAME As String = String.Empty
        Dim COLTYPE As String = String.Empty
        Dim Width As String = String.Empty
        Dim NULLS As String = String.Empty
        Dim sSQLFormatMerge As String = String.Empty
        Dim sField As String = String.Empty
        Dim sFormatDate = "{0}/{1}/{2}"
        Dim sValue As String = String.Empty
        Dim sValueUPdate As String = String.Empty
        Dim sFormatValueNumberField As String = "{0} AS {1}"
        Dim sFormatValueStringField As String = "'{0}' AS {1}"
        Dim sFormatValueDateField As String = "to_Date('{0}','mm/dd/yyyy') AS {1}"
        Dim sValueField As String = String.Empty
        Dim sFormatValueString As String = "'{0}'"
        Dim sFormatValueDate As String = "to_Date('{0}','mm/dd/yyyy')"

        Dim sSelectField As String = String.Empty
        Dim sSQLFormatSelect As String = "SELECT {0} FROM DUAL"
        Dim sSQLSelect As String = String.Empty
        Dim sSQLPK As String = "SELECT NVL(MAX({1}),0)+1 AS MAX_NO FROM {0} "
        Dim sMaxPK As String = String.Empty
        Dim sSQLFormatMergeUpdate As String = String.Empty
        Dim sSQLMergeUpdate As String = String.Empty
        Dim sSQLUpdate As String = String.Empty
        Dim sSQLUpdateFormat As String = "UPDATE {0} SET {1} WHERE {2}"
        Dim sUpdateFormat As String = "D.{0} = S.{0}"
        Dim sUpdateFormatForUpdate As String = "{0} = {1}"
        Dim sUpdateValue As String = String.Empty
        Dim sUpdateWhereKEy As String = String.Empty
        Dim sConditionValue As String = String.Empty

        Dim sInsertFormatSource As String = "D.{0}"
        Dim sInsertFormatTarget As String = "S.{0}"
        Dim sInsertField As String = String.Empty
        Dim sInsertValue As String = String.Empty
        Dim inSearchFormat As String = String.Empty
        Dim spSearch() As String
        Dim spKey() As String
        Dim spKeyUpdate() As String
        Dim sKeySearch As String = String.Empty
        Dim sValueKey As String = String.Empty
        Dim sResult As String = String.Empty
        Dim oTabPanel As TabPage = Nothing
        Dim oPanel As Panel = Nothing
        Dim sTagKey As String = String.Empty
        Dim spKeyValueFK() As String = Nothing
        Dim sKeyFK As String = String.Empty
        Dim sValueFK As String = String.Empty
        Try
            If Pn_Control.Controls.Count > 0 Then
                inTableName = LBL_CONFIG_NAME.Tag
                For iTabpage As Integer = 0 To TabControl.TabPages.Count - 1
                    oTabPanel = CType(TabControl.TabPages(iTabpage), TabPage)
                    If Not oTabPanel Is Nothing Then
                        sTagKey = (oTabPanel.Tag)
                        If Not String.IsNullOrEmpty(sTagKey) Then
                            spKeyValueFK = sTagKey.Split(";")
                            If spKeyValueFK.Length > 0 Then sKeyFK = spKeyValueFK(0).Replace("Key:", String.Empty)
                            If spKeyValueFK.Length > 1 Then sValueFK = spKeyValueFK(1).Replace("Value:", String.Empty)
                        End If
                        For iPanelp As Integer = 0 To oTabPanel.Controls.Count - 1
                            If TypeOf oTabPanel.Controls(iPanelp) Is Panel Then
                                oPanel = CType(oTabPanel.Controls(iPanelp), Panel)
                                If Not oPanel Is Nothing Then
                                    If oPanel.Name.IndexOf("Pn_Control") > -1 Then

                                        inSearchFormat = oPanel.Tag
                                        If Not String.IsNullOrEmpty(inSearchFormat) Then
                                            spSearch = inSearchFormat.Split(";")
                                            If Not spSearch Is Nothing Then
                                                For ilength As Integer = 0 To spSearch.Length - 1
                                                    If spSearch(ilength).IndexOf("Key=") > -1 Then
                                                        sKeySearch = spSearch(ilength).Replace("Key=", "").Trim
                                                    End If
                                                Next
                                            End If
                                        End If


                                        If Not String.IsNullOrEmpty(inTableName) Then
                                            If Not String.IsNullOrEmpty(sKeyFK) And Not String.IsNullOrEmpty(sValueFK) Then
                                                sSQL = String.Format(sSQLColInsertWithFK, inTableName)
                                            Else
                                                sSQL = String.Format(sSQLColInsert, inTableName)
                                            End If
                                            If Not String.IsNullOrEmpty(sSQL) Then
                                                obj_Datatable_ColInsert = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                                If Not obj_Datatable_ColInsert Is Nothing Then
                                                    sSelectField = String.Empty
                                                    sUpdateValue = String.Empty
                                                    sInsertField = String.Empty
                                                    sInsertValue = String.Empty

                                                    For i As Integer = 0 To obj_Datatable_ColInsert.Rows.Count - 1
                                                        If Not obj_Datatable_ColInsert.Rows(i)("COLNO") Is DBNull.Value Then COLNO = obj_Datatable_ColInsert.Rows(i)("COLNO")
                                                        If Not obj_Datatable_ColInsert.Rows(i)("CNAME") Is DBNull.Value Then CNAME = obj_Datatable_ColInsert.Rows(i)("CNAME")
                                                        If Not obj_Datatable_ColInsert.Rows(i)("COLTYPE") Is DBNull.Value Then COLTYPE = obj_Datatable_ColInsert.Rows(i)("COLTYPE")
                                                        If Not obj_Datatable_ColInsert.Rows(i)("WIDTH") Is DBNull.Value Then Width = obj_Datatable_ColInsert.Rows(i)("WIDTH")
                                                        If Not obj_Datatable_ColInsert.Rows(i)("NULLS") Is DBNull.Value Then NULLS = obj_Datatable_ColInsert.Rows(i)("NULLS")

                                                        If Not String.IsNullOrEmpty(sInsertField) Then sInsertField &= ","
                                                        sInsertField &= String.Format(sInsertFormatSource, CNAME)
                                                        If Not String.IsNullOrEmpty(sInsertValue) Then sInsertValue &= ","
                                                        sInsertValue &= String.Format(sInsertFormatTarget, CNAME)


                                                        For iPanel As Integer = 0 To oPanel.Controls.Count - 1
                                                            If TypeOf oPanel.Controls(iPanel) Is Panel Then
                                                                objPanel = CType(oPanel.Controls(iPanel), Panel)
                                                                If Not objPanel Is Nothing Then
                                                                    For iC As Integer = 0 To objPanel.Controls.Count - 1
                                                                        sValueField = String.Empty
                                                                        sValueUPdate = String.Empty
                                                                        If TypeOf objPanel.Controls(iC) Is ComboBox Then
                                                                            objCombobox = CType(objPanel.Controls(iC), ComboBox)
                                                                            If Not objCombobox Is Nothing Then
                                                                                If objCombobox.Name.ToUpper = CNAME.ToUpper Then
                                                                                    sValue = objCombobox.Text.Replace("'", "''")
                                                                                    If String.IsNullOrEmpty(sValue) Then
                                                                                        sValueField = String.Format(sFormatValueNumberField, "NULL", CNAME)
                                                                                        sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, "NULL")
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValueField = String.Format(sFormatValueNumberField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, sValue)
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueStringField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, String.Format(sFormatValueString, sValue))
                                                                                        End If
                                                                                    End If

                                                                                    Exit For
                                                                                End If
                                                                            End If
                                                                        ElseIf TypeOf objPanel.Controls(iC) Is CheckBox Then
                                                                            objCheckbox = CType(objPanel.Controls(iC), CheckBox)
                                                                            If Not objCheckbox Is Nothing Then
                                                                                If objCheckbox.Name.ToUpper = CNAME.ToUpper Then
                                                                                    If objCheckbox.Checked Then
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValue = "1"
                                                                                        Else
                                                                                            sValue = "Y"
                                                                                        End If
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValue = "0"
                                                                                        Else
                                                                                            sValue = "N"
                                                                                        End If
                                                                                    End If
                                                                                    If String.IsNullOrEmpty(sValue) Then
                                                                                        sValueField = String.Format(sFormatValueNumberField, "NULL", CNAME)
                                                                                        sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, "NULL")
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValueField = String.Format(sFormatValueNumberField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, sValue)
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueStringField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, String.Format(sFormatValueString, sValue))
                                                                                        End If
                                                                                    End If
                                                                                    Exit For
                                                                                End If
                                                                            End If
                                                                        ElseIf TypeOf objPanel.Controls(iC) Is DateTimePicker Then
                                                                            objDate = CType(objPanel.Controls(iC), DateTimePicker)
                                                                            If Not objDate Is Nothing Then
                                                                                If objDate.Name.ToUpper = CNAME.ToUpper Then
                                                                                    If objDate.Checked Then
                                                                                        sValue = String.Format(sFormatDate, objDate.Value.Month.ToString("00"), objDate.Value.Day.ToString("00"), objDate.Value.Year.ToString("0000"))
                                                                                    Else
                                                                                        sValue = String.Empty
                                                                                    End If
                                                                                    If String.IsNullOrEmpty(sValue) Then
                                                                                        sValueField = String.Format(sFormatValueNumberField, "NULL", CNAME)
                                                                                        sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, "NULL")
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValueField = String.Format(sFormatValueNumberField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, sValue)
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueDateField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, String.Format(sFormatValueDate, sValue))
                                                                                        End If
                                                                                    End If
                                                                                    If sKeySearch.ToUpper = CNAME.ToUpper Then sValueKey = sValue
                                                                                    Exit For
                                                                                End If
                                                                            End If
                                                                        ElseIf TypeOf objPanel.Controls(iC) Is RichTextBox Then
                                                                            objRichTextbox = CType(objPanel.Controls(iC), RichTextBox)
                                                                            If Not objRichTextbox Is Nothing Then
                                                                                If objRichTextbox.Name.ToUpper = CNAME.ToUpper Then
                                                                                    sValue = objRichTextbox.Text.Replace("'", "''")
                                                                                    If String.IsNullOrEmpty(sValue) Then
                                                                                        sValueField = String.Format(sFormatValueNumberField, "NULL", CNAME)
                                                                                        sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, "NULL")
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValueField = String.Format(sFormatValueNumberField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, sValue)
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueStringField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, String.Format(sFormatValueString, sValue))

                                                                                        End If
                                                                                    End If
                                                                                    Exit For
                                                                                End If
                                                                            End If
                                                                        ElseIf TypeOf objPanel.Controls(iC) Is TextBox Then
                                                                            objTextbox = CType(objPanel.Controls(iC), TextBox)
                                                                            If Not objTextbox Is Nothing Then
                                                                                If objTextbox.Name.ToUpper = CNAME.ToUpper Then
                                                                                    sValue = objTextbox.Text.Replace("'", "''")
                                                                                    If String.IsNullOrEmpty(sValue) Then
                                                                                        If objTextbox.ReadOnly Then
                                                                                            sMaxPK = Code_Application.ReturnValueSql(String.Format(sSQLPK, inTableName, CNAME.ToUpper), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                                                                            If Not String.IsNullOrEmpty(sMaxPK) Then
                                                                                                sValueField = String.Format(sFormatValueNumberField, sMaxPK, CNAME)
                                                                                            End If
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueNumberField, "NULL", CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, "NULL")
                                                                                        End If
                                                                                    Else
                                                                                        If COLTYPE = "NUMBER" Then
                                                                                            sValueField = String.Format(sFormatValueNumberField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, sValue)
                                                                                        Else
                                                                                            sValueField = String.Format(sFormatValueStringField, sValue, CNAME)
                                                                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, CNAME, String.Format(sFormatValueString, sValue))

                                                                                        End If
                                                                                    End If
                                                                                    Exit For
                                                                                End If
                                                                            End If
                                                                        End If

                                                                    Next

                                                                    If Not String.IsNullOrEmpty(sValueField) Then
                                                                        If Not String.IsNullOrEmpty(sSelectField) Then sSelectField &= ","
                                                                        sSelectField &= sValueField
                                                                    End If
                                                                    If Not String.IsNullOrEmpty(sValueUPdate) Then
                                                                        If Not String.IsNullOrEmpty(sUpdateValue) Then sUpdateValue &= ","
                                                                        sUpdateValue &= sValueUPdate

                                                                        If Not String.IsNullOrEmpty(sKeySearch) Then
                                                                            spKey = sKeySearch.Split(",")
                                                                            If Not spKey Is Nothing Then
                                                                                For il As Integer = 0 To spKey.Length - 1
                                                                                    spKeyUpdate = sValueUPdate.Split(" = ")
                                                                                    sUpdateWhereKEy = String.Empty
                                                                                    If Not spKeyUpdate Is Nothing Then
                                                                                        If spKeyUpdate.Length > 0 Then
                                                                                            If spKeyUpdate(0) = spKey(il) Then
                                                                                                If Not String.IsNullOrEmpty(sUpdateWhereKEy) Then sUpdateWhereKEy &= " AND "
                                                                                                sUpdateWhereKEy &= sValueUPdate
                                                                                                Exit For
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                Next
                                                                            End If
                                                                        End If

                                                                    End If
                                                                End If
                                                            End If
                                                        Next
                                                    Next

                                                End If
                                            End If
                                        End If

                                        If Not String.IsNullOrEmpty(sKeyFK) And Not String.IsNullOrEmpty(sValueFK) Then
                                            sValueField = String.Format(sFormatValueNumberField, sValueFK, sKeyFK)
                                            sValueUPdate = String.Format(sUpdateFormatForUpdate, sKeyFK, sValueFK)
                                            If Not String.IsNullOrEmpty(sValueField) Then
                                                If Not String.IsNullOrEmpty(sSelectField) Then sSelectField &= ","
                                                sSelectField &= sValueField
                                            End If
                                        End If



                                        If Not String.IsNullOrEmpty(sSelectField) Then
                                            sSQLSelect = String.Format(sSQLFormatSelect, sSelectField)
                                        End If

                                        If Not String.IsNullOrEmpty(sKeySearch) Then
                                            spKey = sKeySearch.Split(",")
                                            sConditionValue = String.Empty
                                            If Not spKey Is Nothing Then
                                                For il As Integer = 0 To spKey.Length - 1
                                                    If Not String.IsNullOrEmpty(sConditionValue) Then sConditionValue &= " AND "
                                                    sConditionValue &= String.Format(sUpdateFormat, spKey(il).ToString)
                                                Next
                                            End If
                                        End If
                                        sSQLFormatMergeUpdate = " Merge Into @Table Name: D"
                                        sSQLFormatMergeUpdate &= vbCrLf & " Using               ( @Select Field: ) S"
                                        sSQLFormatMergeUpdate &= vbCrLf & " On                  ( @Condition Field: ) "
                                        sSQLFormatMergeUpdate &= vbCrLf & " When Not Matched Then    "
                                        sSQLFormatMergeUpdate &= vbCrLf & "     Insert ( @Insert Field: ) "
                                        sSQLFormatMergeUpdate &= vbCrLf & "     Values ( @Insert Value: ) "


                                        sSQLMergeUpdate = sSQLFormatMergeUpdate
                                        sSQLMergeUpdate = sSQLMergeUpdate.Replace("@Table Name:", inTableName)
                                        sSQLMergeUpdate = sSQLMergeUpdate.Replace("@Select Field:", sSQLSelect)
                                        sSQLMergeUpdate = sSQLMergeUpdate.Replace("@Condition Field:", sConditionValue)
                                        sSQLMergeUpdate = sSQLMergeUpdate.Replace("@Insert Field:", sInsertField)
                                        sSQLMergeUpdate = sSQLMergeUpdate.Replace("@Insert Value:", sInsertValue)


                                        If isModeNewEdit Then
                                            sSQLUpdate = String.Format(sSQLUpdateFormat, inTableName, sUpdateValue, sUpdateWhereKEy)
                                            sResult = Code_Application.Execute(sSQLUpdate, cUser_Login, cPassword_Login, cConnecton_Login)
                                            sSQLUpdate = String.Empty
                                        Else
                                            sResult = Code_Application.Execute(sSQLMergeUpdate, cUser_Login, cPassword_Login, cConnecton_Login)
                                            sSQLMergeUpdate = String.Empty
                                        End If

                                        If Not obj_Datatable_ColInsert Is Nothing Then obj_Datatable_ColInsert = Nothing
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next


                MessageBox.Show("Complete", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mode_Button(True)
            Else
                MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Me.LBL_STATUS.Text = ex.Message
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            obj_Datatable_ColInsert = Nothing
            objPanel = Nothing
            objCombobox = Nothing
            objCheckbox = Nothing
            objDate = Nothing
            objTextbox = Nothing
            spItem = Nothing
        End Try



    End Sub

    Private Sub BTN_CANCEL_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CANCEL.Click
        If Pn_Control.Controls.Count > 0 Then
            If Not BTN_CANCEL.Tag Is Nothing Then
                If TypeOf BTN_CANCEL.Tag Is TabPage Then
                    TabControl.TabPages.Remove(CType(BTN_CANCEL.Tag, TabPage))
                End If
            End If
            Mode_Button(True)
        Else
            MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub LoadDefectNo(isSearch As Boolean, Optional inID As Integer = 0)
        Dim inTableName As String = String.Empty
        Dim inSearchFormat As String = String.Empty
        Dim sSQLFormat As String = "Select * from {0} WHERE {1}"
        Dim sSQLSearch As String = String.Empty
        Dim sSQLSearchChild As String = String.Empty
        Dim sFieldFK As String = String.Empty
        Dim sSQL As String = String.Empty
        Dim obj_Datatable As DataTable = Nothing
        Dim obj_DatatableChild As DataTable = Nothing
        Dim sKey As String = String.Empty
        Dim sValue As String = String.Empty
        Dim objPanel As Panel = Nothing
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objRichTextbox As RichTextBox = Nothing
        Dim sITem As String = String.Empty
        Dim spItem() As String = Nothing
        Dim spSearch() As String = Nothing
        Dim ofrm As FRM_LOOKUP = Nothing
        Dim sSearchID As String = String.Empty
        Dim sKeySearch As String = String.Empty
        Dim sFieldSearch As String = String.Empty
        Dim sQuerySearch As String = String.Empty
        Dim sLabelSearch As String = String.Empty
        Dim sWidthSearch As String = String.Empty
        Dim sQueryChild As String = String.Empty
        Dim inField() As String = Nothing
        Dim inLabel() As String = Nothing
        Dim inWidth() As Integer
        Dim sFilter As String = String.Empty
        Dim sSQLFK As String = "select Max(bb.column_name) as Column_name from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name "
        Dim sFormatFKKeyValue As String = "Key:{0};Value:{1}"
        Dim sValueFKKeyValue As String = String.Empty
        Dim oTabPage As TabPage = Nothing
        Dim Pn_ControlChild As Panel = Nothing
        Dim objLabelRight As Label = Nothing
        Dim obj_Datatable_Config As DataTable = Nothing
        Dim COLNO As Integer = 0
        Dim CNAME As String = String.Empty
        Dim LBLNAME As String = String.Empty
        Dim COLTYPE As String = String.Empty
        Dim WIDTH As Integer = 0
        Dim NULLS As String = String.Empty
        Dim sControl_Identify As String = String.Empty
        Dim iControl_Length As Integer = 0
        Dim isControl_Key As Boolean = False
        Dim iControl_Multiline As Boolean = False
        Dim objLabel As Label = Nothing
        Dim sSQLConfig As String = "select b.*,nvl(a.comments,b.cname) comments from ALL_COL_COMMENTS a,COL b where a.table_name=b.tname and a.column_name=b.cname and upper(b.tname)='{0}' and not b.cname in (select bb.column_name  from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name) order by b.colno Desc"
        Dim sComboboxTag As String = String.Empty
        Dim sSQLFormatCombobox As String = "select {1} from {0} Where not {1} is null Group by {1} Order by 1"
        Dim obj_DataTable_Combobox As DataTable = Nothing
        Dim sSQLCombo As String = String.Empty
        Dim sQuerySearchChild As String = String.Empty
        Try
            ClearNode()
            DefaultView()
            AddStatus()
            If Pn_Control.Controls.Count > 0 Then
                inTableName = LBL_CONFIG_NAME.Tag
                inSearchFormat = Pn_Control.Tag
                If Not String.IsNullOrEmpty(inSearchFormat) Then
                    spSearch = inSearchFormat.Split(";")
                    If Not spSearch Is Nothing Then
                        For ilength As Integer = 0 To spSearch.Length - 1
                            If spSearch(ilength).IndexOf("Key=") > -1 Then
                                sKeySearch = spSearch(ilength).Replace("Key=", "").Trim
                            End If
                            If spSearch(ilength).IndexOf("Query=") > -1 Then
                                sQuerySearch = spSearch(ilength).Replace("Query=", "").Trim
                            End If
                            If spSearch(ilength).IndexOf("Field=") > -1 Then
                                sFieldSearch = spSearch(ilength).Replace("Field=", "")
                                If Not sFieldSearch.Split(",") Is Nothing Then
                                    ReDim inField(sFieldSearch.Split(",").Length - 1)
                                    For il As Integer = 0 To sFieldSearch.Split(",").Length - 1
                                        inField(il) = sFieldSearch.Split(",")(il).Trim
                                    Next
                                End If
                            End If
                            If spSearch(ilength).IndexOf("Width=") > -1 Then
                                sWidthSearch = spSearch(ilength).Replace("Width=", "")
                                If Not sWidthSearch.Split(",") Is Nothing Then
                                    ReDim inWidth(sWidthSearch.Split(",").Length - 1)
                                    For il As Integer = 0 To sWidthSearch.Split(",").Length - 1
                                        inWidth(il) = sWidthSearch.Split(",")(il).Trim
                                    Next
                                End If
                            End If
                            If spSearch(ilength).IndexOf("Label=") > -1 Then
                                sLabelSearch = spSearch(ilength).Replace("Label=", "")
                                If Not sLabelSearch.Split(",") Is Nothing Then
                                    ReDim inLabel(sLabelSearch.Split(",").Length - 1)
                                    For il As Integer = 0 To sLabelSearch.Split(",").Length - 1
                                        inLabel(il) = sLabelSearch.Split(",")(il).Trim
                                    Next
                                End If
                            End If

                            If spSearch(ilength).IndexOf("Query Child=") > -1 Then
                                sQuerySearchChild = spSearch(ilength).Replace("Query Child=", "").Trim
                            End If

                        Next
                    End If

                    If isSearch Then 'Lookup 
                        sSQLSearch = sQuerySearch
                        ofrm = New FRM_LOOKUP(sSQLSearch, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login), inField, inWidth, inLabel)
                        ofrm.ShowDialog()
                        If Not ofrm.outValue Is Nothing Then
                            If ofrm.outValue.Length > 0 Then
                                If sKeySearch.Split(",").Length > 1 Then
                                    For ik As Integer = 0 To sKeySearch.Split(",").Length - 1
                                        If Not String.IsNullOrEmpty(sFilter) Then sFilter &= " AND "
                                        sFilter &= String.Format("Upper({0}) = '{1}'", sKeySearch.Split(",")(ik), ofrm.outValue(ik).ToUpper)
                                    Next
                                Else
                                    sSearchID = ofrm.outValue(0)
                                    BTN_CANCEL.Tag = sSearchID
                                    sFilter = String.Format("Upper({0}) = '{1}'", sKeySearch.ToUpper, sSearchID.ToUpper)
                                    If TabControl.TabPages.Count > 0 Then TabControl.TabPages(0).Text = String.Format("Defect {0}", sSearchID)
                                End If
                            End If
                        End If
                    Else 'No Lookup
                        sSearchID = inID
                        BTN_CANCEL.Tag = sSearchID
                        TreeView1.SelectedNode = Nothing
                        sFilter = String.Format("Upper({0}) = '{1}'", sKeySearch.ToUpper, sSearchID.ToUpper)
                        If TabControl.TabPages.Count > 0 Then TabControl.TabPages(0).Text = String.Format("Defect {0}", sSearchID)
                    End If

                    If Not String.IsNullOrEmpty(inTableName) Then
                        sSQL = String.Format(sSQLFormat, inTableName, sFilter)
                        If Not String.IsNullOrEmpty(sSQL) Then
                            obj_Datatable = Code_Application.ReturnValueToDatatable(sSQL, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                            If Not obj_Datatable Is Nothing Then
                                For iRow As Integer = 0 To obj_Datatable.Rows.Count - 1
                                    For iColumn As Integer = 0 To obj_Datatable.Columns.Count - 1
                                        sKey = String.Empty
                                        sValue = String.Empty

                                        sKey = obj_Datatable.Columns(iColumn).ColumnName
                                        If Not obj_Datatable.Rows(iRow)(iColumn) Is DBNull.Value Then sValue = obj_Datatable.Rows(iRow)(iColumn)

                                        For iPanel As Integer = 0 To Pn_Control.Controls.Count - 1
                                            If TypeOf Pn_Control.Controls(iPanel) Is Panel Then
                                                objPanel = CType(Pn_Control.Controls(iPanel), Panel)
                                                If Not objPanel Is Nothing Then
                                                    For iC As Integer = 0 To objPanel.Controls.Count - 1

                                                        If TypeOf objPanel.Controls(iC) Is ComboBox Then
                                                            objCombobox = CType(objPanel.Controls(iC), ComboBox)
                                                            If Not objCombobox Is Nothing Then
                                                                If objCombobox.Name.ToUpper = sKey.ToUpper Then
                                                                    If objCombobox.Items.Count > 0 Then
                                                                        For ifind As Integer = 0 To objCombobox.Items.Count - 1
                                                                            If objCombobox.Items(ifind) = sValue Then
                                                                                objCombobox.SelectedIndex = ifind
                                                                                Exit For
                                                                            End If
                                                                        Next
                                                                    End If
                                                                End If
                                                            End If

                                                        ElseIf TypeOf objPanel.Controls(iC) Is CheckBox Then
                                                            objCheckbox = CType(objPanel.Controls(iC), CheckBox)
                                                            If Not objCheckbox Is Nothing Then
                                                                If objCheckbox.Name.ToUpper = sKey.ToUpper Then
                                                                    objCheckbox.Checked = sValue.ToUpper = "1" Or sValue.ToUpper = "Y"
                                                                    Exit For

                                                                End If
                                                            End If
                                                        ElseIf TypeOf objPanel.Controls(iC) Is DateTimePicker Then
                                                            objDate = CType(objPanel.Controls(iC), DateTimePicker)
                                                            If Not objDate Is Nothing Then
                                                                If objDate.Name.ToUpper = sKey.ToUpper Then
                                                                    If Not String.IsNullOrEmpty(sValue) Then
                                                                        If IsDate(sValue) Then
                                                                            objDate.Checked = True
                                                                            objDate.Value = Convert.ToDateTime(sValue)
                                                                        End If
                                                                    Else
                                                                        objDate.Checked = False
                                                                    End If
                                                                    Exit For
                                                                End If
                                                            End If
                                                        ElseIf TypeOf objPanel.Controls(iC) Is RichTextBox Then
                                                            objRichTextbox = CType(objPanel.Controls(iC), RichTextBox)
                                                            If Not objRichTextbox Is Nothing Then
                                                                If objRichTextbox.Name.ToUpper = sKey.ToUpper Then
                                                                    objRichTextbox.Text = (sValue)
                                                                    Exit For
                                                                End If
                                                            End If
                                                        ElseIf TypeOf objPanel.Controls(iC) Is TextBox Then
                                                            objTextbox = CType(objPanel.Controls(iC), TextBox)
                                                            If Not objTextbox Is Nothing Then
                                                                If objTextbox.Name.ToUpper = sKey.ToUpper Then
                                                                    objTextbox.Text = sValue
                                                                    Exit For
                                                                End If
                                                            End If
                                                        End If

                                                    Next
                                                End If
                                            End If
                                        Next
                                    Next
                                Next
                                Mode_Button(True)
                            End If
                        End If

                        Try

                            Dim sSQLStatus As String = String.Empty
                            Dim obj_DatatableStatus As DataTable = Nothing
                            Dim sDefectNo As String = String.Empty
                            Dim sStatus As String = String.Empty
                            Dim sCRUserID As String = String.Empty
                            Dim sCRUserName As String = String.Empty
                            Dim sCRUserFullName As String = String.Empty
                            Dim sCRDate As String = String.Empty
                            Dim sOwnerUserID As String = String.Empty
                            Dim sOwnerUserName As String = String.Empty
                            Dim sOwnerFullName As String = String.Empty
                            Dim imgConNumber As PictureBox = Nothing
                            Dim lblStatus As Label = Nothing
                            Dim lblCreateBy As Label = Nothing
                            Dim colorBaackgroup As Color = Nothing
                            Dim colorforegroup As Color = Nothing

                            sSQLStatus = " SELECT A.DEFECT_NO, A.DEFECT_STATUS AS STATUS,"
                            sSQLStatus &= vbCrLf & "   A.N_CR_BY       AS CR_USERID,"
                            sSQLStatus &= vbCrLf & "   B.C_USERNAME    AS CR_USERNAME,"
                            sSQLStatus &= vbCrLf & "   B.C_FULLNAME    AS CR_FULLNAME,"
                            sSQLStatus &= vbCrLf & "   A.D_CR_DATE     AS CR_DATE,"
                            sSQLStatus &= vbCrLf & "   C.N_USERID      AS ALERT_USERID,"
                            sSQLStatus &= vbCrLf & "   A.OWNER         AS ALERT_USERNAME,"
                            sSQLStatus &= vbCrLf & "   C.C_FULLNAME    AS ALERT_FULLNAME"
                            sSQLStatus &= vbCrLf & "   FROM DWH_JOB_TRACK A, DWH_CONFIG_USER B, DWH_CONFIG_USER C"
                            sSQLStatus &= vbCrLf & "   WHERE(A.DEFECT_NO_PARENT = {0})"
                            sSQLStatus &= vbCrLf & "   AND A.N_CR_BY = B.N_USERID"
                            sSQLStatus &= vbCrLf & "   AND A.OWNER = C.C_USERNAME(+)"
                            sSQLStatus &= vbCrLf & "   ORDER BY A.DEFECT_NO DESC"




                            sSQLStatus = String.Format(sSQLStatus, sSearchID)
                            If Not String.IsNullOrEmpty(sSQLStatus) Then
                                obj_DatatableStatus = Code_Application.ReturnValueToDatatable(sSQLStatus, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                If Not obj_DatatableStatus Is Nothing Then
                                    If obj_DatatableStatus.Rows.Count > 0 Then
                                        Pn_Status.Controls.Clear()
                                        For istatus As Integer = 0 To obj_DatatableStatus.Rows.Count - 1

                                            sDefectNo = String.Empty
                                            sStatus = String.Empty
                                            sCRUserID = String.Empty
                                            sCRUserName = String.Empty
                                            sCRUserFullName = String.Empty
                                            sCRDate = String.Empty
                                            sOwnerUserID = String.Empty
                                            sOwnerUserName = String.Empty
                                            sOwnerFullName = String.Empty


                                            If Not obj_DatatableStatus.Rows(istatus)("DEFECT_NO") Is DBNull.Value Then sDefectNo = obj_DatatableStatus.Rows(istatus)("DEFECT_NO")
                                            If Not obj_DatatableStatus.Rows(istatus)("STATUS") Is DBNull.Value Then sStatus = obj_DatatableStatus.Rows(istatus)("STATUS")
                                            If Not obj_DatatableStatus.Rows(istatus)("CR_USERID") Is DBNull.Value Then sCRUserID = obj_DatatableStatus.Rows(istatus)("CR_USERID")
                                            If Not obj_DatatableStatus.Rows(istatus)("CR_USERNAME") Is DBNull.Value Then sCRUserName = obj_DatatableStatus.Rows(istatus)("CR_USERNAME")
                                            If Not obj_DatatableStatus.Rows(istatus)("CR_FULLNAME") Is DBNull.Value Then sCRUserFullName = obj_DatatableStatus.Rows(istatus)("CR_FULLNAME")
                                            If Not obj_DatatableStatus.Rows(istatus)("CR_DATE") Is DBNull.Value Then sCRDate = obj_DatatableStatus.Rows(istatus)("CR_DATE")
                                            If Not obj_DatatableStatus.Rows(istatus)("ALERT_USERID") Is DBNull.Value Then sOwnerUserID = obj_DatatableStatus.Rows(istatus)("ALERT_USERID")
                                            If Not obj_DatatableStatus.Rows(istatus)("ALERT_USERNAME") Is DBNull.Value Then sOwnerUserName = obj_DatatableStatus.Rows(istatus)("ALERT_USERNAME")
                                            If Not obj_DatatableStatus.Rows(istatus)("ALERT_FULLNAME") Is DBNull.Value Then sOwnerFullName = obj_DatatableStatus.Rows(istatus)("ALERT_FULLNAME")


                                            'colorBaackgroup = Cls_Random.Color_Random_Back
                                            'colorforegroup = Cls_Random.Color_Random_Fore
                                            Dim aBitmap() As System.Drawing.Bitmap = Code_Application.ImgNumberPicture(istatus + 1)
                                            For il As Integer = 0 To aBitmap.Length - 1
                                                If Not aBitmap(il) Is Nothing Then
                                                    imgConNumber = New PictureBox
                                                    imgConNumber.Image = aBitmap(il)
                                                    imgConNumber.SizeMode = PictureBoxSizeMode.StretchImage
                                                    imgConNumber.Dock = DockStyle.Right
                                                    imgConNumber.Size = New Size(24, 24)
                                                    If Not String.IsNullOrEmpty(sOwnerFullName) Then ToolTip1.SetToolTip(imgConNumber, sOwnerFullName)
                                                    If Not imgConNumber Is Nothing Then Pn_Status.Controls.Add(imgConNumber)
                                                End If
                                            Next


                                            lblStatus = New Label
                                            lblStatus.Text = sStatus & vbCrLf & sCRDate
                                            lblStatus.Dock = DockStyle.Right
                                            lblStatus.AutoSize = True
                                            lblStatus.BackColor = colorBaackgroup
                                            lblStatus.ForeColor = colorforegroup
                                            lblStatus.TextAlign = ContentAlignment.MiddleCenter
                                            If Not lblStatus Is Nothing Then Pn_Status.Controls.Add(lblStatus)
                                            If Not String.IsNullOrEmpty(sOwnerFullName) And Not String.IsNullOrEmpty(sCRUserFullName) Then
                                                If Not String.Equals(sOwnerFullName.ToUpper, sCRUserFullName.ToUpper) Then
                                                    lblCreateBy = New Label
                                                    lblCreateBy.Text = sOwnerFullName & " << " & sCRUserFullName
                                                    lblCreateBy.Dock = DockStyle.Right
                                                    lblCreateBy.TextAlign = ContentAlignment.MiddleCenter
                                                    lblCreateBy.BackColor = colorBaackgroup
                                                    lblCreateBy.ForeColor = colorforegroup
                                                    lblCreateBy.AutoSize = True
                                                    If Not lblCreateBy Is Nothing Then Pn_Status.Controls.Add(lblCreateBy)
                                                End If
                                            End If
                                        Next
                                    Else
                                        Pn_Status.Controls.Clear()
                                    End If
                                End If
                            End If

                        Catch ex As Exception
                            LBL_STATUS.Text = ex.Message
                        End Try


                        Try

                            Dim PictureBox As PictureBox = Nothing
                            Dim sSQLPicture As String = String.Empty
                            Dim obj_DatatablePicture As DataTable = Nothing
                            Dim sDefectNo As String = String.Empty
                            Dim sSeq_No As String = String.Empty
                            Dim blobImage As Byte() = Nothing
                            Dim fs As IO.FileStream = Nothing
                            Dim objPicture As Panel = Nothing
                            Dim sFormatFile As String = "{0}_{1}"
                            sSQLPicture = String.Format("SELECT DEFECT_NO,SEQ_NO,IMAGE FROM dwh_job_track_image WHERE DEFECT_NO={0} ORDER BY SEQ_NO DESC", sSearchID)
                            If Not String.IsNullOrEmpty(sSQLPicture) Then
                                obj_DatatablePicture = Code_Application.ReturnValueToDatatable(sSQLPicture, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                If Not obj_DatatablePicture Is Nothing Then
                                    If obj_DatatablePicture.Rows.Count > 0 Then
                                        Pn_Picture.Controls.Clear()
                                        For iPicture As Integer = 0 To obj_DatatablePicture.Rows.Count - 1
                                            sDefectNo = obj_DatatablePicture.Rows(iPicture)("DEFECT_NO")
                                            sSeq_No = obj_DatatablePicture.Rows(iPicture)("SEQ_NO")
                                            Try
                                                blobImage = CType(obj_DatatablePicture.Rows(iPicture)("IMAGE"), Byte())
                                                If Not blobImage Is Nothing Then
                                                    fs = New IO.FileStream(Guid.NewGuid.ToString, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                                                    fs.Write(blobImage, 0, blobImage.Length)
                                                End If
                                            Catch exx As Exception
                                                Dim ee As String = exx.Message
                                                Me.LBL_STATUS.Text = ee
                                            Finally
                                                blobImage = Nothing
                                            End Try
                                            If Not fs Is Nothing Then
                                                Dim img = Image.FromStream(fs)
                                                objPicture = PanelPictureBox(sSearchID, sSeq_No, img)
                                                Pn_Picture.Controls.Add(objPicture)
                                                fs = Nothing
                                            End If
                                        Next
                                    Else
                                        Pn_Picture.Controls.Clear()
                                        objPicture = PanelPictureBox(sSearchID, String.Empty, Nothing)
                                        Pn_Picture.Controls.Add(objPicture)
                                    End If
                                End If
                            End If

                        Catch ex As Exception
                            LBL_STATUS.Text = ex.Message
                        End Try

                        sFieldFK = Code_Application.ReturnValueSql(String.Format(sSQLFK, inTableName, sKeySearch), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                        sSQLSearchChild = String.Format(sQuerySearchChild, sSearchID)
                        If Not String.IsNullOrEmpty(sSQLSearchChild) Then
                            obj_DatatableChild = Code_Application.ReturnValueToDatatable(sSQLSearchChild, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                            If Not obj_DatatableChild Is Nothing Then
                                For iTab As Integer = 0 To obj_DatatableChild.Rows.Count - 1
                                    oTabPage = New TabPage
                                    oTabPage.Text = "Defect " & obj_DatatableChild.Rows(iTab)(sKeySearch)
                                    oTabPage.Tag = String.Format(sFormatFKKeyValue, sFieldFK, sSearchID)
                                    Pn_ControlChild = New Panel
                                    Pn_ControlChild.AutoScroll = True
                                    Pn_ControlChild.Name = Pn_Control.Name
                                    Pn_ControlChild.Tag = Pn_Control.Tag
                                    Pn_ControlChild.Dock = DockStyle.Fill

                                    obj_Datatable_Config = Code_Application.ReturnValueToDatatable(String.Format(sSQLConfig, inTableName), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                    If Not obj_Datatable_Config Is Nothing Then
                                        If obj_Datatable_Config.Rows.Count > 0 Then

                                            For i As Integer = 0 To obj_Datatable_Config.Rows.Count - 1
                                                COLNO = 0
                                                CNAME = String.Empty
                                                COLTYPE = String.Empty
                                                WIDTH = 0
                                                NULLS = String.Empty
                                                sControl_Identify = String.Empty
                                                iControl_Length = 0
                                                isControl_Key = False
                                                sComboboxTag = String.Empty
                                                If Not obj_Datatable_Config.Rows(i)("COLNO") Is DBNull.Value Then COLNO = obj_Datatable_Config.Rows(i)("COLNO")
                                                If Not obj_Datatable_Config.Rows(i)("CNAME") Is DBNull.Value Then CNAME = obj_Datatable_Config.Rows(i)("CNAME")
                                                If Not obj_Datatable_Config.Rows(i)("COMMENTS") Is DBNull.Value Then LBLNAME = obj_Datatable_Config.Rows(i)("COMMENTS")
                                                If Not obj_Datatable_Config.Rows(i)("COLTYPE") Is DBNull.Value Then COLTYPE = obj_Datatable_Config.Rows(i)("COLTYPE")
                                                If Not obj_Datatable_Config.Rows(i)("WIDTH") Is DBNull.Value Then WIDTH = obj_Datatable_Config.Rows(i)("WIDTH")
                                                If Not obj_Datatable_Config.Rows(i)("NULLS") Is DBNull.Value Then NULLS = obj_Datatable_Config.Rows(i)("NULLS")

                                                If COLTYPE = "NUMBER" And WIDTH > 1 And NULLS = "NULL" Then
                                                    sControl_Identify = "COMBOBOX"
                                                    iControl_Length = WIDTH
                                                ElseIf COLTYPE = "VARCHAR2" And WIDTH = 8 Then
                                                    sControl_Identify = "COMBOBOX"
                                                    iControl_Length = WIDTH
                                                ElseIf COLTYPE = "CHAR" And WIDTH = 1 Then
                                                    sControl_Identify = "CHECKBOX"
                                                    iControl_Length = WIDTH
                                                ElseIf COLTYPE = "VARCHAR2" And WIDTH = 1 Then
                                                    sControl_Identify = "CHECKBOX"
                                                    iControl_Length = WIDTH
                                                ElseIf COLTYPE = "VARCHAR2" And WIDTH > 1 Then
                                                    sControl_Identify = "TEXTBOX"
                                                    iControl_Length = WIDTH
                                                    If NULLS = "NOT NULL" Then isControl_Key = True
                                                    If WIDTH > 200 Then
                                                        sControl_Identify = "RICHTEXT"
                                                        iControl_Multiline = True
                                                    End If
                                                ElseIf COLTYPE = "DATE" Then
                                                    sControl_Identify = "DATE"
                                                    iControl_Length = WIDTH
                                                Else
                                                    sControl_Identify = "TEXTBOX"
                                                    iControl_Length = WIDTH
                                                    If NULLS = "NOT NULL" Then isControl_Key = True
                                                    If WIDTH > 200 Then
                                                        sControl_Identify = "RICHTEXT"
                                                        iControl_Multiline = True
                                                    End If
                                                End If
                                                If sControl_Identify = "COMBOBOX" Then
                                                    objPanel = New Panel
                                                    objPanel.Size = New Size(200, 25)

                                                    objLabelRight = New Label
                                                    objLabelRight.Size = New Size(10, 25)
                                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabelRight.Dock = DockStyle.Right
                                                    objLabelRight.Text = " "
                                                    objLabelRight.AutoSize = False

                                                    objLabel = New Label
                                                    objLabel.Size = New Size(125, 25)
                                                    objLabel.Tag = "LBL_" & CNAME
                                                    objLabel.Text = LBLNAME
                                                    objLabel.AutoSize = False
                                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabel.Dock = DockStyle.Left
                                                    objCombobox = New ComboBox
                                                    objCombobox.Name = CNAME
                                                    objCombobox.Dock = DockStyle.Fill
                                                    sSQLCombo = String.Format(sSQLFormatCombobox, inTableName, CNAME)
                                                    obj_DataTable_Combobox = Code_Application.ReturnValueToDatatable(sSQLCombo, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                                    If Not obj_DataTable_Combobox Is Nothing Then
                                                        For iCombo As Integer = 0 To obj_DataTable_Combobox.Rows.Count - 1
                                                            If Not obj_DataTable_Combobox.Rows(iCombo)(0) Is DBNull.Value Then
                                                                If Not String.IsNullOrEmpty(sComboboxTag) Then sComboboxTag &= ","
                                                                sComboboxTag &= obj_DataTable_Combobox.Rows(iCombo)(0)
                                                                objCombobox.Items.Add(obj_DataTable_Combobox.Rows(iCombo)(0))
                                                            End If
                                                        Next
                                                    End If
                                                    If Not obj_DataTable_Combobox Is Nothing Then obj_DataTable_Combobox = Nothing
                                                    If objCombobox.Items.Count > 0 Then objCombobox.SelectedIndex = 0
                                                    If Not obj_DatatableChild.Rows(iTab)(CNAME) Is DBNull.Value Then
                                                        objCombobox.Text = obj_DatatableChild.Rows(iTab)(CNAME)
                                                    End If
                                                    objCombobox.Tag = sComboboxTag
                                                    objCombobox.MaxLength = iControl_Length

                                                    If COLTYPE = "NUMBER" Then AddHandler objCombobox.KeyPress, AddressOf Cmb_Number_KeyPress
                                                    objPanel.Controls.Add(objCombobox)
                                                    objPanel.Controls.Add(objLabelRight)
                                                    objPanel.Controls.Add(objLabel)
                                                    objPanel.Dock = DockStyle.Top
                                                    Pn_ControlChild.Controls.Add(objPanel)
                                                ElseIf sControl_Identify = "CHECKBOX" Then
                                                    objPanel = New Panel
                                                    objPanel.Size = New Size(200, 25)

                                                    objLabelRight = New Label
                                                    objLabelRight.Size = New Size(10, 25)
                                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabelRight.Dock = DockStyle.Right
                                                    objLabelRight.Text = " "
                                                    objLabelRight.AutoSize = False

                                                    objLabel = New Label
                                                    objLabel.Size = New Size(125, 25)
                                                    objLabel.Tag = "LBL_" & CNAME
                                                    objLabel.Text = LBLNAME
                                                    objLabel.AutoSize = False
                                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabel.Dock = DockStyle.Left

                                                    objCheckbox = New CheckBox
                                                    objCheckbox.Name = CNAME
                                                    objCheckbox.Dock = DockStyle.Fill
                                                    If Not obj_DatatableChild.Rows(iTab)(CNAME) Is DBNull.Value Then
                                                        objCheckbox.Checked = (obj_DatatableChild.Rows(iTab)(CNAME) = "Y") Or (obj_DatatableChild.Rows(iTab)(CNAME) = "1")
                                                    End If


                                                    objPanel.Controls.Add(objCheckbox)
                                                    objPanel.Controls.Add(objLabelRight)
                                                    objPanel.Controls.Add(objLabel)
                                                    objPanel.Dock = DockStyle.Top

                                                    Pn_ControlChild.Controls.Add(objPanel)
                                                ElseIf sControl_Identify = "DATE" Then
                                                    objPanel = New Panel
                                                    objPanel.Size = New Size(200, 25)

                                                    objLabelRight = New Label
                                                    objLabelRight.Size = New Size(10, 25)
                                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabelRight.Dock = DockStyle.Right
                                                    objLabelRight.Text = " "
                                                    objLabelRight.AutoSize = False

                                                    objLabel = New Label
                                                    objLabel.Size = New Size(125, 25)
                                                    objLabel.Tag = "LBL_" & CNAME
                                                    objLabel.Text = LBLNAME
                                                    objLabel.AutoSize = False
                                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabel.Dock = DockStyle.Left

                                                    objDate = New DateTimePicker
                                                    objDate.Name = CNAME
                                                    objDate.Format = DateTimePickerFormat.Short
                                                    objDate.ShowCheckBox = True
                                                    objDate.Checked = True
                                                    If Not obj_DatatableChild.Rows(iTab)(CNAME) Is DBNull.Value Then
                                                        If IsDate(obj_DatatableChild.Rows(iTab)(CNAME)) Then
                                                            objDate.Value = Convert.ToDateTime(obj_DatatableChild.Rows(iTab)(CNAME))
                                                        End If
                                                    End If

                                                    objDate.Dock = DockStyle.Fill
                                                    objPanel.Controls.Add(objDate)
                                                    objPanel.Controls.Add(objLabelRight)
                                                    objPanel.Controls.Add(objLabel)
                                                    objPanel.Dock = DockStyle.Top

                                                    Pn_ControlChild.Controls.Add(objPanel)
                                                ElseIf sControl_Identify = "TEXTBOX" Then
                                                    objPanel = New Panel
                                                    objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                                                    objLabelRight = New Label
                                                    objLabelRight.Size = New Size(10, 25)
                                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabelRight.Dock = DockStyle.Right
                                                    objLabelRight.Text = " "
                                                    objLabelRight.AutoSize = False

                                                    objLabel = New Label
                                                    objLabel.Size = New Size(125, 25)
                                                    objLabel.Tag = "LBL_" & CNAME
                                                    objLabel.Text = LBLNAME
                                                    objLabel.AutoSize = False
                                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabel.Dock = DockStyle.Left

                                                    objTextbox = New TextBox
                                                    objTextbox.Name = CNAME
                                                    If CNAME.ToUpper.IndexOf("PASSWORD") > 0 Or CNAME.ToUpper.IndexOf("PWD") > 0 Then objTextbox.PasswordChar = "*"
                                                    If objTextbox.Name.ToUpper.IndexOf("CR_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("CREATE_BY") > 0 Then objTextbox.Enabled = False
                                                    If objTextbox.Name.ToUpper.IndexOf("UPD_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("UPDATE_BY") > 0 Then objTextbox.Enabled = False
                                                    objTextbox.Dock = DockStyle.Fill
                                                    objTextbox.BackColor = Color.White
                                                    objTextbox.TextAlign = HorizontalAlignment.Left
                                                    objTextbox.MaxLength = iControl_Length
                                                    If isControl_Key Then
                                                        If COLTYPE = "NUMBER" Then
                                                            objTextbox.ReadOnly = True
                                                        Else
                                                            objTextbox.ReadOnly = False
                                                        End If
                                                        objTextbox.BackColor = Color.Khaki
                                                        objTextbox.TextAlign = HorizontalAlignment.Right
                                                    End If
                                                    If Not obj_DatatableChild.Rows(iTab)(CNAME) Is DBNull.Value Then objTextbox.Text = obj_DatatableChild.Rows(iTab)(CNAME)

                                                    If COLTYPE = "NUMBER" Then AddHandler objTextbox.KeyPress, AddressOf Txt_Number_KeyPress
                                                    objPanel.Controls.Add(objTextbox)
                                                    objPanel.Controls.Add(objLabelRight)
                                                    objPanel.Controls.Add(objLabel)
                                                    objPanel.Dock = DockStyle.Top

                                                    Pn_ControlChild.Controls.Add(objPanel)

                                                ElseIf sControl_Identify = "RICHTEXT" Then
                                                    objPanel = New Panel
                                                    objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                                                    objLabelRight = New Label
                                                    objLabelRight.Size = New Size(10, 25)
                                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabelRight.Dock = DockStyle.Right
                                                    objLabelRight.Text = " "
                                                    objLabelRight.AutoSize = False

                                                    objLabel = New Label
                                                    objLabel.Size = New Size(125, 25)
                                                    objLabel.Tag = "LBL_" & CNAME
                                                    objLabel.Text = LBLNAME
                                                    objLabel.AutoSize = False
                                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                                    objLabel.Dock = DockStyle.Left

                                                    objRichTextbox = New RichTextBox
                                                    objRichTextbox.Name = CNAME
                                                    objRichTextbox.Dock = DockStyle.Fill
                                                    objRichTextbox.BackColor = Color.Khaki
                                                    objRichTextbox.MaxLength = iControl_Length
                                                    If Not obj_DatatableChild.Rows(iTab)(CNAME) Is DBNull.Value Then objRichTextbox.Text = obj_DatatableChild.Rows(iTab)(CNAME)
                                                    objPanel.Controls.Add(objRichTextbox)
                                                    objPanel.Controls.Add(objLabelRight)
                                                    objPanel.Controls.Add(objLabel)
                                                    objPanel.Dock = DockStyle.Top

                                                    Pn_ControlChild.Controls.Add(objPanel)
                                                End If

                                                If Not objPanel Is Nothing Then objPanel = Nothing
                                                If Not objLabel Is Nothing Then objLabel = Nothing
                                                If Not objCombobox Is Nothing Then objCombobox = Nothing
                                                If Not objCheckbox Is Nothing Then objCheckbox = Nothing
                                                If Not objDate Is Nothing Then objDate = Nothing
                                                If Not objTextbox Is Nothing Then objTextbox = Nothing
                                                If Not objRichTextbox Is Nothing Then objRichTextbox = Nothing
                                            Next
                                        End If
                                    End If
                                    If Not Pn_ControlChild Is Nothing Then oTabPage.Controls.Add(Pn_ControlChild)
                                    If Not oTabPage Is Nothing Then TabControl.TabPages.Add(oTabPage)
                                Next
                            End If
                        End If
                        BTN_ADD.Visible = True
                    End If
                End If
            Else
                MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LBL_STATUS.Text = ex.Message
        Finally
            obj_Datatable = Nothing
            obj_DatatableChild = Nothing
            objPanel = Nothing
            objCombobox = Nothing
            objCheckbox = Nothing
            objDate = Nothing
            objTextbox = Nothing
            spItem = Nothing
            oTabPage = Nothing
            Pn_ControlChild = Nothing
        End Try
    End Sub
    Private Sub BTN_SEARCH_Click(sender As System.Object, e As System.EventArgs) Handles BTN_SEARCH.Click
        LoadDefectNo(True)
    End Sub
    Private Function ConvertToRTF(inString As String) As String
        Dim inRTF As DataObject = Nothing
        Try
            inRTF = New DataObject
            If Not inRTF Is Nothing Then inRTF.SetData(DataFormats.Rtf, inString)
        Catch ex As Exception
            inRTF = Nothing
        End Try
        Return inRTF.GetData(DataFormats.Rtf)
    End Function
    Private Sub Mode_Button(inMode As Boolean)
        BTN_NEW.Enabled = inMode
        'BTN_COPY.Enabled = inMode
        BTN_EDIT.Enabled = inMode
        BTN_SAVE.Enabled = Not inMode
        BTN_CANCEL.Enabled = Not inMode
        BTN_SEARCH.Enabled = inMode
    End Sub
    Private Sub BTN_REFRESH_Click(sender As System.Object, e As System.EventArgs)
        If Pn_Control.Controls.Count > 0 Then

            Mode_Button(True)
        Else
            MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Cmb_Number_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Txt_Number_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BTN_COPY_Click(sender As System.Object, e As System.EventArgs)
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objPanel As Panel = Nothing
        Dim sITem As String = String.Empty
        Dim spITem() As String = Nothing
        Dim isSearch As Boolean = False
        If Pn_Control.Controls.Count > 0 Then
            For iControlx As Integer = 0 To Pn_Control.Controls.Count - 1
                If TypeOf Pn_Control.Controls(iControlx) Is Panel Then
                    objPanel = CType(Pn_Control.Controls(iControlx), Panel)
                    If Not objPanel Is Nothing Then
                        For iC As Integer = 0 To objPanel.Controls.Count - 1
                            If TypeOf objPanel.Controls(iC) Is TextBox Then
                                objTextbox = CType(objPanel.Controls(iC), TextBox)
                                If Not objTextbox Is Nothing Then
                                    If objTextbox.ReadOnly And Not String.IsNullOrEmpty(objTextbox.Text) Then
                                        isSearch = True
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            If isSearch Then
                For iControl As Integer = 0 To Pn_Control.Controls.Count - 1
                    If TypeOf Pn_Control.Controls(iControl) Is Panel Then
                        objPanel = CType(Pn_Control.Controls(iControl), Panel)
                        If Not objPanel Is Nothing Then
                            For iC As Integer = 0 To objPanel.Controls.Count - 1
                                If TypeOf objPanel.Controls(iC) Is TextBox Then
                                    objTextbox = CType(objPanel.Controls(iC), TextBox)
                                    If Not objTextbox Is Nothing Then
                                        If objTextbox.ReadOnly Then
                                            objTextbox.Text = String.Empty
                                            objTextbox.ReadOnly = False
                                            isModeNewEdit = False
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
                isModeNewEdit = False
                Mode_Button(False)
            Else
                MessageBox.Show("Please Search Data Before Copy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        Else
            MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function inFieldPrimaryKey(inTablename As String) As String
        Dim inSearchFormat As String = String.Empty
        Dim sKeySearch As String = String.Empty
        Dim spSearch() As String = Nothing
        Dim sResult As String = String.Empty
        Try
            inSearchFormat = Pn_Control.Tag
            If Not String.IsNullOrEmpty(inSearchFormat) Then
                spSearch = inSearchFormat.Split(";")
                If Not spSearch Is Nothing Then
                    For ilength As Integer = 0 To spSearch.Length - 1
                        If spSearch(ilength).IndexOf("Key=") > -1 Then
                            sKeySearch = spSearch(ilength).Replace("Key=", "").Trim
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            sKeySearch = String.Empty
            LBL_STATUS.Text = ex.Message
        End Try
        sResult = sKeySearch
        Return sResult
    End Function
    Private Sub BTN_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_ADD.Click
        Dim obj_Datatable_Config As DataTable = Nothing
        Dim COLNO As Integer = 0
        Dim CNAME As String = String.Empty
        Dim LBLNAME As String = String.Empty
        Dim COLTYPE As String = String.Empty
        Dim WIDTH As Integer = 0
        Dim NULLS As String = String.Empty
        Dim sControl_Identify As String = String.Empty
        Dim iControl_Length As Integer = 0
        Dim isControl_Key As Boolean = False
        Dim iControl_Multiline As Boolean = False

        Dim sSQLConfig As String = "select b.*,nvl(a.comments,b.cname) comments from ALL_COL_COMMENTS a,COL b where a.table_name=b.tname and a.column_name=b.cname and upper(b.tname)='{0}' and not b.cname in (select bb.column_name  from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name) order by b.colno Desc"

        Dim sSQLFormatCombobox As String = "select {1} from {0} Where not {1} is null Group by {1} Order by 1"
        Dim obj_DataTable_Combobox As DataTable = Nothing
        Dim sSQLCombo As String = String.Empty
        Dim objPanelValue As Panel = Nothing
        Dim objPanel As Panel = Nothing
        Dim objLabel As Label = Nothing
        Dim objLabelRight As Label = Nothing
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim objRichTextbox As RichTextBox = Nothing
        Dim sComboboxTag As String = String.Empty
        Dim inTableName As String = LBL_CONFIG_NAME.Tag
        Dim sValue As String = String.Empty
        Dim oTabChild As TabPage = Nothing
        Dim Pn_ControlChild As Panel = Nothing
        Dim sFieldPrimarykey As String = String.Empty
        Dim sValuePrimarykey As String = String.Empty




        Dim sSQLPK As String = "SELECT NVL(MAX({1}),0)+1 AS MAX_NO FROM {0} "
        Dim sFieldFK As String = String.Empty
        Dim sMaxPK As String = String.Empty
        Dim sLabelDefectChild As String = String.Empty
        Dim inSearchFormat As String = String.Empty
        Dim spSearch() As String = Nothing
        Dim sKeySearch As String = String.Empty
        Dim sFormatPanel As String = "{0}_{1}"
        Dim sSQLFK As String = "select Max(bb.column_name) as Column_name from all_constraints aa, all_cons_columns bb, all_cons_columns cc where aa.table_name = '{0}'   AND aa.CONSTRAINT_TYPE = 'R'   and aa.owner = bb.owner   and aa.owner = cc.owner   and bb.position = cc.position   and aa.constraint_name = bb.constraint_name   and aa.r_constraint_name = cc.constraint_name and bb.table_name=cc.table_name "
        Dim sFormatFKKeyValue As String = "Key:{0};Value:{1}"
        Dim sValueFKKeyValue As String = String.Empty
        Try

            If Not BTN_NEW.Enabled Then MessageBox.Show("This function not avalible", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
            If Not TabControl Is Nothing Then
                If Pn_Control.Controls.Count > 0 Then
                    sFieldPrimarykey = inFieldPrimaryKey(inTableName)
                    obj_Datatable_Config = Code_Application.ReturnValueToDatatable(String.Format(sSQLConfig, inTableName), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                    If Not obj_Datatable_Config Is Nothing Then
                        If obj_Datatable_Config.Rows.Count > 0 Then
                            Pn_ControlChild = New Panel
                            Pn_ControlChild.AutoScroll = True
                            Pn_ControlChild.Tag = Pn_Control.Tag
                            Pn_ControlChild.Name = Pn_Control.Name
                            Pn_ControlChild.Dock = DockStyle.Fill
                            For i As Integer = 0 To obj_Datatable_Config.Rows.Count - 1
                                COLNO = 0
                                CNAME = String.Empty
                                COLTYPE = String.Empty
                                WIDTH = 0
                                NULLS = String.Empty
                                sControl_Identify = String.Empty
                                iControl_Length = 0
                                isControl_Key = False
                                sComboboxTag = String.Empty
                                If Not obj_Datatable_Config.Rows(i)("COLNO") Is DBNull.Value Then COLNO = obj_Datatable_Config.Rows(i)("COLNO")
                                If Not obj_Datatable_Config.Rows(i)("CNAME") Is DBNull.Value Then CNAME = obj_Datatable_Config.Rows(i)("CNAME")
                                If Not obj_Datatable_Config.Rows(i)("COMMENTS") Is DBNull.Value Then LBLNAME = obj_Datatable_Config.Rows(i)("COMMENTS")
                                If Not obj_Datatable_Config.Rows(i)("COLTYPE") Is DBNull.Value Then COLTYPE = obj_Datatable_Config.Rows(i)("COLTYPE")
                                If Not obj_Datatable_Config.Rows(i)("WIDTH") Is DBNull.Value Then WIDTH = obj_Datatable_Config.Rows(i)("WIDTH")
                                If Not obj_Datatable_Config.Rows(i)("NULLS") Is DBNull.Value Then NULLS = obj_Datatable_Config.Rows(i)("NULLS")

                                If COLTYPE = "NUMBER" And WIDTH > 1 And NULLS = "NULL" Then
                                    sControl_Identify = "COMBOBOX"
                                    iControl_Length = WIDTH
                                ElseIf COLTYPE = "VARCHAR2" And WIDTH = 8 Then
                                    sControl_Identify = "COMBOBOX"
                                    iControl_Length = WIDTH
                                ElseIf COLTYPE = "CHAR" And WIDTH = 1 Then
                                    sControl_Identify = "CHECKBOX"
                                    iControl_Length = WIDTH
                                ElseIf COLTYPE = "VARCHAR2" And WIDTH = 1 Then
                                    sControl_Identify = "CHECKBOX"
                                    iControl_Length = WIDTH
                                ElseIf COLTYPE = "VARCHAR2" And WIDTH > 1 Then
                                    sControl_Identify = "TEXTBOX"
                                    iControl_Length = WIDTH
                                    If NULLS = "NOT NULL" Then isControl_Key = True
                                    If WIDTH > 200 Then
                                        sControl_Identify = "RICHTEXT"
                                        iControl_Multiline = True
                                    End If
                                ElseIf COLTYPE = "DATE" Then
                                    sControl_Identify = "DATE"
                                    iControl_Length = WIDTH
                                Else
                                    sControl_Identify = "TEXTBOX"
                                    iControl_Length = WIDTH
                                    If NULLS = "NOT NULL" Then isControl_Key = True
                                    If WIDTH > 50 Then iControl_Multiline = True
                                End If
                                If sControl_Identify = "COMBOBOX" Then
                                    objPanel = New Panel
                                    objPanel.Size = New Size(200, 25)

                                    objLabelRight = New Label
                                    objLabelRight.Size = New Size(10, 25)
                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                    objLabelRight.Dock = DockStyle.Right
                                    objLabelRight.Text = " "
                                    objLabelRight.AutoSize = False

                                    objLabel = New Label
                                    objLabel.Size = New Size(125, 25)
                                    objLabel.Tag = "LBL_" & CNAME
                                    objLabel.Text = LBLNAME
                                    objLabel.AutoSize = False
                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                    objLabel.Dock = DockStyle.Left
                                    objCombobox = New ComboBox
                                    objCombobox.Name = CNAME
                                    objCombobox.Dock = DockStyle.Fill
                                    sSQLCombo = String.Format(sSQLFormatCombobox, inTableName, CNAME)
                                    obj_DataTable_Combobox = Code_Application.ReturnValueToDatatable(sSQLCombo, cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                    If Not obj_DataTable_Combobox Is Nothing Then
                                        For iCombo As Integer = 0 To obj_DataTable_Combobox.Rows.Count - 1
                                            If Not obj_DataTable_Combobox.Rows(iCombo)(0) Is DBNull.Value Then
                                                If Not String.IsNullOrEmpty(sComboboxTag) Then sComboboxTag &= ","
                                                sComboboxTag &= obj_DataTable_Combobox.Rows(iCombo)(0)
                                                objCombobox.Items.Add(obj_DataTable_Combobox.Rows(iCombo)(0))
                                            End If
                                        Next
                                    End If
                                    If Not obj_DataTable_Combobox Is Nothing Then obj_DataTable_Combobox = Nothing
                                    If objCombobox.Items.Count > 0 Then objCombobox.SelectedIndex = 0
                                    objCombobox.Tag = sComboboxTag
                                    objCombobox.MaxLength = iControl_Length
                                    If COLTYPE = "NUMBER" Then AddHandler objCombobox.KeyPress, AddressOf Cmb_Number_KeyPress
                                    objPanel.Controls.Add(objCombobox)
                                    objPanel.Controls.Add(objLabelRight)
                                    objPanel.Controls.Add(objLabel)
                                    objPanel.Dock = DockStyle.Top
                                    Pn_ControlChild.Controls.Add(objPanel)
                                ElseIf sControl_Identify = "CHECKBOX" Then
                                    objPanel = New Panel
                                    objPanel.Size = New Size(200, 25)

                                    objLabelRight = New Label
                                    objLabelRight.Size = New Size(10, 25)
                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                    objLabelRight.Dock = DockStyle.Right
                                    objLabelRight.Text = " "
                                    objLabelRight.AutoSize = False

                                    objLabel = New Label
                                    objLabel.Size = New Size(125, 25)
                                    objLabel.Tag = "LBL_" & CNAME
                                    objLabel.Text = LBLNAME
                                    objLabel.AutoSize = False
                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                    objLabel.Dock = DockStyle.Left

                                    objCheckbox = New CheckBox
                                    objCheckbox.Name = CNAME
                                    objCheckbox.Dock = DockStyle.Fill
                                    objPanel.Controls.Add(objCheckbox)
                                    objPanel.Controls.Add(objLabelRight)
                                    objPanel.Controls.Add(objLabel)
                                    objPanel.Dock = DockStyle.Top

                                    Pn_ControlChild.Controls.Add(objPanel)
                                ElseIf sControl_Identify = "DATE" Then
                                    objPanel = New Panel
                                    objPanel.Size = New Size(200, 25)

                                    objLabelRight = New Label
                                    objLabelRight.Size = New Size(10, 25)
                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                    objLabelRight.Dock = DockStyle.Right
                                    objLabelRight.Text = " "
                                    objLabelRight.AutoSize = False

                                    objLabel = New Label
                                    objLabel.Size = New Size(125, 25)
                                    objLabel.Tag = "LBL_" & CNAME
                                    objLabel.Text = LBLNAME
                                    objLabel.AutoSize = False
                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                    objLabel.Dock = DockStyle.Left

                                    objDate = New DateTimePicker
                                    objDate.Name = CNAME
                                    objDate.Format = DateTimePickerFormat.Short
                                    objDate.ShowCheckBox = True
                                    objDate.Checked = True


                                    objDate.Dock = DockStyle.Fill
                                    objPanel.Controls.Add(objDate)
                                    objPanel.Controls.Add(objLabelRight)
                                    objPanel.Controls.Add(objLabel)
                                    objPanel.Dock = DockStyle.Top

                                    Pn_ControlChild.Controls.Add(objPanel)
                                ElseIf sControl_Identify = "TEXTBOX" Then
                                    objPanel = New Panel
                                    objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                                    objLabelRight = New Label
                                    objLabelRight.Size = New Size(10, 25)
                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                    objLabelRight.Dock = DockStyle.Right
                                    objLabelRight.Text = " "
                                    objLabelRight.AutoSize = False

                                    objLabel = New Label
                                    objLabel.Size = New Size(125, 25)
                                    objLabel.Tag = "LBL_" & CNAME
                                    objLabel.Text = LBLNAME
                                    objLabel.AutoSize = False
                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                    objLabel.Dock = DockStyle.Left

                                    objTextbox = New TextBox
                                    objTextbox.Name = CNAME
                                    If CNAME.ToUpper.IndexOf("PASSWORD") > 0 Or CNAME.ToUpper.IndexOf("PWD") > 0 Then objTextbox.PasswordChar = "*"
                                    If objTextbox.Name.ToUpper.IndexOf("CR_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("CREATE_BY") > 0 Then
                                        objTextbox.Enabled = False
                                    End If
                                    If objTextbox.Name.ToUpper.IndexOf("UPD_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("UPDATE_BY") > 0 Then
                                        objTextbox.Enabled = False
                                    End If
                                    objTextbox.Dock = DockStyle.Fill
                                    objTextbox.BackColor = Color.White
                                    objTextbox.TextAlign = HorizontalAlignment.Left
                                    objTextbox.MaxLength = iControl_Length
                                    If isControl_Key Then
                                        If COLTYPE = "NUMBER" Then
                                            objTextbox.ReadOnly = True
                                        Else
                                            objTextbox.ReadOnly = False
                                        End If
                                        objTextbox.BackColor = Color.Khaki
                                        objTextbox.TextAlign = HorizontalAlignment.Right
                                    End If

                                    If COLTYPE = "NUMBER" Then AddHandler objTextbox.KeyPress, AddressOf Txt_Number_KeyPress
                                    objPanel.Controls.Add(objTextbox)
                                    objPanel.Controls.Add(objLabelRight)
                                    objPanel.Controls.Add(objLabel)
                                    objPanel.Dock = DockStyle.Top

                                    Pn_ControlChild.Controls.Add(objPanel)
                                ElseIf sControl_Identify = "RICHTEXT" Then
                                    objPanel = New Panel
                                    objPanel.Size = New Size(125, IIf(WIDTH > 50, Math.Ceiling(WIDTH / 500) * 25, 25))

                                    objLabelRight = New Label
                                    objLabelRight.Size = New Size(10, 25)
                                    objLabelRight.TextAlign = ContentAlignment.MiddleLeft
                                    objLabelRight.Dock = DockStyle.Right
                                    objLabelRight.Text = " "
                                    objLabelRight.AutoSize = False

                                    objLabel = New Label
                                    objLabel.Size = New Size(125, 25)
                                    objLabel.Tag = "LBL_" & CNAME
                                    objLabel.Text = LBLNAME
                                    objLabel.AutoSize = False
                                    objLabel.TextAlign = ContentAlignment.MiddleLeft
                                    objLabel.Dock = DockStyle.Left

                                    objRichTextbox = New RichTextBox
                                    objRichTextbox.Name = CNAME
                                    objRichTextbox.Dock = DockStyle.Fill
                                    objRichTextbox.BackColor = Color.Khaki
                                    objRichTextbox.MaxLength = iControl_Length
                                    objPanel.Controls.Add(objRichTextbox)
                                    objPanel.Controls.Add(objLabelRight)
                                    objPanel.Controls.Add(objLabel)
                                    objPanel.Dock = DockStyle.Top

                                    Pn_ControlChild.Controls.Add(objPanel)
                                End If
                                If Not objPanel Is Nothing Then objPanel = Nothing
                                If Not objLabel Is Nothing Then objLabel = Nothing
                                If Not objCombobox Is Nothing Then objCombobox = Nothing
                                If Not objCheckbox Is Nothing Then objCheckbox = Nothing
                                If Not objDate Is Nothing Then objDate = Nothing
                                If Not objTextbox Is Nothing Then objTextbox = Nothing
                                If Not objRichTextbox Is Nothing Then objRichTextbox = Nothing

                            Next
                        End If
                    End If

                    If Not Pn_ControlChild Is Nothing Then
                        If Pn_ControlChild.Controls.Count > 0 Then
                            'Find Value in from pn control
                            For IO As Integer = 0 To Pn_ControlChild.Controls.Count - 1
                                If TypeOf Pn_ControlChild.Controls(IO) Is Panel Then
                                    objPanelValue = CType(Pn_ControlChild.Controls(IO), Panel)
                                    If Not objPanelValue Is Nothing Then
                                        For ip As Integer = 0 To objPanelValue.Controls.Count - 1
                                            If TypeOf objPanelValue.Controls(ip) Is ComboBox Then
                                                objCombobox = CType(objPanelValue.Controls(ip), ComboBox)
                                                If Not objCombobox Is Nothing Then
                                                    sValue = findValueinMaster(objCombobox.Name)
                                                    If Not String.IsNullOrEmpty(sValue) Then
                                                        objCombobox.Text = sValue
                                                    End If
                                                End If
                                            ElseIf TypeOf objPanelValue.Controls(ip) Is CheckBox Then
                                                objCheckbox = CType(objPanelValue.Controls(ip), CheckBox)
                                                If Not objCheckbox Is Nothing Then
                                                    sValue = findValueinMaster(objCheckbox.Name)
                                                    If Not String.IsNullOrEmpty(sValue) Then
                                                        objCheckbox.Checked = sValue.ToUpper = "1" Or sValue.ToUpper = "Y"
                                                    End If
                                                End If
                                            ElseIf TypeOf objPanelValue.Controls(ip) Is DateTimePicker Then
                                                objDate = CType(objPanelValue.Controls(ip), DateTimePicker)
                                                If Not objDate Is Nothing Then
                                                    sValue = findValueinMaster(objDate.Name)
                                                    If Not String.IsNullOrEmpty(sValue) Then
                                                        If IsDate(sValue) Then
                                                            objDate.MinDate = "01/01/1753"
                                                            objDate.MaxDate = "31/12/9998"
                                                            objDate.Checked = True
                                                            objDate.Value = Convert.ToDateTime(sValue)
                                                        End If
                                                    Else
                                                        objDate.Checked = False
                                                    End If
                                                End If
                                            ElseIf TypeOf objPanelValue.Controls(ip) Is TextBox Then
                                                objTextbox = CType(objPanelValue.Controls(ip), TextBox)
                                                If Not objTextbox Is Nothing Then
                                                    sValue = findValueinMaster(objTextbox.Name)
                                                    If Not String.IsNullOrEmpty(sValue) Then
                                                        objTextbox.Text = sValue
                                                        If objTextbox.Name.ToUpper.IndexOf("CR_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("CREATE_BY") > 0 Then
                                                            objTextbox.Text = ToolStripUserID.Text
                                                        End If
                                                        If objTextbox.Name.ToUpper.IndexOf("UPD_BY") > 0 Or objTextbox.Name.ToUpper.IndexOf("UPDATE_BY") > 0 Then
                                                            objTextbox.Text = ToolStripUserID.Text
                                                        End If
                                                    End If

                                                    If sFieldPrimarykey.ToUpper = objTextbox.Name.ToString.ToUpper Then
                                                        sValuePrimarykey = sValue
                                                        sMaxPK = Code_Application.ReturnValueSql(String.Format(sSQLPK, inTableName, sFieldPrimarykey), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                                        If Not String.IsNullOrEmpty(sMaxPK) Then
                                                            objTextbox.Text = sMaxPK
                                                            sLabelDefectChild = String.Format("Defect {0}", sMaxPK)
                                                        End If
                                                        sFieldFK = Code_Application.ReturnValueSql(String.Format(sSQLFK, inTableName, sKeySearch), cUser_Login, cPassword_Login, cConnecton_string.Replace("$Datasource", cConnecton_Login))
                                                        If Not String.IsNullOrEmpty(sMaxPK) And Not String.IsNullOrEmpty(sFieldFK) And Not String.IsNullOrEmpty(sValuePrimarykey) Then
                                                            sValueFKKeyValue = String.Format(sFormatFKKeyValue, sFieldFK, sValuePrimarykey)
                                                        End If
                                                    End If
                                                End If

                                            End If
                                        Next
                                    End If
                                End If
                            Next
                            'Find Value in from pn control
                            If Not Pn_ControlChild Is Nothing Then Pn_ControlChild.Name = String.Format(sFormatPanel, Pn_Control.Name, sMaxPK)
                            oTabChild = New TabPage
                            oTabChild.Tag = sValueFKKeyValue
                            oTabChild.Text = sLabelDefectChild
                            oTabChild.Controls.Add(Pn_ControlChild)
                            TabControl.TabPages.Add(oTabChild)
                            TabControl.SelectedTab = oTabChild
                            BTN_CANCEL.Tag = oTabChild

                            isModeNewEdit = False
                            Mode_Button(False)
                        End If
                    End If

                Else
                    MessageBox.Show("Please Select Menu Control", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            LBL_STATUS.Text = ex.Message
        End Try
    End Sub

    Private Function findValueinMaster(inTag As String) As String
        Dim objPanel As Panel = Nothing
        Dim objCombobox As ComboBox = Nothing
        Dim objCheckbox As CheckBox = Nothing
        Dim objDate As DateTimePicker = Nothing
        Dim objTextbox As TextBox = Nothing
        Dim sResult As String = String.Empty
        Dim sValue As String = String.Empty
        Dim sFormatDate As String = "{0}/{1}/{2}"
        Try
            If Pn_Control.Controls.Count > 0 Then
                For iPanel As Integer = 0 To Pn_Control.Controls.Count - 1
                    If TypeOf Pn_Control.Controls(iPanel) Is Panel Then
                        objPanel = CType(Pn_Control.Controls(iPanel), Panel)
                        If Not objPanel Is Nothing Then
                            For iC As Integer = 0 To objPanel.Controls.Count - 1
                                If TypeOf objPanel.Controls(iC) Is ComboBox Then
                                    objCombobox = CType(objPanel.Controls(iC), ComboBox)
                                    If Not objCombobox Is Nothing Then
                                        If objCombobox.Name.ToUpper = inTag.ToUpper Then
                                            objCombobox.Enabled = False
                                            sValue = objCombobox.Text
                                            Exit For
                                        End If
                                    End If
                                ElseIf TypeOf objPanel.Controls(iC) Is CheckBox Then
                                    objCheckbox = CType(objPanel.Controls(iC), CheckBox)
                                    If Not objCheckbox Is Nothing Then
                                        If objCheckbox.Name.ToUpper = inTag.ToUpper Then
                                            objCheckbox.Enabled = False
                                            sValue = IIf(objCheckbox.Checked, "Y", "N")
                                            Exit For
                                        End If
                                    End If
                                ElseIf TypeOf objPanel.Controls(iC) Is DateTimePicker Then
                                    objDate = CType(objPanel.Controls(iC), DateTimePicker)
                                    If Not objDate Is Nothing Then
                                        If objDate.Name.ToUpper = inTag.ToUpper Then
                                            objDate.Enabled = False
                                            If objDate.Checked Then
                                                sValue = String.Format(sFormatDate, objDate.Value.Month.ToString("00"), objDate.Value.Day.ToString("00"), objDate.Value.Year.ToString("0000"))
                                            Else
                                                sValue = String.Empty
                                            End If
                                            Exit For
                                        End If
                                    End If
                                ElseIf TypeOf objPanel.Controls(iC) Is TextBox Then
                                    objTextbox = CType(objPanel.Controls(iC), TextBox)
                                    If Not objTextbox Is Nothing Then
                                        If objTextbox.Name.ToUpper = inTag.ToUpper Then
                                            objTextbox.Enabled = False
                                            sValue = objTextbox.Text
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            sValue = String.Empty
            LBL_STATUS.Text = ex.Message
        Finally

        End Try
        sResult = sValue
        Return sResult
    End Function
    Private Sub objPicture_ZoomClick(sender As System.Object, e As System.EventArgs)
        Dim objPicture As PictureBox = Nothing
        Dim ofrm As FRM_ZOOM = Nothing
        objPicture = CType(sender, PictureBox)
        If Not objPicture.Tag Is Nothing Then
            ofrm = New FRM_ZOOM(objPicture.Tag)
            ofrm.ShowDialog()
            ofrm = Nothing
        End If
    End Sub

    Private Sub objPicture_DeleteClick(sender As System.Object, e As System.EventArgs)
        Dim objPicture As PictureBox = Nothing
        Dim sSQLDeleteBlob As String = "DELETE FROM DWH_JOB_TRACK_IMAGE  WHERE DEFECT_NO={0} AND SEQ_NO={1}"
        Dim sSQL As String = String.Empty
        Dim PictureBox As PictureBox = Nothing
        Dim sValueKey As String = String.Empty
        Dim sMaxSeq As String = String.Empty
        Dim iSeq As Integer = 0
        Dim sResult As String = String.Empty
        objPicture = CType(sender, PictureBox)
        If Not objPicture Is Nothing Then
            If MessageBox.Show("Are you delete Picture? ", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(objPicture.Tag) And Not String.IsNullOrEmpty(objPicture.Name) Then
                    If TypeOf sender Is PictureBox Then
                        objPicture = CType(sender, PictureBox)
                    End If
                    If Not objPicture.Tag Is Nothing Then
                        sValueKey = objPicture.Tag
                        sMaxSeq = objPicture.Name
                        sSQL = String.Format(sSQLDeleteBlob, sValueKey, sMaxSeq)
                        sResult = Code_Application.Execute(sSQL, cUser_Login, cPassword_Login, cConnecton_Login)
                        If sResult = "True" Then
                            For Each op In Pn_Picture.Controls
                                If TypeOf op Is Panel Then
                                    If CType(op, Panel).Name = sMaxSeq Then
                                        Pn_Picture.Controls.Remove(op)
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub View_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged, RadioButton2.CheckedChanged, RadioButton1.CheckedChanged
        ClearNode()
        DefaultView()
        AddStatus()
    End Sub
      
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class


