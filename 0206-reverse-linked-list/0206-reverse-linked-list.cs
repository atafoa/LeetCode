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
    public ListNode ReverseList(ListNode head) {
        // two pointers
        // initialize current to head
        // maintain a prev pointer set to null
        // take next pointer and reverse, then shift
        // if curr is null then stop looping and return prev

        ListNode prev = null;
        ListNode curr = head;
        ListNode next = null;

        while(curr != null)
        {
            next = curr.next; 
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}