Imports System.IO
Public Class Form1
    Dim PressedKey(2) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PressedKey(0) = 0
        PressedKey(1) = 0
        ComboBox1.Items.AddRange(Ports.SerialPort.GetPortNames)
        ComboBox2.Items.AddRange(Ports.SerialPort.GetPortNames)

        Label3.Enabled = CheckBox1.Checked
        Label4.Enabled = CheckBox1.Checked
        Label5.Enabled = CheckBox1.Checked
        Label6.Enabled = CheckBox1.Checked
        TextBox3.Enabled = CheckBox1.Checked
        TextBox4.Enabled = CheckBox1.Checked
        TextBox5.Enabled = CheckBox1.Checked
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim window As CW_Config
        window = New CW_Config
        window.pressedkey1 = PressedKey(0)
        window.pressedkey2 = PressedKey(1)
        window.ShowDialog()
        PressedKey(0) = window.pressedkey1
        PressedKey(1) = window.pressedkey2
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.Focus()
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        endkey(PressedKey(0))
        endkey(PressedKey(1))
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If Button3.Text = "接続" Then
                SerialPort1.PortName = ComboBox1.SelectedItem
                SerialPort1.Open()
                Button3.Text = "切断"
            ElseIf Button3.Text = "切断" Then
                SerialPort1.Close()
                ComboBox1.Items.AddRange(Ports.SerialPort.GetPortNames)
                Button3.Text = "接続"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button2.PreviewKeyDown
        startkey(e.KeyValue)
        e.IsInputKey = True

        'MessageBox.Show(e.KeyCode.ToString + "+" + e.KeyData.ToString + "+" + e.KeyValue.ToString + "+" + e.Modifiers.ToString + "+")
    End Sub

    Private Sub Button2_MouseDown(sender As Object, e As MouseEventArgs) Handles Button2.MouseDown
        startkey(e.Button)
    End Sub
    Private Sub Button2_KeyUp(sender As Object, e As KeyEventArgs) Handles Button2.KeyUp
        endkey(e.KeyValue)

    End Sub

    Private Sub Button2_MouseUp(sender As Object, e As MouseEventArgs) Handles Button2.MouseUp
        endkey(e.Button)
    End Sub

    Private Sub startkey(code As Integer)
        If PressedKey(0) = code Then
            TextBox1.BackColor = Color.Red
            TextBox1.ForeColor = Color.White
            If RTS.Checked Then
                SerialPort1.RtsEnable = True
            ElseIf DTR.Checked Then
                SerialPort1.DtrEnable = True
            End If
        ElseIf PressedKey(1) = code Then
            TextBox2.BackColor = Color.Red
            TextBox2.ForeColor = Color.White
            If RTS.Checked Then
                SerialPort1.DtrEnable = True
            ElseIf DTR.Checked Then
                SerialPort1.RtsEnable = True
            End If
        End If
    End Sub
    Private Sub endkey(code As Integer)
        If PressedKey(0) = code Then
            TextBox1.BackColor = Color.White
            TextBox1.ForeColor = Color.Black
            If RTS.Checked Then
                SerialPort1.RtsEnable = False
            ElseIf DTR.Checked Then
                SerialPort1.DtrEnable = False
            End If
        ElseIf PressedKey(1) = code Then
            TextBox2.BackColor = Color.White
            TextBox2.ForeColor = Color.Black
            If RTS.Checked Then
                SerialPort1.DtrEnable = False
            ElseIf DTR.Checked Then
                SerialPort1.RtsEnable = False
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SerialPort1.Close()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            GroupBox1.Enabled = False
        ElseIf Not CheckBox2.Checked Then
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Label3.Enabled = CheckBox1.Checked
        Label4.Enabled = CheckBox1.Checked
        Label5.Enabled = CheckBox1.Checked
        Label6.Enabled = CheckBox1.Checked
        TextBox3.Enabled = CheckBox1.Checked
        TextBox4.Enabled = CheckBox1.Checked
        TextBox5.Enabled = CheckBox1.Checked
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Console.Beep(NumericUpDown1.Value, 1000)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If Button4.Text = "接続" Then
                SerialPort2.PortName = ComboBox2.SelectedItem
                SerialPort2.Open()
                Button4.Text = "切断"
            ElseIf Button4.Text = "切断" Then
                SerialPort2.Close()
                ComboBox2.Items.AddRange(Ports.SerialPort.GetPortNames)
                Button4.Text = "接続"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
