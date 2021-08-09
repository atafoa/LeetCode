#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);

class SinglyLinkedListNode {
    public:
        int data;
        SinglyLinkedListNode *next;

        SinglyLinkedListNode(int node_data) {
            this->data = node_data;
            this->next = nullptr;
        }
};

class SinglyLinkedList {
    public:
        SinglyLinkedListNode *head;
        SinglyLinkedListNode *tail;

        SinglyLinkedList() {
            this->head = nullptr;
            this->tail = nullptr;
        }

        void insert_node(int node_data) {
            SinglyLinkedListNode* node = new SinglyLinkedListNode(node_data);

            if (!this->head) {
                this->head = node;
            } else {
                this->tail->next = node;
            }

            this->tail = node;
        }
};

void print_singly_linked_list(SinglyLinkedListNode* node, string sep, ofstream& fout) {
    while (node) {
        fout << node->data;

        node = node->next;

        if (node) {
            fout << sep;
        }
    }
}



/*
 * Complete the 'condense' function below.
 *
 * Given an unsorted list remove duplicates from the list by traversing it once
 * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
 * The function accepts INTEGER_SINGLY_LINKED_LIST head as parameter.
 */

/*
 * For your reference:
 *
 * SinglyLinkedListNode {
 *     int data;
 *     SinglyLinkedListNode* next;
 * };
 *
 */
 
 /*
    Simple solution(brute force): consider every distinct pair of nodes in the list and check if they have the same data or not. 
    if the data matches, delete latter node. Time complexity O(n^2)
    where N is total number of nodes in list
    
    We can perform a better solution using hashing
    We can traverse the given list and insert each encountered node in a set
    If the current node already exisists, ignore it and move to the next element
    Then remove all duplicate nodes
    */

//Function to remove duplicates from a list
SinglyLinkedListNode* condense(SinglyLinkedListNode* head) {
    SinglyLinkedListNode* previous = nullptr;
    SinglyLinkedListNode* current = head;
    
    //take an empty set to store linked list nodes for future references
    unordered_set<int> set;
    
    //do till linked list is empty
    while(current != nullptr)
    {
        //if the current node is seen before, ignore it
        if(set.find(current->data) != set.end())
        {
            previous->next = current->next;
        }
        else {
            //insert the current node into the set and proceed to the next node
            set.insert(current->data);
            previous = current;
        }
        current = previous->next;
    }
    return head;
}
