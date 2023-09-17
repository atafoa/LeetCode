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
    public void ReorderList(ListNode head) {
        // split the list into two halves using two pointers a fast and slow pointer
        // reverse the second half of the list
        // merge both halves of the list one by one


        ListNode slow = head, fast = head.next;
        // split
        while(fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        // left is first half, right is second half
        ListNode left = head;
        ListNode right = slow.next;

        // break the link between the first and second half;
        slow.next = null;

        //reverse right
        ListNode prev = null;
        ListNode curr = right;

        // reverse right half
        while(curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        //prev is head of reversed list so set right to prev
        right = prev;

        //merge
        while(right != null)
        {
            // maintain reference of next nodes of left and right
            ListNode leftTemp = left.next;
            ListNode rightTemp = right.next;

            //set right pointer next to the left
            left.next = right;
            // merge the maintained ref of left.next in front of right
            right.next = leftTemp;

            //move forward
            left = leftTemp;
            right = rightTemp;
        }
    }
}