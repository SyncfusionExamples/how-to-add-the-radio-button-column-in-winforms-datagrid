using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_WF
{
    [ToolboxItem(false)]
    public partial class GridCellRadioButton : RadioButtonAdv
    {
        public GridCellRadioButton()
        {
        }

        /// <summary>
        /// Draws  check mark of the radio button.
        /// </summary>
        /// <param name="g">Graphics object</param>
        public void DrawSelectedCheckMark(Graphics g, Rectangle mrectBox, RadioButtonAdv radio, Color circleBackColor, Color iconColor)
        {
            Rectangle rect = mrectBox;
            rect.Inflate((int)DpiAware.LogicalToDeviceUnits(-5), (int)DpiAware.LogicalToDeviceUnits(-5));

            using (Pen pen = new Pen(circleBackColor))
            {
                g.DrawEllipse(pen, rect);
            }

            rect.Inflate(-1, -1);

            using (GraphicsPath path = this.GetCheckMarkPath(rect))
            {
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = iconColor;
                    brush.CenterPoint = new PointF((float)rect.X + 1, (float)rect.Y + 1);
                    brush.SurroundColors = new Color[] { iconColor };
                    SmoothingMode mode = SmoothingMode.AntiAlias;
                    g.SmoothingMode = mode;
                    g.FillPath(brush, path);
                }
            }

            using (GraphicsPath path = this.GetCheckMarkBorderPath(rect))
            {
                using (Pen pen = new Pen(iconColor))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        internal GraphicsPath GetCheckMarkBorderPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            #region Fortouch
            path.AddEllipse(rect);
            path.CloseFigure();
            #endregion
            return path;
        }

        internal GraphicsPath GetCheckMarkPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);
            path.CloseFigure();
            return path;
        }

        public void DrawBorder(Graphics g, Color borderColor, Rectangle mrectBox, RadioButtonAdv radioButtonAdv)
        {
            Rectangle rect = mrectBox;
            rect.Inflate(-1, -1);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.AssumeLinear;

            using (Pen pen = new Pen(borderColor))
            {
                pen.Width = 1;
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
