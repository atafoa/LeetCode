/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        // use a hash table
        // this involves storing visited nodes in a hast table, during traversal if a node encountered already exists in the table theres a cycle
        // alt use two pointers moving at two different speeds if there is a cycle the fast pointer would catch up to the slow pointer

        // create an empty set
        // travserse the list starting from the head node
        // at each node check if it already exists in set
        // if it does return true
        // else add node to set


        HashSet<ListNode> visitedNodes = new();
        ListNode currentNode = head;

        while(currentNode != null)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return true;
            }
            visitedNodes.Add(currentNode);
            currentNode = currentNode.next;
        }

        return false;
    }
}