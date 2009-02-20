using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace com.bighetti.Mobile.Controls
{
    public partial class TextBoxDecimal : TextBox
    {
        private int decimals = 2;

        public TextBoxDecimal()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(TextBoxDecimal_KeyPress);
            this.LostFocus += new EventHandler(TextBoxDecimal_LostFocus);
        }

        public int Decimals
        {
            get { return this.decimals; }
            set { this.decimals = value; }
        }

        private void Format()
        {
            if (this.Text.Trim().Length > 0)
            {
                try
                {
                    this.Text = String.Format("{0:n" + this.decimals.ToString() + "}", Convert.ToDecimal(this.Text));
                }
                catch
                {
                    this.Text = String.Format("{0:n" + this.decimals.ToString() + "}", 0);
                }
            }
        }

        private void TextBoxDecimal_LostFocus(object sender, EventArgs e)
        {
            this.Format();
        }

        private void TextBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int[] characters = new int[] { 8, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };

            if ((Array.IndexOf<int>(characters, e.KeyChar) == -1)
                && (e.KeyChar.ToString() != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar.ToString() == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                {
                    if (this.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) != -1)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
