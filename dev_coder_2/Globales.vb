Imports MySqlConnector
Module Globales
    Public conexion As New Conexion()
    Public usuarioActual As Usuario
    Public mejorasActuales As List(Of Mejoras) = New List(Of Mejoras)()
    Public Class Usuario
        Private Property id As Integer
        Private Property nombre As String
        Private Property prestigio As Integer
        Private Property bits As Integer
        Private Property tiempoJugado As Integer
        Private Property mejorasTotales As Integer
        Private Property codigoNivel As Integer
        Public Sub New(id As Integer, nombre As String, prestigio As Integer, bits As Integer, tiempoJugado As Integer, mejorasTotales As Integer, codigoNivel As Integer)
            Me.id = id
            Me.nombre = nombre
            Me.prestigio = prestigio
            Me.bits = bits
            Me.tiempoJugado = tiempoJugado
            Me.mejorasTotales = mejorasTotales
            Me.codigoNivel = codigoNivel
        End Sub
        Public Function getId() As Integer
            Return id
        End Function
        Public Function getNombre() As String
            Return nombre
        End Function
        Public Function getPrestigio() As Integer
            Return prestigio
        End Function
        Public Function getBits() As Integer
            Return bits
        End Function
        Public Function getTiempoJugado() As Integer
            Return tiempoJugado
        End Function
        Public Function getMejorasTotales() As Integer
            Return mejorasTotales
        End Function
        Public Function getCodigoNivel() As Integer
            Return codigoNivel
        End Function
        Public Sub setId(id As Integer)
            Me.id = id
        End Sub
        Public Sub setNombre(nombre As String)
            Me.nombre = nombre
        End Sub
        Public Sub setPrestigio(prestigio As Integer)
            Me.prestigio = prestigio
        End Sub
        Public Sub setBits(bits As Integer)
            Me.bits = bits
        End Sub
        Public Sub setTiempoJugado(tiempoJugado As Integer)
            Me.tiempoJugado = tiempoJugado
        End Sub
        Public Sub setMejorasTotales(mejorasTotales As Integer)
            Me.mejorasTotales = mejorasTotales
        End Sub
        Public Sub setCodigoNivel(codigoNivel As Integer)
            Me.codigoNivel = codigoNivel
        End Sub
    End Class
    Public Class Mejoras
        Private Property nombre As String
        Private Property tipo As String
        Private Property nivel As Integer
        Private Property costo As Integer

        Public Sub New(nombre As String, tipo As String, nivel As Integer, costo As Integer)
            Me.nombre = nombre
            Me.tipo = tipo
            Me.nivel = nivel
            Me.costo = costo
        End Sub

        Public Function getNombre() As String
            Return nombre
        End Function
        Public Function getTipo() As String
            Return tipo
        End Function
        Public Function getNivel() As Integer
            Return nivel
        End Function
        Public Function getCosto() As Integer
            Return costo
        End Function
        Public Sub setNombre(nombre As String)
            Me.nombre = nombre
        End Sub
        Public Sub setTipo(tipo As String)
            Me.tipo = tipo
        End Sub
        Public Sub setNivel(nivel As Integer)
            Me.nivel = nivel
        End Sub
        Public Sub setCosto(costo As Integer)
            Me.costo = costo
        End Sub
    End Class
End Module
