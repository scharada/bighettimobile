using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace com.bighetti.Mobile.Controls
{
    public partial class TextBoxInteger : TextBox
    {
        public TextBoxInteger()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(TextBoxInteger_KeyPress);
        }

        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            int[] characters = new int[] { 8, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };

            if (Array.IndexOf<int>(characters, e.KeyChar) == -1)
            {
                e.Handled = true;
            }
        }
    }
}
