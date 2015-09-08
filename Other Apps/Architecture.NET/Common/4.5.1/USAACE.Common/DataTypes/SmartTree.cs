using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.Common.DataTypes
{
    [Serializable]
    public class SmartTreeNode<TValue>
    {
        private IList<SmartTreeNode<TValue>> _childNodes;
        private TValue _value;
        private SmartTreeNode<TValue> _parentNode;

        public SmartTreeNode()
        {
            _childNodes = new List<SmartTreeNode<TValue>>();
        }

        public SmartTreeNode(TValue value)
        {
            _childNodes = new List<SmartTreeNode<TValue>>();
            _value = value;
        }

        private SmartTreeNode(TValue value, SmartTreeNode<TValue> parent)
        {
            _childNodes = new List<SmartTreeNode<TValue>>();
            _value = value;
            _parentNode = parent;
        }

        public TValue Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public SmartTreeNode<TValue> ParentNode
        {
            get
            {
                return _parentNode;
            }
        }

        public IEnumerable<SmartTreeNode<TValue>> ChildNodes
        {
            get
            {
                return _childNodes;
            }
        }

        public SmartTreeNode<TValue> AddNode(TValue value)
        {
            SmartTreeNode<TValue> newNode = new SmartTreeNode<TValue>(value, this);
            _childNodes.Add(newNode);

            return newNode;
        }

        public void DeleteNode(TValue value)
        {
            if (value == null)
            {
                return;
            }

            SmartTreeNode<TValue> deleteNode = _childNodes.FirstOrDefault(x => x.Value != null && x.Value.Equals(value));

            if (deleteNode != null)
            {
                _childNodes.Remove(deleteNode); 
            }
        }

        public SmartTreeNode<TValue> FindNode(TValue value)
        {
            if (this.Value != null && this.Value.Equals(value))
            {
                return this;
            }
            else
            {
                foreach (SmartTreeNode<TValue> childNode in _childNodes)
                {
                    if (childNode.FindNode(value) != null)
                    {
                        return childNode;
                    }
                }

                return null;
            }
        }

        public SmartTreeNode<TValue> FindFirstChild(Func<TValue, Boolean> expression)
        {
            if (expression.Invoke(this.Value))
            {
                return this;
            }
            else
            {
                foreach (SmartTreeNode<TValue> childNode in _childNodes)
                {
                    SmartTreeNode<TValue> foundNode = childNode.FindFirstChild(expression);

                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }

                return null;
            }
        }

        public SmartTreeNode<TValue> FindFirstParent(Func<TValue, Boolean> expression)
        {
            if (expression.Invoke(this.Value))
            {
                return this;
            }
            else
            {
                return _parentNode != null ? _parentNode.FindFirstParent(expression) : null;
            }
        }
    }
}
