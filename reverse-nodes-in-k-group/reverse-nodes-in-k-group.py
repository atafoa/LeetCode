# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def reverseKGroup(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        
        def reverse_first_k(head,k):
            node = head
            pre = None
            while k>0:
                next_node = node.next
                node.next = pre
                pre = node
                node = next_node
                k -= 1
            return pre
        
        final_head = None
        counter = 0
        tail = None
        node = head
        
        while node:
            node = node.next
            counter += 1
            
            if 0 == counter % k:
                
                #reverse the group
                rev_head = reverse_first_k(head,k)
                if final_head is None:
                    final_head = rev_head
                    
                if tail:
                    tail.next = rev_head
                
                tail = head
                head = node
                
        if tail:        
            tail.next = head    
        
        if final_head is None:
            return head
        
        return final_head
                