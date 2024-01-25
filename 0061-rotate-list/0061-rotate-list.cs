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
    public ListNode RotateRight(ListNode head, int k) {
        //make list circular
        // move to the last node of the list, join that to the head and calculate where the new head would be
        
        /*
        if shifting by one, then new head is last           node
        if shifting by two, then new head is            last node -1, etc
        note: handle shifts greater than the # of           nodes by making k = k % count
        */
        
        if(head==null) 
            return head;
		var n = head;
		int count = 0;
		while (n.next != null)
        {
			n = n.next;
			count++;
		}
		n.next = head;
		n = n.next;
		count ++;
		
		k = k % count;
		for(var i = 0; i < count-(k+1); i++) 
            n = n.next;

		head = n.next;
		n.next = null;
		return head;
    }
}