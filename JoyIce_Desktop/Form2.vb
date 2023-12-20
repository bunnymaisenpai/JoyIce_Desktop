Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports MongoDB.Bson
Imports MongoDB.Driver
Public Class Form2
    Private videoSource As New VideoCaptureDevice()
    Private reader As New BarcodeReader()
    Private isCameraRunning As Boolean = False

    Private Sub Label1_Click(sender As Object, e As EventArgs) 
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartCamera()
    End Sub
    Private Sub StartCamera()
        Dim videoDevices As FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        If videoDevices.Count > 0 Then
            videoSource = New VideoCaptureDevice(videoDevices(0).MonikerString)
            AddHandler videoSource.NewFrame, AddressOf VideoSource_NewFrame
            videoSource.Start()
            isCameraRunning = True
        Else
            MessageBox.Show("No video devices found.")
        End If
    End Sub

    Private Sub StopCamera()
        If isCameraRunning Then
            videoSource.SignalToStop()
            videoSource.WaitForStop()
            isCameraRunning = False
        End If
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StopCamera()
    End Sub

    Private Sub VideoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        Try
            Dim result = reader.Decode(New Bitmap(eventArgs.Frame))

            If result IsNot Nothing Then
                PictureBox2.Invoke(Sub() PictureBox2.Image = DirectCast(eventArgs.Frame.Clone(), Drawing.Image))
                BunifuTextBox1.Invoke(Sub() BunifuTextBox1.Text = result.Text)

                ' Optionally, you can stop the camera when a QR code is recognized
                ' StopCamera()
            Else
                PictureBox2.Invoke(Sub() PictureBox2.Image = DirectCast(eventArgs.Frame.Clone(), Drawing.Image))
            End If
        Catch ex As Exception
            ' Handle any exceptions here
            BunifuTextBox1.Invoke(Sub() BunifuTextBox1.Text = "")
        End Try
    End Sub

    Private Sub BunifuTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BunifuTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If BunifuTextBox1.Text = "" Then
                MsgBox("Please scan QR CODE!", MsgBoxStyle.Critical)
            Else
                BunifuButton1.PerformClick()
            End If
        End If
    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged
        BunifuTextBox1.UseSystemPasswordChar = True
    End Sub

    Private Sub p1_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        If BunifuTextBox1.Text = "" Then
            MsgBox("Please scan QR CODE!", MsgBoxStyle.Critical)
        Else
            Dim rfid As String = BunifuTextBox1.Text

            ' Connect to MongoDB Atlas
            Dim connectionString As String = "mongodb+srv://jasondionanao87:Pogiakoxd123@cluster0.kzbqdga.mongodb.net/"
            Dim client As New MongoClient(connectionString)
            Dim database As IMongoDatabase = client.GetDatabase("Joyicedb")
            Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("admin")

            ' Create a filter for username and password
            Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.And(
        Builders(Of BsonDocument).Filter.Regex("qr", New BsonRegularExpression(rfid, "i")) ' "i" for case-insensitive matching
    )


            ' Execute the query
            Dim result As BsonDocument = collection.Find(filter).FirstOrDefault()

            If result IsNot Nothing Then

                ' Login successful
                MessageBox.Show("Login successful!")
                Form3.Show()
                Me.Hide()
            Else
                ' Login failed
                MsgBox("Invalid QR Code!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        BunifuTextBox1.Clear()
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