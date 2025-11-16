Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Windows.Forms ' Required for DataGridView and MsgBox

Module RetrieveData


    ' Connection object should be shared across the module
    Private Con As MySqlConnection = GetConnection("localhost", "petshop_db", "root", "")

    ''' <summary>
    ''' Executes a SELECT query and fills the provided DataGridView with the results.
    ''' </summary>
    ''' <param name="query">The SQL SELECT statement to execute.</param>
    ''' <param name="dgv">The DataGridView object to be filled with the retrieved data.</param>
    Public Function FillData(ByVal query As String, ByRef dgv As DataGridView) As DataTable
        Dim dt As New DataTable()

        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Using da As New MySqlDataAdapter(query, Con)
                da.Fill(dt)
            End Using

            dgv.DataSource = dt ' Bind to DataGridView

        Catch ex As Exception
            MsgBox("Error filling data grid: " & ex.Message, MsgBoxStyle.Critical, "Database Error")

        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try

        Return dt ' ✅ Return the loaded DataTable
    End Function


End Module