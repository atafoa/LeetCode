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
    //inorder traversal of the bst, we know that all the node values we visit are asc
    // to validate when we visit a node if the value is less or equal to prev value then return false
    Stack<int> stack;
    bool result;
    public bool IsValidBST(TreeNode root) {
        stack = new Stack<int>();
        result = true;
        DFS(root);
        return result;
    }

    private void DFS(TreeNode root)
    {
        if(root == null || result == false)
            return;
        DFS(root.left);
        if(stack.Count > 0 && stack.Pop() >= root.val)
            result = false;

        stack.Push(root.val);
        DFS(root.right);
    }
}