Imports System.Data.SqlClient

Module General

    Public GlobalEmpnit As String = ""

    Public strHostConnectionString As String = "Data Source=sql5052.site4now.net;Initial Catalog=db_a6478c_onnebsync;User ID=db_a6478c_onnebsync_admin;Password=razors1805;MultipleActiveResultSets=True"
    Public cn_host As New SqlConnection


    Public strSqlConectionString As String = ""
    Public cn As New SqlConnection

    Public tipo_sistema As String = ""
    Public minutos_sincronizar As Integer = 0

    Public Sub cargar_conexion_archivo()
        Try
            Dim fic As String = Application.StartupPath + "\CONECTION.INI"
            Dim sr As New System.IO.StreamReader(fic)

            tipo_sistema = sr.ReadLine
            minutos_sincronizar = CType(sr.ReadLine, Integer)
            Dim sucursal As String = sr.ReadLine
            Dim server = sr.ReadLine()
            Dim dbs = sr.ReadLine()
            Dim user = sr.ReadLine()
            Dim pass = sr.ReadLine()
            sr.Close()

            strSqlConectionString = "Data Source=" & server & ";Initial Catalog=" & dbs & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"

            GlobalEmpnit = sucursal

            cn = New SqlConnection(strSqlConectionString)

        Catch ex As Exception
            MessageBox.Show("No existe CONECTION.INI, consulte a servicio técnico")
            End
        End Try
    End Sub


    Public Function update_clave_host(ByVal sucursal As String, ByVal clave1 As String, ByVal clave2 As String, ByVal clave3 As String, ByVal clave4 As String, ByVal clave5 As String) As Boolean

        Dim r As Boolean

        Dim qry As String = ""

        If tipo_sistema = "ONNE" Then
            qry = "
                    UPDATE 
                        COMMUNITY_EMPRESAS_SYNC
                    SET
                        TOKEN_CLAVE_1=@C,
                        TOKEN_CLAVE_2=@C
                    WHERE
                        EMPNIT=@E
            "
        Else 'isc
            qry = "
                UPDATE 
                    TOKEN_CLAVES
                SET CLAVE_1=@C1, CLAVE_2=@C2, CLAVE_3=@C3, CLAVE_4=@C4, CLAVE_5=@C5 
                WHERE EMPNIT=@E"
        End If


        Try
            Using cn_host As New SqlConnection(strHostConnectionString)
                If cn_host.State <> ConnectionState.Open Then
                    cn_host.Open()
                End If

                Dim cmd As New SqlCommand(qry, cn_host)
                cmd.Parameters.AddWithValue("@E", sucursal)
                cmd.Parameters.AddWithValue("@C1", clave1)
                cmd.Parameters.AddWithValue("@C2", clave2)
                cmd.Parameters.AddWithValue("@C3", clave3)
                cmd.Parameters.AddWithValue("@C4", clave4)
                cmd.Parameters.AddWithValue("@C5", clave5)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i <> 0 Then
                    r = True
                Else
                    r = False
                End If


            End Using
        Catch ex As Exception
            r = False
        End Try



        Return r

    End Function


    Public Function update_clave_general(ByVal sucursal As String, ByVal clave As String) As Boolean

        Dim r As Boolean

        Dim qry As String = ""

        If tipo_sistema = "ONNE" Then
            qry = "UPDATE CONFIG SET PASS=@C WHERE ID=2;"
        Else
            'ISC
            qry = "
                UPDATE 
                    EMPRESAS
                SET 
                    CLAVEMODPRECIOS=@C,
                    CLAVEANULAR=@C,
                    CLAVEELIMINAR=@C,
                    CLAVECIERRE=@C,
                    CLAVELIMCRE=@C,
                    CLAVEFECHA=@C,
                    CLAVEINVEX=@C,
                    CLAVEDESCUENTO=@C,
                    CLAVEDESCDOC=@C,
                    CLAVESALVENCLIE=@C,
                    CLAVECANTPEDIDA=@C,
                    CLAVECOSTOPRECIO=@C,
                    CLAVECODCAT=@C,
                    CLAVEPENENV=@C,
                    CLAVEINGCC=@C,
                    CLAVEEGRCC=@C,
                    CLAVEMESA=@C,
                    CLAVEELIPROD=@C,
                    CLAVEDOCSINSERIE=@C,
                    CLAVEDESACCORTE=@C,
                    CLAVECANTIDADEMPAQUE=@C,
                    CLAVEREIMPDOC=@C,
                    CLAVEMAXIMOBODEGA=@C,
                    CLAVEMODELIPROD=@C,
                    CLAVECANJEPUNTOS=@C,
                    CLAVEBODCANTIDAD=@C,
                    CLAVEBODVALOR=@C,
                    CLAVERECFAC=@C 
                WHERE 
                    EMP_NIT=@E"

        End If


        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@E", sucursal)
                cmd.Parameters.AddWithValue("@C", clave)

                Dim i As Integer = cmd.ExecuteNonQuery
                If i <> 0 Then
                    r = True
                Else
                    r = False
                End If


            End Using
        Catch ex As Exception
            r = False
        End Try



        Return r

    End Function


End Module
