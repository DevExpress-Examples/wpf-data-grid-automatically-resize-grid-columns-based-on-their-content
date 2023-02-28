<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648085/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2042)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Automatically Resize Grid Columns Based on Their Content

Set the column's [Width](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.Width) property to `Auto` to make the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) automatically recalculate the optimal width for this column based on its visible content:

![image](https://user-images.githubusercontent.com/65009440/221838472-4471dd29-12e1-48c7-8abb-e9addc80c454.png)

This example contains the following [implicit style](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-create-apply-style#apply-a-style-implicitly) that applies the specified setting to all columns:

```xaml
<Window.Resources>
    <Style TargetType="dxg:GridColumn">
        <Setter Property="Width" Value="Auto"/>
    </Style>
</Window.Resources>
```

## Files to Review

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))

## Documentation

* [Move and Resize Columns](https://docs.devexpress.com/WPF/6296/controls-and-libraries/data-grid/grid-view-data-layout/columns-and-card-fields/move-and-resize-columns)
* [BaseColumn.Width](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.Width)

## More Examples

* [WPF Data Grid - Specify the Column's Relative Width](https://github.com/DevExpress-Examples/how-to-set-gridcolumns-relative-width-t155660)
