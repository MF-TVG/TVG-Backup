using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.Common.DataTypes
{
    [Serializable]
    public class SmartDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> _values;

        public SmartDictionary()
        {
            _values = new Dictionary<TKey, TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (_values.ContainsKey(key))
                {
                    return _values[key];
                }
                else
                {
                    return default(TValue);
                }
            }
            set
            {
                if (_values.ContainsKey(key))
                {
                    _values[key] = value;
                }
                else
                {
                    _values.Add(key, value);
                }
            }
        }
    }
}
