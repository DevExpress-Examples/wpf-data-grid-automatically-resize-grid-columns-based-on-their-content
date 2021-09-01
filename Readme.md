<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648085/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2042)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
*Files to look at*:

* **[MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))**

# How to automatically resize grid columns based on their content

You can automatically change column widths based on their content by setting the [BaseColumn.Width](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.Width?v=20.1) property to `Auto`.

In this example, we apply a style to grid columns [implicitly](https://docs.microsoft.com/en-us/dotnet/desktop-wpf/fundamentals/styles-templates-create-apply-style#apply-a-style-implicitly) and set `Width` there:

```xml
<Window.Resources>
    <Style TargetType="dxg:GridColumn">
        <Setter Property="Width" Value="Auto" />
    </Style>
</Window.Resources>
```
