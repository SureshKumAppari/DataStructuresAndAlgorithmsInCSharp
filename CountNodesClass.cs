using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class CountNodesClass
    {
        public static int CountNodes(TreeNode root)
        {
            return root != null ? 1 + CountNodes(root.right) + CountNodes(root.left) : 0;
        }
    }
}
