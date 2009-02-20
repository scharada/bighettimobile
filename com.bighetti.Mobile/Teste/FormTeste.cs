using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.bighetti.Mobile.Teste
{
    public partial class FormTeste : Form
    {
        public FormTeste()
        {
            InitializeComponent();

            //ChartBar
            com.bighetti.Mobile.Chart.SerieGroup serieGroup1 = new com.bighetti.Mobile.Chart.SerieGroup();
            serieGroup1.Label = "Group 1";
            serieGroup1.Series.Add("Item 1", 20);
            serieGroup1.Series.Add("Item 2", -40);
            serieGroup1.Series.Add("Item 3", 50);

            com.bighetti.Mobile.Chart.SerieGroup serieGroup2 = new com.bighetti.Mobile.Chart.SerieGroup();
            serieGroup2.Label = "Group 2";
            serieGroup2.Series.Add("Item 1", 70);
            serieGroup2.Series.Add("Item 2", 90);
            serieGroup2.Series.Add("Item 3", -80);

            com.bighetti.Mobile.Chart.SerieGroup serieGroup3 = new com.bighetti.Mobile.Chart.SerieGroup();
            serieGroup3.Label = "Group 3";
            serieGroup3.Series.Add("Item 1", 10);
            serieGroup3.Series.Add("Item 2", 30);
            serieGroup3.Series.Add("Item 3", 40);

            //chartBar1.Groups.Add(serieGroup1);
            //chartBar1.Groups.Add(serieGroup2);
            //chartBar1.Groups.Add(serieGroup3);

            //chartBar1.Format = "n0";

            //chartBar1.Refresh();

            //decimal
            keyboardNumeric1.TextBox = textBoxDecimal1;
            keyboardNumeric1.DecimalSeparator = true;
            keyboardNumeric1.Decimals = 2;

            //integer
            keyboardNumeric2.TextBox = textBoxInteger1;
            keyboardNumeric2.DecimalSeparator = false;
        }

        private void FormTeste_Load(object sender, EventArgs e)
        {

        }
    }
}