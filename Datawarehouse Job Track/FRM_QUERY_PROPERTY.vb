Public Class FRM_QUERY_PROPERTY
    Sub New(inDatatable As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ShowTabControl(inDatatable)
    End Sub
    Private Sub ShowTabControl(objDatatable As DataTable)
        Dim oTabControl As TabControl = Nothing
        Dim oTabPage As TabPage = Nothing
        Dim objPanel As Panel = Nothing
        Dim objLabel As Label = Nothing
        Dim objLabelRight As Label = Nothing
        Dim objLabelValue As Label = Nothing
        Dim iRow As Integer = 0
        Dim sCaption As String = String.Empty
        Dim sValue As String = String.Empty
        Dim iColumnwidth As Integer = 0
        If Not objDatatable Is Nothing Then
            oTabControl = New TabControl
            oTabControl.Dock = DockStyle.Fill
            For Each oRow As DataRow In objDatatable.Rows
                If Not oRow Is Nothing Then
                    iRow += 1
                    oTabPage = New TabPage
                    oTabPage.Text = iRow.ToString
                    For Each oColumn As DataColumn In objDatatable.Columns
                        If Not oColumn Is Nothing Then
                            sValue = oRow(oColumn.ColumnName)
                            iColumnwidth = oColumn.MaxLength
                            sCaption = oColumn.Caption
                            If IsNumeric(sValue) Then
                            ElseIf IsDate(sValue) Then
                            Else

                            End If


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
                            objLabel.Text = sCaption
                            objLabel.AutoSize = False
                            objLabel.TextAlign = ContentAlignment.MiddleLeft
                            objLabel.Dock = DockStyle.Left

                            objLabelValue = New Label
                            objLabelValue.Size = New Size(125, 25)
                            objLabelValue.Text = sValue
                            objLabelValue.AutoSize = False
                            objLabelValue.TextAlign = ContentAlignment.MiddleLeft
                            objLabelValue.Dock = DockStyle.Fill
                           
                            objPanel.Controls.Add(objLabelValue)
                            objPanel.Controls.Add(objLabelRight)
                            objPanel.Controls.Add(objLabel)
                            objPanel.Dock = DockStyle.Top
                            oTabPage.Controls.Add(objPanel)


                        End If
                    Next
                    oTabControl.TabPages.Add(oTabPage)
                End If
            Next
            Me.Controls.Add(oTabControl)
        End If
    End Sub
End Class