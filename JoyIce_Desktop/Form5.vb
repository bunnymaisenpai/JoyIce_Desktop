Imports System.IO
Imports MongoDB.Bson
Imports MongoDB.Driver
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports DnsClient.Protocol
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Bunifu.UI.WinForms

Public Class Form5
    ' Initialize MongoClient and collections as class-level variables
    Private connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
    Private client As MongoClient
    Private sourceCollection As IMongoCollection(Of BsonDocument)
    Private destinationCollection As IMongoCollection(Of BsonDocument)
    Private selectedDocumentToTransfer As BsonDocument
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connect to MongoDB Atlas and initialize collections
        client = New MongoClient(connectionString)
        sourceCollection = client.GetDatabase("Joyicedb").GetCollection(Of BsonDocument)("JIp")

        ' Load documents into the ListBox
        LoadDocumentsToListBox()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
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
            BunifuTextBox3.Text = selectedItem.GetValue("chocolatestick").AsString
            BunifuTextBox4.Text = selectedItem.GetValue("chocolateprice").AsString
            BunifuTextBox5.Text = selectedItem.GetValue("milkstick").AsString
            BunifuTextBox6.Text = selectedItem.GetValue("milkprice").AsString
            BunifuTextBox7.Text = selectedItem.GetValue("pineapplestick").AsString
            BunifuTextBox8.Text = selectedItem.GetValue("pineappleprice").AsString
            BunifuTextBox9.Text = selectedItem.GetValue("sweetcornstick").AsString
            BunifuTextBox10.Text = selectedItem.GetValue("sweetcornprice").AsString
            BunifuTextBox11.Text = selectedItem.GetValue("watermelonstick").AsString
            BunifuTextBox12.Text = selectedItem.GetValue("watermelonprice").AsString
            BunifuTextBox2.Text = selectedItem.GetValue("address").AsString

        Else
            BunifuTextBox1.Text = ""
            BunifuTextBox2.Text = ""
            BunifuTextBox3.Text = ""
            BunifuTextBox4.Text = ""
            BunifuTextBox5.Text = ""
            BunifuTextBox6.Text = ""
            BunifuTextBox7.Text = ""
            BunifuTextBox8.Text = ""
            BunifuTextBox9.Text = ""
            BunifuTextBox10.Text = ""
            BunifuTextBox11.Text = ""
            BunifuTextBox12.Text = ""
            BunifuTextBox13.Text = ""
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
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim a, b, c, d, f, tyx, tsum, sum As Integer
        a = BunifuTextBox4.Text
        b = BunifuTextBox6.Text
        c = BunifuTextBox8.Text
        d = BunifuTextBox10.Text
        f = BunifuTextBox12.Text
        sum = a + b + c + d + f
        tyx = sum * 0.1
        tsum = sum + tyx
        BunifuTextBox13.Text = tsum
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        BunifuTextBox1.Text = ""
        BunifuTextBox2.Text = ""
        BunifuTextBox3.Text = ""
        BunifuTextBox4.Text = ""
        BunifuTextBox5.Text = ""
        BunifuTextBox6.Text = ""
        BunifuTextBox7.Text = ""
        BunifuTextBox8.Text = ""
        BunifuTextBox9.Text = ""
        BunifuTextBox10.Text = ""
        BunifuTextBox11.Text = ""
        BunifuTextBox12.Text = ""
        BunifuTextBox13.Text = ""
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        If BunifuTextBox12.Text = "" Then
            MsgBox("Please click the total")
        Else

            ' Get the text from the textboxes
            Dim text1 As String = BunifuTextBox1.Text
            Dim text2 As String = BunifuTextBox2.Text
            Dim text3 As String = BunifuTextBox3.Text
            Dim text4 As String = BunifuTextBox4.Text
            Dim text5 As String = BunifuTextBox5.Text
            Dim text6 As String = BunifuTextBox6.Text
            Dim text7 As String = BunifuTextBox7.Text
            Dim text8 As String = BunifuTextBox8.Text
            Dim text9 As String = BunifuTextBox9.Text
            Dim text10 As String = BunifuTextBox10.Text
            Dim text11 As String = BunifuTextBox11.Text
            Dim text12 As String = BunifuTextBox12.Text
            Dim text13 As String = BunifuTextBox13.Text

            BunifuTextBox14.Text = ""
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)

            BunifuTextBox14.AppendText(vbTab + vbTab & "ORDER RECEIPT" + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText("Reseller Name: " + vbTab & text1 + vbTab + vbTab + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)
            BunifuTextBox14.AppendText("Address:" + vbTab & text2 + vbTab + vbTab + vbNewLine)
            BunifuTextBox14.AppendText(" " + vbNewLine)

            BunifuTextBox14.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + vbNewLine)

            If Convert.ToInt32(text4) > 0 Then
                BunifuTextBox14.AppendText(" " + vbNewLine)
                BunifuTextBox14.AppendText("JOYICE CHOCOLATE STICK 40G" + vbTab + vbTab & "₱" & text4 + vbNewLine)
            End If

            If Convert.ToInt32(text6) > 0 Then
                BunifuTextBox14.AppendText(" " + vbNewLine)
                BunifuTextBox14.AppendText("JOYICE MILK STICK 40G" + vbTab + vbTab + vbTab & "₱" & text6 + vbNewLine)
            End If

            If Convert.ToInt32(text8) > 0 Then
                BunifuTextBox14.AppendText(" " + vbNewLine)
                BunifuTextBox14.AppendText("JOYICE PINEAPPLE" + vbTab + vbTab + vbTab & "₱" & text8 + vbNewLine)
            End If

            If Convert.ToInt32(text10) > 0 Then
                BunifuTextBox14.AppendText(" " + vbNewLine)
                BunifuTextBox14.AppendText("JOYICE SWEETCORN 52G" + vbTab + vbTab & "₱" & text10 + vbNewLine)
            End If

            If Convert.ToInt32(text12) > 0 Then
                BunifuTextBox14.AppendText(" " + vbNewLine)
                BunifuTextBox14.AppendText("JOYICE WATERMELON 65G" + vbTab + vbTab & "₱" & text12 + vbNewLine)
            End If
            BunifuTextBox14.AppendText(" " + vbNewLine)

            BunifuTextBox14.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + vbNewLine)
            BunifuTextBox14.AppendText("TOTAL PRICE" + vbTab + vbTab + vbTab + vbTab & "₱" & text13 + vbNewLine)
            BunifuTextBox14.AppendText("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =" + vbNewLine)
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(BunifuTextBox14.Text, Font, Brushes.Black, 0, 20)
        e.Graphics.DrawImage(Form1.PictureBox1.Image, 80, 0, Form1.PictureBox1.Width - 15, Form1.PictureBox1.Height - 25)
    End Sub
End Class