Imports System.IO
Imports System.IO.Compression
Imports System.Resources
Imports System.Globalization.CultureInfo
Public Class Code_Application
    Private resourceCulture As Global.System.Globalization.CultureInfo
    Public Shared Function ImgNumberPicture(ByVal intID As Integer) As Drawing.Bitmap()
        Dim obj As Object = Nothing
        Dim objDraw As Drawing.Bitmap = Nothing
        Dim objDrawArray() As Drawing.Bitmap = Nothing
        Dim sValue As String = String.Empty
        Dim cValue As Char
        Try
            If intID <= 9 Then
                ReDim objDrawArray(0)
                obj = (My.Resources.ResourceManager.GetObject(intID))
                If Not obj Is Nothing Then
                    If TypeOf obj Is Bitmap Then
                        objDraw = (CType(obj, System.Drawing.Bitmap))
                        objDrawArray(0) = objDraw
                    End If
                End If
            Else
                ReDim objDrawArray(intID.ToString.Length)
                sValue = intID.ToString
                For i As Integer = 0 To sValue.Length - 1
                    cValue = sValue(i)
                    obj = (My.Resources.ResourceManager.GetObject(cValue))
                    If Not obj Is Nothing Then
                        If TypeOf obj Is Bitmap Then
                            objDraw = (CType(obj, System.Drawing.Bitmap))
                            objDrawArray(i) = objDraw
                        End If
                    End If
                Next
            End If
        Catch
            objDraw = Nothing
        Finally
            obj = Nothing
        End Try
        Return objDrawArray
    End Function
    Public Shared Sub PR_Listview_Add(ByVal _CHA_Lsv() As String, ByVal lsv_Details As ListView, ByVal odatatable As DataTable, ByVal inIconKey As String, ByVal imagelist As ImageList, ByVal isAutoResize As Boolean)
        Dim _LSV_Add As ListViewItem = Nothing
        Try
            _LSV_Add = New ListViewItem(_CHA_Lsv)
            _LSV_Add.Tag = odatatable
            If Not String.IsNullOrEmpty(inIconKey) Then
                _LSV_Add.StateImageIndex = fnKeyIndex(imagelist, inIconKey)
            End If
            lsv_Details.Items.Add(_LSV_Add)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            _LSV_Add = Nothing
        End Try

        For i As Integer = 0 To lsv_Details.Columns.Count - 1
            If lsv_Details.Columns(i).Width > 0 Then
                If isAutoResize Then lsv_Details.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent) Else lsv_Details.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next

    End Sub
    Public Shared Function fn_ShowData(ByVal oDataview As DataView, ByVal inListview As ListView) As Boolean
        Dim inValue() As String = Nothing
        Dim Otable As DataTable = Nothing
        Dim isResult As Boolean = True
        Try
            If Not oDataview Is Nothing Then
                Otable = oDataview.ToTable
                inListview.Tag = Otable
                inListview.Items.Clear()
                For ir As Integer = 0 To Otable.Rows.Count - 1
                    ReDim inValue(Otable.Columns.Count - 1)
                    For iColumn As Integer = 0 To Otable.Columns.Count - 1
                        If Not Otable.Rows(ir)((iColumn)) Is DBNull.Value Then inValue(iColumn) = Otable.Rows(ir)((iColumn)) Else inValue(iColumn) = String.Empty
                    Next
                    PR_Listview_Add(inValue, inListview, Nothing, 0, Nothing, False)
                Next
            End If
        Catch ex As Exception
            Otable = Nothing
            isResult = False
        Finally
            inValue = Nothing
            Otable = Nothing
        End Try
        Return isResult
    End Function
    Public Shared Sub fn_LoadData(ByVal inSQL As String, ByVal inUser As String, ByVal inPassword As String, ByVal inTNS As String, ByVal inField() As String, ByVal inListview As ListView, Optional ByRef oOutDatatable As DataTable = Nothing)
        Dim Otable As DataTable = Nothing
        Dim OService As Public_Service._Public = Nothing
        Dim inValue() As String = Nothing
        Try
            If Not String.IsNullOrEmpty(inSQL) And Not String.IsNullOrEmpty(inUser) And Not String.IsNullOrEmpty(inPassword) And Not String.IsNullOrEmpty(inTNS) Then
                OService = New Public_Service._Public
                If Not OService Is Nothing Then Otable = OService.SelectDataToDatatableTNS(inTNS, inUser, inPassword, inSQL)
                If Not Otable Is Nothing Then
                    oOutDatatable = Otable
                    inListview.Tag = Otable
                    inListview.Items.Clear()
                    For ir As Integer = 0 To Otable.Rows.Count - 1
                        ReDim inValue(inField.Length - 1)
                        For iColumn As Integer = 0 To inField.Length - 1
                            If Not Otable.Rows(ir)(inField(iColumn)) Is DBNull.Value Then inValue(iColumn) = Otable.Rows(ir)(inField(iColumn)) Else inValue(iColumn) = String.Empty
                        Next
                        PR_Listview_Add(inValue, inListview, Nothing, 0, Nothing, False)
                    Next
                End If
            End If
        Catch ex As Exception
            Otable = Nothing
        Finally
            OService = Nothing
        End Try
    End Sub
    Public Shared Function ReturnValueToDatatable(ByVal inSQL As String, ByVal inUser As String, ByVal inPassword As String, ByVal inTNS As String) As DataTable
        Dim Otable As DataTable = Nothing
        Dim OService As Public_Service._Public = Nothing
        Try
            If Not String.IsNullOrEmpty(inSQL) And Not String.IsNullOrEmpty(inUser) And Not String.IsNullOrEmpty(inPassword) And Not String.IsNullOrEmpty(inTNS) Then
                OService = New Public_Service._Public
                If Not OService Is Nothing Then Otable = OService.SelectDataToDatatableTNS(inTNS, inUser, inPassword, inSQL)
            End If
        Catch ex As Exception
            Otable = Nothing
        Finally
            OService = Nothing
        End Try
        Return Otable
    End Function

    'Public Shared Function ExecuteSQLWithBlob(ByVal CnnStr As String, ByVal sSql As String, Param() As Public_Service.ParamOracle) As Boolean
    '    Dim oraConnection As Oracle.DataAccess.Client.OracleConnection = Nothing
    '    Dim oraCleCommand As Oracle.DataAccess.Client.OracleCommand = Nothing
    '    Dim isResult As Boolean = False
    '    Try
    '        oraConnection = New Oracle.DataAccess.Client.OracleConnection(CnnStr)
    '        If Not oraConnection Is Nothing Then oraConnection.Open()
    '        oraCleCommand = New Oracle.DataAccess.Client.OracleCommand(sSql, oraConnection)
    '        For Each Item As ParamOraclex In Param
    '            If Not Item Is Nothing Then
    '                oraCleCommand.Parameters.Add(Item.Key, Item.Type, Item.Value, ParameterDirection.Input)
    '            End If
    '        Next
    '        isResult = (oraCleCommand.ExecuteNonQuery() > -1)
    '    Catch ex As Exception
    '        isResult = False
    '    Finally
    '        If Not oraConnection Is Nothing Then oraConnection.Close()
    '        If Not oraConnection Is Nothing Then oraConnection = Nothing
    '        If Not oraCleCommand Is Nothing Then oraCleCommand = Nothing
    '    End Try
    '    Return isResult
    'End Function
    Public Shared Function ExecuteWithBlob(ByVal inConnect As String, ByVal inSQL As String, ByVal inParamOracle() As Public_Service.ParamOracle) As String
        Dim OService As Public_Service._Public = Nothing
        Dim sResult As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(inSQL) And Not String.IsNullOrEmpty(inConnect) Then
                OService = New Public_Service._Public
                If Not OService Is Nothing Then
                    sResult = OService.ExecuteDataWithFile(inConnect, inSQL, inParamOracle)
                End If
            End If
        Catch ex As Exception
            sResult = String.Empty
        Finally
            OService = Nothing
        End Try
        Return sResult
    End Function
    Public Shared Function Execute(ByVal inSQL As String, ByVal inUser As String, ByVal inPassword As String, ByVal inTNS As String) As String
        Dim OService As Public_Service._Public = Nothing
        Dim sResult As String = String.Empty
        Dim sFormatConnect As String = "{0}/{1}@{2}"
        Try
            If Not String.IsNullOrEmpty(inSQL) And Not String.IsNullOrEmpty(inUser) And Not String.IsNullOrEmpty(inPassword) And Not String.IsNullOrEmpty(inTNS) Then
                OService = New Public_Service._Public
                If Not OService Is Nothing Then sResult = OService.ExecuteData(String.Format(sFormatConnect, inUser, inPassword, inTNS), inSQL)
            End If
        Catch ex As Exception
            sResult = String.Empty
        Finally
            OService = Nothing
        End Try
        Return sResult
    End Function


    Public Shared Function ReturnValueSql(ByVal inSQL As String, ByVal inUser As String, ByVal inPassword As String, ByVal inTNS As String)
        Dim Otable As DataTable = Nothing
        Dim OService As Public_Service._Public = Nothing
        Dim sResult As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(inSQL) And Not String.IsNullOrEmpty(inUser) And Not String.IsNullOrEmpty(inPassword) And Not String.IsNullOrEmpty(inTNS) Then
                OService = New Public_Service._Public
                If Not OService Is Nothing Then Otable = OService.SelectDataToDatatableTNS(inTNS, inUser, inPassword, inSQL)
                If Not Otable Is Nothing Then
                    If Otable.Rows.Count > 0 Then
                        sResult = String.Empty
                        If Not Otable.Rows(0)(0) Is DBNull.Value Then sResult = Otable.Rows(0)(0)
                    End If
                End If
            End If
        Catch ex As Exception
            sResult = String.Empty
        Finally
            Otable = Nothing
            OService = Nothing
        End Try
        Return sResult
    End Function


    Public Shared Function fnKeyIndex(ByVal imagelist As ImageList, ByVal Name As String) As Integer
        Dim iIndex As Integer = 0
        Try
            If Not imagelist Is Nothing Then
                For Each sKey In imagelist.Images.Keys
                    If String.Equals(Name.ToUpper, sKey.ToUpper) Then
                        Exit For
                    Else
                        iIndex += 1
                    End If
                Next
            End If
        Catch
            iIndex = 0
        End Try
        Return iIndex
    End Function
    Public Shared Sub PR_Listview_Delete(ByVal LSV_Details As System.Windows.Forms.ListView)
        Try
            If LSV_Details.Items.Count > 0 Then
                Dim lvi As ListViewItem
                lvi = LSV_Details.SelectedItems(0)
                LSV_Details.Items.Remove(lvi)
                For i As Integer = 0 To LSV_Details.Items.Count - 1
                    LSV_Details.Items(i).SubItems(0).Text = i + 1
                Next
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Shared Sub PR_Listview_Deletes(ByVal LSV_Details As System.Windows.Forms.ListView)
        Try
            If LSV_Details.Items.Count > 0 Then
                Dim lvi As ListViewItem
                lvi = LSV_Details.SelectedItems(0)
                LSV_Details.Items.Remove(lvi)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Public Shared Function GetComputerName() As String
        Dim sResult As String = String.Empty
        Try
            sResult = System.Net.Dns.GetHostName

        Catch ex As Exception
            sResult = String.Empty
        End Try
        Return IIf(String.IsNullOrEmpty(sResult), String.Empty, sResult)
    End Function
    Public Shared Function GetLoginame() As String
        Dim spUsername() As String
        Dim sUsername As String = String.Empty
        Dim sResult As String = String.Empty
        Try
            sUsername = My.User.Name
            If Not String.IsNullOrEmpty(sUsername) Then
                If sUsername.IndexOf("\") Then
                    spUsername = sUsername.Split("\")
                    If spUsername.Length > 1 Then
                        sResult = spUsername(1).ToString
                    Else
                        sResult = sUsername
                    End If
                Else
                    sResult = sUsername
                End If
            End If
        Catch ex As Exception
            sResult = String.Empty
        End Try
        Return IIf(String.IsNullOrEmpty(sResult), String.Empty, sResult)
    End Function
    Public Shared Function getIPAddress() As String
        Dim sHost As String = String.Empty
        Dim sResult As String = String.Empty
        Dim ipHost As System.Net.IPHostEntry = Nothing
        Try
            sHost = System.Net.Dns.GetHostName
            If Not String.IsNullOrEmpty(sHost) Then
                ipHost = System.Net.Dns.GetHostByName(sHost)
                If Not ipHost Is Nothing Then
                    sResult = ipHost.AddressList(0).ToString
                End If
            Else
                sResult = String.Empty
            End If

        Catch ex As Exception
            sResult = String.Empty
        End Try
        Return IIf(String.IsNullOrEmpty(sResult), String.Empty, sResult)
    End Function

    Public Shared Function ReadSetting(ByVal key As String) As String
        Dim Result As String = String.Empty
        Try
            Result = System.Configuration.ConfigurationManager.AppSettings.Get(key)
            If IsNothing(Result) Then
                Result = "Not found"
            End If
            Console.WriteLine(Result)
        Catch e As Exception
            Console.WriteLine("Error reading app settings")
            Result = "Not found"
        End Try
        Return Result
    End Function


#Region " Run Process Function "

    ' [ Run Process Function ]
    '
    ' // By Elektro H@cker
    '
    ' Examples :
    '
    ' MsgBox(Run_Process("Process.exe")) 
    ' MsgBox(Run_Process("Process.exe", "Arguments"))
    ' MsgBox(Run_Process("CMD.exe", "/C Dir /B", True))
    ' MsgBox(Run_Process("CMD.exe", "/C @Echo OFF & For /L %X in (0,1,50000) Do (Echo %X)", False, False))
    ' MsgBox(Run_Process("CMD.exe", "/C Dir /B /S %SYSTEMDRIVE%\*", , False, 500))
    ' If Run_Process("CMD.exe", "/C Dir /B", True).Contains("File.txt") Then MsgBox("File found")



    Public Shared Function Run_Process(ByVal Process_Name As String, Optional ByVal Process_Arguments As String = Nothing, Optional ByVal Read_Output As Boolean = False, Optional ByVal Process_Hide As Boolean = False, Optional ByVal Process_TimeOut As Integer = 999999999) As Boolean
        ' Returns True if "Read_Output" argument is False and Process was finished OK
        ' Returns False if ExitCode is not "0"
        ' Returns Nothing if process can't be found or can't be started
        ' Returns "ErrorOutput" or "StandardOutput" (In that priority) if Read_Output argument is set to True.
        Dim isRun As Boolean = True
        Try

            Dim My_Process As New Process()
            Dim My_Process_Info As New ProcessStartInfo()

            My_Process_Info.FileName = Process_Name ' Process filename
            My_Process_Info.Arguments = Process_Arguments ' Process arguments
            My_Process_Info.CreateNoWindow = Process_Hide ' Show or hide the process Window
            My_Process_Info.UseShellExecute = False ' Don't use system shell to execute the process
            My_Process_Info.RedirectStandardOutput = Read_Output '  Redirect (1) Output
            My_Process_Info.RedirectStandardError = Read_Output ' Redirect non (1) Output
            My_Process.EnableRaisingEvents = True ' Raise events
            My_Process.StartInfo = My_Process_Info
            My_Process.Start() ' Run the process NOW

            My_Process.WaitForExit(Process_TimeOut) ' Wait X ms to kill the process (Default value is 999999999 ms which is 277 Hours)

            Dim ERRORLEVEL = My_Process.ExitCode ' Stores the ExitCode of the process
            If Not ERRORLEVEL = 0 Then Exit Try ' Returns the Exitcode if is not 0

            If Read_Output = True Then
                Dim Process_ErrorOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Error Output (If any)
                Dim Process_StandardOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Standard Output (If any)
                ' Return output by priority
                If Process_ErrorOutput IsNot Nothing Then Return Process_ErrorOutput ' Returns the ErrorOutput (if any)
                If Process_StandardOutput IsNot Nothing Then Return Process_StandardOutput ' Returns the StandardOutput (if any)
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            isRun = False
        End Try

        Return isRun ' Returns True if Read_Output argument is set to False and the process finished without errors.

    End Function

#End Region
End Class
