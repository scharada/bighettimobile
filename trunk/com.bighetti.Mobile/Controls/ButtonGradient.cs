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
    public class ButtonGradient : Control
    {
        #region Members
        // The coordinates of the cursor the last time
        // there was a MouseUp or MouseDown message.
        private Point lastCursorCoordinates;

        // The value of the text color.
        private Color initColor = new Color();

        private System.ComponentModel.IContainer components = null;
        private bool gotKeyDown = false;
        private Bitmap _DoubleBuffer;
        private Color _EndColor = Color.DarkSeaGreen;
        private Color _StartColor = Color.ForestGreen;
        private bool _ReverseGradient = false;
        private GradientFill.FillDirection _FillDirection = GradientFill.FillDirection.TopToBottom;
        private int _StartOffset;
        private int _EndOffset;
        private bool _Enabled = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GradientFilledButton"/> class.
        /// </summary>
        public ButtonGradient()
        {
            components = new System.ComponentModel.Container();
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
                return _FillDirection;
            }
            set
            {
                _FillDirection = value;
                Invalidate();
            }
        }

        // The start color for the GradientFill. This is the color
        // at the left or top of the control depeneding on the value
        // of the FillDirection property.
        public Color StartColor
        {
            get { return _StartColor; }
            set
            {
                _StartColor = value;
                Invalidate();
            }
        }

        // The end color for the GradientFill. This is the color
        // at the right or bottom of the control depending on the value
        // of the FillDirection property
        public Color EndColor
        {
            get { return _EndColor; }
            set
            {
                _EndColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [reverse gradient].
        /// </summary>
        /// <value><c>true</c> if [reverse gradient]; otherwise, <c>false</c>.</value>
        public bool ReverseGradient
        {
            get { return _ReverseGradient; }
            set { _ReverseGradient = value; }
        }

        /// <summary>
        /// Gets or sets the start offset.
        /// This is the offset from the left or top edge
        /// of the button to start the gradient fill.
        /// </summary>
        /// <value>The start offset.</value>
        public int StartOffset
        {
            get { return _StartOffset; }
            set
            {
                _StartOffset = value;
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
            get { return _EndOffset; }
            set
            {
                _EndOffset = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <value></value>
        /// <returns>true if the control can respond to user interaction; otherwise, false. The default is true.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        new public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                // Only do if value changes
                if (_Enabled != value)
                {
                    _Enabled = value;

                    if (_Enabled == true)
                        enableControl();
                    else
                        disableControl();

                    Invalidate();
                }
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
                if (_DoubleBuffer == null)
                    _DoubleBuffer = new Bitmap(
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                return _DoubleBuffer;
            }
            set
            {
                if (_DoubleBuffer != null)
                    _DoubleBuffer.Dispose();
                _DoubleBuffer = value;
            }
        }
        #endregion

        #region Events
        // Called when the control is resized. When that happens,
        // recreate the bitmap used for double-buffering.
        protected override void OnResize(EventArgs e)
        {
            DoubleBufferImage = new Bitmap(
                this.ClientSize.Width,
                this.ClientSize.Height);
            base.OnResize(e);
        }

        // Called when the control gets focus. Need to repaint
        // the control to ensure the focus rectangle is drawn correctly.
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        //
        // Called when the control loses focus. Need to repaint
        // the control to ensure the focus rectangle is removed.
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Capture)
            {
                Point coord = new Point(e.X, e.Y);
                if (this.ClientRectangle.Contains(coord) !=
                    this.ClientRectangle.Contains(lastCursorCoordinates))
                {
                    DrawButton(this.ClientRectangle.Contains(coord));
                }
                lastCursorCoordinates = coord;
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (_Enabled == true))
            {
                // Start capturing the mouse input
                this.Capture = true;
                // Get the focus because button is clicked.
                this.Focus();

                // draw the button
                DrawButton(true);
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_Enabled == true)
            {
                this.Capture = false;

                DrawButton(false);

                base.OnMouseUp(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            gotKeyDown = true;
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Space:
                case System.Windows.Forms.Keys.Enter:
                    DrawButton(true);
                    break;
                case System.Windows.Forms.Keys.Up:
                case System.Windows.Forms.Keys.Left:
                    this.Parent.SelectNextControl(this, false, false, true, true);
                    break;
                case System.Windows.Forms.Keys.Down:
                case System.Windows.Forms.Keys.Right:
                    this.Parent.SelectNextControl(this, true, false, true, true);
                    break;
                default:
                    gotKeyDown = false;
                    base.OnKeyDown(e);
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Space:
                case System.Windows.Forms.Keys.Enter:
                    if (gotKeyDown)
                    {
                        DrawButton(false);
                        OnClick(EventArgs.Empty);
                        gotKeyDown = false;
                    }
                    break;
                default:
                    base.OnKeyUp(e);
                    break;
            }
        }

        /// <summary>
        /// Override this method with no code to avoid flicker.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButton(e.Graphics, this.Capture &&
                (this.ClientRectangle.Contains(lastCursorCoordinates)));
        }
        #endregion

        #region Methods
        //
        // Gets a Graphics object for the provided window handle
        //  and then calls DrawButton(Graphics, bool).
        //
        // If pressed is true, the button is drawn
        // in the depressed state.
        private void DrawButton(bool pressed)
        {
            Graphics gr = this.CreateGraphics();
            DrawButton(gr, pressed);
            gr.Dispose();
        }

        // Draws the button on the specified Grapics
        // in the specified state.
        //
        // Parameters:
        //  gr - The Graphics object on which to draw the button.
        //  pressed - If true, the button is drawn in the depressed state.
        private void DrawButton(Graphics gr, bool pressed)
        {
            // Get a Graphics object from the background image.
            Graphics gr2 = Graphics.FromImage(DoubleBufferImage);

            // Fill solid up until where the gradient fill starts.
            if (_StartOffset > 0)
            {
                if (_FillDirection == GradientFill.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(
                        new SolidBrush((pressed ^ _ReverseGradient) ? EndColor : StartColor),
                        0, 0, _StartOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(new SolidBrush((pressed ^ _ReverseGradient) ? EndColor : StartColor),
                                      0, 0, Width, _StartOffset);
                }
            }

            // Draw the gradient fill.
            Rectangle rc = this.ClientRectangle;
            if (_FillDirection == GradientFill.FillDirection.LeftToRight)
            {
                rc.X = _StartOffset;
                rc.Width = rc.Width - _StartOffset - _EndOffset;
            }
            else
            {
                rc.Y = _StartOffset;
                rc.Height = rc.Height - _StartOffset - _EndOffset;
            }
            GradientFill.Fill(
                gr2,
                rc,
                (pressed ^ _ReverseGradient) ? _EndColor : _StartColor,
                (pressed ^ _ReverseGradient) ? _StartColor : _EndColor,
                _FillDirection);

            // Fill solid from the end of the gradient fill
            // to the edge of the button.
            if (_EndOffset > 0)
            {
                if (_FillDirection == GradientFill.FillDirection.LeftToRight)
                {
                    gr2.FillRectangle(new SolidBrush((pressed ^ _ReverseGradient) ? StartColor : EndColor),
                                      rc.X + rc.Width, 0, _EndOffset, Height);
                }
                else
                {
                    gr2.FillRectangle(new SolidBrush((pressed ^ _ReverseGradient) ? StartColor : EndColor),
                                      0, rc.Y + rc.Height, Width, _EndOffset);
                }
            }

            // Draw the text.
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            gr2.DrawString(this.Text, this.Font,
                           new SolidBrush(this.ForeColor),
                           this.ClientRectangle, sf);

            // Draw the border.
            // Need to shrink the width and height by 1 otherwise
            // there will be no border on the right or bottom.
            rc = this.ClientRectangle;
            rc.Width--;
            rc.Height--;
            Pen pen = new Pen(SystemColors.WindowFrame);

            gr2.DrawRectangle(pen, rc);

            // Draw from the background image onto the screen.
            gr.DrawImage(DoubleBufferImage, 0, 0);
            gr2.Dispose();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"></see> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
