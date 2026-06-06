using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalApp.Controls
{
    public enum BtnVariant { Default, Add, Delete, Save }

    /// <summary>Кнопка с пресетом цвета по варианту (Add/Delete/Save/Default).</summary>
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
            FlatAppearance.BorderSize = 1;
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Size = new Size(110, 32);
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
                    FlatAppearance.BorderColor = Color.FromArgb(255, 193, 7);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 213, 79);
                    break;
                case BtnVariant.Delete:
                    BackColor = Color.FromArgb(183, 28, 28);
                    ForeColor = Color.White;
                    FlatAppearance.BorderColor = Color.FromArgb(183, 28, 28);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
                    break;
                case BtnVariant.Save:
                    BackColor = Color.FromArgb(229, 57, 53);
                    ForeColor = Color.White;
                    FlatAppearance.BorderColor = Color.FromArgb(229, 57, 53);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(244, 92, 89);
                    break;
                default:
                    BackColor = Color.FromArgb(30, 30, 34);
                    ForeColor = Color.FromArgb(240, 240, 244);
                    FlatAppearance.BorderColor = Color.FromArgb(60, 60, 66);
                    FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 56);
                    break;
            }
            Invalidate();
        }
    }
}
