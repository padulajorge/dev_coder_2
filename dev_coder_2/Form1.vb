Imports MySqlConnector

Public Class Form1
    Private Sub ingresarBtn_Click(sender As Object, e As EventArgs) Handles ingresarBtn.Click
        validarUsuario()
    End Sub

    Private Sub validarUsuario()
        Dim nombreJugador As String = jugadorTexBox.Text.Trim()
        If nombreJugador = "" Then
            MessageBox.Show("Por favor, ingresa un nombre de usuario.")
            Return
        End If

        Dim conn As MySqlConnection = Globales.conexion.Abrir()
        Dim query As String =
            "select count(*)
            from jugadores j
            where j.nombre = @nombre;"
        Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@nombre", nombreJugador)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        ' Verificar si el usuario existe
        If count > 0 Then
            Dim query2 As String =
                "select j.id, j.nombre, e.prestigio_lenguaje, e.bits, e.mejoras_totales, e.tiempo_jugado, e.codigo_nivel
                from estadisticas e
                inner join jugadores j on e.jugador_estadistica_id = j.id
                where j.nombre = @nombre"
            Dim cmd2 As MySqlCommand = New MySqlCommand(query2, conn)
            cmd2.Parameters.AddWithValue("@nombre", nombreJugador)
            Dim reader As MySqlDataReader = cmd2.ExecuteReader()
            If reader.Read() Then
                Dim id As Integer = reader.GetInt32(0)
                Dim nombre As String = reader.GetString(1)
                Dim prestigio As Integer = reader.GetInt32(2)
                Dim bits As Integer = reader.GetInt32(3)
                Dim mejorasTotales As Integer = reader.GetInt32(4)
                Dim tiempoJugado As Integer = reader.GetInt32(5)
                Dim codigoNivel As Integer = reader.GetInt32(6)
                ' Crear el objeto usuario y asignarlo a la variable global
                Globales.usuarioActual = New Globales.Usuario(id, nombre, prestigio, bits, tiempoJugado, mejorasTotales, codigoNivel)
                ' Mostrar mensaje de éxito
                Dim VentanaJuego As New VentanaJuego()
                VentanaJuego.Show()
                Me.Hide()
                AddHandler VentanaJuego.FormClosed, AddressOf VentanaJuego_Cerrar
            End If
            reader.Close()
        Else
            Dim result As DialogResult = MessageBox.Show("Usuario no encontrado. ¿Deseas crear un nuevo perfil con este nombre?", "Crear perfil", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                ' Si el usuario no existe, insertarlo en la base de datos
                Dim query3 As String =
                "insert into jugadores (nombre) values (@nombre);"
                Dim cmd3 As MySqlCommand = New MySqlCommand(query3, conn)
                cmd3.Parameters.AddWithValue("@nombre", nombreJugador)
                cmd3.ExecuteNonQuery()
                ' Obtener el ID del nuevo jugador
                Dim query4 As String =
                "select id from jugadores where nombre = @nombre;"
                Dim cmd4 As MySqlCommand = New MySqlCommand(query4, conn)
                cmd4.Parameters.AddWithValue("@nombre", nombreJugador)
                Dim reader2 As MySqlDataReader = cmd4.ExecuteReader()
                If reader2.Read() Then
                    Dim id As Integer = reader2.GetInt32(0)
                    ' Crear el objeto usuario y asignarlo a la variable global
                    Globales.usuarioActual = New Globales.Usuario(id, nombreJugador, 1, 0, 0, 0, 0)
                    ' Mostrar mensaje de éxito
                    Dim VentanaJuego As New VentanaJuego()
                    VentanaJuego.Show()
                    Me.Hide()
                    AddHandler VentanaJuego.FormClosed, AddressOf VentanaJuego_Cerrar
                End If
                reader2.Close()
            End If
        End If
        Globales.conexion.Cerrar()
    End Sub
    Private Sub VentanaJuego_Cerrar(sender As Object, e As FormClosedEventArgs)
        Application.Exit()
    End Sub
    Private Sub jugadorTexBox_KeyDown(sender As Object, e As KeyEventArgs) Handles jugadorTexBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            validarUsuario()
            e.SuppressKeyPress = True ' Evita el sonido de "ding" al presionar Enter
        End If
    End Sub
End Class
