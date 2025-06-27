namespace ForStady
{
    internal class MyTree
    {
        public int Value { get; }
        private List<MyTree> _children = new List<MyTree>();
        public MyTree(int value, MyTree root)
        {
            Value = value;
            root._children.Add(this);
        }
        public MyTree? FindExample(int value)
        {
            if (Value == value) return this;
            MyTree ?findedMyTree = _children.FirstOrDefault(child => child.Value==value);
            return findedMyTree;
        }

    }
}
