using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitnesstrackerr
{
    public partial class CircularProgressBar : UserControl
    {
        private int value = 0;
        private int maxValue = 100;
        private Color progressColor = Color.MediumPurple;

        public int Value
        {
            get => value;
            set { this.value = value; Invalidate(); }
        }

        public int MaxValue
        {
            get => maxValue;
            set { maxValue = value; Invalidate(); }
        }

        public Color ProgressColor
        {
            get => progressColor;
            set { progressColor = value; Invalidate(); }
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Size = new Size(120, 120);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int thickness = 10;
            float sweepAngle = 360.0f * value / maxValue;

            Rectangle rect = new Rectangle(thickness, thickness, Width - 2 * thickness, Height - 2 * thickness);

            // Draw base circle
            using (Pen basePen = new Pen(Color.WhiteSmoke, thickness))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawArc(basePen, rect, 0, 360);
            }

            // Draw progress arc
            using (Pen progressPen = new Pen(progressColor, thickness))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawArc(progressPen, rect, -90, sweepAngle);
            }

            // Draw text
            using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
            using (Font font = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Brush brush = new SolidBrush(progressColor))
            {
                e.Graphics.DrawString($"{value}%", font, brush, ClientRectangle, sf);
            }
        }
        private void CircularProgressBar_Load(object sender, EventArgs e)
        {
            // You can initialize things here
        }
    }
}