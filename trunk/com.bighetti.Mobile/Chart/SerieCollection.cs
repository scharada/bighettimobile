using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace com.bighetti.Mobile.Chart
{
    public class SerieCollection : IList, ICollection, IEnumerable
    {
        #region Attributes
        
        private ArrayList series = new ArrayList();
        
        #endregion

        #region Properties

        public Serie this[int i]
        {
            get
            {
                return ((Serie)this.series[i]);
            }
            set
            {
                this.series[i] = value;
            }
        }

        public decimal Max
        {
            get
            {
                decimal max = 0;
                for (int i = 0; i < this.series.Count; i++)
                {
                    if ((series[i] as Serie).Y > max)
                        max = (series[i] as Serie).Y;
                }
                return max;
            }
        }

        public decimal Min
        {
            get
            {
                decimal min = 0;
                for (int i = 0; i < this.series.Count; i++)
                {
                    if ((series[i] as Serie).Y < min)
                        min = (series[i] as Serie).Y;
                }
                return min;
            }
        }

        #endregion

        #region Methods

        public void Add(Serie value)
        {
            this.series.Add(value);
        }

        public void Add(string x, decimal y)
        {
            this.series.Add(new Serie(x, y));
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.series.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return (this.series.Count);
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return (false);
            }
        }

        public object SyncRoot
        {
            get
            {
                return (this);
            }
        }

        #endregion

        #region IEnumerable Members

        public System.Collections.IEnumerator GetEnumerator()
        {
            return (this.series.GetEnumerator());
        }

        #endregion

        #region IList Members

        public int Add(object value)
        {
            return this.series.Add(value);
        }

        public void Clear()
        {
            this.series.Clear();
        }

        public bool Contains(object value)
        {
            return this.series.Contains(value);
        }

        public int IndexOf(object value)
        {
            return this.series.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            this.series.Insert(index, value);
        }

        public bool IsFixedSize
        {
            get { return this.series.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return this.series.IsReadOnly; }
        }

        public void Remove(object value)
        {
            this.series.Remove(value);
        }

        public void RemoveAt(int index)
        {
            this.series.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return this.series[index];
            }
            set
            {
                this.series[index] = value;
            }
        }

        #endregion
    }
}
