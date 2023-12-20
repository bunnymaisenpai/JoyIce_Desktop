Imports MongoDB.Bson
Imports MongoDB.Driver
Imports SharpCompress.Common
Imports System.IO
Imports System.Windows.Forms
Public Class reg
    Private client As MongoClient
    Private database As IMongoDatabase
    Private collection As IMongoCollection(Of BsonDocument)
    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If BunifuTextBox1.Text = "" Or BunifuTextBox2.Text = "" Or BunifuTextBox3.Text = "" Then
            MsgBox("Please Fill-up the blank!", MsgBoxStyle.Critical)
        Else
            ' Connect to MongoDB Atlas
            Dim connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
            client = New MongoClient(connectionString)
            database = client.GetDatabase("Joyicedb")
            collection = database.GetCollection(Of BsonDocument)("admin")

            ' Create a new document
            Dim document As New BsonDocument()
            document.Add("username", BunifuTextBox1.Text)
            document.Add("password", BunifuTextBox2.Text)
            document.Add("qr", "none")
            document.Add("email", BunifuTextBox3.Text)

            ' Insert the document into the collection
            collection.InsertOne(document)

            ' Clear the input fields
            BunifuTextBox1.Text = ""
            BunifuTextBox2.Text = ""
            BunifuTextBox3.Text = ""

            MessageBox.Show("User registered successfully!")
            Form1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class