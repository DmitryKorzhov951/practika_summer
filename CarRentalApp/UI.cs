using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Общие элементы оформления и палитра.</summary>
    static class UI
    {
        // ---- Палитра ----
        public static readonly Color Primary    = Color.FromArgb( 44,  82, 130); // тёмно-синий
        public static readonly Color PrimaryLt  = Color.FromArgb( 49, 130, 206); // светло-синий
        public static readonly Color Accent     = Color.FromArgb( 56, 161, 105); // зелёный
        public static readonly Color Danger     = Color.FromArgb(197,  48,  48); // красный
        public static readonly Color Surface    = Color.FromArgb(247, 250, 252); // фон
        public static readonly Color SurfaceAlt = Color.FromArgb(237, 242, 247); // чередование строк
        public static readonly Color OnPrimary  = Color.White;
        public static readonly Color TextDim    = Color.FromArgb(113, 128, 150);

        public static readonly Font Header     = new("Segoe UI Semibold", 13, FontStyle.Bold);
        public static readonly Font Body       = new("Segoe UI", 9);
        public static readonly Font BodyBold   = new("Segoe UI Semibold", 9, FontStyle.Bold);

        /// <summary>Цветная полоса заголовка формы.</summary>
        public static Panel MakeHeader(string text)
        {
            var p = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 44,
                BackColor = Primary
            };
            p.Controls.Add(new Label
            {
                Text       = text,
                Dock       = DockStyle.Fill,
                Font       = Header,
                ForeColor  = OnPrimary,
                TextAlign  = ContentAlignment.MiddleLeft,
                Padding    = new Padding(16, 0, 0, 0)
            });
            // тонкая нижняя полоска-акцент
            p.Controls.Add(new Panel { Dock = DockStyle.Bottom, Height = 3, BackColor = PrimaryLt });
            return p;
        }

        public enum BtnStyle { Default, Primary, Accent, Danger }

        /// <summary>Кнопка с акцентом.</summary>
        public static Button MakeBtn(string text, EventHandler onClick, int width = 110,
                                     BtnStyle style = BtnStyle.Default)
        {
            var b = new Button
            {
                Text   = text,
                Width  = width,
                Height = 30,
                Font   = Body,
                FlatStyle = FlatStyle.Flat,
                Cursor  = Cursors.Hand,
                Margin  = new Padding(2)
            };
            b.FlatAppearance.BorderSize = 1;

            switch (style)
            {
                case BtnStyle.Primary:
                    b.BackColor = Primary;
                    b.ForeColor = OnPrimary;
                    b.FlatAppearance.BorderColor = Primary;
                    b.FlatAppearance.MouseOverBackColor = PrimaryLt;
                    break;
                case BtnStyle.Accent:
                    b.BackColor = Accent;
                    b.ForeColor = OnPrimary;
                    b.FlatAppearance.BorderColor = Accent;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 187, 120);
                    break;
                case BtnStyle.Danger:
                    b.BackColor = Danger;
                    b.ForeColor = OnPrimary;
                    b.FlatAppearance.BorderColor = Danger;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 62, 62);
                    break;
                default:
                    b.BackColor = Color.White;
                    b.ForeColor = Color.FromArgb(45, 55, 72);
                    b.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 224);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(237, 242, 247);
                    break;
            }
            b.Click += onClick;
            return b;
        }

        /// <summary>Нижняя панель с кнопками.</summary>
        public static FlowLayoutPanel MakeButtonsPanel()
        {
            var p = new FlowLayoutPanel
            {
                Dock          = DockStyle.Bottom,
                Height        = 46,
                Padding       = new Padding(10, 8, 10, 8),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor     = Surface
            };
            // тонкая верхняя разделительная линия
            p.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(pen, 0, 0, p.Width, 0);
            };
            return p;
        }

        /// <summary>Верхняя панель параметров (для табличных/фильтров).</summary>
        public static FlowLayoutPanel MakeParamsPanel()
        {
            var p = new FlowLayoutPanel
            {
                Dock          = DockStyle.Top,
                Height        = 44,
                Padding       = new Padding(10, 8, 10, 8),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor     = Surface
            };
            p.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            };
            return p;
        }

        /// <summary>Стилизация DataGridView.</summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.FromArgb(226, 232, 240);
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowTemplate.Height = 28;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = OnPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = BodyBold;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle.Font = Body;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(190, 227, 248);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 55, 72);
            grid.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            grid.AlternatingRowsDefaultCellStyle.BackColor = SurfaceAlt;
        }
    }
}
