using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PracticeConsole
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;

        }
    }

    class DeleteNodesAndReturnForest
    {
        private void Solve(string[] args)
        {
            TreeNode root = new TreeNode(1, null, null);
            root.left = new TreeNode(2, new TreeNode(4, null, null), new TreeNode(5, null, null));
            root.right = new TreeNode(3, new TreeNode(6, null, null), new TreeNode(7, null, null));
            int[] to_delete = new int[] { 3, 5 };
            IList<TreeNode> newList = DelNodes(root, to_delete);
            Console.WriteLine(newList[0].left.left.val + "," + newList[1].val + "," + newList[2].val);
        }
        public static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            // apply preorder traversal
            // passing parent node, isLeft (left child)
            // put to_delete to a hashSet
            if (root == null)
                return new List<TreeNode>();
            var set = new HashSet<int>(to_delete);
            var list = new List<TreeNode>();

            runPreorderTraversal(root, null, false, set, list);

            return list;
        }

        /*     
        Input:
               1
              / \
             /   \
            2     3
           / \   / \
          4   5 6   7
          
        Output:
               1
              / 
             /   
            2     
           /      
          4     6   7

         */
        private static void runPreorderTraversal(TreeNode root, TreeNode parent, bool isLeft,
                                         HashSet<int> set, List<TreeNode> list)
        {
            if (root == null)
            {
                return;
            }

            var val = root.val;
            var isDelete = set.Contains(val);
            var next = root;

            if (isDelete)
            {
                if (parent != null)
                {
                    if (isLeft)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }

                next = null;
            }
            else // is not delete
            {
                if (parent == null)
                {
                    list.Add(root);
                }

                next = root;
            }

            runPreorderTraversal(root.left, next, true, set, list);
            runPreorderTraversal(root.right, next, false, set, list);
        }

        public void TreeTraversal(TreeNode root, TreeNode parent, bool isLeft, HashSet<int> set, IList<TreeNode> list)
        {
            if (root == null) return;

            int val = root.val;
            bool isToDelete = set.Contains(val);
            var next = root;

            if(isToDelete)
            {
                if(parent != null)
                {
                    if(isLeft)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
                next = null;
            }
            else
            {
                if(parent == null)
                {
                    list.Add(root);
                }
                next = root;
            }

            TreeTraversal(root.left, next, true, set, list);
            TreeTraversal(root.right, next, false, set, list);
        }
    }
}
