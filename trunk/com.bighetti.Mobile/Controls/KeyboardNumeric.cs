using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace com.bighetti.Mobile.Controls
{
    public partial class KeyboardNumeric : UserControl
    {
        private TextBox textBox = new TextBox();
        private string messageClearText = "Limpar Campo?";
        private string messageClearCaption = "Limpar";
        private int decimals = 2;

        public TextBox TextBox
        {
            get
            {
                return this.textBox;
            }
            set
            {
                this.textBox = value;
            }
        }

        public string MessageClearText
        {
            get
            {
                return this.messageClearText;
            }
            set
            {
                this.messageClearText = value;
            }
        }

        public string MessageClearCaption
        {
            get
            {
                return this.messageClearCaption;
            }
            set
            {
                this.messageClearCaption = value;
            }
        }

        public int Decimals
        {
            get
            {
                return this.decimals;
            }
            set
            {
                this.decimals = value;
            }
        }

        public bool DecimalSeparator
        {
            get
            {
                return this.btnDecimalSeparator.Visible;
            }
            set
            {
                this.btnDecimalSeparator.Visible = value;
            }
        }

        public KeyboardNumeric()
        {
            InitializeComponent();
            
            this.btnDecimalSeparator.Text = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            this.Size = new Size(67, 83);
        }

        private void AddText(string text)
        {
            if (textBox != null)
            {
                if (this.DecimalSeparator)
                {
                    int indexOfDecimalSeparator = textBox.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    if (indexOfDecimalSeparator >= 0)
                    {
                        if ((textBox.Text.Length - indexOfDecimalSeparator - 1) < decimals)
                        {
                            textBox.Text += text;
                        }
                    }

                    if (indexOfDecimalSeparator == -1)
                    {
                        textBox.Text += text;
                    }
                }
                else
                {
                    textBox.Text += text;
                }
            }
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            AddText("0");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (textBox != null)
            {
                if (MessageBox.Show(this.messageClearText, this.messageClearCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    textBox.Text = "";
                }
            }
        }

        private void btnSeparador_Click(object sender, EventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.Text.Trim().Length == 0)
                {
                    AddText("0" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                }
                else 
                {
                    if (textBox.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) == -1)
                    {
                        AddText(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    }
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AddText("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddText("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddText("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddText("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddText("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddText("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddText("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddText("9");
        }
    }
}
