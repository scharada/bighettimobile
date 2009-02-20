using System;
using System.Collections.Generic;
using System.Text;

namespace com.bighetti.Mobile.Chart
{
    public class Serie
    {
        #region Attributes

        private string x = "";
        private decimal y = 0;

        #endregion

        #region Properties

        public string X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public decimal Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        #endregion

        #region Constructors

        public Serie()
        {
        }

        public Serie(string x, decimal y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion
    }
}
