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

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler Me.AssociatedObject.ItemsSourceChanged, AddressOf AssociatedObject_ItemsSourceChanged
            AddHandler Me.AssociatedObject.Loaded, AddressOf AssociatedObject_Loaded
        End Sub

        Private Sub AssociatedObject_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            Dim collection = Me.AssociatedObject.ItemsSource
            Me.AssociatedObject.ItemsSource = Nothing
            Me.AssociatedObject.ItemsSource = collection
            If (TryCast(Me.AssociatedObject.View, TableView)) IsNot Nothing Then
                TryCast(Me.AssociatedObject.View, TableView).BestFitColumns()
            End If
        End Sub

        Protected Overrides Sub OnDetaching()
            Me.UnSubscribeCollectionChanged(Me.AssociatedObject.ItemsSource)
            Me.UnSubscribeItemChanged(Me.AssociatedObject.ItemsSource)
            RemoveHandler Me.AssociatedObject.ItemsSourceChanged, AddressOf AssociatedObject_ItemsSourceChanged
            RemoveHandler Me.AssociatedObject.Loaded, AddressOf AssociatedObject_Loaded
            MyBase.OnDetaching()
        End Sub

        Private Sub AssociatedObject_ItemsSourceChanged(ByVal sender As Object, ByVal e As ItemsSourceChangedEventArgs)
            If e.OldItemsSource IsNot Nothing Then
                UnSubscribeItemChanged(e.OldItemsSource)
                UnSubscribeCollectionChanged(e.OldItemsSource)
            End If
            If e.NewItemsSource IsNot Nothing Then
                SubscribeItemChanged(e.NewItemsSource)
                SubscribeCollectionChanged(e.NewItemsSource)
            End If
            If (TryCast(Me.AssociatedObject.View, TableView)) IsNot Nothing Then
                TryCast(Me.AssociatedObject.View, TableView).BestFitColumns()
            End If
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
            Next obj
        End Sub

        Public Sub UnSubscribeItemChanged(ByVal source As Object)
            Dim collection = TryCast(source, IList)
            For Each obj As Object In collection
                Dim castObject = TryCast(obj, INotifyPropertyChanged)
                If castObject IsNot Nothing Then
                    RemoveHandler castObject.PropertyChanged, AddressOf castObject_PropertyChanged
                End If
            Next obj
        End Sub

        Private Sub notifyCollection_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.NewItems IsNot Nothing Then
                SubscribeItemChanged(e.NewItems)
            End If
            If e.OldItems IsNot Nothing Then
                UnSubscribeItemChanged(e.OldItems)
            End If
            TryCast(Me.AssociatedObject.View, TableView).BestFitColumns()
        End Sub


        Private Sub castObject_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            TryCast(Me.AssociatedObject.View, TableView).BestFitColumns()
        End Sub
    End Class
End Namespace
