using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole
{
    class LongestConsecutive
    {
        public int LongestConsec(TreeNode root)
        {
            return dfs(root, null, 0);
        }


        private int dfs(TreeNode p, TreeNode parent, int length)
        {
            if (p == null) return length;
            length = (parent != null && p.val == parent.val + 1) ? length + 1 : 1;
            return Math.Max(length, Math.Max(dfs(p.left, p, length),
                                             dfs(p.right, p, length)));
        }


    }
}
