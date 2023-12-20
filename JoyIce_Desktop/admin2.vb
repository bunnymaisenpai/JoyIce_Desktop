Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class admin2
    ' Initialize MongoClient and collections as class-level variables
    Private connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
    Private client As MongoClient
    Private sourceCollection As IMongoCollection(Of BsonDocument)
    Private destinationCollection As IMongoCollection(Of BsonDocument)
    Private selectedDocumentToTransfer As BsonDocument

    Private Sub admin2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connect to MongoDB Atlas and initialize collections
        client = New MongoClient(connectionString)
        sourceCollection = client.GetDatabase("Joyicedb").GetCollection(Of BsonDocument)("admin")

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
            BunifuTextBox2.Text = selectedItem.GetValue("password").AsString
            BunifuTextBox3.Text = selectedItem.GetValue("qr").AsString
            BunifuTextBox4.Text = selectedItem.GetValue("email").AsString
        Else
            BunifuTextBox1.Text = ""
            BunifuTextBox2.Text = ""
            BunifuTextBox3.Text = ""
            BunifuTextBox4.Text = ""
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

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        If BunifuTextBox1.Text = "" Or BunifuTextBox2.Text = "" Or BunifuTextBox3.Text = "" Or BunifuTextBox4.Text = "" Then
            MsgBox("Cannot Update!")
        Else
            ' Update a new document
            Dim filter As New BsonDocument()
            filter.Add("username", BunifuTextBox1.Text)

            Dim update = New BsonDocument()
            update.Add("$set", New BsonDocument("password", BunifuTextBox2.Text).
            Add("qr", BunifuTextBox3.Text).
            Add("email", BunifuTextBox4.Text))
            sourceCollection.UpdateOneAsync(filter, update)


            MessageBox.Show("Account Updated successfully!")

        End If
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        If lstDocuments.SelectedIndex >= -1 Then

            Dim selectedName As String = lstDocuments.SelectedItem.ToString()

            ' Create a regex filter to find data matching the selected name pattern
            Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Regex("username", New BsonRegularExpression(selectedName))

            ' Delete the matching data
            Dim deleteResult = sourceCollection.DeleteMany(filter)

            ' Check if the deletion was successful
            If deleteResult.DeletedCount > 0 Then
                MessageBox.Show("Selected data deleted successfully!")
                BunifuTextBox1.Text = ""
                BunifuTextBox2.Text = ""
                BunifuTextBox3.Text = ""
                BunifuTextBox4.Text = ""
            Else
                MessageBox.Show("No matching data found to delete.")
            End If
        Else
            MessageBox.Show("Please select an item to delete.")
        End If
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        BunifuTextBox1.Clear()
        BunifuTextBox2.Clear()
        BunifuTextBox3.Clear()
        BunifuTextBox4.Clear()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        admin1.Show()
        Me.Close()
    End Sub
End Class