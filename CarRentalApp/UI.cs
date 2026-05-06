using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp
{
    /// <summary>Общие элементы оформления (компактный стиль).</summary>
    static class UI
    {
        public static readonly Font Header = new("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font Body   = new("Segoe UI", 9);

        /// <summary>Тонкий заголовок формы.</summary>
        public static Label MakeHeader(string text)
        {
            return new Label
            {
                Text       = text,
                Dock       = DockStyle.Top,
                Height     = 28,
                Font       = Header,
                TextAlign  = ContentAlignment.MiddleLeft,
                Padding    = new Padding(10, 0, 0, 0),
                BackColor  = SystemColors.Control,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        /// <summary>Стандартная компактная кнопка.</summary>
        public static Button MakeBtn(string text, EventHandler onClick, int width = 100)
        {
            var b = new Button
            {
                Text   = text,
                Width  = width,
                Height = 26,
                Font   = Body,
                UseVisualStyleBackColor = true
            };
            b.Click += onClick;
            return b;
        }

        /// <summary>Нижняя панель с кнопками.</summary>
        public static FlowLayoutPanel MakeButtonsPanel()
        {
            return new FlowLayoutPanel
            {
                Dock     = DockStyle.Bottom,
                Height   = 36,
                Padding  = new Padding(6, 4, 6, 4),
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = SystemColors.Control
            };
        }

        /// <summary>Верхняя панель параметров (для табличных/фильтров).</summary>
        public static FlowLayoutPanel MakeParamsPanel()
        {
            return new FlowLayoutPanel
            {
                Dock     = DockStyle.Top,
                Height   = 36,
                Padding  = new Padding(6, 4, 6, 4),
                BackColor = SystemColors.Control
            };
        }
    }
}
