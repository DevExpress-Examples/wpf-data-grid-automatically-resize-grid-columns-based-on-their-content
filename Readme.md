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
