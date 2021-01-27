
Imports System.DirectoryServices
Imports System.Text

Public Class Active_Directory
    Public Shared Function ValidateUser(ByVal domainDN As String, ByVal sAMAccountName As String, sPassword As String) As String
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://" & domainDN, sAMAccountName, sPassword)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Try
            Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try
        Return (Success)
    End Function

    Public Shared Function GetUserGroups(ByVal domainDN As String, ByVal sAMAccountName As String) As String
        Dim lGroups As List(Of String) = Nothing
        Dim dEntry As DirectoryEntry = Nothing
        Dim svalue As String = String.Empty
        Dim ist As Integer = 0
        Dim ien As Integer = 0
        Try
            'Create the DirectoryEntry object to bind the distingusihedName of your domain
            Using rootDE As New DirectoryEntry("LDAP://" & domainDN)

                'Create a DirectorySearcher for performing a search on abiove created DirectoryEntry
                Using dSearcher As New DirectorySearcher(rootDE)

                    'Create the sAMAccountName as filter
                    dSearcher.Filter = "(&(sAMAccountName=" & sAMAccountName & ")(objectClass=User)(objectCategory=Person))"
                    dSearcher.PropertiesToLoad.Add("memberOf")
                    dSearcher.ClientTimeout.Add(New TimeSpan(0, 20, 0))
                    dSearcher.ServerTimeLimit.Add(New TimeSpan(0, 20, 0))

                    'Search the user in AD
                    Dim sResult As SearchResult = dSearcher.FindOne

                    If sResult Is Nothing Then
                        Throw New ApplicationException("No user with username " & sAMAccountName & " could be found in the domain")
                    Else
                        dEntry = sResult.GetDirectoryEntry
                        If Not dEntry Is Nothing Then
                            ist = dEntry.Path.IndexOf("=")
                            ien = dEntry.Path.IndexOf(",")
                            svalue = dEntry.Path.Substring(ist, ien - ist)
                        End If
                         
                    End If
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return svalue
    End Function

    ''' <summary>
    ''' This function will perform a recursive search and will add only one occurance of 
    ''' the group found in the enumeration.
    ''' </summary>
    ''' <param name="dSearcher">DirectorySearcher object to perform search</param>
    ''' <param name="lGroups">List of the Groups from AD</param>
    ''' <param name="sGrpName">
    ''' Group name which needs to be checked inside the Groups collection
    ''' </param>
    ''' <param name="SID">objectSID of the object</param>
    ''' <remarks></remarks>
    Public Shared Sub RecursivelyGetGroups(ByVal dSearcher As DirectorySearcher, ByVal lGroups As List(Of String), ByVal sGrpName As String, ByVal SID As String)
        'Check if the group has already not found
        If Not lGroups.Contains(sGrpName) Then
            lGroups.Add(sGrpName & " : " & SID)

            'Now perform the search based on this group
            dSearcher.Filter = "(&(objectClass=grp)(CN=" & sGrpName & "))".Replace("\", "\\")
            dSearcher.ClientTimeout.Add(New TimeSpan(0, 2, 0))
            dSearcher.ServerTimeLimit.Add(New TimeSpan(0, 2, 0))

            'Search this group
            Dim GroupSearchResult As SearchResult = dSearcher.FindOne
            If Not GroupSearchResult Is Nothing Then
                For Each grp In GroupSearchResult.Properties("memberOf")
                    Dim ParentGroupName As String = CStr(grp).Remove(0, 3)

                    'Bind to this group
                    Dim deTempForSID As New DirectoryEntry("LDAP://" + grp.ToString().Replace("/", "\/"))
                    Try
                        'Get the objectSID which is Byte array
                        Dim objectSid As Byte() = DirectCast(deTempForSID.Properties("objectSid").Value, Byte())

                        'Pass this Byte array to Security.Principal.SecurityIdentifier to convert this 
                        'byte array to SDDL format
                        Dim ParentSID As New System.Security.Principal.SecurityIdentifier(objectSid, 0)

                        If ParentGroupName.Contains(",CN") Then
                            ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",CN"))
                        ElseIf ParentGroupName.Contains(",OU") Then
                            ParentGroupName = ParentGroupName.Remove(ParentGroupName.IndexOf(",OU"))
                        End If
                        RecursivelyGetGroups(dSearcher, lGroups, ParentGroupName, ParentSID.ToString())
                    Catch ex As Exception
                        Console.WriteLine("Error while binding to path : " + grp.ToString())
                        Console.WriteLine(ex.Message.ToString())
                    End Try
                Next
            End If
        End If
    End Sub
End Class
