using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace com.bighetti.Mobile.Chart
{
    public class SerieGroupCollection : IList, ICollection, IEnumerable
    {
        #region Attributes

        private ArrayList groups = new ArrayList();

        #endregion

        #region Properties

        public SerieGroup this[int i]
        {
            get
            {
                return ((this.groups[i] as SerieGroup));
            }
            set
            {
                this.groups[i] = value;
            }
        }

        public int MaxLengthSeries
        {
            get
            {
                int maxLength = 0;

                for (int i = 0; i < this.groups.Count; i++)
                {
                    int serieLength = (this.groups[i] as SerieGroup).Series.Count;
                    if ((serieLength > maxLength))
                    {
                        maxLength = serieLength;
                    }
                }

                return maxLength;
            }
        }

        public decimal MinValueSeries
        {
            get
            {
                decimal minValue = 0;

                for (int i = 0; i < this.groups.Count; i++)
                {
                    decimal serieMinValue = (this.groups[i] as SerieGroup).Series.Min;
                    if ((serieMinValue < minValue))
                    {
                        minValue = serieMinValue;
                    }
                }

                return minValue;
            }
        }

        public decimal MaxValueSeries
        {
            get
            {
                decimal maxValue = 0;

                for (int i = 0; i < this.groups.Count; i++)
                {
                    decimal serieMaxValue = (this.groups[i] as SerieGroup).Series.Max;
                    if ((serieMaxValue > maxValue))
                    {
                        maxValue = serieMaxValue;
                    }
                }

                return maxValue;
            }
        }

        #endregion

        #region Methods

        public void Add(ref SerieGroup value)
        {
            this.groups.Add(value);
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.groups.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return (this.groups.Count);
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
            return (this.groups.GetEnumerator());
        }

        #endregion

        #region IList Members

        public int Add(object value)
        {
            return this.groups.Add(value);
        }

        public void Clear()
        {
            this.groups.Clear();
        }

        public bool Contains(object value)
        {
            return this.groups.Contains(value);
        }

        public int IndexOf(object value)
        {
            return this.groups.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            this.groups.Insert(index, value);
        }

        public bool IsFixedSize
        {
            get { return this.groups.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return this.groups.IsReadOnly; }
        }

        public void Remove(object value)
        {
            this.groups.Remove(value);
        }

        public void RemoveAt(int index)
        {
            this.groups.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return this.groups[index];
            }
            set
            {
                this.groups[index] = value;
            }
        }

        #endregion
    }
}
