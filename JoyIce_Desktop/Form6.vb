Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class Form6
    Dim client As MongoClient
    Dim database As IMongoDatabase
    Dim collection As IMongoCollection(Of BsonDocument)
    Public Sub New()
        InitializeComponent()

        ' Connect to MongoDB Atlas
        client = New MongoClient("mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/")
        database = client.GetDatabase("Joyicedb")
        collection = database.GetCollection(Of BsonDocument)("inventory")
    End Sub


    Private Sub Label9_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If BunifuTextBox1.Text = "" Or BunifuTextBox2.Text = "" Or BunifuTextBox3.Text = "" Or BunifuTextBox4.Text = "" Or BunifuTextBox5.Text = "" Then
            MsgBox("Cannot Update!")
        Else
            ' Update a new document
            Dim filter As New BsonDocument()
            filter.Add("filter", "inventory")
            Dim update = New BsonDocument()
            update.Add("$set", New BsonDocument("chocolatestick", BunifuTextBox1.Text).
            Add("milkstick", BunifuTextBox2.Text).
            Add("pineapplestick", BunifuTextBox3.Text).
            Add("sweetcornstick", BunifuTextBox4.Text).
            Add("watermelonstick", BunifuTextBox5.Text))
            collection.UpdateOneAsync(filter, update)


            MessageBox.Show("Account Updated successfully!")
        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        BunifuTextBox1.Clear()
        BunifuTextBox2.Clear()
        BunifuTextBox3.Clear()
        BunifuTextBox4.Clear()
        BunifuTextBox5.Clear()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class