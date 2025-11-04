
Public Class token

    Private Sub token_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call cambiar_claves()

        TimerToken.Interval = 60000
        TimerToken.Start()
        TimerConteo.Start()

    End Sub



    Private Sub TimerToken_Tick(sender As Object, e As EventArgs) Handles TimerToken.Tick

        Call cambiar_claves()

    End Sub

    Dim contador As Integer = 0

    Private Sub cambiar_claves()



        Dim rand As New Random()

        Try
            Dim clave_1 As Integer = rand.Next(100, 999999)
            Dim clave_2 As Integer = rand.Next(200, 999999)
            Dim clave_3 As Integer = rand.Next(300, 999999)
            Dim clave_4 As Integer = rand.Next(400, 999999)
            Dim clave_5 As Integer = rand.Next(500, 999999)
            Dim clave_6 As Integer = rand.Next(600, 999999)
            Dim clave_7 As Integer = rand.Next(700, 999999)
            Dim clave_8 As Integer = rand.Next(800, 999999)
            Dim clave_9 As Integer = rand.Next(900, 999999)
            Dim clave_10 As Integer = rand.Next(1, 999999)


            Me.LB_CLAVE_1.Text = get_string_clave(clave_1)
            Me.LB_CLAVE_2.Text = get_string_clave(clave_2)
            Me.LB_CLAVE_3.Text = get_string_clave(clave_3)
            Me.LB_CLAVE_4.Text = get_string_clave(clave_4)
            Me.LB_CLAVE_5.Text = get_string_clave(clave_5)
            Me.LB_CLAVE_6.Text = get_string_clave(clave_6)
            Me.LB_CLAVE_7.Text = get_string_clave(clave_7)
            Me.LB_CLAVE_8.Text = get_string_clave(clave_8)
            Me.LB_CLAVE_9.Text = get_string_clave(clave_9)
            Me.LB_CLAVE_10.Text = get_string_clave(clave_10)


        Catch ex As Exception

        End Try
    End Sub

    Private Function get_string_clave(ByVal clave As Integer) As String
        Dim str As String = ""

        Select Case CType(clave.ToString.Length, Integer)
            Case 1
                str = "00000" + clave.ToString
            Case 2
                str = "0000" + clave.ToString
            Case 3
                str = "000" + clave.ToString
            Case 4
                str = "00" + clave.ToString
            Case 5
                str = "0" + clave.ToString
            Case 6
                str = clave.ToString
        End Select

        Return str


    End Function

    Private Sub TimerConteo_Tick(sender As Object, e As EventArgs) Handles TimerConteo.Tick

        contador = contador + 1
        Me.lbTimer.Text = contador
        If contador = 60 Then contador = 0

    End Sub
End Class