# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def preorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        
        def helper(node):
            
            #base case
            if node is None:
                return
            
            #recursion
            result.append(node.val)
            helper(node.left)
            helper(node.right)
            
            
            
        result = []
        helper(root)
        return result