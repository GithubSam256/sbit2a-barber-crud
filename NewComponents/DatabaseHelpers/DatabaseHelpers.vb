Imports Microsoft.Data.SqlClient
Imports MySql.Data.MySqlClient

Module DatabaseHelpers
    ' 🔹 Build connection string using parameters
    Private Function BuildConnectionString(server As String, database As String, username As String, password As String) As String
        Return $"Server={server};Database={database};User ID={username};Password={password};"
    End Function

    ' 🔹 Function to get a MySQL connection
    Public Function GetConnection(server As String, database As String, username As String, password As String) As MySqlConnection
        Dim connStr As String = BuildConnectionString(server, database, username, password)
        Return New MySqlConnection(connStr)
    End Function

    ' 🔹 Test connection (accepts parameters)
    Public Sub TestConnection(server As String, database As String, username As String, password As String)
        Try
            Using conn As MySqlConnection = GetConnection(server, database, username, password)
                conn.Open()
                MessageBox.Show("✅ MySQL connection successful!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Connection failed: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module