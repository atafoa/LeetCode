/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Time = Space = O(logn), Recursive
        // both p & q are on left side of current node LCA on left
        // both p & q are on right side of current node LCA on right
        // both either p or q value matches current node LCA is current
        // one is on left and other in on right sided of current node LCA is current

        if(p.val < root.val && q.val < root.val)
            return LowestCommonAncestor(root.left, p, q);
        else if(p.val > root.val && q.val > root.val)
            return LowestCommonAncestor(root.right, p, q);
        else return root;

        // iterative
        /*
            while (curr)
            {
                if(p.val < curr.val && q.val < curr.val) curr = curr.left;
                else if(p.val > curr.val && q.val > curr.val) curr = curr.right;
                else return curr;
            }
            return curr
        */
    }
}