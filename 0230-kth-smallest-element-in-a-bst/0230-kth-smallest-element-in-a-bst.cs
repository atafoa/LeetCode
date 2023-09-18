/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k) {

        // inorder traversal of the tree
        // traverse down left subtree of tree adding to stack
        // when null we want to pop back up to the prev node ( top of stack )
        // only after visiting a node we visit right sub tree adding to stack

        int cur = 0; // no of elements visited 
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (stack.Count > 0 || root != null)
        {
            if(root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                root = stack.Pop();
                cur++;
                if (cur == k)
                    return root.val;
                root = root.right;
            }
        }

        return -1;
    }
}