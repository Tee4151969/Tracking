Imports System.Data.OleDb
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Configuration
Imports System.IO

Module SMSServices

    Private CnnStr As String = ""
    Private sqlCmd As String = ""
    Private errCode As Long = 0
    Private errDesc As String = ""

    Public Class DBInfo
        Public User As String
        Public Password As String
        Public DNS As String
    End Class

#Region "SelectData"

    Public Function SelectData(ByVal aAlias As String, ByVal aSql As String) As DataSet
        Dim objDS As New DataSet
        Dim DNS As New DBInfo

        Dim myobjCnn As OracleConnection = New OracleConnection
        Dim myObjDS As DataSet
        Dim myAdap As OracleDataAdapter = New OracleDataAdapter

        '-- Get User/Pass/DB from Configuration Table
        DNS = GetDBInfo(aAlias)
        '-- Return if nothing

        If DNS.User Is Nothing OrElse DNS.Password Is Nothing OrElse DNS.DNS Is Nothing Then Return Nothing

        CnnStr = Get_CNNStr(DNS.User, DNS.Password, DNS.DNS)
        '-- If Connect still open -> Close it and re-open with new connectin string
        If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()

        myobjCnn = New OracleConnection(CnnStr)
        myobjCnn.Open()
        '-- Assign Request SQL Command
        myAdap.SelectCommand = New OracleCommand(aSql, myobjCnn)
        myObjDS = New DataSet
        '-- Put data into Adapter
        myAdap.Fill(myObjDS)
        '-- Close Connect when done
        If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()
        '-- Clear object
        myAdap = Nothing
        myobjCnn = Nothing

        Return myObjDS
    End Function
    Private Sub WriteToFile(text As String)
        Dim path As String = "D:\Log\OracleJobServiceLog.txt"
        Dim folder As String = "c:\Log"
        Dim isPass As Boolean = False
        If IO.File.Exists(path) Then
            isPass = True
        End If
        Try
            If isPass Then
                Using writer As New StreamWriter(path, True)
                    writer.WriteLine(String.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
                    writer.Close()
                End Using
            End If
        Catch ex As Exception
            Dim sMessage As String = String.Empty
        End Try
    End Sub

    Public Function CnnWithDatabase(ByVal aDatabaseInfo As String) As String
        Dim DNS As New DBInfo
        Try
            DNS = GetDBInfoUserPassword(aDatabaseInfo)
            If DNS.User Is Nothing OrElse DNS.Password Is Nothing OrElse DNS.DNS Is Nothing Then Return Nothing
            CnnStr = Get_CNNStr(DNS.User, DNS.Password, DNS.DNS)
        Catch ex As Exception
            CnnStr = String.Empty
        End Try
        Return CnnStr
    End Function
    Public Function SelectDataWithDatabase(ByVal aDatabaseInfo As String, ByVal aSql As String) As DataSet
        Dim objDS As New DataSet
        Dim DNS As New DBInfo
        Dim myobjCnn As OracleConnection = New OracleConnection
        Dim myObjDS As DataSet
        Dim myAdap As OracleDataAdapter = New OracleDataAdapter
        Try
            DNS = GetDBInfoUserPassword(aDatabaseInfo)
            If DNS.User Is Nothing OrElse DNS.Password Is Nothing OrElse DNS.DNS Is Nothing Then Return Nothing
            CnnStr = Get_CNNStr(DNS.User, DNS.Password, DNS.DNS)

            If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()
            myobjCnn = New OracleConnection(CnnStr)
            myobjCnn.Open()
            myAdap.SelectCommand = New OracleCommand(aSql, myobjCnn)
            myObjDS = New DataSet
            '-- Put data into Adapter
            myAdap.Fill(myObjDS)
            '-- Close Connect when done
            If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()
            '-- Clear object
            myAdap = Nothing
            myobjCnn = Nothing
        Catch ex As Exception
            myObjDS = Nothing
        End Try
        Return myObjDS
    End Function
    Public Function SelectDataWithConnectionstring(ByVal inConnectionstring As String, inUser As String, inPassword As String, ByVal aSql As String) As DataSet
        Dim objDS As New DataSet
        Dim DNS As New DBInfo
        Dim myobjCnn As OracleConnection = New OracleConnection
        Dim myObjDS As DataSet
        Dim myAdap As OracleDataAdapter = New OracleDataAdapter
        Try
            CnnStr = String.Format(inConnectionstring, inUser, inPassword)
            If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()
            myobjCnn = New OracleConnection(CnnStr)
            myobjCnn.Open()
            myAdap.SelectCommand = New OracleCommand(aSql, myobjCnn)
            myObjDS = New DataSet
            '-- Put data into Adapter
            myAdap.Fill(myObjDS)
            '-- Close Connect when done
            If myobjCnn.State = ConnectionState.Open OrElse myobjCnn.State = ConnectionState.Connecting Then myobjCnn.Close()
            '-- Clear object
            myAdap = Nothing
            myobjCnn = Nothing
        Catch ex As Exception
            myObjDS = Nothing
        End Try
        Return myObjDS
    End Function

    Private Function Select_RS(ByVal objCnn As OracleConnection, ByVal SQLTxt As String) As OracleDataReader  ' OleDbDataReader
        Dim objCommand As OracleCommand
        Dim RS As OracleDataReader = Nothing
        clearErrorMsg(errCode, errDesc)
        Try

            objCommand = New OracleCommand(SQLTxt, objCnn)

            If objCnn.State = ConnectionState.Open Then
                RS = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
            End If
        Catch ex As Exception
            errCode = -1
            errDesc = ex.Message.ToString
            RS = Nothing
        Finally
            'objCnn.Close()
        End Try

        Return RS
    End Function

#End Region

#Region "ExecuteSQL"
    Public Function ExecuteSQLWithFullConnect(ByVal CnnStr As String, ByVal aSql As String) As Boolean
        Dim outXML As String = ""
        Dim myObjCnn As New OracleConnection
        Dim result As Boolean = False
        '-- If Connect still open -> Close it and re-open with new connectin string
        If myObjCnn.State = ConnectionState.Open OrElse myObjCnn.State = ConnectionState.Connecting Then myObjCnn.Close()

        myObjCnn = New OracleConnection(CnnWithDatabase(CnnStr))

        myObjCnn.Open()
        result = Execute_RS(myObjCnn, aSql)

        If Not myObjCnn Is Nothing Then myObjCnn.Close()

        Return result
    End Function
    Public Function ExecuteSQLWithConnect(ByVal myObjCnn As OracleConnection, ByVal aSql As String) As Boolean
        Dim outXML As String = ""
        Dim result As Boolean = False
        '-- If Connect still open -> Close it and re-open with new connectin string
        If myObjCnn.State = ConnectionState.Open OrElse myObjCnn.State = ConnectionState.Connecting Then myObjCnn.Close()

        myObjCnn = New OracleConnection(CnnStr)

        myObjCnn.Open()
        result = Execute_RS(myObjCnn, aSql)

        If Not myObjCnn Is Nothing Then myObjCnn.Close()

        Return result
    End Function
    Public Function ExecuteSQL(ByVal aAlias As String, ByVal aSql As String) As Boolean
        Dim outXML As String = ""
        Dim result As Boolean = False
        Dim myObjCnn As New OracleConnection
        Dim DSN As New DBInfo

        DSN = GetDBInfo(aAlias)

        CnnStr = Get_CNNStr(DSN.User, DSN.Password, DSN.DNS)

        '-- If Connect still open -> Close it and re-open with new connectin string
        If myObjCnn.State = ConnectionState.Open OrElse myObjCnn.State = ConnectionState.Connecting Then myObjCnn.Close()

        myObjCnn = New OracleConnection(CnnStr)

        myObjCnn.Open()
        result = Execute_RS(myObjCnn, aSql)

        If Not myObjCnn Is Nothing Then myObjCnn.Close()

        Return result
    End Function

    Private Function Execute_RS(ByVal myCnn As OracleConnection, ByVal SQLTxt As String) As Boolean
        Dim objCommand As OracleCommand
        Dim row As Integer

        objCommand = New OracleCommand(SQLTxt, myCnn)

        If myCnn.State = ConnectionState.Open Then
            row = objCommand.ExecuteNonQuery()
            If row >= 0 Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
#End Region

#Region "Manage Connection"

    Private Function Get_CNNStr(ByVal UserIn As String, ByVal PasswdIN As String, ByVal SystemIn As String) As String
        Dim AllString As String = Replace("User Id=$User;Password=$Password;Data Source=$DSN;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5; Decr Pool Size=2;Enlist=false;Pooling=true", "'", """")
        AllString = Replace(AllString, "$DSN", SystemIn)
        AllString = Replace(AllString, "$Password", PasswdIN)
        AllString = Replace(AllString, "$User", UserIn)
        Return AllString
    End Function

    Public Function GetDBInfoUserPassword(ByVal myDatabase As String) As DBInfo
        Dim myReturn As DBInfo = Nothing

        Dim sUserDatabase As String = ""
        Dim sPasswordDatabase As String = ""
        Dim sNameDatabase As String = ""

        Dim spUserPassword() As String = Nothing
        Dim spDatabase() As String = Nothing

        spDatabase = myDatabase.Split("@")
        If Not spDatabase Is Nothing Then
            If spDatabase.Length > 0 Then
                spUserPassword = spDatabase(0).Split("/")
                If Not spUserPassword Is Nothing Then
                    If spUserPassword.Length > 0 Then sUserDatabase = spUserPassword(0).ToUpper
                    If spUserPassword.Length > 1 Then sPasswordDatabase = spUserPassword(1).ToUpper
                End If
            End If
            If spDatabase.Length > 1 Then sNameDatabase = spDatabase(1).ToUpper
        End If
        If Not String.IsNullOrEmpty(sUserDatabase) And Not String.IsNullOrEmpty(sPasswordDatabase) And Not String.IsNullOrEmpty(sNameDatabase) Then
            myReturn = New DBInfo
            myReturn.User = sUserDatabase
            myReturn.Password = sPasswordDatabase
            myReturn.DNS = sNameDatabase
        End If
        If Not spDatabase Is Nothing Then spDatabase = Nothing
        If Not spUserPassword Is Nothing Then spUserPassword = Nothing

        Return myReturn
    End Function
    Public Function GetDBInfo(ByVal myAlias As String) As DBInfo
        Dim myReturn As New DBInfo
        Dim TmpDBConfig As String = ""
        Dim myInfo() As String

        If TmpDBConfig Is Nothing Then TmpDBConfig = myAlias
        If TmpDBConfig <> "" Then
            myInfo = Split(TmpDBConfig, ";")
            myReturn.User = myInfo(0)
            myReturn.Password = myInfo(1)
            myReturn.DNS = myInfo(2)
        End If
        Return myReturn
    End Function

    Private Function clearErrorMsg(ByRef errCode As Integer, ByRef errDesc As String)
        errCode = 0
        errDesc = ""

        Return ""
    End Function
#End Region
   
    Public Function Execute_Procedure(ByVal myCnn As OracleConnection, inProc As String) As Boolean
        Dim objCommand As OracleCommand = Nothing
        Dim row As Integer = 0
        Dim sResult As String = String.Empty
        Dim ProcName As String = String.Empty
        Dim isExecute As Boolean = False

        
        Try
            ProcName = inProc
            WriteToFile("Execute_Procedure =" & inProc.ToString)
            If Not String.IsNullOrEmpty(ProcName) Then
                objCommand = New OracleCommand
                objCommand.Connection = myCnn
                objCommand.CommandText = ProcName
                objCommand.CommandType = CommandType.StoredProcedure
                WriteToFile(myCnn.ConnectionString.ToString)

                myCnn.Open()
                If myCnn.State = ConnectionState.Open Then
                    row = objCommand.ExecuteNonQuery()
                    isExecute = (row <> 0)
                    WriteToFile("Execute_Procedure Row =" & row.ToString)
                End If
                If Not objCommand Is Nothing Then objCommand.Dispose()
            End If
            Return isExecute
        Catch ex As Exception
            WriteToFile(ex.Message)
        End Try
    End Function
End Module
