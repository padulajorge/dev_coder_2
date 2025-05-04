Imports System.Timers
Imports MySqlConnector

Public Class VentanaJuego
    Private codigoNivel As Integer = Globales.usuarioActual.getCodigoNivel() ' Obtener el nivel de código del usuario
    Private codigoSegmentos As New List(Of String) ' Lista para almacenar los segmentos de código
    Private acumulador As Integer = 0 ' Índice acumulativo para mostrar los segmentos
    Private WithEvents codigoTimer As New Timer(333) ' Temporizador de 1 segundo
    Private WithEvents guardarTimer As New Timer(60000) ' Temporizador de 1 minuto para guardar datos
    Private errorDeCompilacion As Boolean = False ' Estado de error de compilación
    Private segmentosDesordenados As New List(Of String) ' Lista para almacenar los segmentos desordenados
    Private segmentosOrdenados As New List(Of String) ' Lista para almacenar el orden correcto

    ' Colores para formatear el código
    Private colorPalabrasClave As Color = Color.Blue
    Private colorComentarios As Color = Color.Green
    Private colorStrings As Color = Color.Brown
    Private colorNumeros As Color = Color.DarkOrange
    Private colorOperadores As Color = Color.Purple
    Private colorTiposDatos As Color = Color.Teal
    Private colorNormal As Color = Color.Black
    Private colorError As Color = Color.Red
    Private colorMetodos As Color = Color.DarkCyan
    Private colorPreprocesador As Color = Color.Gray

    ' Diccionario de palabras clave por lenguaje
    Private palabrasClavePorLenguaje As New Dictionary(Of String, List(Of String)) From {
        {"VB", New List(Of String) From {
            "Imports", "Public", "Private", "Class", "Sub", "Function", "End", "Dim",
            "As", "New", "While", "For", "Next", "If", "Then", "Else", "ElseIf",
            "Select", "Case", "Return", "Integer", "String", "Boolean", "Date",
            "Double", "WithEvents", "Handles", "Me", "Get", "Set", "Try", "Catch",
            "Finally", "Throw", "Continue", "Exit", "Do", "Loop", "Until", "And",
            "Or", "Not", "Is", "Nothing", "True", "False", "Shared", "Static",
            "ByVal", "ByRef", "Optional", "ParamArray", "Inherits", "Implements",
            "Interface", "Module", "Namespace", "Partial", "Property", "ReadOnly",
            "WriteOnly", "Structure", "Type", "Using", "When", "With", "Yield"
        }},
        {"Java", New List(Of String) From {
            "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char",
            "class", "const", "continue", "default", "do", "double", "else", "enum",
            "extends", "final", "finally", "float", "for", "if", "implements", "import",
            "instanceof", "int", "interface", "long", "native", "new", "package", "private",
            "protected", "public", "return", "short", "static", "strictfp", "super", "switch",
            "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile",
            "while", "true", "false", "null"
        }},
        {"C++", New List(Of String) From {
            "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand", "bitor",
            "bool", "break", "case", "catch", "char", "char8_t", "char16_t", "char32_t",
            "class", "compl", "concept", "const", "consteval", "constexpr", "const_cast",
            "continue", "co_await", "co_return", "co_yield", "decltype", "default", "delete",
            "do", "double", "dynamic_cast", "else", "enum", "explicit", "export", "extern",
            "false", "float", "for", "friend", "goto", "if", "inline", "int", "long",
            "mutable", "namespace", "new", "noexcept", "not", "not_eq", "nullptr", "operator",
            "or", "or_eq", "private", "protected", "public", "register", "reinterpret_cast",
            "requires", "return", "short", "signed", "sizeof", "static", "static_assert",
            "static_cast", "struct", "switch", "template", "this", "thread_local", "throw",
            "true", "try", "typedef", "typeid", "typename", "union", "unsigned", "using",
            "virtual", "void", "volatile", "wchar_t", "while", "xor", "xor_eq"
        }}
    }

    ' Diccionario de tipos de datos por lenguaje
    Private tiposDatosPorLenguaje As New Dictionary(Of String, List(Of String)) From {
        {"VB", New List(Of String) From {
            "Integer", "String", "Boolean", "Date", "Double", "Single", "Long",
            "Short", "Byte", "Char", "Decimal", "Object", "Variant", "Array",
            "List", "Dictionary", "Collection", "Queue", "Stack"
        }},
        {"Java", New List(Of String) From {
            "boolean", "byte", "char", "double", "float", "int", "long", "short",
            "String", "Object", "Integer", "Double", "Float", "Long", "Short",
            "Byte", "Character", "Boolean", "List", "ArrayList", "LinkedList",
            "Map", "HashMap", "Set", "HashSet", "Queue", "Stack", "Vector"
        }},
        {"C++", New List(Of String) From {
            "bool", "char", "char8_t", "char16_t", "char32_t", "double", "float",
            "int", "long", "short", "void", "wchar_t", "string", "vector", "list",
            "map", "set", "queue", "stack", "array", "tuple", "pair", "auto"
        }}
    }

    ' Diccionario de operadores por lenguaje
    Private operadoresPorLenguaje As New Dictionary(Of String, List(Of String)) From {
        {"VB", New List(Of String) From {
            "+", "-", "*", "/", "\", "^", "&", "=", "<", ">", "<=", ">=", "<>",
            "And", "Or", "Not", "Xor", "Mod", "Like", "Is", "IsNot", "AndAlso",
            "OrElse", "AddressOf", "GetType", "TypeOf", "New"
        }},
        {"Java", New List(Of String) From {
            "+", "-", "*", "/", "%", "++", "--", "==", "!=", ">", "<", ">=", "<=",
            "&&", "||", "!", "&", "|", "^", "~", "<<", ">>", ">>>", "+=", "-=",
            "*=", "/=", "%=", "&=", "|=", "^=", "<<=", ">>=", ">>>=", "=", "?",
            ":", "instanceof", "new"
        }},
        {"C++", New List(Of String) From {
            "+", "-", "*", "/", "%", "++", "--", "==", "!=", ">", "<", ">=", "<=",
            "&&", "||", "!", "&", "|", "^", "~", "<<", ">>", "+=", "-=", "*=",
            "/=", "%=", "&=", "|=", "^=", "<<=", ">>=", "=", "?", ":", "::",
            ".*", "->*", "new", "delete", "sizeof", "typeid", "static_cast",
            "dynamic_cast", "const_cast", "reinterpret_cast"
        }}
    }

    ' Variable para el lenguaje actual
    Private lenguajeActual As String = "VB"

    Public Sub SetLenguaje(lenguaje As String)
        If palabrasClavePorLenguaje.ContainsKey(lenguaje) Then
            lenguajeActual = lenguaje
            FormatearCodigo()
        End If
    End Sub

    Private Sub VentanaJuego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuración inicial de los controles
        ConfigurarRichTextBox()
        ConfigurarDataGridView()
        ConfigurarConsola()
        MejorasGlobales()
        InicializarTreeView()
        CargarCodigo(codigoNivel)
        
        ' Configurar el temporizador para que se ejecute en el hilo de la UI
        AddHandler codigoTimer.Elapsed, AddressOf ActualizarCodigo
        codigoTimer.Start()
        
        guardarTimer.Start() ' Iniciar el temporizador de guardado

        ' Deshabilitar el botón de compilación inicialmente
        compilarBtn.Enabled = False

        ' Actualizar texto de los botones con nombre y costo de las mejoras
        ActualizarBotonesMejoras()
    End Sub

    Private Sub VentanaJuego_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Detener los temporizadores
        codigoTimer.Stop()
        guardarTimer.Stop()

        ' Guardar datos antes de cerrar
        GuardarDatosEnBaseDeDatos()
    End Sub

    Private Sub guardarTimer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles guardarTimer.Elapsed
        ' Guardar datos cada minuto
        GuardarDatosEnBaseDeDatos()
    End Sub

    Private Sub ConfigurarRichTextBox()
        ' Configurar el RichTextBox para mostrar código
        codigoRichTextBox.Font = New Font("Consolas", 10)
        codigoRichTextBox.WordWrap = False
        codigoRichTextBox.AcceptsTab = True
        codigoRichTextBox.ScrollBars = RichTextBoxScrollBars.Both
        codigoRichTextBox.BackColor = Color.White
        codigoRichTextBox.ForeColor = colorNormal
        codigoRichTextBox.DetectUrls = False
        codigoRichTextBox.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub ConfigurarDataGridView()
        ' Configurar el DataGridView para mejor visualización
        codigoDataGridView.AllowDrop = True
        codigoDataGridView.Font = New Font("Consolas", 10)
        codigoDataGridView.BorderStyle = BorderStyle.Fixed3D
        codigoDataGridView.RowHeadersVisible = False
        codigoDataGridView.ColumnHeadersVisible = False
        codigoDataGridView.AllowUserToAddRows = False
        codigoDataGridView.AllowUserToDeleteRows = False
        codigoDataGridView.AllowUserToResizeRows = False
        codigoDataGridView.AllowUserToResizeColumns = False
        codigoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        codigoDataGridView.MultiSelect = False
        codigoDataGridView.ReadOnly = True
        codigoDataGridView.BackgroundColor = Color.White
        codigoDataGridView.GridColor = Color.LightGray
        codigoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        codigoDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Configurar la columna única
        codigoDataGridView.Columns.Clear()
        Dim columna As New DataGridViewTextBoxColumn()
        columna.Name = "Codigo"
        columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        columna.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        codigoDataGridView.Columns.Add(columna)
    End Sub

    Private Sub ConfigurarConsola()
        ' Configurar el TextBox de consola
        consolaTextBox.Font = New Font("Consolas", 10)
        consolaTextBox.BackColor = Color.Black
        consolaTextBox.ForeColor = Color.White
        consolaTextBox.ReadOnly = True
        consolaTextBox.Multiline = True
        consolaTextBox.ScrollBars = ScrollBars.Vertical
        consolaTextBox.BorderStyle = BorderStyle.Fixed3D
        consolaTextBox.WordWrap = True
    End Sub

    Private Sub InicializarTreeView()
        TreeView1.Nodes.Clear()

        ' Nodo raíz
        Dim nodoRaiz As New TreeNode("Proyecto POO")
        TreeView1.Nodes.Add(nodoRaiz)

        ' Nodo para los bits del jugador
        Dim nodoBits As New TreeNode($"Bits: {Globales.usuarioActual.getBits()}")
        nodoRaiz.Nodes.Add(nodoBits)

        ' Agrupar mejoras por tipo
        Dim mejorasPorTipo = Globales.mejorasActuales.GroupBy(Function(m) m.getTipo)

        ' Crear nodos por tipo
        For Each grupo In mejorasPorTipo
            Dim nodoTipo As New TreeNode(grupo.Key) ' Nodo del tipo
            nodoRaiz.Nodes.Add(nodoTipo)

            ' Crear nodos por nombre dentro del tipo
            For Each mejora As Mejoras In grupo
                Dim nodoNombre As New TreeNode(mejora.getNombre) ' Nodo del nombre
                nodoTipo.Nodes.Add(nodoNombre)

                ' Crear nodo del nivel dentro del nombre
                Dim nodoNivel As New TreeNode($"Nivel: {mejora.getNivel}")
                nodoNombre.Nodes.Add(nodoNivel)
            Next
        Next
        TreeView1.ExpandAll() ' Expandir todos los nodos
    End Sub

    Private Sub ActualizarBitsTreeView()
        ' Buscar el nodo de bits
        If TreeView1.Nodes.Count > 0 AndAlso TreeView1.Nodes(0).Nodes.Count > 0 Then
            Dim nodoBits As TreeNode = TreeView1.Nodes(0).Nodes(0)
            nodoBits.Text = $"Bits: {Globales.usuarioActual.getBits()}"
        End If
    End Sub

    Private Sub MejorasGlobales()
        If Globales.usuarioActual.getId <= 0 Then
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
            Return
        End If
        Dim conn As MySqlConnection = Globales.conexion.Abrir()
        Dim query As String =
            "SELECT mejoras.nombre, mejoras.tipo, mj.nivel, mejoras.costo
            FROM mejoras_jugadores mj
            JOIN jugadores ON mj.jugador_id = jugadores.id
            JOIN mejoras ON mj.mejora_id = mejoras.id
            WHERE mj.jugador_id = @jugador_id;"
        Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@jugador_id", Globales.usuarioActual.getId())
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            Dim nombre As String = reader.GetString("nombre")
            Dim tipo As String = reader.GetString("tipo")
            Dim nivel As Integer = reader.GetInt32("nivel")
            Dim costo As Integer = reader.GetInt32("costo")
            Globales.mejorasActuales.Add(New Mejoras(nombre, tipo, nivel, costo))
        End While
        reader.Close()
    End Sub

    Private Sub CargarCodigo(nivel As Integer)
        ' Limpia las listas y el RichTextBox
        codigoSegmentos.Clear()
        segmentosDesordenados.Clear()
        segmentosOrdenados.Clear()
        codigoRichTextBox.Clear()
        codigoDataGridView.Rows.Clear()

        ' Conexión a la base de datos para obtener los segmentos del nivel actual
        Dim conn As MySqlConnection = Globales.conexion.Abrir()
        Dim query As String =
            "SELECT segmento, codigo FROM codigo WHERE nivel = @nivel AND lenguaje_id = @lenguaje_id ORDER BY segmento ASC;"
        Dim cmd As MySqlCommand = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@nivel", nivel)
        cmd.Parameters.AddWithValue("@lenguaje_id", Globales.usuarioActual.getPrestigio())
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dim codigo As String = reader.GetString("codigo")
            codigoSegmentos.Add(codigo)
            segmentosOrdenados.Add(codigo)
        End While

        reader.Close()
        conn.Close()
        
        ' Reinicia el acumulador
        acumulador = 0
        
        ' Actualizar el RichTextBox con el nuevo código
        ActualizarRichTextBox()
        FormatearCodigo()
    End Sub

    Private Sub ActualizarCodigo(sender As Object, e As ElapsedEventArgs)
        If Not errorDeCompilacion Then
            If acumulador < codigoSegmentos.Count Then
                Me.BeginInvoke(Sub()
                    ActualizarRichTextBox()
                    CalcularBitsPorBucles()
                    acumulador += 1
                End Sub)
            Else
                ' Verificar probabilidad de error (20%)
                Dim rnd As New Random()
                If rnd.Next(1, 101) <= 20 Then
                    Me.BeginInvoke(Sub() SimularErrorCompilacion())
                Else
                    ' Reinicia el proceso si no hay error
                    acumulador = 0
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarRichTextBox()
        ' Limpiar el RichTextBox
        codigoRichTextBox.Clear()

        ' Texto combinado hasta el índice actual
        Dim textoCombinado As String = ""

        ' Combinar todos los segmentos hasta el acumulador actual
        For i As Integer = 0 To Math.Min(acumulador, codigoSegmentos.Count - 1)
            textoCombinado &= codigoSegmentos(i) & vbCrLf
        Next

        ' Establecer el texto completo
        codigoRichTextBox.Text = textoCombinado

        ' Aplicar formato al código
        FormatearCodigo()

        ' Mover el cursor al final
        codigoRichTextBox.SelectionStart = codigoRichTextBox.TextLength
        codigoRichTextBox.ScrollToCaret()
    End Sub

    Private Sub FormatearCodigo()
        ' Guardar la posición actual del cursor
        Dim posicionCursor As Integer = codigoRichTextBox.SelectionStart
        Dim longitudSeleccion As Integer = codigoRichTextBox.SelectionLength

        ' Configurar el formato base
        codigoRichTextBox.SelectionStart = 0
        codigoRichTextBox.SelectionLength = codigoRichTextBox.TextLength
        codigoRichTextBox.SelectionFont = New Font("Consolas", 10)
        codigoRichTextBox.SelectionColor = colorNormal

        ' Formatear palabras clave
        For Each palabra In palabrasClavePorLenguaje(lenguajeActual)
            ResaltarPalabra(palabra, colorPalabrasClave)
        Next

        ' Formatear tipos de datos
        For Each tipo In tiposDatosPorLenguaje(lenguajeActual)
            ResaltarPalabra(tipo, colorTiposDatos)
        Next

        ' Formatear operadores
        For Each operador In operadoresPorLenguaje(lenguajeActual)
            ResaltarPalabra(operador, colorOperadores)
        Next

        ' Formatear números
        ResaltarNumeros()

        ' Formatear comentarios
        ResaltarComentarios()

        ' Formatear strings
        ResaltarStrings()

        ' Formatear métodos
        ResaltarMetodos()

        ' Formatear directivas de preprocesador (para C++)
        If lenguajeActual = "C++" Then
            ResaltarPreprocesador()
        End If

        ' Restaurar la posición del cursor y la selección
        codigoRichTextBox.SelectionStart = posicionCursor
        codigoRichTextBox.SelectionLength = longitudSeleccion
    End Sub

    Private Sub ResaltarPalabra(palabra As String, color As Color)
        Dim indiceInicio As Integer = 0
        Dim posicionActual As Integer = codigoRichTextBox.SelectionStart

        While indiceInicio < codigoRichTextBox.TextLength
            indiceInicio = codigoRichTextBox.Find(palabra, indiceInicio, RichTextBoxFinds.WholeWord)
            If indiceInicio = -1 Then Exit While

            codigoRichTextBox.SelectionStart = indiceInicio
            codigoRichTextBox.SelectionLength = palabra.Length
            codigoRichTextBox.SelectionColor = color

            indiceInicio += palabra.Length
        End While

        codigoRichTextBox.SelectionStart = posicionActual
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub ResaltarNumeros()
        Dim indiceInicio As Integer = 0
        Dim posicionActual As Integer = codigoRichTextBox.SelectionStart

        While indiceInicio < codigoRichTextBox.TextLength
            ' Buscar dígitos
            Dim indiceNumero As Integer = codigoRichTextBox.Text.IndexOfAny("0123456789".ToCharArray(), indiceInicio)
            If indiceNumero = -1 Then Exit While

            ' Verificar que el número no sea parte de una palabra
            If indiceNumero > 0 AndAlso Char.IsLetterOrDigit(codigoRichTextBox.Text(indiceNumero - 1)) Then
                indiceInicio = indiceNumero + 1
                Continue While
            End If

            ' Encontrar el final del número
            Dim indiceFin As Integer = indiceNumero
            While indiceFin < codigoRichTextBox.TextLength AndAlso Char.IsDigit(codigoRichTextBox.Text(indiceFin))
                indiceFin += 1
            End While

            ' Resaltar el número
            codigoRichTextBox.SelectionStart = indiceNumero
            codigoRichTextBox.SelectionLength = indiceFin - indiceNumero
            codigoRichTextBox.SelectionColor = colorNumeros

            indiceInicio = indiceFin
        End While

        codigoRichTextBox.SelectionStart = posicionActual
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub ResaltarMetodos()
        Dim indiceInicio As Integer = 0
        Dim posicionActual As Integer = codigoRichTextBox.SelectionStart

        While indiceInicio < codigoRichTextBox.TextLength
            ' Buscar paréntesis de apertura
            Dim indiceParentesis As Integer = codigoRichTextBox.Text.IndexOf("(", indiceInicio)
            If indiceParentesis = -1 Then Exit While

            ' Buscar el inicio del nombre del método
            Dim indiceInicioMetodo As Integer = indiceParentesis - 1
            While indiceInicioMetodo >= 0 AndAlso Char.IsLetterOrDigit(codigoRichTextBox.Text(indiceInicioMetodo))
                indiceInicioMetodo -= 1
            End While
            indiceInicioMetodo += 1

            ' Resaltar el nombre del método
            If indiceInicioMetodo < indiceParentesis Then
                codigoRichTextBox.SelectionStart = indiceInicioMetodo
                codigoRichTextBox.SelectionLength = indiceParentesis - indiceInicioMetodo
                codigoRichTextBox.SelectionColor = colorMetodos
            End If

            indiceInicio = indiceParentesis + 1
        End While

        codigoRichTextBox.SelectionStart = posicionActual
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub ResaltarComentarios()
        Dim lineas() As String = codigoRichTextBox.Text.Split(New String() {vbCrLf}, StringSplitOptions.None)
        Dim indiceActual As Integer = 0

        For Each linea As String In lineas
            Dim indiceComentario As Integer = linea.IndexOf("'")
            If indiceComentario >= 0 Then
                codigoRichTextBox.SelectionStart = indiceActual + indiceComentario
                codigoRichTextBox.SelectionLength = linea.Length - indiceComentario
                codigoRichTextBox.SelectionColor = colorComentarios
            End If
            indiceActual += linea.Length + 2
        Next

        codigoRichTextBox.SelectionStart = 0
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub ResaltarStrings()
        Dim indiceInicio As Integer = 0

        While indiceInicio < codigoRichTextBox.TextLength
            Dim indiceApertura As Integer = codigoRichTextBox.Text.IndexOf("""", indiceInicio)
            If indiceApertura = -1 Then Exit While

            Dim indiceCierre As Integer = codigoRichTextBox.Text.IndexOf("""", indiceApertura + 1)
            If indiceCierre = -1 Then Exit While

            codigoRichTextBox.SelectionStart = indiceApertura
            codigoRichTextBox.SelectionLength = indiceCierre - indiceApertura + 1
            codigoRichTextBox.SelectionColor = colorStrings

            indiceInicio = indiceCierre + 1
        End While

        codigoRichTextBox.SelectionStart = 0
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub ResaltarPreprocesador()
        Dim indiceInicio As Integer = 0
        Dim posicionActual As Integer = codigoRichTextBox.SelectionStart

        While indiceInicio < codigoRichTextBox.TextLength
            ' Buscar #
            Dim indiceGato As Integer = codigoRichTextBox.Text.IndexOf("#", indiceInicio)
            If indiceGato = -1 Then Exit While

            ' Encontrar el final de la línea
            Dim indiceFin As Integer = codigoRichTextBox.Text.IndexOf(vbCrLf, indiceGato)
            If indiceFin = -1 Then indiceFin = codigoRichTextBox.TextLength

            ' Resaltar la directiva
            codigoRichTextBox.SelectionStart = indiceGato
            codigoRichTextBox.SelectionLength = indiceFin - indiceGato
            codigoRichTextBox.SelectionColor = colorPreprocesador

            indiceInicio = indiceFin
        End While

        codigoRichTextBox.SelectionStart = posicionActual
        codigoRichTextBox.SelectionLength = 0
        codigoRichTextBox.SelectionColor = colorNormal
    End Sub

    Private Sub SimularErrorCompilacion()
        errorDeCompilacion = True
        codigoTimer.Stop()
        
        ' Crear una copia desordenada de los segmentos
        segmentosDesordenados = New List(Of String)(codigoSegmentos)
        Dim rnd As New Random()
        segmentosDesordenados = segmentosDesordenados.OrderBy(Function(x) rnd.Next()).ToList()

        ' Limpiar y llenar el DataGridView con los segmentos desordenados
        codigoDataGridView.Rows.Clear()
        For Each segmento In segmentosDesordenados
            ' Reemplazar saltos de línea por Environment.NewLine para consistencia
            Dim textoFormateado As String = segmento.Replace(vbCrLf, Environment.NewLine)
            codigoDataGridView.Rows.Add(textoFormateado)
        Next

        ' Ajustar la altura del DataGridView según la cantidad de elementos y su contenido
        AjustarAlturaDataGridView()

        ' Mostrar mensaje de error en la consola
        MostrarErrorConsola()

        ' Habilitar el botón de compilación
        compilarBtn.Enabled = True
    End Sub

    Private Sub MostrarErrorConsola()
        ' Generar un mensaje de error de compilación similar a una consola real
        Dim mensajeError As New System.Text.StringBuilder()
        Dim rnd As New Random()
        mensajeError.AppendLine("Compilando código...")
        mensajeError.AppendLine("Error de compilación detectado en línea " & rnd.Next(1, 50))
        mensajeError.AppendLine("Error: SyntaxError - Orden incorrecto de instrucciones")
        mensajeError.AppendLine("Detalles: Las instrucciones deben estar en el orden correcto para una ejecución adecuada")
        mensajeError.AppendLine("Sugerencia: Reordena las instrucciones para corregir el error")
        mensajeError.AppendLine("")
        mensajeError.AppendLine("Presiona 'Compilar' después de ordenar el código correctamente")

        consolaTextBox.Text = mensajeError.ToString()
    End Sub

    Private Sub AjustarAlturaDataGridView()
        ' Calcular la altura necesaria basada en la cantidad de elementos y su contenido
        Dim alturaTotal As Integer = 0
        For Each fila As DataGridViewRow In codigoDataGridView.Rows
            fila.Height = 22 ' Altura base
            ' Ajustar altura según el contenido
            Dim texto As String = fila.Cells(0).Value.ToString()
            Dim lineas As Integer = texto.Split(Environment.NewLine).Length
            If lineas > 1 Then
                fila.Height = 22 * lineas ' Aumentar altura según número de líneas
            End If
            alturaTotal += fila.Height
        Next

        ' Agregar espacio para el borde
        alturaTotal += 2
        codigoDataGridView.Height = Math.Min(alturaTotal, 400) ' Limitar altura máxima a 400
    End Sub

    Private Sub compilarBtn_Click(sender As Object, e As EventArgs) Handles compilarBtn.Click
        ' Verificar si el orden es correcto
        Dim ordenCorrecto As Boolean = True
        For i As Integer = 0 To codigoDataGridView.Rows.Count - 1
            If codigoDataGridView.Rows(i).Cells(0).Value.ToString() <> segmentosOrdenados(i) Then
                ordenCorrecto = False
                Exit For
            End If
        Next

        If ordenCorrecto Then
            ' Restaurar el estado normal
            errorDeCompilacion = False
            codigoTimer.Start()
            ' Limpiar el DataGridView y la consola
            codigoDataGridView.Rows.Clear()
            consolaTextBox.Clear()
            
            ' Asegurar que el RichTextBox muestre el código formateado
            ActualizarRichTextBox()
            FormatearCodigo()
            
            ' Deshabilitar el botón de compilación
            compilarBtn.Enabled = False
            
            MostrarMensajeConsola("Compilación exitosa: El código se ha ordenado correctamente." & vbCrLf &
                                "Procediendo con la ejecución...")
        Else
            ' Mostrar mensaje de error en la consola
            MostrarMensajeConsola("Error de compilación: El orden no es correcto." & vbCrLf &
                                "Por favor, revisa el orden de las instrucciones y vuelve a intentarlo.")
        End If
    End Sub

    Private Sub codigoDataGridView_MouseDown(sender As Object, e As MouseEventArgs) Handles codigoDataGridView.MouseDown
        Dim hit As DataGridView.HitTestInfo = codigoDataGridView.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 Then
            codigoDataGridView.DoDragDrop(codigoDataGridView.Rows(hit.RowIndex), DragDropEffects.Move)
        End If
    End Sub

    Private Sub codigoDataGridView_DragEnter(sender As Object, e As DragEventArgs) Handles codigoDataGridView.DragEnter
        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub codigoDataGridView_DragDrop(sender As Object, e As DragEventArgs) Handles codigoDataGridView.DragDrop
        Dim punto As Point = codigoDataGridView.PointToClient(New Point(e.X, e.Y))
        Dim hit As DataGridView.HitTestInfo = codigoDataGridView.HitTest(punto.X, punto.Y)
        Dim filaArrastrada As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)

        If filaArrastrada IsNot Nothing Then
            If hit.RowIndex >= 0 Then
                ' Insertar en la posición de destino
                Dim nuevaFila As DataGridViewRow = CType(filaArrastrada.Clone(), DataGridViewRow)
                For i As Integer = 0 To filaArrastrada.Cells.Count - 1
                    nuevaFila.Cells(i).Value = filaArrastrada.Cells(i).Value
                Next
                codigoDataGridView.Rows.Remove(filaArrastrada)
                codigoDataGridView.Rows.Insert(hit.RowIndex, nuevaFila)
            Else
                ' Si no hay fila destino, mover al final
                codigoDataGridView.Rows.Remove(filaArrastrada)
                codigoDataGridView.Rows.Add(filaArrastrada)
            End If
        End If
    End Sub

    Private Sub AplicarSangria()
        Dim lineas() As String = codigoRichTextBox.Text.Split(New String() {vbCrLf}, StringSplitOptions.None)
        Dim nivelSangria As Integer = 0
        Dim textoFormateado As New System.Text.StringBuilder()

        For Each linea As String In lineas
            ' Calcular el nivel de sangría
            If linea.Trim().StartsWith("End") OrElse
               linea.Trim().StartsWith("Next") OrElse
               linea.Trim().StartsWith("Loop") Then
                nivelSangria = Math.Max(0, nivelSangria - 1)
            End If

            ' Aplicar sangría
            textoFormateado.Append(New String(" "c, nivelSangria * 4))
            textoFormateado.AppendLine(linea.Trim())

            ' Ajustar nivel de sangría para la siguiente línea
            If linea.Trim().StartsWith("If") OrElse
               linea.Trim().StartsWith("For") OrElse
               linea.Trim().StartsWith("While") OrElse
               linea.Trim().StartsWith("Sub") OrElse
               linea.Trim().StartsWith("Function") OrElse
               linea.Trim().StartsWith("Class") Then
                nivelSangria += 1
            End If
        Next

        ' Aplicar el texto formateado
        codigoRichTextBox.Text = textoFormateado.ToString()
    End Sub

    Private Sub ActualizarBotonesMejoras()
        ' Obtener las mejoras actuales
        Dim mejoraEncapsulamiento = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Encapsulamiento")
        Dim mejoraClases = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Clases")
        Dim mejoraHerencia = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Herencia")
        Dim mejoraAgregacion = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Agregación")
        Dim mejoraAsociacion = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Asociación")
        Dim mejoraPolimorfismo = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Polimorfismo")

        ' Actualizar texto de los botones
        encapsulamientoBtn.Text = $"Encapsulamiento ({mejoraEncapsulamiento.getCosto()} bits)"
        clasesBtn.Text = $"Clases{vbCrLf}(costo: Encapsulamiento 10)"
        herenciaBtn.Text = $"Herencia{vbCrLf}(costo: Clases 10)"
        agregacionBtn.Text = $"Agregación{vbCrLf}(costo: Herencia 60)"
        asociacionBtn.Text = $"Asociación{vbCrLf}(costo: Agregación 600)"
        polimorfismoBtn.Text = "Polimorfismo (Acción especial)"

        ' Configurar alineación del texto para los botones
        clasesBtn.TextAlign = ContentAlignment.MiddleCenter
        herenciaBtn.TextAlign = ContentAlignment.MiddleCenter
        agregacionBtn.TextAlign = ContentAlignment.MiddleCenter
        asociacionBtn.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Private Sub encapsulamientoBtn_Click(sender As Object, e As EventArgs) Handles encapsulamientoBtn.Click
        ComprarMejora("Encapsulamiento", 1)
    End Sub

    Private Sub clasesBtn_Click(sender As Object, e As EventArgs) Handles clasesBtn.Click
        ComprarMejora("Clases", 2)
    End Sub

    Private Sub herenciaBtn_Click(sender As Object, e As EventArgs) Handles herenciaBtn.Click
        ComprarMejora("Herencia", 3)
    End Sub

    Private Sub agregacionBtn_Click(sender As Object, e As EventArgs) Handles agregacionBtn.Click
        ComprarMejora("Agregación", 4)
    End Sub

    Private Sub asociacionBtn_Click(sender As Object, e As EventArgs) Handles asociacionBtn.Click
        ComprarMejora("Asociación", 5)
    End Sub

    Private Sub polimorfismoBtn_Click(sender As Object, e As EventArgs) Handles polimorfismoBtn.Click
        ComprarMejora("Polimorfismo", 6)
    End Sub
    Private Sub MostrarMensajeConsola(mensaje As String)
        If consolaTextBox.InvokeRequired Then
            consolaTextBox.Invoke(Sub() consolaTextBox.Text = mensaje)
        Else
            consolaTextBox.Text = mensaje
        End If
    End Sub

    Private Sub ComprarMejora(nombreMejora As String, nivelRequerido As Integer)
        ' Verificar si hay un error de compilación activo
        If errorDeCompilacion Then
            MostrarMensajeConsola("Error: No puedes comprar mejoras mientras hay un error de compilación sin resolver." & vbCrLf & 
                                "Por favor, resuelve el error antes de continuar.")
            Return
        End If

        ' Verificar si el jugador tiene suficientes bits
        Dim mejoraActual As Mejoras = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = nombreMejora)
        If mejoraActual Is Nothing Then
            MostrarMensajeConsola("Error: Mejora no encontrada en el sistema.")
            Return
        End If

        ' Verificar requisitos según el nivel
        Select Case nivelRequerido
            Case 1 ' Encapsulamiento
                ' Solo requiere bits
                If Globales.usuarioActual.getBits() < mejoraActual.getCosto() Then
                    MostrarMensajeConsola("Error: Bits insuficientes." & vbCrLf & 
                                        $"Necesitas {mejoraActual.getCosto()} bits para comprar esta mejora.")
                    Return
                End If
            Case 2 ' Clases
                ' Requiere niveles de Encapsulamiento
                Dim mejoraEncapsulamiento = Globales.mejorasActuales.FirstOrDefault(
                    Function(m) m.getNombre() = "Encapsulamiento")
                
                If mejoraEncapsulamiento Is Nothing OrElse mejoraEncapsulamiento.getNivel() < 10 Then
                    MostrarMensajeConsola("Error: Requisitos no cumplidos." & vbCrLf & 
                                        "Necesitas tener 10 niveles en Encapsulamiento para comprar esta mejora.")
                    Return
                End If
            Case 3 ' Herencia
                ' Requiere niveles de Clases
                Dim mejoraClases = Globales.mejorasActuales.FirstOrDefault(
                    Function(m) m.getNombre() = "Clases")
                
                If mejoraClases Is Nothing OrElse mejoraClases.getNivel() < 10 Then
                    MostrarMensajeConsola("Error: Requisitos no cumplidos." & vbCrLf & 
                                        "Necesitas tener 10 niveles en Clases para comprar esta mejora.")
                    Return
                End If
            Case 4 ' Agregación
                ' Requiere niveles de Herencia
                Dim mejoraHerencia = Globales.mejorasActuales.FirstOrDefault(
                    Function(m) m.getNombre() = "Herencia")
                
                If mejoraHerencia Is Nothing OrElse mejoraHerencia.getNivel() < 60 Then
                    MostrarMensajeConsola("Error: Requisitos no cumplidos." & vbCrLf & 
                                        "Necesitas tener 60 niveles en Herencia para comprar esta mejora.")
                    Return
                End If
            Case 5 ' Asociación
                ' Requiere niveles de Agregación
                Dim mejoraAgregacion = Globales.mejorasActuales.FirstOrDefault(
                    Function(m) m.getNombre() = "Agregación")
                
                If mejoraAgregacion Is Nothing OrElse mejoraAgregacion.getNivel() < 600 Then
                    MostrarMensajeConsola("Error: Requisitos no cumplidos." & vbCrLf & 
                                        "Necesitas tener 600 niveles en Agregación para comprar esta mejora.")
                    Return
                End If
            Case 6 ' Polimorfismo
                ' Aún no implementado
                MostrarMensajeConsola("Información: Esta mejora requiere una acción especial para ser desbloqueada.")
                Return
        End Select

        Try
            Dim nivelesComprados As Integer = 0
            Dim costoTotal As Integer = 0
            Dim bitsDisponibles As Integer = Globales.usuarioActual.getBits()
            Dim nivelCodigoAnterior As Integer = Globales.usuarioActual.getCodigoNivel()

            ' Calcular cuántos niveles se pueden comprar
            Select Case nivelRequerido
                Case 1 ' Encapsulamiento
                    ' Calcular cuántos niveles se pueden comprar con los bits disponibles
                    Dim costoActual As Integer = mejoraActual.getCosto()
                    Dim incrementoBase As Integer = 1 ' Incremento base de 1 bit
                    
                    ' Calcular niveles máximos que se pueden comprar
                    While bitsDisponibles >= costoActual
                        nivelesComprados += 1
                        costoTotal += costoActual
                        bitsDisponibles -= costoActual
                        ' Nueva fórmula de incremento más gradual: costoActual + incrementoBase
                        costoActual += incrementoBase
                    End While
                    
                    ' Verificar si se alcanzó el límite de niveles
                    If nivelesComprados = 0 Then
                        MostrarMensajeConsola("Error: Bits insuficientes para comprar al menos un nivel.")
                        Return
                    End If
                    
                    ' Actualizar bits del jugador
                    Globales.usuarioActual.setBits(Globales.usuarioActual.getBits() - costoTotal)
                    
                    ' Actualizar nivel y costo de la mejora
                    mejoraActual.setNivel(mejoraActual.getNivel() + nivelesComprados)
                    mejoraActual.setCosto(costoActual) ' Guardar el costo actual para la próxima compra
                    
                    ' Actualizar TreeView inmediatamente
                    ActualizarTreeViewMejora(mejoraActual)
                    
                    MostrarMensajeConsola($"Compra exitosa: Adquiridos {nivelesComprados} niveles de {nombreMejora} por {costoTotal} bits")
                    
                Case 2 ' Clases
                    ' Calcular cuántos niveles se pueden comprar con los niveles de Encapsulamiento
                    Dim mejoraEncapsulamiento = Globales.mejorasActuales.FirstOrDefault(
                        Function(m) m.getNombre() = "Encapsulamiento")
                    nivelesComprados = mejoraEncapsulamiento.getNivel() \ 10
                    
                    ' Sumar los nuevos niveles a los existentes
                    mejoraActual.setNivel(mejoraActual.getNivel() + nivelesComprados)
                    mejoraActual.setCosto(10) ' Precio inicial de Clases
                    
                    ' Reducir niveles de Encapsulamiento
                    mejoraEncapsulamiento.setNivel(0)
                    mejoraEncapsulamiento.setCosto(10) ' Resetear al precio inicial
                    
                    ' Actualizar TreeView para ambas mejoras
                    ActualizarTreeViewMejora(mejoraActual)
                    ActualizarTreeViewMejora(mejoraEncapsulamiento)
                    
                Case 3 ' Herencia
                    ' Calcular cuántos niveles se pueden comprar con los niveles de Clases
                    Dim mejoraClases = Globales.mejorasActuales.FirstOrDefault(
                        Function(m) m.getNombre() = "Clases")
                    nivelesComprados = mejoraClases.getNivel() \ 10
                    
                    ' Sumar los nuevos niveles a los existentes
                    mejoraActual.setNivel(mejoraActual.getNivel() + nivelesComprados)
                    mejoraActual.setCosto(10) ' Precio inicial de Herencia
                    
                    ' Reducir niveles de Clases
                    mejoraClases.setNivel(0)
                    mejoraClases.setCosto(10) ' Resetear al precio inicial
                    
                    ' Actualizar TreeView para ambas mejoras
                    ActualizarTreeViewMejora(mejoraActual)
                    ActualizarTreeViewMejora(mejoraClases)
                    
                Case 4 ' Agregación
                    ' Calcular cuántos niveles se pueden comprar con los niveles de Herencia
                    Dim mejoraHerencia = Globales.mejorasActuales.FirstOrDefault(
                        Function(m) m.getNombre() = "Herencia")
                    nivelesComprados = mejoraHerencia.getNivel() \ 60
                    
                    ' Sumar los nuevos niveles a los existentes
                    mejoraActual.setNivel(mejoraActual.getNivel() + nivelesComprados)
                    mejoraActual.setCosto(10) ' Precio inicial de Agregación
                    
                    ' Reducir niveles de Herencia
                    mejoraHerencia.setNivel(0)
                    mejoraHerencia.setCosto(10) ' Resetear al precio inicial
                    
                    ' Actualizar TreeView para ambas mejoras
                    ActualizarTreeViewMejora(mejoraActual)
                    ActualizarTreeViewMejora(mejoraHerencia)
                    
                Case 5 ' Asociación
                    ' Calcular cuántos niveles se pueden comprar con los niveles de Agregación
                    Dim mejoraAgregacion = Globales.mejorasActuales.FirstOrDefault(
                        Function(m) m.getNombre() = "Agregación")
                    nivelesComprados = mejoraAgregacion.getNivel() \ 600
                    
                    ' Sumar los nuevos niveles a los existentes
                    mejoraActual.setNivel(mejoraActual.getNivel() + nivelesComprados)
                    mejoraActual.setCosto(10) ' Precio inicial de Asociación
                    
                    ' Reducir niveles de Agregación
                    mejoraAgregacion.setNivel(0)
                    mejoraAgregacion.setCosto(10) ' Resetear al precio inicial
                    
                    ' Actualizar TreeView para ambas mejoras
                    ActualizarTreeViewMejora(mejoraActual)
                    ActualizarTreeViewMejora(mejoraAgregacion)
            End Select

            ' Asignar el nivel de código según la mejora comprada
            If nivelesComprados > 0 Then
                Select Case nivelRequerido
                    Case 1 ' Encapsulamiento
                        Globales.usuarioActual.setCodigoNivel(1)
                    Case 2 ' Clases
                        Globales.usuarioActual.setCodigoNivel(2)
                    Case 3 ' Herencia
                        Globales.usuarioActual.setCodigoNivel(3)
                    Case 4 ' Agregación
                        Globales.usuarioActual.setCodigoNivel(4)
                    Case 5 ' Asociación
                        Globales.usuarioActual.setCodigoNivel(5)
                End Select

                ' Verificar si el nivel de código ha cambiado
                If Globales.usuarioActual.getCodigoNivel() > nivelCodigoAnterior Then
                    ' Recargar el código con el nuevo nivel
                    CargarCodigo(Globales.usuarioActual.getCodigoNivel())
                    ' Asegurar que el RichTextBox muestre el código formateado
                    ActualizarRichTextBox()
                    FormatearCodigo()
                End If
            End If

            ' Actualizar TreeView y botones
            ActualizarBitsTreeView()
            ActualizarBotonesMejoras()

        Catch ex As Exception
            MostrarMensajeConsola($"Error crítico: {ex.Message}" & vbCrLf & 
                                "Por favor, contacta al administrador del sistema.")
        End Try
    End Sub

    Private Sub ActualizarTreeViewMejora(mejora As Mejoras)
        ' Buscar el nodo de la mejora en el TreeView
        For Each nodoTipo As TreeNode In TreeView1.Nodes(0).Nodes
            If nodoTipo.Text = mejora.getTipo() Then
                For Each nodoNombre As TreeNode In nodoTipo.Nodes
                    If nodoNombre.Text = mejora.getNombre() Then
                        ' Actualizar el nivel en el nodo correspondiente
                        nodoNombre.Nodes(0).Text = $"Nivel: {mejora.getNivel()}"
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Private Sub GuardarDatosEnBaseDeDatos()
        Try
            Dim conn As MySqlConnection = Globales.conexion.Abrir()
            
            ' Actualizar datos del usuario
            Dim queryUsuario As String = "UPDATE estadisticas SET prestigio_lenguaje = @prestigio, bits = @bits, codigo_nivel = @codigo_nivel WHERE jugador_estadistica_id = @id"
            Dim cmdUsuario As MySqlCommand = New MySqlCommand(queryUsuario, conn)
            cmdUsuario.Parameters.AddWithValue("@prestigio", Globales.usuarioActual.getPrestigio())
            cmdUsuario.Parameters.AddWithValue("@bits", Globales.usuarioActual.getBits())
            cmdUsuario.Parameters.AddWithValue("@codigo_nivel", Globales.usuarioActual.getCodigoNivel())
            cmdUsuario.Parameters.AddWithValue("@id", Globales.usuarioActual.getId())
            cmdUsuario.ExecuteNonQuery()

            ' Actualizar niveles de mejoras
            For Each mejora In Globales.mejorasActuales
                Dim queryMejora As String = "UPDATE mejoras_jugadores SET nivel = @nivel WHERE jugador_id = @jugador_id AND mejora_id = (SELECT id FROM mejoras WHERE nombre = @nombre)"
                Dim cmdMejora As MySqlCommand = New MySqlCommand(queryMejora, conn)
                cmdMejora.Parameters.AddWithValue("@nivel", mejora.getNivel())
                cmdMejora.Parameters.AddWithValue("@jugador_id", Globales.usuarioActual.getId())
                cmdMejora.Parameters.AddWithValue("@nombre", mejora.getNombre())
                cmdMejora.ExecuteNonQuery()
            Next

            conn.Close()
        Catch ex As Exception
            MostrarMensajeConsola($"Error al guardar los datos: {ex.Message}")
        End Try
    End Sub

    Private Sub CalcularBitsPorBucles()
        ' Guardar bits antes de sumar
        Dim bitsAnteriores As Integer = Globales.usuarioActual.getBits()

        ' Calcular bits base por bucle
        Dim bitsTotales As Integer = 1

        System.Diagnostics.Debug.WriteLine($"Bits base por bucles: {bitsTotales}")

        ' Aplicar modificadores de mejoras
        Dim mejoraEncapsulamiento = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Encapsulamiento")
        Dim mejoraClases = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Clases")
        Dim mejoraHerencia = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Herencia")
        Dim mejoraAgregacion = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Agregación")
        Dim mejoraAsociacion = Globales.mejorasActuales.FirstOrDefault(Function(m) m.getNombre() = "Asociación")

        ' Aplicar multiplicadores según niveles de mejoras
        If mejoraEncapsulamiento IsNot Nothing Then
            bitsTotales *= (1 + mejoraEncapsulamiento.getNivel())
            System.Diagnostics.Debug.WriteLine($"Después de Encapsulamiento (nivel {mejoraEncapsulamiento.getNivel()}): {bitsTotales}")
        End If
        If mejoraClases IsNot Nothing Then
            bitsTotales *= (1 + mejoraClases.getNivel())
            System.Diagnostics.Debug.WriteLine($"Después de Clases (nivel {mejoraClases.getNivel()}): {bitsTotales}")
        End If
        If mejoraHerencia IsNot Nothing Then
            bitsTotales *= (1 + mejoraHerencia.getNivel())
            System.Diagnostics.Debug.WriteLine($"Después de Herencia (nivel {mejoraHerencia.getNivel()}): {bitsTotales}")
        End If
        If mejoraAgregacion IsNot Nothing Then
            bitsTotales *= (1 + mejoraAgregacion.getNivel())
            System.Diagnostics.Debug.WriteLine($"Después de Agregación (nivel {mejoraAgregacion.getNivel()}): {bitsTotales}")
        End If
        If mejoraAsociacion IsNot Nothing Then
            bitsTotales *= (1 + mejoraAsociacion.getNivel())
            System.Diagnostics.Debug.WriteLine($"Después de Asociación (nivel {mejoraAsociacion.getNivel()}): {bitsTotales}")
        End If

        System.Diagnostics.Debug.WriteLine($"Bits totales ganados: {bitsTotales}")

        ' Verificar si hay overflow al sumar los bits
        Try
            ' Intentar sumar los bits
            Dim nuevoTotal As Integer = Globales.usuarioActual.getBits() + bitsTotales
            If nuevoTotal < Globales.usuarioActual.getBits() Then
                ' Se produjo un overflow
                Throw New OverflowException()
            End If
            Globales.usuarioActual.setBits(nuevoTotal)
        Catch ex As OverflowException
            ' Detener el temporizador para evitar mensajes repetidos
            codigoTimer.Stop()

            ' Manejar el overflow
            MessageBox.Show("¡Felicidades! Has alcanzado el máximo nivel en este lenguaje. Avanzando al siguiente nivel de prestigio...", 
                          "Prestigio alcanzado", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Information)

            ' Reiniciar todos los niveles de mejoras
            For Each mejora In Globales.mejorasActuales
                mejora.setNivel(0)
                mejora.setCosto(10) ' Resetear al costo inicial
            Next

            ' Reiniciar bits y nivel de código
            Globales.usuarioActual.setBits(0)
            Globales.usuarioActual.setCodigoNivel(0)

            ' Aumentar el prestigio
            Globales.usuarioActual.setPrestigio(Globales.usuarioActual.getPrestigio() + 1)

            ' Guardar los cambios en la base de datos
            GuardarDatosEnBaseDeDatos()

            ' Limpiar y recargar todos los elementos del formulario
            TreeView1.Nodes.Clear() ' Limpiar explícitamente el TreeView
            Globales.mejorasActuales.Clear() ' Limpiar la lista de mejoras
            MejorasGlobales() ' Recargar las mejoras
            InicializarTreeView()
            CargarCodigo(0)
            ActualizarBotonesMejoras()

            ' Mostrar mensaje de nuevo prestigio
            MessageBox.Show($"¡Has alcanzado el prestigio {Globales.usuarioActual.getPrestigio()}! Comenzando una nueva etapa...", 
                          "Nuevo Prestigio", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Information)

            ' Reiniciar el temporizador después de todo el proceso
            codigoTimer.Start()
            Return
        End Try

        ' Actualizar TreeView y botones para mostrar los nuevos bits
        ActualizarBitsTreeView()
        ActualizarBotonesMejoras()

        ' Mostrar bits ganados en el nodo de bits
        If TreeView1.Nodes.Count > 0 AndAlso TreeView1.Nodes(0).Nodes.Count > 0 Then
            Dim nodoBits As TreeNode = TreeView1.Nodes(0).Nodes(0)
            nodoBits.Text = $"Bits: {Globales.usuarioActual.getBits()} (+{bitsTotales})"
        End If
    End Sub
End Class