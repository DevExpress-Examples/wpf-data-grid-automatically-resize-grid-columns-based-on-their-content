using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Mvvm.UI.Interactivity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace E2042 {

    public class GridControlFitBehavior : Behavior<GridControl>
    {

        protected GridControl Grid { get { return AssociatedObject; } }
        protected TableView View { get { return Grid.View as TableView; } }
        protected override void OnAttached()
        {
            base.OnAttached();
            if (Grid.ItemsSource != null)
            {
                SubscribeItemChanged(Grid.ItemsSource);
                SubscribeCollectionChanged(Grid.ItemsSource);
            }
            Grid.ItemsSourceChanged += ItemsSourceChanged;
            Grid.Loaded += Loaded;
        }

        void Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (View != null)
                View.BestFitColumns();
        }

        protected override void OnDetaching()
        {
            UnSubscribeCollectionChanged(Grid.ItemsSource);
            UnSubscribeItemChanged(Grid.ItemsSource);
            Grid.ItemsSourceChanged -= ItemsSourceChanged;
            Grid.Loaded -= Loaded;
            base.OnDetaching();
        }

        void ItemsSourceChanged(object sender, ItemsSourceChangedEventArgs e)
        {
            if (e.OldItemsSource != null)
            {
                UnSubscribeItemChanged(e.OldItemsSource);
                UnSubscribeCollectionChanged(e.OldItemsSource);
            }
            if (e.NewItemsSource != null)
            {
                SubscribeItemChanged(e.NewItemsSource);
                SubscribeCollectionChanged(e.NewItemsSource);
            }
            DoBestFit();
        }

        private void DoBestFit()
        {
            if (View != null)
                View.BestFitColumns();
        }

        public void SubscribeCollectionChanged(object source)
        {
            var notifyCollection = source as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged += notifyCollection_CollectionChanged;
            }
        }

        public void UnSubscribeCollectionChanged(object source)
        {
            var notifyCollection = source as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged -= notifyCollection_CollectionChanged;
            }
        }

        public void SubscribeItemChanged(object source)
        {
            var collection = source as IList;
            foreach (object obj in collection)
            {
                var castObject = obj as INotifyPropertyChanged;
                if (castObject != null)
                {
                    castObject.PropertyChanged += castObject_PropertyChanged;
                }
            }
        }

        public void UnSubscribeItemChanged(object source)
        {
            var collection = source as IList;
            foreach (object obj in collection)
            {
                var castObject = obj as INotifyPropertyChanged;
                if (castObject != null)
                {
                    castObject.PropertyChanged -= castObject_PropertyChanged;
                }
            }
        }

        void notifyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                SubscribeItemChanged(e.NewItems);
            if (e.OldItems != null)
                UnSubscribeItemChanged(e.OldItems);
            DoBestFit();
        }


        void castObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DoBestFit();
        }
    }
}
