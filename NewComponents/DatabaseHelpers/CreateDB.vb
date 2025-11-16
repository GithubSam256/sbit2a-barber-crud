Imports MySql.Data.MySqlClient

Module CreatePetShopDB

    ' Database configuration
    Private Const SERVER As String = "localhost"
    Private Const DATABASE As String = "petshop_db"
    Private Const USERNAME As String = "root"
    Private Const PASSWORD As String = ""

    Public Sub InitializeDatabase()
        Try
            ' Step 1: Create database if not exists
            CreateDatabaseIfNotExists()

            ' Step 2: Create tables if not exist
            CreateTablesIfNotExist()

        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateDatabaseIfNotExists()
        Try
            Using con As MySqlConnection = DatabaseHelpers.GetConnection(SERVER, "", USERNAME, PASSWORD)
                con.Open()
                Dim createDbQuery As String = $"CREATE DATABASE IF NOT EXISTS {DATABASE};"
                Using cmd As New MySqlCommand(createDbQuery, con)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Failed to create database: " & ex.Message)
        End Try
    End Sub

    Private Sub CreateTablesIfNotExist()
        Try
            Using con As MySqlConnection = DatabaseHelpers.GetConnection(SERVER, DATABASE, USERNAME, PASSWORD)
                con.Open()

                ' 1️⃣ Pet Categories Table
                Dim createCategoriesTable As String = "
                CREATE TABLE IF NOT EXISTS pet_categories (
                    category_id INT AUTO_INCREMENT PRIMARY KEY,
                    category_name VARCHAR(100) NOT NULL UNIQUE,
                    description TEXT NULL
                );"
                ExecuteCommand(con, createCategoriesTable)

                ' 2️⃣ Pets Table
                Dim createPetsTable As String = "
                CREATE TABLE IF NOT EXISTS pets (
                    pet_id INT AUTO_INCREMENT PRIMARY KEY,
                    pet_name VARCHAR(150) NOT NULL,
                    category_id INT,
                    selling_price DECIMAL(10,2) NOT NULL,
                    cost_price DECIMAL(10,2) NOT NULL,
                    reorder_level INT DEFAULT 0,
                    FOREIGN KEY (category_id) REFERENCES pet_categories(category_id)
                        ON UPDATE CASCADE
                        ON DELETE SET NULL
                );"
                ExecuteCommand(con, createPetsTable)

                ' 3️⃣ Pet Purchases Table
                Dim createPurchasesTable As String = "
                CREATE TABLE IF NOT EXISTS pet_purchases (
                    purchase_id INT AUTO_INCREMENT PRIMARY KEY,
                    pet_id INT,
                    quantity INT NOT NULL,
                    purchase_price DECIMAL(10,2) NOT NULL,
                    total_price DECIMAL(10,2) GENERATED ALWAYS AS (quantity * purchase_price) STORED,
                    purchase_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                );"
                ExecuteCommand(con, createPurchasesTable)

                ' 4️⃣ Pet Stock Table
                Dim createStockTable As String = "
                CREATE TABLE IF NOT EXISTS pet_stock (
                    batch_id INT AUTO_INCREMENT PRIMARY KEY,
                    pet_id INT NOT NULL,
                    quantity INT NOT NULL,
                    expiry_date DATE NOT NULL,
                    purchase_id INT,
                    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE,
                    FOREIGN KEY (purchase_id) REFERENCES pet_purchases(purchase_id)
                        ON UPDATE CASCADE
                        ON DELETE SET NULL
                );"
                ExecuteCommand(con, createStockTable)

                ' 5️⃣ Pet Sales Table
                Dim createSalesTable As String = "
                CREATE TABLE IF NOT EXISTS pet_sales (
                    sale_id INT AUTO_INCREMENT PRIMARY KEY,
                    pet_id INT NOT NULL,
                    quantity INT NOT NULL,
                    sale_price DECIMAL(10,2) NOT NULL,
                    total_price DECIMAL(10,2) GENERATED ALWAYS AS (quantity * sale_price) STORED,
                    sale_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                );"
                ExecuteCommand(con, createSalesTable)

            End Using
        Catch ex As Exception
            Throw New Exception("Failed to create tables: " & ex.Message)
        End Try
    End Sub

    Private Sub ExecuteCommand(con As MySqlConnection, query As String)
        Using cmd As New MySqlCommand(query, con)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Module
