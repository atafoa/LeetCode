/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
    ListNode *getIntersectionNode(ListNode *headA, ListNode *headB) {
        
        // 1. get length of both lists
        // 2. loop through the longer list m - n times: where 'm' is the length of the longer list and 'n' is the length of the shorter list - so as to shift the head of the longer list to the same starting position as that of the shorter list
        // because of step 2 above, traversing both lists would result in them getting to the end at the same time
        // 3. hence, if there is an intersection, node1 will equal node2, if not they'll get to null and we can return a null pointer
        
        ListNode *nodeA = headA;
        ListNode *nodeB = headB;
        int firstLength = 0;
        int secondLength = 0;
        
        // step 1
        while(nodeA != nullptr || nodeB != nullptr) {
            if (nodeA != nullptr) {
                firstLength++;
                nodeA = nodeA->next;
            }
            
            if (nodeB != nullptr) {
                secondLength++;
                nodeB = nodeB->next;
            }
        }
        
        // step 2
        nodeA = headA;
        nodeB = headB;
        if (firstLength > secondLength) {
            // shift start point to be the same as shorter list
            for(size_t i = 0; i < firstLength - secondLength; i++) nodeA = nodeA->next;
        } else {
            // shift start point to be the same as shorter list
            if (secondLength > firstLength)
                for(size_t i = 0; i < secondLength - firstLength; i++) nodeB = nodeB->next;
        }
        
        // step 3
        while(nodeA != nullptr) {
            if (nodeA == nodeB) return nodeA;
            nodeA = nodeA->next;
            nodeB = nodeB->next;
        }
        
        return nodeA;
        
    }
};