using System;
namespace BinaryTree.Models
{
    public class Node
    {
        
        #region PROPERTIES

        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        #endregion


        public Node(int value)
        {
            this.Value = value;
        }
    }
}
