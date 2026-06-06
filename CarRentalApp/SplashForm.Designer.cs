namespace CarRentalApp
{
    partial class SplashForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer;
        private CarRentalApp.Controls.SplashBackground splashBg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splashBg = new CarRentalApp.Controls.SplashBackground();
            this.SuspendLayout();

            this.timer.Interval = 2200;

            this.splashBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splashBg.Name = "splashBg";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.ClientSize = new System.Drawing.Size(620, 360);
            this.Controls.Add(this.splashBg);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заставка";
            this.ResumeLayout(false);
        }
    }
}
