Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Toy
    Dim myconnection As New OleDbConnection("Data source = localhost;" + "password = int1; user Id = system ; provider=oraOLEDB.oracle")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillDataDrid()
        Try
            Dim myconnection As New OleDbConnection("Data source = localhost;" + "password = int1; user Id = system ;  provider=oraOLEDB.oracle")

            Dim sql As String = "INSERT INTO TOY(TOY_ID,TOY_NAME,DESCRIPTION,AGE,IMAGE_PATH,STOCK,PRICE)VALUES(?,?,?,?,?,?,?)"

            myconnection.Open()
            Dim command As New OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
            command.Parameters.AddWithValue("?", ComboBox1.SelectedValue)
            command.Parameters.AddWithValue("?", TextBox2.Text)
            command.Parameters.AddWithValue("?", ComboBox2.SelectedValue)
            command.Parameters.AddWithValue("?", TextBox3.Text)
            command.Parameters.AddWithValue("?", CInt(TextBox4.Text))
            command.Parameters.AddWithValue("?", CInt(TextBox5.Text))

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Inserted")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub FillDataDrid()
        Dim adp As New OleDbDataAdapter("select * from toy", myconnection)
        Dim ds As New DataSet
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Toy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDataDrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String = "UPDATE TOY SET TOY_NAME=?, DESCRIPTION=?, AGE=?, IMAGE_PATH=?, STOCK=?, PRICE=? WHERE TOY_ID=?"
            myconnection.Open()

            Dim command As New OleDbCommand(sql, myconnection)

            command.Parameters.AddWithValue("?", ComboBox1.SelectedValue)
            command.Parameters.AddWithValue("?", TextBox2.Text)
            command.Parameters.AddWithValue("?", ComboBox2.SelectedValue)
            command.Parameters.AddWithValue("?", TextBox3.Text)
            command.Parameters.AddWithValue("?", CInt(TextBox4.Text))
            command.Parameters.AddWithValue("?", CInt(TextBox5.Text))
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text)) ' Add the parameter for TOY_ID

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Updated")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            myconnection.Open()
            Dim sql As String = "DELETE FROM TOY WHERE TOY_ID=?"

            Dim command As New OleDb.OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", TextBox1.Text)

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Deleted")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class