Imports System.IO
Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class Form7
    ' Initialize MongoClient and collections as class-level variables
    Private connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
    Private client As MongoClient
    Private sourceCollection As IMongoCollection(Of BsonDocument)
    Private destinationCollection As IMongoCollection(Of BsonDocument)
    Private selectedDocumentToTransfer As BsonDocument
    Private Sub Label9_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connect to MongoDB Atlas and initialize collections
        client = New MongoClient(connectionString)
        sourceCollection = client.GetDatabase("Joyicedb").GetCollection(Of BsonDocument)("review")

        ' Load documents into the ListBox
        LoadDocumentsToListBox()
    End Sub
    Private Sub LoadDocumentsToListBox()
        ' Clear existing items and load documents from the source collection into the ListBox
        lstDocuments.Items.Clear()

        Dim documents As List(Of BsonDocument) = sourceCollection.Find(New BsonDocument()).ToList()
        For Each doc In documents
            ' Display the title or any other identifier of the document in the ListBox
            lstDocuments.Items.Add(New DocumentItem(doc))
        Next
    End Sub
    Public Class DocumentItem
        ' This class is used to store a reference to a BsonDocument in the ListBox
        ' You can customize this to display different information about the document
        Public Property Document As BsonDocument

        Public Sub New(doc As BsonDocument)
            Document = doc
        End Sub

        Public Overrides Function ToString() As String
            ' Customize how the document is displayed in the ListBox
            ' In this example, we use the title field if it exists, otherwise use the ObjectId
            If Document.Contains("title") Then
                Return Document("title").AsString
            Else
                Return Document("username").ToString()
            End If
        End Function
    End Class

    Private Sub lstDocuments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDocuments.SelectedIndexChanged
        ' Display the selected document's title and description in TextBoxes
        If lstDocuments.SelectedIndex <> -1 Then
            Dim selectedItem As BsonDocument = DirectCast(lstDocuments.SelectedItem, DocumentItem).Document

            BunifuTextBox1.Text = selectedItem.GetValue("username").AsString
            BunifuTextBox2.Text = selectedItem.GetValue("report").AsString
            BunifuTextBox3.Text = selectedItem.GetValue("message").AsString
            BunifuTextBox4.Text = selectedItem.GetValue("chocolatestick").AsString
            BunifuTextBox5.Text = selectedItem.GetValue("milkstick").AsString
            BunifuTextBox6.Text = selectedItem.GetValue("pineapplestick").AsString
            BunifuTextBox7.Text = selectedItem.GetValue("sweetcornstick").AsString
            BunifuTextBox8.Text = selectedItem.GetValue("watermelonstick").AsString

        Else
            BunifuTextBox1.Text = ""
            BunifuTextBox2.Text = ""
            BunifuTextBox3.Text = ""
            BunifuTextBox4.Text = ""
            BunifuTextBox5.Text = ""
            BunifuTextBox6.Text = ""
            BunifuTextBox7.Text = ""
            BunifuTextBox8.Text = ""
        End If
    End Sub
    Private Sub LoadData()
        ' Load data from the collection
        Dim allData = sourceCollection.Find(New BsonDocument()).ToList()

        ' Clear the ListBox before adding data
        lstDocuments.Items.Clear()

        ' Populate the ListBox with names from the collection
        For Each dataItem As BsonDocument In allData
            Dim name As String = dataItem("username").ToString()
            lstDocuments.Items.Add(name)
        Next
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