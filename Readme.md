<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128578285/11.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3878)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_SplittingCells/MainPage.xaml) (VB: [MainPage.xaml](./VB/DXPivotGrid_SplittingCells/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DXPivotGrid_SplittingCells/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_SplittingCells/MainPage.xaml.vb))
<!-- default file list end -->
# How to split field value cells
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3878)**
<!-- run online end -->


<p>The following example demonstrates how to split field value cells.</p><p>In this example, the Grand Total column header is split into two cells: Price and Count. To do this, the CustomFieldValueCells event is handled, and the event parameter's Split method is used. Cells that should be split are identified by a predicate that returns true for those cells. The quantity, size and captions of newly created cells are specified by an array of cell definitions (the FieldValueSplitData objects).</p><br />


<br/>


