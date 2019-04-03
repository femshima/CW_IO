Imports Microsoft.VisualBasic.Devices
Public Class CW_Config
    Property pressedkey1 As Integer
    Property pressedkey2 As Integer
    Private Sub CW_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a1 As MouseButtons = pressedkey1
        Dim a2 As MouseButtons = pressedkey2
        Label1.Text = pressedkey1
        Label2.Text = pressedkey2
        If Not (a1 = 0 Or IsNothing(a1)) Then
            Label1.Text = a1.ToString
        End If
        If Not (a2 = 0 Or IsNothing(a2)) Then
            Label2.Text = a2.ToString
        End If
    End Sub
    Private Sub Button1_MouseClick(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        If RadioButton1.Checked Then
            Label1.Text = e.Button.ToString
            pressedkey1 = e.Button
        ElseIf RadioButton2.Checked Then
            Label2.Text = e.Button.ToString
            pressedkey2 = e.Button
        End If
    End Sub


    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.Focus()
    End Sub

    Private Sub Button1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button1.PreviewKeyDown
        If RadioButton1.Checked Then
            Label1.Text = e.KeyValue.ToString
            pressedkey1 = e.KeyValue
        ElseIf RadioButton2.Checked Then
            Label2.Text = e.KeyValue.ToString
            pressedkey2 = e.KeyValue
        End If
    End Sub
End Class