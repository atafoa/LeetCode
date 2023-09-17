/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // create a dummy node and init two pointers fast and slow such that fast is n times faster than slow
        // to position slow just before the node to delete move both pointers until fast.next is null
        // after nodes are in correct pos delete node by pointing slow.next to slow.next.next
        // return head via dummy.next

        ListNode dummy = new(0, head);
        ListNode slow = dummy, fast = dummy;

        //Gap of fast and slow is n
        for(int i = 0; i < n; i++)
        {
            fast = fast.next;
        }

        // Move slow to the node behind the node to delete
        while(fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        //delete node
        slow.next = slow.next.next;

        return dummy.next;
    }
}