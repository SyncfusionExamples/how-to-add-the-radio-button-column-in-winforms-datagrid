using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid_WF
{
    public partial class Form1 : Form
    {
        ObservableCollection<OrderInfo> list = new ObservableCollection<OrderInfo>();
        public Form1()
        {
            InitializeComponent();

            list.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", new DateTime(2020, 06, 12), true, Options.A));
            list.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.", null, true, Options.B));
            list.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", new DateTime(2020, 06, 12), true, Options.A));
            list.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", new DateTime(2020, 06, 12), true, Options.B));
            list.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", new DateTime(2020, 06, 12), true, Options.C));
            list.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", new DateTime(2020, 06, 12), true, Options.A));
            list.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", new DateTime(2020, 06, 12), true, Options.B));
            list.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid", null, true, Options.A));
            list.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille", null, true, Options.C));
            list.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", new DateTime(2020, 06, 12), true, Options.A));
            this.sfDataGrid1.AutoGenerateColumns = false;
            this.sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            this.sfDataGrid1.DataSource = list;

            this.sfDataGrid1.CellRenderers.Add("RadioButton", new GridRadioButtonCellRender(this.sfDataGrid1, Options.A));

            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country" });
            this.sfDataGrid1.Columns.Add(new GridRadioButtonColumn() { MappingName = "RadioOptions", ItemCount = 3, Width = 140 });

        }

      

        
    }

   


}


