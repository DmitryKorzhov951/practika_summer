using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Controls
{
    /// <summary>DataGridView с уже применённой тёмной темой: красные заголовки на чёрном, тёмные ячейки.</summary>
    [DesignerCategory("Code")]
    public class StyledGrid : DataGridView
    {
        public StyledGrid()
        {
            AllowUserToAddRows = true;
            AllowUserToResizeRows = false;
            AutoGenerateColumns = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BackgroundColor = Color.FromArgb(18, 18, 20);
            BorderStyle = BorderStyle.None;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(15, 15, 18),
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(229, 57, 53),
                Padding = new Padding(10, 0, 10, 0),
                SelectionBackColor = Color.FromArgb(15, 15, 18),
                SelectionForeColor = Color.FromArgb(229, 57, 53),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
            };
            ColumnHeadersHeight = 36;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(30, 30, 34),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(240, 240, 244),
                Padding = new Padding(6, 2, 6, 2),
                SelectionBackColor = Color.FromArgb(183, 28, 28),
                SelectionForeColor = Color.White,
            };
            AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(38, 38, 44),
                ForeColor = Color.FromArgb(240, 240, 244),
            };
            EnableHeadersVisualStyles = false;
            GridColor = Color.FromArgb(60, 60, 66);
            RowHeadersVisible = false;
            RowTemplate.Height = 30;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
