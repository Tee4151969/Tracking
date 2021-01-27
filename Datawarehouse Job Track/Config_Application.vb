Public Class Config_Application
    Public Shared Function ReadSetting(key As String) As String
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
End Class
