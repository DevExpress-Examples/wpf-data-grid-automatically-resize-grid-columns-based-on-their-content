<!-- default file list -->
*Files to look at*:

* [GridControlFitBehavior.cs](./CS/GridControlFitBehavior.cs) (VB: [GridControlFitBehavior.vb](./VB/GridControlFitBehavior.vb))
* **[MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))**
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [Task.cs](./CS/Task.cs) (VB: [Task.vb](./VB/Task.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->
# How to allow columns to fit their content after changing or modifying GridControl's ItemSource


<p>This example demonstrates how to allow columns to fit their content after changing or modifying GridControl's ItemSource.<br />To provide this capability in this sample, we iterate through GridControl's ItemsSource collection and subscribe to the PropertyChanged event of each item in this collection. Then we subscribe to GridControl's ItemsSourceChanged event, get GridControl's ItemsSource collection and subscribe to its CollectionChanged event. When one of these events is raised, we call TableView's BestFitColumns method. Please note that GridControl's ItemsSource collection must support the INotifyCollectionChanged interface and each item in this collection must support the INotifyPropertyChanged interface.<br /><br /><br /><strong>UPDATED:<br /></strong></p>
<p>All the required event subscriptions and the corresponding event handlers are encapsulated into the custom Behavior class descendant. </p>

<br/>


