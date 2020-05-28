using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid_WF
{
    public class GridRadioButtonCellRender : GridCellRendererBase
    {
        public GridRadioButtonCellRender(SfDataGrid dataGrid, Options options)
        {
            IsEditable = true;
            DataGrid = dataGrid;
            RadioOptions = options;
        }

        protected Options RadioOptions { get; set; }

        protected List<GridCellRadioButton> RadioButtonCollection { get; set; }

        /// <summary>
        /// Gets or Sets to specifies the datagrid.
        /// </summary>
        protected SfDataGrid DataGrid { get; set; }

        protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            int starHeight, starWidth;
            Rectangle drawArea;

            var padding = 5;
            starWidth = 16;
            starHeight = 16;

            var RadioButtonColumn = column.GridColumn as GridRadioButtonColumn;
            drawArea = new Rectangle(cellRect.X + padding, cellRect.Y + ((cellRect.Height / 2) - (starHeight / 2)), starWidth, starHeight);

            RadioButtonCollection = new List<GridCellRadioButton>();
            for (int i = 0; i < RadioButtonColumn.ItemCount; i++)
            {
                var radioButton = new GridCellRadioButton();

                radioButton.Location = new Point(drawArea.X, drawArea.Y);
                radioButton.Width = starWidth;
                radioButton.Height = starHeight;

                //Draw outer border of RadioButton
                radioButton.DrawBorder(paint, Color.Black, drawArea, radioButton);

                Point point = new Point(drawArea.X + drawArea.Width + 2, drawArea.Y);
                Font font = style.GetFont() != Control.DefaultFont ? style.GetFont() : Control.DefaultFont;

                int value = i;
                var buttonValue = ((Options)value).ToString();

                //Draw string for RadioButton
                paint.DrawString(buttonValue, font, new SolidBrush(Color.Gray), point);
                if (buttonValue.Equals(cellValue))
                {
                    radioButton.DrawSelectedCheckMark(paint, drawArea, radioButton, Color.Black, Color.Black);
                }
                //Add RadioButton to Cell
                RadioButtonCollection.Add(radioButton);

                //Set the start point for next RadioButton
                Size stringlenth = TextRenderer.MeasureText((RadioOptions = 0).ToString(), font);
                drawArea.X += drawArea.Width + 10 + stringlenth.Width;
            }
        }

        protected override void OnMouseDown(DataColumnBase dataColumn, RowColumnIndex rowColumnIndex, MouseEventArgs e)
        {
            var radiobuttoncollection = (dataColumn.Renderer as GridRadioButtonCellRender).RadioButtonCollection;
            PropertyInfo dataRow = (dataColumn as DataColumnBase).GetType().GetProperty("DataRow", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataRow rowdata = (DataRow)dataRow.GetValue(dataColumn as DataColumnBase);

            for (int i = 0; i < radiobuttoncollection.Count; i++)
            {
                var rect = radiobuttoncollection[i].Bounds;
                if (e.Location.X > rect.X && e.Location.X < (rect.X + rect.Width))
                {
                    radiobuttoncollection[i].Checked = true;
                    (rowdata.RowData as OrderInfo).RadioOptions = (Options)i;

                    DataGrid.TableControl.Invalidate(rect, true);

                }
            }
        }
    }

    
}
