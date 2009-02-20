//////////////////////////////////////////////////////////////
/// http://msdn2.microsoft.com/en-us/library/ms229655.aspx ///
//////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;


namespace com.bighetti.Mobile.Controls
{
    public class PanelGradient : Panel
    {
        #region Members
        // The value of the text color.
        private Color initColor = new Color();

        private Bitmap doubleBuffer;
        private Color endColor = Color.DarkSeaGreen;
        private Color startColor = Color.ForestGreen;
        private bool reverseGradient = false;
        private GradientFill.FillDirection fillDirection = GradientFill.FillDirection.TopToBottom;
        private int startOffset;
        private int endOffset;
        private int border = 1;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GradientFilledButton"/> class.
        /// </summary>
        public PanelGradient()
        {
            initColor = this.ForeColor;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the fill direction.
        /// </summary>
        /// <value>The fill direction.</value>
        public GradientFill.FillDirection FillDirection
        {
            get
            {
                return fillDirection;
            }
            set
            {
                fillDirection = value;
                Invalidate();
            }
        }

        public Color StartColor
        {
            get { return startColor; }
            set
            {
                startColor = value;
                Invalidate();
            }
        }

        public Color EndColor
        {
            get { return endColor; }
            set
            {
                endColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [reverse gradient].
        /// </summary>
        /// <value><c>true</c> if [reverse gradient]; otherwise, <c>false</c>.</value>
        public bool ReverseGradient
        {
            get
            {
                return reverseGradient;
            }
            set
            {
                reverseGradient = value;
            }
        }

        /// <summary>
        /// Gets or sets the start offset.
        /// This is the offset from the left or top edge
        /// of the button to start the gradient fill.
        /// </summary>
        /// <value>The start offset.</value>
        public int StartOffset
        {
            get { return startOffset; }
            set
            {
                startOffset = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the end offset.
        /// This is the offset from the right or bottom edge
        /// of the button to end the gradient fill.
        /// </summary>
        /// <value>The end offset.</value>
        public int EndOffset
        {
            get { return endOffset; }
            set
            {
                endOffset = value;
                Invalidate();
            }
        }

        public int Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the double buffer image.
        /// Used to double-buffer our drawing to avoid flicker
        /// between painting the background, border, focus-rect
        /// and the text of the control.
        /// </summary>
        /// <value>The double buffer image.</value>
        private Bitmap DoubleBufferImage
        {
            get
            {
                if (doubleBuffer == null)
                    doubleBuffer = new Bitmap(
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                return doubleBuffer;
            }
            set
            {
                if (doubleBuffer != null)
                    doubleBuffer.Dispose();
                doubleBuffer = value;
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawPanel(e.Graphics);
        }
        #endregion

        #region Methods
        //
        // Gets a Graphics object for the provided window handle
        //  and then calls DrawButton(Graphics, bool).
        //
        // If pressed is true, the button is drawn
        // in the depressed state.
        private void DrawPanel()
        {
            Graphics gr = this.CreateGraphics();
            DrawPanel(gr);
            gr.Dispose();
        }

        // Draws the button on the specified Grapics
        // in the specified state.
        //
        // Parameters:
        //  gr - The Graphics object on which to draw the button.
        //  pressed - If true, the button is drawn in the depressed state.
        private void DrawPanel(Graphics gr)
        {
            // Get a Graphics object from the background image.
            Graphics gr2 = Graphics.FromImage(DoubleBufferImage);

            // Fill solid up until where the gradient fill starts.
            if (startOffset > 0)
            {
                if (fillDirection == GradientFill.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(
                        new SolidBrush((reverseGradient) ? EndColor : StartColor),
                        0, 0, startOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(new SolidBrush((reverseGradient) ? EndColor : StartColor),
                                      0, 0, Width, startOffset);
                }
            }

            // Draw the gradient fill.
            Rectangle rc = this.ClientRectangle;
            if (fillDirection == GradientFill.FillDirection.LeftToRight)
            {
                rc.X = startOffset;
                rc.Width = rc.Width - startOffset - endOffset;
            }
            else
            {
                rc.Y = startOffset;
                rc.Height = rc.Height - startOffset - endOffset;
            }
            GradientFill.Fill(
                gr2,
                rc,
                (reverseGradient) ? endColor : startColor,
                (reverseGradient) ? startColor : endColor,
                fillDirection);

            // Fill solid from the end of the gradient fill
            // to the edge of the button.
            if (endOffset > 0)
            {
                if (fillDirection == GradientFill.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(new SolidBrush((reverseGradient) ? StartColor : EndColor),
                                      rc.X + rc.Width, 0, endOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(new SolidBrush((reverseGradient) ? StartColor : EndColor),
                                      0, rc.Y + rc.Height, Width, endOffset);
                }
            }

            if (border > 0)
            {
                // Draw the border.
                // Need to shrink the width and height by 1 otherwise
                // there will be no border on the right or bottom.
                rc = this.ClientRectangle;
                rc.Width = rc.Width - border;
                rc.Height = rc.Height - border;
                Pen pen = new Pen(SystemColors.WindowFrame);

                gr2.DrawRectangle(pen, rc);
            }
            // Draw from the background image onto the screen.
            gr.DrawImage(DoubleBufferImage, 0, 0);
            gr2.Dispose();

        }

        /// <summary>
        /// Disables the control.
        /// </summary>
        protected void disableControl()
        {
            initColor = this.ForeColor;
            this.ForeColor = Color.DarkGray;
        }

        /// <summary>
        /// Enables the control.
        /// </summary>
        protected void enableControl()
        {
            this.ForeColor = initColor;
        }
        #endregion
    }
}
