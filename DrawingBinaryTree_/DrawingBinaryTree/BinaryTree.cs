using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingBinaryTree
{
    public class BinaryTreeItem<T>
    {
        public T Value;
        public BinaryTreeItem<T> parent;
        public BinaryTreeItem<T> left;
        public BinaryTreeItem<T> right;
        public BinaryTreeItem(T Value, BinaryTreeItem<T> parent = null, BinaryTreeItem<T> left = null, BinaryTreeItem<T> right = null)
        {
            this.Value = Value;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
    }
    public class BinaryTree<T> where T : IComparable
    {

        private BinaryTreeItem<T> _root = null;
        private bool allowDuplicateKeys = false;
        private int _count = 0;
        public int Count { get => _count; }
        public BinaryTreeItem<T> RootItem
        {
            get
            {
                return _root;
            }
        }

        private void Add(T value, BinaryTreeItem<T> item)
        {
            if (!allowDuplicateKeys && value.CompareTo(item.Value) == 0)
            {
                item.Value = value;
            }
            else if (value.CompareTo(item.Value) < 0)
            {
                //go to left
                if (item.left == null)
                {
                    item.left = new BinaryTreeItem<T>(value, item);
                    ++_count;
                }
                else
                {
                    Add(value, item.left);
                }
            }
            else //go to right
            {
                if (item.right == null)
                {
                    item.right = new BinaryTreeItem<T>(value, item);
                    ++_count;
                }
                else
                {
                    Add(value, item.right);
                }
            }
        }

        private IEnumerator<BinaryTreeItem<T>> GetItemEnumerator(BinaryTreeItem<T> item)
        {
            Stack<BinaryTreeItem<T>> stackItem = new Stack<BinaryTreeItem<T>>();
            while (item != null || stackItem.Count != 0)
            {
                if (stackItem.Count != 0)
                {
                    item = stackItem.Pop();
                    yield return item;

                    if (item.right != null) item = item.right;
                    else item = null;
                }
                while (item != null)
                {
                    stackItem.Push(item);
                    item = item.left;
                }
            }
        }

        private BinaryTreeItem<T> GetItemFromValue(T value, BinaryTreeItem<T> item)
        {
            if (item.Value.Equals(value))
                return item;
            else if (item.Value.CompareTo(value) > 0)
            {
                if (item.left != null)
                    return GetItemFromValue(value, item.left);
            }
            else
            {
                if (item.right != null)
                    return GetItemFromValue(value, item.right);
            }
            return null;
        }

        private void RemoveItem(BinaryTreeItem<T> item, BinaryTreeItem<T> parent)
        {
            if (item.left == null && item.right == null)
            {
                RemoveItemWithoutChildren(item, parent);
            }
            else if (item.left != null && item.right != null)
            {
                RemoveItemWithBothChildren(item, parent);
            }
            else
            {
                RemoveItemWithOneChild(item, parent);
            }
            --_count;
        }

        private void RemoveItemWithoutChildren(BinaryTreeItem<T> item, BinaryTreeItem<T> parent)
        {
            if (item == _root)
            {
                _root = null;
                return;
            }
            if (parent.left == item)
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
        }

        private void RemoveItemWithOneChild(BinaryTreeItem<T> item, BinaryTreeItem<T> parent)
        {
            BinaryTreeItem<T> childItem;

            childItem = item.left ?? item.right;

            if (parent.left == item)
            {
                parent.left = childItem;
            }
            else
            {
                parent.right = childItem;
            }

            childItem.parent = parent;
        }

        private void RemoveItemWithBothChildren(BinaryTreeItem<T> item, BinaryTreeItem<T> parent)
        {
            //Find successor Node
            BinaryTreeItem<T> success = item.right;
            BinaryTreeItem<T> successParent = item;
            bool tmp = true;
            while (success.left != null)
            {
                tmp = false;
                successParent = success;
                success = success.left;
            }
            if (tmp)
            {
                item.Value = item.right.Value;
                item.right = item.right.right;
                return;
            }
            item.Value = success.Value;
            successParent.left = success.right;

            if (success.right != null) success.right.parent = successParent;
        }

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new BinaryTreeItem<T>(value);
                ++_count;
            }
            else Add(value, _root);
        }

        public void Remove(T value)
        {
            var item = GetItemFromValue(value, RootItem);
            if (item != null)
            {
                RemoveItem(item, item.parent);
            }
                
        }

        public IEnumerator<T> GetEnumerator()
        {
            using (IEnumerator<BinaryTreeItem<T>> e = GetItemEnumerator(_root))
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Value;
                }
            }
        }
    }
}
