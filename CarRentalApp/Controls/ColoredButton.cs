using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Controls
{
    public enum BtnVariant { Default, Add, Delete, Save, DarkRed, LightRose, Navy }

    /// <summary>Кнопка с пресетом цвета по варианту.</summary>
    [DesignerCategory("Code")]
    public class ColoredButton : Button
    {
        private BtnVariant _variant = BtnVariant.Default;

        [Category("ColoredButton"), DefaultValue(BtnVariant.Default)]
        public BtnVariant Variant
        {
            get => _variant;
            set { _variant = value; ApplyVariant(); }
        }

        public ColoredButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            Size = new Size(130, 36);
            UseVisualStyleBackColor = false;
            Cursor = Cursors.Hand;
            ApplyVariant();
        }

        private void ApplyVariant()
        {
            switch (_variant)
            {
                case BtnVariant.Add:
                    BackColor = Color.FromArgb(255, 193, 7);
                    ForeColor = Color.FromArgb(40, 28, 0);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 213, 79);
                    break;
                case BtnVariant.Delete:
                    BackColor = Color.FromArgb(183, 28, 28);
                    ForeColor = Color.White;
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
                    break;
                case BtnVariant.Save:
                    BackColor = Color.FromArgb(229, 57, 53);
                    ForeColor = Color.White;
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(244, 92, 89);
                    break;
                case BtnVariant.DarkRed:
                    BackColor = Color.FromArgb(123, 24, 24);
                    ForeColor = Color.White;
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(155, 40, 40);
                    break;
                case BtnVariant.LightRose:
                    BackColor = Color.FromArgb(176, 110, 110);
                    ForeColor = Color.White;
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(196, 130, 130);
                    break;
                case BtnVariant.Navy:
                    BackColor = Color.FromArgb(50, 60, 110);
                    ForeColor = Color.White;
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 80, 140);
                    break;
                default:
                    BackColor = Color.FromArgb(30, 30, 34);
                    ForeColor = Color.FromArgb(240, 240, 244);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 56);
                    break;
            }
            Invalidate();
        }
    }
}
