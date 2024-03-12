Imports System.Data.OleDb

Public Class Bill
    Dim myconnection As New OleDbConnection("Data source=localhost; password=int1; user Id=system; provider=oraOLEDB.oracle")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            myconnection.Open()
            Dim sql As String = "INSERT INTO BILLS(ABILL_ID, CUSTOMER, TOY_ID, QTY, DISCOUNT, TOTAL_AMOUNT, BUY_DATE) VALUES(?, ?, ?, ?, ?, ?, TO_DATE(?, 'YYYY-MM-DD'))"

            Using command As New OleDb.OleDbCommand(sql, myconnection)
                command.Parameters.AddWithValue("?", TextBox1.Text)
                command.Parameters.AddWithValue("?", TextBox2.Text)
                command.Parameters.AddWithValue("?", TextBox3.Text)
                command.Parameters.AddWithValue("?", TextBox4.Text)
                command.Parameters.AddWithValue("?", ComboBox1.SelectedValue)
                command.Parameters.AddWithValue("?", TextBox8.Text)
                command.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("yyyy-MM-dd"))

                Dim affectedRows = command.ExecuteNonQuery()

                If affectedRows >= 1 Then
                    MessageBox.Show("Data Inserted")
                    generateBill()
                    FillDataDridBill()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myconnection.Close()
        End Try
    End Sub

    Private Sub FillDataDridBill()
        Dim adp As OleDbDataAdapter
        Dim ds As New DataSet
        adp = New OleDb.OleDbDataAdapter("SELECT * FROM BILLS", myconnection)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub generateBill()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = -1
        TextBox8.Clear()
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Sub Bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDataDridBill()
    End Sub
End Class
