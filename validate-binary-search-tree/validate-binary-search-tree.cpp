/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */

/*

Solution
When we do inorder traversal on a BST we know that all the node values that we visit are ascending so to validate a BST we can do inorder traversal if when we visit a node, the value of that node is less than or equal to the previous node value then we can know that BST is not a correct BST and return false. We need to notice on the corner case when the left most node value is INT_MIN.

Time Complexity
Because we might have to visit all the nodes in the tree so the time comlexity is O(n).

Space Complexity
Because the number of stack calls can go up to the number of all nodes of the tree so the space complexity is O(n).

*/

class Solution {
public:
    int prev;
    bool first = true;
    bool res;
    void inorder(TreeNode* root) {
        if (root!=NULL && res) {
            inorder(root->left);
            if (!first && root->val<=prev) {
                res = false;
                return;
            }
            prev = root->val;
            first = false;
            inorder(root->right);
        }
    }
    
    bool isValidBST(TreeNode* root) {
        res = true;
        inorder(root);
        return res;
    }
};