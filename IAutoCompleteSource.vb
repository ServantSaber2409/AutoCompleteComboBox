
''' <summary>
''' Interface para estandarizar la entrada de datos al <see cref="AutoCompleteComboBox.ItemsSource"/>
''' </summary>
''' <remarks>Estándar para el <see cref="AutoCompleteComboBox.ItemsSource"/> del <see cref="AutoCompleteComboBox"/></remarks>
Public Interface IAutoCompleteSource
    ''' <summary>
    ''' Id de Usuario
    ''' </summary>
    ''' <value>ID usuario de NXM</value>
    ''' <remarks>Estandar para busqueda</remarks>
    Property Id As Integer
    ''' <summary>
    ''' Obtiene o establece el Nombre del Usuario
    ''' </summary>
    ''' <value>Nombre de Usuario de base de datos</value>
    ''' <remarks>Estandar para busqueda</remarks>
    Property UserName As String
    ''' <summary>
    ''' Obtiene o establece el Nombre de Red del Usuario
    ''' </summary>
    ''' <value>Usuario de RED</value>
    ''' <remarks>Estandar para busqueda</remarks>
    Property UserNet As String
End Interface

''' <summary>
''' Clase utilizada para llenar el <see cref="ListBox"/>
''' </summary>
''' <remarks>Usado para realizar pruebas, cada uno puede generar su propia clase, pero se debe de heredar de la interface <see cref="IAutoCompleteSource"/></remarks>
Public Class AutoCompleteComboBoxSource
    Implements IAutoCompleteSource

    Private _id As Integer
    Private _userName As String
    Private _userNet As String
    ''' <summary>
    ''' Inicializa una nueva clase de <see cref="AutoCompleteComboBoxSource"/>
    ''' </summary>
    ''' <param name="id">Id de Usuario</param>
    ''' <param name="userName">Nombre de Usuario</param>
    ''' <param name="userNet">Usuario de RED</param>
    ''' <remarks>Inicializa una nueva clase de <see cref="AutoCompleteComboBox"/> para llenar el <see cref="ListBox"/> del <see cref="AutoCompleteComboBox.ItemsSource"/></remarks>
    Public Sub New(id As Integer, userName As String, userNet As String)
        _id = id
        _userName = userName
        _userNet = userNet
    End Sub

    ''' <summary>
    ''' Id de Usuario
    ''' </summary>
    ''' <value>Id Usuario</value>
    ''' <remarks>Este ID es de base de datos y es el asignado para NXM</remarks>
    Public Property Id As Integer Implements IAutoCompleteSource.Id
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    ''' <summary>
    ''' Nombre del Usuario
    ''' </summary>
    ''' <value>Nombre de Usuario</value>
    ''' <remarks>Se toma de base de datos</remarks>
    Public Property UserName As String Implements IAutoCompleteSource.UserName
        Get
            Return _userName
        End Get
        Set(value As String)
            _userName = value
        End Set
    End Property

    ''' <summary>
    ''' Usuario de Red
    ''' </summary>
    ''' <value>Usuario de RED</value>
    ''' <remarks>Se toma de base de datos</remarks>
    Public Property UserNet As String Implements IAutoCompleteSource.UserNet
        Get
            Return _userNet
        End Get
        Set(value As String)
            _userNet = value
        End Set
    End Property
End Class

''' <summary>
''' Tipo de Búsqueda
''' </summary>
''' <remarks>Tipo de Búsqueda que realizará el control</remarks>
Public Enum SearchType
    ''' <summary>
    ''' Nombre de Usuario
    ''' </summary>
    UserName = 1
    ''' <summary>
    ''' Usuario de Red
    ''' </summary>
    UserNet = 2
End Enum

''' <summary>
''' Clase Utilizada para realizar el tipo de busqueda que realizará el control
''' </summary>
''' <remarks>Utilizado para agregar el nodo en el XAML</remarks>
Public Class AutoCompleteSearchTypes
    Private _searchType As SearchType

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase <see cref="AutoCompleteSearchTypes"/> 
    ''' </summary>
    ''' <remarks>Utilizada para búsqueda en <see cref="AutoCompleteComboBox.ItemsSource"/></remarks>
    Public Sub New()
        _searchType = SearchType.UserName
    End Sub

    ''' <summary>
    ''' Tipo de Búsqueda
    ''' </summary>
    ''' <value>Este valor se configura en XAML para realizar la búsqueda</value>
    ''' <remarks>Utilizado para búsqueda</remarks>
    Public Property SearchType As SearchType
        Get
            Return _searchType
        End Get
        Set(value As SearchType)
            _searchType = value
        End Set
    End Property
End Class
