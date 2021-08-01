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
class Solution {
public:
    TreeNode* changeandput(TreeNode* temp,int n){
        if(temp==NULL){
            return temp;
        }
        TreeNode* node=new TreeNode(temp->val+n);
        node->left=changeandput(temp->left,n);
        node->right=changeandput(temp->right,n);
        return node;
    }
    vector<TreeNode*> generateTrees(int n) {
        vector<vector<TreeNode*>>res(n+1);
        res[0]={NULL};
        res[1]={new TreeNode(1)};
        for(int j=2;j<=n;j++){
            for(int i=1;i<=j;i++){
                for(auto rght:res[j-i]){//for right
                    for(auto lft:res[i-1]){//for left
                        TreeNode* root=new TreeNode(i);
                        root->right=changeandput(rght,i);
                        root->left=lft;
                        res[j].push_back(root);
                    }
                }
             }
        }
        return res[n];
    }
};