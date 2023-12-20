Public Class superadmin

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
        BunifuTextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If BunifuTextBox1.Text = "admin" And BunifuTextBox2.Text = "admin" Then
            MsgBox("Succesfully!", vbOKOnly)
            BunifuTextBox1.Clear()
            BunifuTextBox2.Clear()
            admin1.Show()
            Me.Hide()

        ElseIf BunifuTextBox1.Text = "" Or BunifuTextBox2.Text = "" Then
            MsgBox("Incorrect!", vbOKOnly)
        Else
            MsgBox("You are not SuperAdmin!", vbOKOnly)
        End If
    End Sub
End Class