namespace ForStady
{
    internal enum RedBlackTreeNodeColor
    {
        Red,
        Black
    }
    internal class RedBlackTreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public RedBlackTreeNode<T>? Parent { get; set; }
        public RedBlackTreeNode<T>? Left { get; set; }
        public RedBlackTreeNode<T>? Right { get; set; }
        public RedBlackTreeNodeColor Color { get; set; }
        public RedBlackTreeNode(T data)
        {
            Data = data;
            Color = RedBlackTreeNodeColor.Red;
            Left = Right = Parent = null;
        }
        public RedBlackTreeNode<T>? Grandparent() => Parent?.Parent;
        public RedBlackTreeNode<T>? Uncle()
        {
            var grandparent = Grandparent();
            if(grandparent == null) return null;
            else return Parent == grandparent.Left?grandparent.Right:grandparent.Left; 
        }
    }
}
