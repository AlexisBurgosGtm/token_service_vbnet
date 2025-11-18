
Imports System.Data.SqlClient

Public Class token

    Dim bolConectado As Boolean = False
    Dim milisegundos_minuto As Integer = 60000


    Private Sub token_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Call cargar_conexion_archivo()

        Me.lbSistema.Text = tipo_sistema
        Me.lbMinutos.Text = minutos_sincronizar


        Call intentar_conexiones()

        Call cambiar_claves()


        TimerToken.Interval = minutos_sincronizar * milisegundos_minuto  '60000 
        TimerToken.Start()
        TimerConteo.Start()

        'Me.WindowState = FormWindowState.Minimized
        Me.Visible = False



    End Sub
    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        'Me.WindowState = FormWindowState.Maximized
        Me.Visible = True
    End Sub

    Private Sub intentar_conexiones()

        'conexion local
        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Me.lbConLocal.ForeColor = Color.Green
                Me.lbConLocal.Text = "Conectado..."
                bolConectado = True
            End Using
        Catch ex As Exception
            Me.lbConLocal.ForeColor = Color.Red
            Me.lbConLocal.Text = "Desconectado..."
            bolConectado = False
        End Try

        If bolConectado = False Then
            bolConectado = False
            Exit Sub
        End If
        'conexion remota
        Try
            Using cn_host As New SqlConnection(strHostConnectionString)
                If cn_host.State <> ConnectionState.Open Then
                    cn_host.Open()
                End If
                Me.lbConRemota.ForeColor = Color.Green
                Me.lbConRemota.Text = "Conectado..."
            End Using
        Catch ex As Exception
            Me.lbConRemota.ForeColor = Color.Red
            Me.lbConRemota.Text = "Desconectado..."
        End Try



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
            Dim clave_10 As Integer = rand.Next(1000, 999999)
            Dim clave_11 As Integer = rand.Next(150, 999999)
            Dim clave_12 As Integer = rand.Next(250, 999999)
            Dim clave_13 As Integer = rand.Next(350, 999999)
            Dim clave_14 As Integer = rand.Next(450, 999999)
            Dim clave_15 As Integer = rand.Next(550, 999999)
            Dim clave_16 As Integer = rand.Next(650, 999999)
            Dim clave_17 As Integer = rand.Next(750, 999999)
            Dim clave_18 As Integer = rand.Next(850, 999999)
            Dim clave_19 As Integer = rand.Next(950, 999999)
            Dim clave_20 As Integer = rand.Next(1050, 999999)


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

            If bolConectado = False Then Exit Sub

            If update_clave_host(GlobalEmpnit, Me.LB_CLAVE_1.Text, Me.LB_CLAVE_2.Text, Me.LB_CLAVE_3.Text, Me.LB_CLAVE_4.Text, Me.LB_CLAVE_5.Text) = True Then
                If update_clave_general(GlobalEmpnit, Me.LB_CLAVE_1.Text) = True Then

                Else

                End If
            Else

                End If

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
        Dim faltan As Integer = (minutos_sincronizar * 59) - contador
        Me.lbTimer.Text = faltan
        If contador = (minutos_sincronizar * 59) Then contador = 0

    End Sub



End Class