Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace DXPivotGrid_SplittingCells
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub rbDefault_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If pivotGridControl1 Is Nothing Then
				Return
			End If
			pivotGridControl1.LayoutChanged()
        End Sub
        Private Sub pivotGridControl1_CustomFieldValueCells(ByVal sender As Object, _
                                                    ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGridControl1.DataSource Is Nothing Then
                Return
            End If
            If rbDefault.IsChecked = True Then
                Return
            End If

            ' Creates a predicate that returns true for the Grand Total
            ' headers, and false for any other column/row header.
            ' Only cells that match this predicate are split.
            Dim condition As New Predicate(Of FieldValueCell)(AddressOf AnonymousMethod1)

            ' Creates a list of cell definitions that represent newly created cells.
            ' Two definitions are added to the list. The first one identifies
            ' the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            ' data field headers). The second one identifies the Count cell with 
            ' one nested cell (the Quantity data field header).
            Dim cells As New List(Of FieldValueSplitData)(2)
            cells.Add(New FieldValueSplitData("Price", 2))
            cells.Add(New FieldValueSplitData("Count", 1))

            ' Performs splitting.
            e.Split(True, condition, cells)
        End Sub
        Private Function AnonymousMethod1(ByVal matchCell As FieldValueCell) As Boolean
            Return matchCell.ValueType = FieldValueType.GrandTotal AndAlso _
                matchCell.Field Is Nothing
        End Function
        Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            PivotHelper.FillPivot(pivotGridControl1)
            pivotGridControl1.DataSource = PivotHelper.GetData()
            pivotGridControl1.BestFit()
        End Sub
        Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, _
                                                            ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Value Is Nothing Then
                Return
            End If
            If Object.ReferenceEquals(e.Field, pivotGridControl1.Fields(PivotHelper.Month)) Then
                e.DisplayText = _
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
            End If
        End Sub
	End Class
End Namespace
