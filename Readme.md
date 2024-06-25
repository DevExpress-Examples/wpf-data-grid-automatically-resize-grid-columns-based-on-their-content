<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648085/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2042)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GridControlFitBehavior.cs](./CS/GridControlFitBehavior.cs) (VB: [GridControlFitBehavior.vb](./VB/GridControlFitBehavior.vb))
* **[MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [Task.cs](./CS/Task.cs) (VB: [Task.vb](./VB/Task.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->
# How to allow columns to fit their content after changing or modifying GridControl's ItemSource


<p>This example demonstrates how to allow columns to fit their content after changing or modifying GridControl's ItemSource.<br />To provide this capability in this sample, we iterate through GridControl's ItemsSource collection and subscribe to the PropertyChanged event of each item in this collection. Then we subscribe to GridControl's ItemsSourceChanged event, get GridControl's ItemsSource collection and subscribe to its CollectionChanged event. When one of these events is raised, we call TableView's BestFitColumns method. Please note that GridControl's ItemsSource collection must support the INotifyCollectionChanged interface and each item in this collection must support the INotifyPropertyChanged interface.<br /><br /><br /><strong>UPDATED:<br /></strong></p>
<p>All the required event subscriptions and the corresponding event handlers are encapsulated into the custom Behavior class descendant. </p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-automatically-resize-grid-columns-based-on-their-content&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-automatically-resize-grid-columns-based-on-their-content&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
