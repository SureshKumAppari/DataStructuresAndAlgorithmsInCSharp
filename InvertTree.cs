using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeConsole.InterviewProcess
{
    class InvertTree
    {
        public void Solve(string[] args)
        {
            TreeNode root = new TreeNode(1, null, null);
            root.left = new TreeNode(2, new TreeNode(4, null, null), new TreeNode(5, null, null));
            root.right = new TreeNode(3, new TreeNode(6, null, null), new TreeNode(7, null, null));
            InvertTreeCall(root);
        }

        public static TreeNode InvertTreeCall(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode l = root.left;
            root.left = InvertTreeCall(root.right);
            root.right = InvertTreeCall(l);
            return root;
        }

        //public class TreeNode
        //{
        //    public int val;
        //    public TreeNode left;
        //    public TreeNode right;
        //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        //    {
        //        this.val = val;
        //        this.left = left;
        //        this.right = right;
        //    }
        //}
    }
}
