Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class Category

    Private bs As New BindingSource()
    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadCategory(CategoryTable)
        TableWithActions.TableWithButtons(CategoryTable)
        SetHeaderSize(CategoryTable)

        TableWithActions.TableWithButtons(CategoryTable, AddressOf UpdateCategory, AddressOf DeleteCategory)
    End Sub


    Public Sub LoadCategory(dgv As DataGridView)

        Dim sql As String = "
        SELECT 
            category_id AS `ID`,
            category_name AS `Category_Name`,
            description AS `Description`
        FROM pet_categories
    "

        ' Load the data using your RetrieveDatas module
        Dim dt As DataTable = GlobalCrud.ExecuteQuery(sql)

        ' Bind to BindingSource
        bs.DataSource = dt
        CategoryTable.DataSource = bs

    End Sub

    Public Sub SetHeaderSize(ByVal dgv As DataGridView)
        ' Only set widths for columns that exist
        If dgv.Columns.Contains("ID") Then dgv.Columns("ID").Width = 70
        If dgv.Columns.Contains("Category_Name") Then dgv.Columns("Category_Name").Width = 380
        If dgv.Columns.Contains("description") Then dgv.Columns("description").Width = 500

    End Sub

    Public Sub DeleteCategory(dgv As DataGridView, rowIndex As Integer)
        ' Get the category ID from the selected row
        Dim categoryId As Integer = CInt(dgv.Rows(rowIndex).Cells("ID").Value)

        ' Confirm deletion
        If MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            ' Delete query
            Dim sql As String = "DELETE FROM pet_categories WHERE category_id = @id"
            Dim param As New MySqlParameter("@id", categoryId)

            ' Execute deletion using GlobalCRUD
            Dim success As Boolean = GlobalCrud.ExecuteNonQuery(sql, param)

            If success Then
                MessageBox.Show("Category deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Reload the table to reflect changes
                LoadCategory(dgv)
            Else
                MessageBox.Show("Failed to delete category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub InsertCategory(dgv As DataGridView)
        ' Show the edit form with empty fields
        Using insertForm As New EditCategoryForm("", "")
            insertForm.FormTitle = "Add New Category"
            insertForm.SaveButtonText = "Save"

            If insertForm.ShowDialog() = DialogResult.OK Then
                Dim newName As String = insertForm.CategoryName
                Dim newDescription As String = insertForm.CategoryDescription

                ' Validation
                If String.IsNullOrWhiteSpace(newName) Then
                    MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Insert query
                Dim sql As String = "INSERT INTO pet_categories (category_name, description) VALUES (@name, @desc)"
                Dim parameters() As MySqlParameter = {
                New MySqlParameter("@name", newName),
                New MySqlParameter("@desc", newDescription)
            }

                ' Execute insert
                Dim success As Boolean = GlobalCrud.ExecuteNonQuery(sql, parameters)

                If success Then
                    MessageBox.Show("Category added successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCategory(dgv)
                Else
                    MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub

    Public Sub UpdateCategory(dgv As DataGridView, rowIndex As Integer)
        ' Get the category ID and current values from the selected row
        Dim categoryId As Integer = CInt(dgv.Rows(rowIndex).Cells("ID").Value)
        Dim currentName As String = dgv.Rows(rowIndex).Cells("Category_Name").Value.ToString()
        Dim currentDescription As String = dgv.Rows(rowIndex).Cells("Description").Value.ToString()

        ' Show the edit form
        Using editForm As New EditCategoryForm(currentName, currentDescription)
            If editForm.ShowDialog() = DialogResult.OK Then
                Dim newName As String = editForm.CategoryName
                Dim newDescription As String = editForm.CategoryDescription

                ' Validation
                If String.IsNullOrWhiteSpace(newName) Then
                    MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Update query
                Dim sql As String = "UPDATE pet_categories SET category_name = @name, description = @desc WHERE category_id = @id"
                Dim parameters() As MySqlParameter = {
                New MySqlParameter("@name", newName),
                New MySqlParameter("@desc", newDescription),
                New MySqlParameter("@id", categoryId)
            }

                ' Execute update
                Dim success As Boolean = GlobalCrud.ExecuteNonQuery(sql, parameters)

                If success Then
                    MessageBox.Show("Category updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCategory(dgv)
                Else
                    MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim().Replace("'", "''")


        ApplyFilterToBindingSource(searchTerm, bs, "Category_Name")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertCategory(CategoryTable)
    End Sub
End Class
