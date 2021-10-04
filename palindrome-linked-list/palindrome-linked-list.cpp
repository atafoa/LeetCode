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
//Find midpoint of LL, break into two halves and then reverse one half.
//Match both one by one iteratively.

class Solution {
public:
    ListNode* middleNode(ListNode* head) {
    if(head==NULL || head->next==NULL){
        return head;
    }
    ListNode* slow=head;
    ListNode* fast=head->next;
    while(fast!=NULL && fast->next!=NULL){
        slow=slow->next;
        fast=fast->next->next;
    }
    return slow;
}

ListNode* rev(ListNode* head){
    ListNode* curr=head;
    ListNode* prev=NULL;
    ListNode* fwd=NULL;
    while(curr!=NULL){
        fwd=curr->next;
        curr->next=prev;
        prev=curr;
        curr=fwd;   
    }
    return prev;
}

bool isPalindrome(ListNode *head)
{
    if(head==NULL || head->next==NULL){
        return true;
    }
   	ListNode* mid=middleNode(head);
	ListNode *n2=mid->next;
    mid->next=NULL;
    ListNode* revn2=rev(n2);
    bool ans=true;
    ListNode* tmp=head;
    while(tmp!=NULL && revn2!=NULL){
        if(tmp->val!=revn2->val){
            return false;
        }
        tmp=tmp->next;
        revn2=revn2->next;
    }
    return true;
}
    
};