Imports MySql.Data.MySqlClient

Module GlobalCrud

    ' ✅ Shared connection (already initialized)
    Private Con As MySqlConnection = GetConnection("localhost", "petshop_db", "root", "")

    ' 🔹 Execute INSERT, UPDATE, DELETE
    Public Function ExecuteNonQuery(ByVal query As String, ByVal ParamArray parameters() As MySqlParameter) As Boolean
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Using cmd As New MySqlCommand(query, Con)
                If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                    cmd.Parameters.AddRange(parameters)
                End If

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Function

    ' 🔹 Execute SELECT (returns DataTable)
    Public Function ExecuteQuery(ByVal query As String, ByVal ParamArray parameters() As MySqlParameter) As DataTable
        Dim dt As New DataTable()
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Using cmd As New MySqlCommand(query, Con)
                If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                    cmd.Parameters.AddRange(parameters)
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
        Return dt
    End Function

    ' 🔹 Execute scalar (for totals, counts, single values)
    Public Function ExecuteScalar(ByVal query As String, ByVal ParamArray parameters() As MySqlParameter) As Object
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Using cmd As New MySqlCommand(query, Con)
                If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                    cmd.Parameters.AddRange(parameters)
                End If
                Return cmd.ExecuteScalar()
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Function

End Module