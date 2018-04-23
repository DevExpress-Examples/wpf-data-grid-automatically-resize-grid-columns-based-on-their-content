Imports DevExpress.Xpf.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Input

Namespace E2042
    Public Class ViewModel
        Implements INotifyPropertyChanged

        Public Sub New()
            Me.SetNewData()
            Me.ChangeItem = New DelegateCommand(AddressOf Me.ChangeItemExecute)
            Me.ChangeSource = New DelegateCommand(AddressOf Me.ChangeSourceExecute)
            Me.DeleteItem = New DelegateCommand(AddressOf Me.DeleteItemExecute)
            Me.AddNewItem = New DelegateCommand(AddressOf Me.AddNewItemExecute)
        End Sub

        Private _List As ObservableCollection(Of Task)
        Public Property List() As ObservableCollection(Of Task)
            Get
                Return _List
            End Get

            Set(ByVal value As ObservableCollection(Of Task))
                If Me._List IsNot value Then
                    Me._List = value
                    Me.OnPropertyChanged("List")
                End If

            End Set
        End Property

        Public Property ChangeSource() As ICommand
        Public Property AddNewItem() As ICommand
        Public Property DeleteItem() As ICommand
        Public Property ChangeItem() As ICommand

        Protected Sub ChangeSourceExecute()
            Me.SetNewData()
        End Sub

        Protected Sub AddNewItemExecute()
            If Me.List IsNot Nothing Then
                Me.List.Add(New Task() With {.Num = 0, .Name = "Additional New Item"})
            End If

        End Sub

        Protected Sub DeleteItemExecute()
            If Me.List IsNot Nothing AndAlso Me.List.Count > 0 Then
                Me.List.RemoveAt(Me.List.Count - 1)
            End If
        End Sub

        Protected Sub ChangeItemExecute()
            If Me.List IsNot Nothing AndAlso Me.List.Count > 0 Then
                Me.List(0).Num = 1000000000
            End If
        End Sub

        Protected Sub SetNewData()
            If Me.List Is Nothing Then
                List = New ObservableCollection(Of Task)()
            Else
                Me.List.Clear()
            End If
            For i As Integer = 0 To 19
                List.Add(New Task() With {.Num = i, .Name = "Name " & i * (i + 10), .IsCompleted = i Mod 2 = 0})
            Next i
        End Sub



        Public Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

End Namespace
