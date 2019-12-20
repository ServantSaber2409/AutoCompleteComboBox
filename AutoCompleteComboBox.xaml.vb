Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes


''' <summary>
''' Control de Usuario para AutoCompleteComboBox
''' </summary>
''' <remarks>Utilizada para Generar el control de usuario</remarks>
Partial Public Class AutoCompleteComboBox
    Inherits UserControl

#Region "DependencyProperty de Control"
    ''' <summary>
    ''' DependencyProperty para la fuente de Datos que llenará el <see cref="ListBox"/>
    ''' </summary>
    ''' <remarks>Utilizado para almacenar los datos</remarks>
    Public Shared ReadOnly ItemSourceProperty As DependencyProperty = DependencyProperty.Register("ItemsSource", GetType(List(Of IAutoCompleteSource)), GetType(AutoCompleteComboBox), New PropertyMetadata(New List(Of IAutoCompleteSource)))
    ''' <summary>
    ''' DependencyProperty para cuando se selecciona un dato del <see cref="ListBox"/>
    ''' </summary>
    ''' <remarks>Es el valor del <see cref="ListBoxItem"/> dentro del <see cref="ListBox"/></remarks>
    Public Shared ReadOnly SelectedValueProperty As DependencyProperty = DependencyProperty.Register("SelectedValue", GetType(Integer), GetType(AutoCompleteComboBox), New PropertyMetadata(0))
    ''' <summary>
    ''' DependencyProperty para agregar el <see cref="Style"/> al <see cref="ListBox"/>
    ''' </summary>
    ''' <remarks>Se Utiliza para agregrar estilos al <see cref="Button"/></remarks>
    Public Shared ReadOnly ListBoxStyleProperty As DependencyProperty = DependencyProperty.Register("ListBoxStyle", GetType(Style), GetType(AutoCompleteComboBox), New FrameworkPropertyMetadata(Nothing, AddressOf PropertyChangedCallback))
    ''' <summary>
    ''' DependencyProperty para realizar el tipo de búsqueda.
    ''' </summary>
    ''' <remarks>Se Utiliza para almacenar los tipos de búsqueda</remarks>
    Public Shared ReadOnly SearchTypeProperty As DependencyProperty = DependencyProperty.Register("SearchTypeContent", GetType(List(Of AutoCompleteSearchTypes)), GetType(AutoCompleteComboBox), New PropertyMetadata(New List(Of AutoCompleteSearchTypes)))
    ''' <summary>
    ''' DependencyProperty para agregar el <see cref="Style"/> al <see cref="Button"/>
    ''' </summary>
    ''' <remarks>Se Utiliza para agregrar estilos al <see cref="Button"/></remarks>
    Public Shared ReadOnly ButtonStyleProperty As DependencyProperty = DependencyProperty.Register("ButtonStyle", GetType(Style), GetType(AutoCompleteComboBox), New FrameworkPropertyMetadata(Nothing, AddressOf PropertyChangedCallback))
    ''' <summary>
    ''' DependencyProperty para agregar el <see cref="Style"/> al <see cref="TextBox"/>
    ''' </summary>
    '''<remarks>Se Utiliza para agregrar estilos al <see cref="Button"/></remarks>
    Public Shared ReadOnly TextBoxStyleProperty As DependencyProperty = DependencyProperty.Register("TextBoxStyle", GetType(Style), GetType(AutoCompleteComboBox), New FrameworkPropertyMetadata(Nothing, AddressOf PropertyChangedCallback))

#End Region

#Region "Variables Privadas Globales"
    ''' <summary>
    ''' Constante para Nombre de Usuario
    ''' </summary>
    Private Const _UserName As String = "UserName"
    ''' <summary>
    ''' Constante para Id
    ''' </summary>
    Private Const _Id As String = "Id"
#End Region


#Region "Eventos"
    ''' <summary>
    ''' Ejecuta el evento de cambio de Valor
    ''' </summary>
    ''' <param name="dependencyObject">Objeto de cambio</param>
    ''' <param name="e">evento que realiza el cambio</param>
    ''' <remarks>Este método se puede dejar así no necesita modificarse</remarks>
    Public Shared Sub PropertyChangedCallback(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
    End Sub

    ''' <summary>
    ''' Ejecuta el evento de cambio de Valor
    ''' </summary>
    ''' <param name="dependencyObject">Objeto de cambio</param>
    ''' <param name="e">evento que realiza el cambio</param>
    ''' <remarks>Este método se puede dejar así no necesita modificarse</remarks>
    Public Shared Sub PropertyChangedCallbackSearchType(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
    End Sub

    ''' <summary>
    ''' Evento para desplazamiento dentro del <see cref="ListBox"/>
    ''' </summary>
    ''' <param name="sender">Objecto que realizó el evento</param>
    ''' <param name="e">Tipo de Evento</param>
    Private Sub suggestionListBox_PreviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.Down Then
            If suggestionListBox.SelectedIndex < suggestionListBox.Items.Count Then suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex + 1
        End If

        If e.Key = Key.Up Then
            If suggestionListBox.SelectedIndex > -1 Then suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex - 1
        End If

        If e.Key = Key.Enter OrElse e.Key = Key.Tab Then
            suggestionListBox.Visibility = Visibility.Collapsed
            e.Handled = (e.Key = Key.Enter)
        End If

        If e.Key = Key.Escape Then
            suggestionListBox.ItemsSource = Nothing
            suggestionListBox.Visibility = Visibility.Collapsed
        End If
    End Sub

    ''' <summary>
    ''' Evento para la búsqueda de datos en la <see cref="ListBox"/>
    ''' </summary>
    ''' <param name="sender">Objeto que realizó el evento</param>
    ''' <param name="e">Tipo de Evento</param>
    Private Sub AutoTexBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        If autoTextBox.Text.Length > 0 Then
            Dim condition As String = String.Format("{0}", autoTextBox.Text)
            Dim result As List(Of IAutoCompleteSource) = Nothing

            For i As Integer = 0 To SearchTypeContent.Count - 1
                Dim temp As List(Of IAutoCompleteSource) = Nothing

                Select Case SearchTypeContent(i).SearchType
                    Case SearchType.UserName
                        temp = ItemsSource.Where(Function(x) x.UserName.Contains(condition)).ToList()

                        If result IsNot Nothing Then
                            result.AddRange(temp)
                        Else
                            result = temp
                        End If

                    Case SearchType.UserNet
                        temp = ItemsSource.Where(Function(x) x.UserNet.Contains(condition)).ToList()

                        If result IsNot Nothing Then
                            result.AddRange(temp)
                        Else
                            result = temp
                        End If
                End Select
            Next

            If result.Count() > 0 Then
                suggestionListBox.ItemsSource = result.Distinct()
                suggestionListBox.DisplayMemberPath = _UserName
                suggestionListBox.SelectedValue = _Id
                suggestionListBox.Visibility = Visibility.Visible
            Else
                suggestionListBox.Visibility = Visibility.Collapsed
                suggestionListBox.ItemsSource = Nothing
            End If
        Else
            suggestionListBox.Visibility = Visibility.Collapsed
            suggestionListBox.ItemsSource = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Evento para desplazamiento en el <see cref="TextBox"/>
    ''' </summary>
    ''' <param name="sender">Objeto que realizó el evento</param>
    ''' <param name="e">Tipo de Evento</param>
    Private Sub AutoTexBox_PreviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.Down Then
            If suggestionListBox.SelectedIndex < suggestionListBox.Items.Count Then suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex + 1
        End If

        If e.Key = Key.Up Then
            If suggestionListBox.SelectedIndex > -1 Then suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex - 1
        End If

        If e.Key = Key.Enter OrElse e.Key = Key.Tab Then
            suggestionListBox.Visibility = Visibility.Collapsed
            e.Handled = (e.Key = Key.Enter)
        End If

        If e.Key = Key.Escape Then
            suggestionListBox.ItemsSource = Nothing
            suggestionListBox.Visibility = Visibility.Collapsed
        End If
    End Sub

    ''' <summary>
    ''' Evento para la selección en el <see cref="ListBox"/>
    ''' </summary>
    ''' <param name="sender">Objeto que realizó el evento</param>
    ''' <param name="e">Tipo de envento</param>
    Private Sub SuggestionListBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        RemoveHandler autoTextBox.TextChanged, AddressOf AutoTexBox_TextChanged
        RemoveHandler suggestionListBox.PreviewKeyDown, AddressOf suggestionListBox_PreviewKeyDown

        If suggestionListBox.ItemsSource IsNot Nothing Then
            autoTextBox.Text = If(suggestionListBox.SelectedItem IsNot Nothing, (TryCast(suggestionListBox.SelectedItem, IAutoCompleteSource)).UserName, Nothing)
            SelectedValue = If(suggestionListBox.SelectedItem IsNot Nothing, (TryCast(suggestionListBox.SelectedItem, IAutoCompleteSource)).Id, 0)
        End If

        AddHandler autoTextBox.TextChanged, AddressOf AutoTexBox_TextChanged
        AddHandler suggestionListBox.PreviewKeyDown, AddressOf suggestionListBox_PreviewKeyDown
    End Sub

    ''' <summary>
    ''' Evento del <see cref="Button"/>
    ''' </summary>
    ''' <param name="sender">Objeto que realizó el evento</param>
    ''' <param name="e">Tipo de evento</param>
    Private Sub BtnAll_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If suggestionListBox.Visibility = Visibility.Collapsed Then
            suggestionListBox.ItemsSource = ItemsSource
            suggestionListBox.DisplayMemberPath = _UserName
            suggestionListBox.SelectedValue = _Id
            suggestionListBox.Visibility = Visibility.Visible
        Else
            suggestionListBox.Visibility = Visibility.Collapsed
        End If
    End Sub

    ''' <summary>
    ''' Evento para salir de la búsqueda.
    ''' </summary>
    ''' <param name="sender">Objeto que realizó el evento</param>
    ''' <param name="e">Tipo de evento</param>
    Private Sub Canvas_PreviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.Escape Then
            suggestionListBox.Visibility = Visibility.Collapsed
            autoTextBox.Text = ""
            suggestionListBox.SelectedIndex = -1
            SelectedValue = 0
        ElseIf e.Key = Key.Enter Then
            suggestionListBox.Visibility = Visibility.Collapsed
        End If
    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Obtiene o establece la Fuente de Datos para llenado del <see cref="ListBox"/>, mediante una <see cref="List(Of IAutoCompleteSource)"/>
    ''' </summary>
    ''' <value>Obtiene o establece la Fuente de Datos para llenado del <see cref="ListBox"/>, mediante una <see cref="List(Of IAutoCompleteSource)"/></value>
    ''' <remarks>Aquí se realiza la búsqueda</remarks>
    Public Property ItemsSource As List(Of IAutoCompleteSource)
        Set(ByVal value As List(Of IAutoCompleteSource))
            SetValue(ItemSourceProperty, value)
        End Set
        Get
            Return CType(GetValue(ItemSourceProperty), List(Of IAutoCompleteSource))
        End Get
    End Property

    ''' <summary>
    ''' Obtiene o establece el SelectedValue del la fuente de datos <see cref="ItemsSource"/>
    ''' </summary>
    ''' <value>Obtiene o establece el SelectedValue del la fuente de datos <see cref="ItemsSource"/></value>
    ''' <remarks>Valor de Seleccionado</remarks>
    Public Property SelectedValue As Integer
        Set(ByVal value As Integer)
            SetValue(SelectedValueProperty, value)
        End Set
        Get
            Return CInt(GetValue(SelectedValueProperty))
        End Get
    End Property

    ''' <summary>
    ''' Obtiene o establece el <see cref="Style"/> del <see cref="ListBox"/>
    ''' </summary>
    ''' <value>Obtiene o establece el <see cref="Style"/> del <see cref="ListBox"/></value>
    ''' <remarks>Hay que colocarlo en el XAML del control</remarks>
    Public Property ListBoxStyle As Style
        Get
            Return CType(GetValue(ListBoxStyleProperty), Style)
        End Get
        Set(ByVal value As Style)
            SetValue(ListBoxStyleProperty, value)
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el <see cref="Style"/> del <see cref="Button"/>
    ''' </summary>
    ''' <value>Obtiene o establece el <see cref="Style"/> del <see cref="Button"/></value>
    ''' <remarks>Hay que colocarlo en el XAML del control</remarks>
    Public Property ButtonStyle As Style
        Get
            Return CType(GetValue(ButtonStyleProperty), Style)
        End Get
        Set(ByVal value As Style)
            SetValue(ButtonStyleProperty, value)
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el <see cref="Style"/> para el <see cref="TextBox"/>
    ''' </summary>
    ''' <value>Obtiene o establece el <see cref="Style"/> para el <see cref="TextBox"/></value>
    ''' <remarks>Hay que colocarlo en el XAML del control</remarks>
    Public Property TextBoxStyle As Style
        Get
            Return CType(GetValue(TextBoxStyleProperty), Style)
        End Get
        Set(ByVal value As Style)
            SetValue(TextBoxStyleProperty, value)
        End Set
    End Property

    ''' <summary>
    ''' Obtiene o establece el tipo de búsqueda que se realizará en el <see cref="ItemsSource"/>
    ''' </summary>
    ''' <value> Obtiene o establece el tipo de búsqueda que se realizará en el <see cref="ItemsSource"/></value>
    ''' <remarks>Hay que colocarlo en el XAML del control</remarks>
    Public Property SearchTypeContent As List(Of AutoCompleteSearchTypes)
        Set(ByVal value As List(Of AutoCompleteSearchTypes))
            SetValue(SearchTypeProperty, value)
        End Set
        Get
            Return CType(GetValue(SearchTypeProperty), List(Of AutoCompleteSearchTypes))
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Inicializa un Control de Usuario para el AutoCompleteComboBox
    ''' </summary>
    ''' <remarks>Contructor del Control de Usuario</remarks>
    Public Sub New()
        InitializeComponent()
        AddHandler autoTextBox.TextChanged, AddressOf AutoTexBox_TextChanged
        AddHandler autoTextBox.PreviewKeyDown, AddressOf AutoTexBox_PreviewKeyDown
        AddHandler suggestionListBox.SelectionChanged, AddressOf SuggestionListBox_SelectionChanged
        AddHandler suggestionListBox.PreviewKeyDown, AddressOf suggestionListBox_PreviewKeyDown
        SearchTypeContent = New List(Of AutoCompleteSearchTypes)
    End Sub


End Class
