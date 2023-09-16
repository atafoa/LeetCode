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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
       var dummyNode = new ListNode();
       var tail = dummyNode;

       var pointer1 = list1;
       var pointer2 = list2;

       while (pointer1 != null & pointer2 != null)
       {
           if (pointer1.val < pointer2.val)
           {
               tail.next = pointer1;
               pointer1 = pointer1.next;
           }
           else
           {
               tail.next = pointer2;
               pointer2 = pointer2.next;
           }
           tail = tail.next;
       }

       tail.next = pointer1 ?? pointer2;
       
       return dummyNode.next;
    }
}