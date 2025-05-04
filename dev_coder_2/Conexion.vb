Imports MySqlConnector

Public Class Conexion
    Private conexion As MySqlConnection

    ' Cambia los datos según tu configuración
    Private cadenaConexion As String = "server=localhost;user=root;password=contraseña;database=dev"

    ' Constructor
    Public Sub New()
        conexion = New MySqlConnection(cadenaConexion)
    End Sub

    ' Método para abrir conexión
    Public Function Abrir() As MySqlConnection
        Dim nuevaConexion As New MySqlConnection(cadenaConexion)
        Try
            nuevaConexion.Open()
        Catch ex As MySqlException
            MessageBox.Show("Error al abrir la conexión: " & ex.Message)
        End Try
        Return nuevaConexion
    End Function

    ' Método para cerrar conexión
    Public Sub Cerrar()
        Try
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error al cerrar la conexión: " & ex.Message)
        End Try
    End Sub

    ' Obtener la conexión actual
    Public Function ObtenerConexion() As MySqlConnection
        Return conexion
    End Function
End Class