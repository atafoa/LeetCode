class Solution:
    def reverseKGroup(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        #Time O(N) Space O(1)
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
        
        node = head
        counter = 0
        while node:
            node = node.next
            counter += 1
            
            if 0 == counter % k:
                
                #reverse the group
                rev_head = reverse_first_k(head,k)
                
                head.next = self.reverseKGroup(node,k)
                
                return rev_head
              
          return head      


