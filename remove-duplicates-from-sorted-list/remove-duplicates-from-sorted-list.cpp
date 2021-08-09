/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */

/*
    Simple solution(brute force): consider every distinct pair of nodes in the list and check if they have the same data or not. 
    if the data matches, delete latter node. Time complexity O(n^2)
    where N is total number of nodes in list
    
    We can perform a better solution using hashing
    We can traverse the given list and insert each encountered node in a set
    If the current node already exisists, ignore it and move to the next element
    Then remove all duplicate nodes
    */


class Solution {
public:
    ListNode* deleteDuplicates(ListNode* head) {
        ListNode* previous = nullptr;
        ListNode* current = head;
        
        //take an empty set to store linked list nodes for future references
        unordered_set<int> set;
        
        //do till linked list is empty
        while(current != nullptr)
        {
            //if the current node is seen before, ignore it
            if(set.find(current->val) != set.end())
            {
                previous->next = current->next;
            }
            else
            {
                //insert the current node into the set and proceed to the next node
                set.insert(current->val);
                previous = current;
            }
            current = previous->next;
        }
        return head;
    }
};