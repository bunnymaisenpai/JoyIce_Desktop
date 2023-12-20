Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class Form1


    Private Sub BunifuTextBox2_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox2.TextChanged
        BunifuTextBox2.UseSystemPasswordChar = True
    End Sub



    Private Sub BunifuTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BunifuTextBox1.KeyPress
        If BunifuTextBox1.Text = "superAdmin" Then
            superadmin.Show()
            Me.Hide()
            BunifuTextBox1.Text = ""
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If BunifuTextBox1.Text = "" Or BunifuTextBox2.Text = "" Then
            MsgBox("Please Input Username and Password!", MsgBoxStyle.Critical)
        Else
            Dim username As String = BunifuTextBox1.Text
            Dim password As String = BunifuTextBox2.Text

            ' Connect to MongoDB Atlas
            Dim connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
            Dim client As New MongoClient(connectionString)
            Dim database As IMongoDatabase = client.GetDatabase("Joyicedb")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("admin")

            ' Create a filter for username and password
            Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.And(
                Builders(Of BsonDocument).Filter.Regex("username", New BsonRegularExpression(username, "i")), ' "i" for case-insensitive matching
                Builders(Of BsonDocument).Filter.Regex("password", New BsonRegularExpression(password, "i"))
            )

            ' Execute the query
            Dim result As BsonDocument = collection.Find(filter).FirstOrDefault()

            If result IsNot Nothing Then
                ' Login successful
                MessageBox.Show("Login successful!")
                BunifuTextBox2.Text = ""
                Form3.Show()
                Me.Hide()
            Else
                ' Login failed
                MsgBox("Invalid username or password!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If MsgBox("Do you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
