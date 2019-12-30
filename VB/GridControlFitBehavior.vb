Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Mvvm.UI.Interactivity
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Linq
Imports System.Text

Namespace E2042

    Public Class GridControlFitBehavior
        Inherits Behavior(Of GridControl)

        Protected ReadOnly Property Grid As GridControl
            Get
                Return AssociatedObject
            End Get
        End Property

        Protected ReadOnly Property View As TableView
            Get
                Return TryCast(Grid.View, TableView)
            End Get
        End Property

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()

            If Grid.ItemsSource IsNot Nothing Then
                SubscribeItemChanged(Grid.ItemsSource)
                SubscribeCollectionChanged(Grid.ItemsSource)
            End If

            AddHandler Grid.ItemsSourceChanged, AddressOf ItemsSourceChanged
            AddHandler Grid.Loaded, AddressOf Loaded
        End Sub

        Private Sub Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            If View IsNot Nothing Then View.BestFitColumns()
        End Sub

        Protected Overrides Sub OnDetaching()
            UnSubscribeCollectionChanged(Grid.ItemsSource)
            UnSubscribeItemChanged(Grid.ItemsSource)
            RemoveHandler Grid.ItemsSourceChanged, AddressOf ItemsSourceChanged
            RemoveHandler Grid.Loaded, AddressOf Loaded
            MyBase.OnDetaching()
        End Sub

        Private Sub ItemsSourceChanged(ByVal sender As Object, ByVal e As ItemsSourceChangedEventArgs)
            If e.OldItemsSource IsNot Nothing Then
                UnSubscribeItemChanged(e.OldItemsSource)
                UnSubscribeCollectionChanged(e.OldItemsSource)
            End If

            If e.NewItemsSource IsNot Nothing Then
                SubscribeItemChanged(e.NewItemsSource)
                SubscribeCollectionChanged(e.NewItemsSource)
            End If

            DoBestFit()
        End Sub

        Private Sub DoBestFit()
            If View IsNot Nothing Then View.BestFitColumns()
        End Sub

        Public Sub SubscribeCollectionChanged(ByVal source As Object)
            Dim notifyCollection = TryCast(source, INotifyCollectionChanged)

            If notifyCollection IsNot Nothing Then
                AddHandler notifyCollection.CollectionChanged, AddressOf notifyCollection_CollectionChanged
            End If
        End Sub

        Public Sub UnSubscribeCollectionChanged(ByVal source As Object)
            Dim notifyCollection = TryCast(source, INotifyCollectionChanged)

            If notifyCollection IsNot Nothing Then
                RemoveHandler notifyCollection.CollectionChanged, AddressOf notifyCollection_CollectionChanged
            End If
        End Sub

        Public Sub SubscribeItemChanged(ByVal source As Object)
            Dim collection = TryCast(source, IList)

            For Each obj As Object In collection
                Dim castObject = TryCast(obj, INotifyPropertyChanged)

                If castObject IsNot Nothing Then
                    AddHandler castObject.PropertyChanged, AddressOf castObject_PropertyChanged
                End If
            Next
        End Sub

        Public Sub UnSubscribeItemChanged(ByVal source As Object)
            Dim collection = TryCast(source, IList)

            For Each obj As Object In collection
                Dim castObject = TryCast(obj, INotifyPropertyChanged)

                If castObject IsNot Nothing Then
                    RemoveHandler castObject.PropertyChanged, AddressOf castObject_PropertyChanged
                End If
            Next
        End Sub

        Private Sub notifyCollection_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then SubscribeItemChanged(e.NewItems)
            If e.OldItems IsNot Nothing Then UnSubscribeItemChanged(e.OldItems)
            DoBestFit()
        End Sub

        Private Sub castObject_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            DoBestFit()
        End Sub
    End Class

End Namespace
