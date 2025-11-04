Imports System.Data.SqlClient

Module General


    Public strHostConnectionString As String = "Data Source=sql5052.site4now.net;Initial Catalog=db_a6478c_onnebsync;User ID=db_a6478c_onnebsync_admin;Password=razors1805;MultipleActiveResultSets=True"
    Public cn_host As New SqlConnection


    Public strSqlConectionString As String = ""
    Public cn As New SqlConnection



    Public Sub cargar_conexion_archivo()
        Try
            Dim fic As String = Application.StartupPath + "\CONECTION.INI"
            Dim sr As New System.IO.StreamReader(fic)

            Dim sucursal As String = sr.ReadLine
            Dim server = sr.ReadLine()
            Dim dbs = sr.ReadLine()
            Dim user = sr.ReadLine()
            Dim pass = sr.ReadLine()
            sr.Close()

            strSqlConectionString = "Data Source=" & server & ";Initial Catalog=" & dbs & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"

            cn = New SqlConnection(strSqlConectionString)

        Catch ex As Exception
            MessageBox.Show("No existe CONECTION.INI, consulte a servicio técnico")
            End
        End Try
    End Sub




End Module
