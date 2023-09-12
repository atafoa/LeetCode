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
    public ListNode DeleteMiddle(ListNode head) {
        /*
        Approach
        Find the middle element using fast and slow pointer concept
        Slow pointer will end up on the middle of the linked list, Always maintain the prev of slow pointer
        Point previous node of middle to next node of middle
        */

        ListNode slow = head;
        ListNode fast = head;
        ListNode temp = null;

        while(fast != null && fast.next != null)
        {
            temp = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        if (temp == null)
            return null;

        temp.next = slow.next;
        return head;
    }
}