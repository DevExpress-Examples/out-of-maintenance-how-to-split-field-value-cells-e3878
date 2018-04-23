using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace DXPivotGrid_SplittingCells {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
        private void rbDefault_Checked(object sender, RoutedEventArgs e) {
            if (pivotGridControl1 == null) return;
            pivotGridControl1.LayoutChanged();
        }
        private void pivotGridControl1_CustomFieldValueCells(object sender, 
            PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGridControl1.DataSource == null) return;
            if (rbDefault.IsChecked == true) return;

            // Creates a predicate that returns true for the Grand Total
            // headers, and false for any other column/row header.
            // Only cells that match this predicate are split.
            Predicate<FieldValueCell> condition =
                new Predicate<FieldValueCell>(delegate(FieldValueCell matchCell) {
                return matchCell.ValueType == FieldValueType.GrandTotal &&
                    matchCell.Field == null;
            });

            // Creates a list of cell definitions that represent newly created cells.
            // Two definitions are added to the list. The first one identifies
            // the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            // data field headers). The second one identifies the Count cell with 
            // one nested cell (the Quantity data field header).
            List<FieldValueSplitData> cells = new List<FieldValueSplitData>(2);
            cells.Add(new FieldValueSplitData("Price", 2));
            cells.Add(new FieldValueSplitData("Count", 1));

            // Performs splitting.
            e.Split(true, condition, cells);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetData();
            pivotGridControl1.BestFit();
        }
        private void pivotGridControl1_FieldValueDisplayText(object sender,
            PivotFieldDisplayTextEventArgs e) {
            if (e.Value == null) return;
            if (e.Field == pivotGridControl1.Fields[PivotHelper.Month]) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
    }
}
