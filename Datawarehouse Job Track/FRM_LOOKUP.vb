Public Class FRM_LOOKUP
    Public outValue() As String
    Dim inFieldName() As String
    Dim objDatatable As DataTable
    Sub New(ByVal inSQL As String, cUser_Login As String, cPassword_Login As String, cConnecton_string As String, ByVal inField() As String, ByVal inWidth() As Integer, ByVal inLbl() As String)
        Dim Value() As ColumnHeader = Nothing
        Dim iValue As ColumnHeader = Nothing
        ' This call is required by the designer.
        InitializeComponent()
        ListView1.Clear()
        ' Add any initialization after the InitializeComponent() call.
        inFieldName = inField
        ReDim Value(inField.Length - 1)
        For i As Integer = 0 To inField.Length - 1
            iValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            If Not inLbl(i) Is Nothing Then
                iValue.Text = inLbl(i).ToString
            Else
                iValue.Text = inField(i).ToString
            End If
            iValue.Name = iValue.Text
            iValue.Tag = inField(i).ToString
            If inWidth(i) > 0 Then
                iValue.Width = inWidth(i)
            End If
            Value(i) = iValue
            cmb_column.Items.Add(iValue.Text)
        Next
        If Not Value Is Nothing Then Me.ListView1.Columns.AddRange(Value)
        Code_Application.fn_LoadData(inSQL, cUser_Login, cPassword_Login, cConnecton_string, inField, ListView1, objDatatable)
        If cmb_column.Items.Count > 0 Then cmb_column.SelectedIndex = 0
        If cmb_condition.Items.Count > 0 Then cmb_condition.SelectedIndex = 0
        Me.Tag = objDatatable
    End Sub
    Public Class ArgumentSend
        Public _dataview As DataView
        Public _listview As ListView
    End Class
    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        Dim iColumn As Integer = 0
        Dim sColumnName As String = String.Empty
        Dim sColumnField As String = String.Empty
        Dim oDatatable As DataTable = Nothing
        Dim oDataview As DataView = Nothing
        Dim sSort As String = String.Empty
        Dim Cursor As Cursor = Nothing
        Dim oAgm As ArgumentSend = Nothing
        Try
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            iColumn = e.Column
            If ListView1.Columns(iColumn).Text.IndexOf("^") <= -1 Then
                ListView1.Columns(iColumn).Text &= "^"
                sSort = " ASC"
            Else
                ListView1.Columns(iColumn).Text = Replace(ListView1.Columns(iColumn).Text, "^", "")
                sSort = " DESC"
            End If
            If iColumn > -1 Then
                sColumnName = ListView1.Columns(iColumn).Text
                sColumnField = ListView1.Columns(iColumn).Tag
                If Not ListView1.Tag Is Nothing Then
                    If TypeOf ListView1.Tag Is DataTable Then
                        oDatatable = ListView1.Tag
                        oDataview = New DataView(oDatatable)
                        oDataview.Sort = sColumnField & sSort
                        oAgm = New ArgumentSend
                        oAgm._dataview = oDataview
                        oAgm._listview = ListView1
                        'bgProcess.RunWorkerAsync(oAgm)
                        Code_Application.fn_ShowData(oDataview, ListView1)
                    End If
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            oDatatable = Nothing
            oDataview = Nothing
            oAgm = Nothing
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListView1.DoubleClick
        Dim lvi As ListViewItem = Nothing
        If ListView1.SelectedItems.Count > 0 Then
            lvi = ListView1.SelectedItems(0)
            ReDim outValue(lvi.SubItems.Count - 1)
            For i As Integer = 0 To lvi.SubItems.Count - 1
                outValue(i) = lvi.SubItems(i).Text
            Next
            If Not outValue Is Nothing Then Me.Close()
        End If
    End Sub

    Private Function GetColumnIndex(ByVal lvw As ListView, ByVal MouseX As Integer) As Integer

        Dim result As Integer = 0

        'Get the right and width pixel values of all the columns 
        Dim ColW As New List(Of Integer)
        Dim Index As Integer = 0


        For Each col As ColumnHeader In lvw.Columns
            ColW.Add(col.Width)
            Dim X As Integer = 0
            For i As Integer = 0 To ColW.Count - 1
                X += ColW(i)
            Next

            'Once you have the rightmost values of the columns 
            'just work out where X falls in between

            If MouseX <= X Then
                result = Index
                Exit For
            End If

            Index += 1

        Next

        Return result
    End Function

    Private Sub ListView1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        Dim lhi As ListViewHitTestInfo = Nothing
        Dim sColumn As String = String.Empty
        Dim iColumn As Integer = 0
        Try
            lhi = ListView1.HitTest(e.X, e.Y)
            If Not lhi Is Nothing Then
                txt_condition.Text = lhi.SubItem.Text
                iColumn = lhi.Item.SubItems.IndexOf(lhi.SubItem)
                If iColumn > -1 Then
                    sColumn = ListView1.Columns(iColumn).Text
                    If Not String.IsNullOrEmpty(sColumn) Then
                        cmb_column.SelectedIndex = cmb_column.Items.IndexOf(Replace(sColumn, "^", ""))
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            lhi = Nothing
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        'Dim lvi As ListViewItem = Nothing
        'If ListView1.SelectedItems.Count > 0 Then
        '    lvi = ListView1.SelectedItems(0)
        '    ReDim outValue(lvi.SubItems.Count - 1)
        '    For i As Integer = 0 To lvi.SubItems.Count - 1
        '        outValue(i) = lvi.SubItems(i).Text
        '    Next
        '    If Not outValue Is Nothing Then

        '    End If
        'End If
    End Sub

    Private Sub FRM_LOOKUP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub



    Private Sub BTN_CANCEL_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CANCEL.Click
        Try
            txt_condition.Clear()
            If cmb_column.Items.Count > 0 Then cmb_column.SelectedIndex = 0
            If cmb_condition.Items.Count > 0 Then cmb_condition.SelectedIndex = 0
            If Not Me.Tag Is Nothing Then
                If TypeOf Me.Tag Is DataTable Then
                    Code_Application.fn_ShowData(New DataView(Me.Tag), ListView1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub BTN_SEARCH_Click(sender As Object, e As System.EventArgs) Handles BTN_SEARCH.Click
        Dim sFormatCondition As String = "({0} {1} '{2}')"
        'Dim sFormatConditionLike As String = "({0} {1} '*{2}*')"
        Dim sFormatConditionLike As String = "(Convert({0}, 'System.String') {1} '%{2}%')"

        Dim sSearch As String = String.Empty
        Dim sField As String = String.Empty
        Dim sCondition As String = String.Empty
        Dim sValue As String = String.Empty
        Dim oDatarow() As DataRow = Nothing
        Dim inValue() As String = Nothing
        Try
            If cmb_column.SelectedIndex > -1 Then
                If inFieldName.Length > cmb_column.SelectedIndex Then sField = inFieldName(cmb_column.SelectedIndex)
            End If
            If cmb_condition.SelectedIndex > -1 Then
                sCondition = cmb_condition.Items(cmb_condition.SelectedIndex).ToString
            End If
            sValue = txt_condition.Text
            If Not String.IsNullOrEmpty(sField) And Not String.IsNullOrEmpty(sCondition) And Not String.IsNullOrEmpty(sValue) Then
                If sCondition.ToUpper.IndexOf("LIKE") > -1 Then
                    sSearch = String.Format(sFormatConditionLike, sField, sCondition, sValue)
                Else
                    sSearch = String.Format(sFormatCondition, sField, sCondition, sValue)
                End If
                If Not String.IsNullOrEmpty(sSearch) Then
                    If Not objDatatable Is Nothing Then
                        oDatarow = objDatatable.Select(sSearch)
                        If Not oDatarow Is Nothing Then
                            If oDatarow.Length > 0 Then
                                ListView1.Items.Clear()
                                For ir As Integer = 0 To oDatarow.Length - 1
                                    ReDim inValue(objDatatable.Columns.Count - 1)
                                    For iColumn As Integer = 0 To objDatatable.Columns.Count - 1
                                        If Not oDatarow(ir)((iColumn)) Is DBNull.Value Then inValue(iColumn) = oDatarow(ir)((iColumn)) Else inValue(iColumn) = String.Empty
                                    Next
                                    Code_Application.PR_Listview_Add(inValue, ListView1, Nothing, 0, Nothing, False)
                                Next
                            Else
                                MessageBox.Show("data not found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("data not found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("data not found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Please specific Seacrh", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Please select condition Seacrh", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub bgProcess_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgProcess.DoWork
        Dim oDataview As DataView = Nothing
        Dim oListview As ListView = Nothing
        Dim oGgmReceive As ArgumentSend = Nothing
        Try
            If Not e.Argument Is Nothing Then
                oGgmReceive = e.Argument
                If Not oGgmReceive Is Nothing Then
                    oDataview = oGgmReceive._dataview
                    oListview = oGgmReceive._listview
                End If
                e.Result = Code_Application.fn_ShowData(oDataview, oListview)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            oDataview = Nothing
            oListview = Nothing
        End Try
    End Sub
     
End Class