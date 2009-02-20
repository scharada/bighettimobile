using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace com.bighetti.Mobile.Chart
{
    public partial class ChartBar : PictureBox
    {
        private SerieGroupCollection groups = new SerieGroupCollection();
        private string format = "n2";
        private Font font = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular);
  
        private readonly Color[] backColors = new Color[] { Color.LightGreen, Color.LightSalmon, Color.LightBlue, Color.LightCoral, Color.LightPink,
            Color.LightSkyBlue, Color.LightSeaGreen, Color.LightSteelBlue, Color.LightSlateGray, Color.LightYellow };


        public SerieGroupCollection Groups
        {
            get
            {
                return this.groups;
            }
            set
            {
                this.groups = value;
            }
        }

        public string Format
        {
            get
            {
                return this.format;
            }
            set
            {
                this.format = value;
            }
        }

        public Font Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }

        public ChartBar()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            this.Bar();
        }

        private Bitmap Bar()
        {
            int width = this.Width;
            int height = this.Height;

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            if (this.groups.Count > 0)
            {
                string[] labels = new string[this.groups[0].Series.Count];
                decimal[] values = new decimal[labels.Length * this.groups.Count];
                Color[] backColors = new Color[this.groups.Count];
                Color[] valueColors = new Color[this.groups.Count];

                decimal minValue = this.groups.MinValueSeries;
                decimal maxValue = this.groups.MaxValueSeries;
                decimal diffValue = 0;

                if (minValue < 0)
                {
                    diffValue = minValue * -1;
                }

                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i] = groups[0].Series[i].X;
                }

                int k = 0;
                for (int i = 0; i < this.groups.Count; i++)
                {
                    k = i;
                    backColors[i] = this.groups[i].BackColor;
                    valueColors[i] = this.groups[i].ValueColor;

                    for (int j = 0; j < labels.Length; j++)
                    {
                        values[k] = this.groups[i].Series[j].Y;
                        k += labels.Length;
                    }
                }
                
                Graphics g = Graphics.FromImage(bitmap);
                
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

                int horizontalMargin = 50;
                int verticalMargin = 25;

                int barSpace = 3;
                int horizontalBarMaxSize = ((width - horizontalMargin - 5 - (barSpace * values.Length)) + barSpace) / values.Length;
                int verticalBarMaxSize = height - (verticalMargin * 2);

                int horizontalPosition = horizontalMargin;
                
                int positiveInitialHeightBar = verticalMargin;
                int positiveFinalHeigthBar = verticalMargin + Convert.ToInt32(((maxValue) / (maxValue + diffValue)) * verticalBarMaxSize);

                int zeroHeight = positiveFinalHeigthBar;

                int negativeInicitalHeightBar = zeroHeight;
                int negativeFinalHeightBar = positiveFinalHeigthBar + (verticalBarMaxSize - zeroHeight);

                int horizontalLegendMaxSize = (width - horizontalMargin) / groups.Count;
                int horizontalLegendPosition = horizontalMargin;

                Pen pen = new Pen(Color.Black, 1);

                //print y line
                g.DrawLine(pen, horizontalMargin - 13, 2, horizontalMargin - 13, height - 4);

                //print x line
                g.DrawLine(pen, horizontalMargin - 33, zeroHeight, height - 5, zeroHeight);

                int l = 0;
                int m = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    if (backColors[m] == Color.Transparent)
                    {
                        backColors[m] = this.backColors[m % 10];
                    }

                    if (valueColors[m] == Color.Transparent)
                    {
                        valueColors[m] = Color.Black;
                    }

                    int verticalBarSize = Convert.ToInt32((Math.Abs(values[i]) / (maxValue + diffValue)) * (height - (verticalMargin * 2)));

                    int diff = 0;

                    if (minValue < 0)
                    {
                        diff = Convert.ToInt32((values[i] / (minValue * -1)) * (height - (verticalMargin * 2)));
                    }

                    int barX = 0;
                    int barY = 0;
                    int labelY = 0;
                    int pointY = 0;

                    if (values[i] >= 0)
                    {
                        barX = horizontalPosition;
                        barY = (zeroHeight - verticalBarSize);
                        labelY = barY - 10;
                        pointY = barY;
                    }
                    else
                    {
                        barX = horizontalPosition;
                        barY = zeroHeight;
                        labelY = barY + verticalBarSize;
                        pointY = barY + verticalBarSize;
                    }

                    //print bar
                    g.FillRectangle(new SolidBrush(backColors[m]), barX, barY, horizontalBarMaxSize, verticalBarSize);

                    //print bar border
                    g.DrawRectangle(pen, barX, barY, horizontalBarMaxSize, verticalBarSize);

                    //print bar label
                    g.DrawString((format != string.Empty ? values[i].ToString(format) : values[i].ToString()), font, new SolidBrush(valueColors[m]), horizontalPosition, labelY);

                    //print y point
                    g.FillEllipse(new SolidBrush(Color.BlueViolet), horizontalMargin - 16, pointY - 3, 6, 6);
                    
                    if (l == 0)
                    {
                        g.DrawString(labels[i / this.groups.Count], font, new SolidBrush(Color.Black), horizontalPosition, height - 15);
                    }

                    if (l == this.groups.Count - 1)
                    {
                        l = -1;
                    }
                    l++;

                    if (m == this.groups.Count - 1)
                    {
                        m = -1;
                    }
                    m++;

                    horizontalPosition += horizontalBarMaxSize + barSpace;
                }

                //print legend
                for (int i = 0; i < groups.Count; i++)
                {
                    g.FillRectangle(new SolidBrush(backColors[i]), horizontalLegendPosition, 4, 8, 8);
                    g.DrawRectangle(pen, horizontalLegendPosition, 4, 8, 8);
                    g.DrawString(groups[i].Label, font, new SolidBrush(Color.Black), horizontalLegendPosition + 11, 2);
                    horizontalLegendPosition += horizontalLegendMaxSize;
                }

                //print zero
                g.DrawString("0", font, new SolidBrush(Color.Black), horizontalMargin - 22, zeroHeight + 2);
            }

            this.Image = bitmap;
            return bitmap;
        }
    }
}
