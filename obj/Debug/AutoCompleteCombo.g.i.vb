﻿#ExternalChecksum("..\..\AutoCompleteCombo.xaml","{ff1816ec-aa5e-4d10-87f7-6f4963833460}","5A2FE4FFC3AE60E41A17ED3F6E003003510DE5CF")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports AutoCompleteComboBoxVB
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''AutoCompleteComboBoxVB
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class AutoCompleteComboBoxVB
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\AutoCompleteCombo.xaml",11)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents autoTextBox As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\AutoCompleteCombo.xaml",12)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents btnAll As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\AutoCompleteCombo.xaml",14)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents suggestionListBox As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/AutoCompleteComboBoxVB;component/autocompletecombo.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\AutoCompleteCombo.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\AutoCompleteCombo.xaml",9)
            AddHandler CType(target,System.Windows.Controls.Canvas).PreviewKeyDown, New System.Windows.Input.KeyEventHandler(AddressOf Me.Canvas_PreviewKeyDown)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.autoTextBox = CType(target,System.Windows.Controls.TextBox)
            Return
        End If
        If (connectionId = 3) Then
            Me.btnAll = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\AutoCompleteCombo.xaml",12)
            AddHandler Me.btnAll.Click, New System.Windows.RoutedEventHandler(AddressOf Me.BtnAll_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            Me.suggestionListBox = CType(target,System.Windows.Controls.ListBox)
            
            #ExternalSource("..\..\AutoCompleteCombo.xaml",14)
            AddHandler Me.suggestionListBox.SelectionChanged, New System.Windows.Controls.SelectionChangedEventHandler(AddressOf Me.SuggestionListBox_SelectionChanged)
            
            #End ExternalSource
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

