using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows;

namespace com.bighetti.Mobile.Chart
{
    public class SerieGroup : Component
    {
        #region Attributes

        private SerieCollection series = new SerieCollection();
        private string label = "";
        private Color borderColor = Color.Transparent;
        private Color backColor = Color.Transparent;
        private Color valueColor = Color.Black;

        #endregion

        #region Properties

        public SerieCollection Series
        {
            get
            {
                return this.series;
            }
            set
            {
                this.series = value;
            }
        }

        public string Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }

        public Color BackColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                this.backColor = value;
            }
        }

        public Color ValueColor
        {
            get
            {
                return this.valueColor;
            }
            set
            {
                this.valueColor = value;
            }
        }

        #endregion
    }
}
