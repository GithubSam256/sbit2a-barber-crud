Module SearchData

    ''' <summary>
    ''' Applies filter to BindingSource for searching across one or more columns.
    ''' </summary>
    ''' <param name="searchString">The text entered by the user in the search bar.</param>
    ''' <param name="bs">The BindingSource component connected to the DataGridView.</param>
    ''' <param name="columnNames">Column name(s) to search. Pass single string or multiple using ParamArray.</param>
    Public Sub ApplyFilterToBindingSource(ByVal searchString As String, ByVal bs As BindingSource, ByVal ParamArray columnNames() As String)
        Dim sanitizedSearchTerm As String = searchString.Trim().Replace("'", "''")

        If String.IsNullOrWhiteSpace(sanitizedSearchTerm) Then
            bs.Filter = Nothing
        Else
            Try
                ' Check if we have a DataTable
                If bs.DataSource Is Nothing OrElse TypeOf bs.DataSource IsNot DataTable Then
                    Return
                End If

                ' Build filter for multiple columns using OR
                Dim filterParts As New List(Of String)

                For Each columnName As String In columnNames
                    If Not String.IsNullOrWhiteSpace(columnName) Then
                        ' Use single quotes for string comparison and % for LIKE
                        filterParts.Add(String.Format("{0} LIKE '%{1}%'", columnName, sanitizedSearchTerm))
                    End If
                Next

                If filterParts.Count > 0 Then
                    ' Join all conditions with OR
                    Dim filterExpression As String = String.Join(" OR ", filterParts)
                    bs.Filter = filterExpression
                Else
                    bs.Filter = Nothing
                End If

            Catch ex As Exception
                Console.WriteLine($"Error applying filter: {ex.Message}")
                MessageBox.Show("Error applying search filter: " & ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bs.Filter = Nothing
            End Try
        End If
    End Sub

End Module