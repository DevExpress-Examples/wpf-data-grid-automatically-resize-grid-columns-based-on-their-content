Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text

Namespace E2042
    Public Class Task
        Implements INotifyPropertyChanged

        Private _Num As Integer
        Private _Name As String
        Private _IsCompleted As Boolean

        Public Property Num() As Integer
            Get
                Return _Num
            End Get
            Set(ByVal value As Integer)
                _Num = value
                NotifyPropertyChanged("Num")
            End Set
        End Property


        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
                NotifyPropertyChanged("Name")
            End Set
        End Property

        Public Property IsCompleted() As Boolean
            Get
                Return _IsCompleted
            End Get
            Set(ByVal value As Boolean)
                _IsCompleted = value
                NotifyPropertyChanged("IsCompleted")
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
