using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PracticeConsole
{
    class DFS
    {
        TreeNode tr = new TreeNode();
        public DFS(int value)
        {
            tr.val = value;
            tr.left = null;
            tr.right = null;
        }

        public void PreOrder(TreeNode node)
        {
            if (node == null)
                return;

            Console.WriteLine("%d", node.val);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void InOrder(TreeNode node)
        {
            if (node == null)
                return;
            InOrder(node.left);
            Console.WriteLine("%d", node.val);
            InOrder(node.right);

        }

        public void PostOrder(TreeNode node)
        {
            if (node == null)
                return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine("%d", node.val);
        }
    }
}
