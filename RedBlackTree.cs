namespace ForStady
{
    internal class RedBlackTree<T> where T : IComparable<T>
    {
        public RedBlackTreeNode<T>? Root {  get; private set; }
        public void Insert(T data)
        {
            var newNode = new RedBlackTreeNode<T>(data);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                RedBlackTreeNode<T>? parent = null;
                while (current != null)
                {
                    parent = current;
                    current = newNode.Data.CompareTo(current.Data) < 0 ? current.Left : current.Right;
                }
                newNode.Parent = parent;
                if (newNode.Data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }
            FixInsertViolations(newNode);
        }
        private void FixInsertViolations(RedBlackTreeNode<T> node)
        {
            while (node != Root && node.Parent.Color == RedBlackTreeNodeColor.Red)
            {
                if(node.Parent == node.Grandparent().Left)
                {
                    var uncle = node.Uncle();
                    if (uncle != null && uncle.Color == RedBlackTreeNodeColor.Red)
                    {
                        node.Parent.Color = RedBlackTreeNodeColor.Black;
                        uncle.Color = RedBlackTreeNodeColor.Black;
                        node.Grandparent().Color = RedBlackTreeNodeColor.Red;
                        node = node.Grandparent();
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node= node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.Color = RedBlackTreeNodeColor.Black;
                        node.Grandparent().Color = RedBlackTreeNodeColor.Red;
                        RotateRight(node.Grandparent());
                        
                    }
                }
                else
                {
                    var uncle = node.Uncle();
                    if (uncle != null && uncle.Color == RedBlackTreeNodeColor.Red)
                    {
                        node.Parent.Color = RedBlackTreeNodeColor.Black;
                        uncle.Color = RedBlackTreeNodeColor.Black;
                        node.Grandparent().Color = RedBlackTreeNodeColor.Red;
                        node = node.Grandparent();
                    }
                    else
                    {
                        if(node == node.Parent.Left)
                        {
                            node= node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = RedBlackTreeNodeColor.Black;
                        node.Grandparent().Color = RedBlackTreeNodeColor.Red;
                        RotateLeft(node.Grandparent());
                    }
                }
            }
            Root.Color = RedBlackTreeNodeColor.Black;
        }
        private void RotateLeft(RedBlackTreeNode<T> node)
        {
            var RightChild = node.Right;
            node.Right = RightChild.Left;
            if (RightChild.Left != null)
            {
                RightChild.Left.Parent = node;
            }
            RightChild.Parent = node;
            if(node.Parent == null)
            {
                Root = RightChild;
            }
            else if (node == node.Parent.Left)
            {
                node.Parent.Left = RightChild;
            }
            else
            {
                node.Parent.Right = RightChild;
            }
            RightChild.Left = node;
            node.Parent = RightChild;
        }
        private void RotateRight(RedBlackTreeNode<T> node)
        {
            var LeftChild = node.Left;
            node.Left = LeftChild.Right;
            if (LeftChild.Right != null)
            {
                LeftChild.Right.Parent = node;
            }
            LeftChild.Parent = node;
            if (node.Parent == null)
            {
                Root = LeftChild;
            }
            else if (node == node.Parent.Right)
            {
                node.Parent.Right = LeftChild;
            }
            else
            {
                node.Parent.Left = LeftChild;
            }
            LeftChild.Right = node;
            node.Parent = LeftChild;
        }
        public bool Contains(T data)
        {
            var current = Root;
            while (current != null)
            {
                int comparation = data.CompareTo(current.Data);
                if(comparation==0)return true;
                current = comparation < 0 ? current.Left : current.Right;
            }
            return false;
        }
        public IEnumerable<T> InOrderTraversal()
        {
            var stack = new Stack<RedBlackTreeNode<T>>();
            var current = Root;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                current = stack.Pop();
                yield return current.Data;
                current = current.Right;
            }
        }
    }
}
