Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.ObjectModel

Namespace E2042

    Public Class ViewModel
        Inherits ViewModelBase

        Public Sub New()
            SetNewData()
        End Sub

        Public Property List As ObservableCollection(Of Task)

        Public Sub SetNewData()
            If List Is Nothing Then
                List = New ObservableCollection(Of Task)()
            Else
                List.Clear()
            End If

            For i As Integer = 0 To 20 - 1
                List.Add(New Task() With {.Num = i, .Name = "Name " & i * (i + 10), .IsCompleted = i Mod 2 = 0})
            Next
        End Sub

        <Command>
        Public Sub ChangeSource()
            SetNewData()
        End Sub

        <Command>
        Public Sub ChangeItem()
            If List IsNot Nothing AndAlso List.Count > 0 Then
                List(0).Num = 1000000000
            End If
        End Sub

        <Command>
        Public Sub AddNewItem()
            If List IsNot Nothing Then
                List.Add(New Task() With {.Num = 0, .Name = "Additional New Item"})
            End If
        End Sub

        <Command>
        Public Sub DeleteItem()
            If List IsNot Nothing AndAlso List.Count > 0 Then
                List.RemoveAt(List.Count - 1)
            End If
        End Sub
    End Class
End Namespace
