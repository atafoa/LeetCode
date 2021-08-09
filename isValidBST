#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);



/*
 * Complete the 'isValid' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts INTEGER_ARRAY a as parameter.
 */
 
 /*
 Given an array of numbers, return true if given array can represent preorder traversal of a Binary Search Tree, else return false. Expected time complexity is O(n).
 
 Brute force: Find the firsrt greater value on right side of current node. Let the index of this node be j. Return true if following conditions hold
    All values after the above found greater value are greater than current node.
    Recursive calls for the subarrays a[i+1...j-1] and a[j+1...n-1] also return true
Else return false

Time complexity O(n^2)

O(n) time solution
Use a stack. Here we find the next greater element and after finding next greater, if we find a smaller element then return false

Create empty stack
Initialize root as INT_MIN
Do following for every element a[i]
     a) If a[i] is smaller than current root, return false.
     b) Keep removing elements from stack while a[i] is greater
        then stack top. Make the last removed item as new root (to
        be compared next).
        At this point, a[i] is greater than the removed root
        (That is why if we see a smaller element in step a), we 
        return false)
     c) push a[i] to stack (All elements in stack are in decreasing
        order)
 */

string isValid(vector<int> a) 
{
    int n = a.size(); //size of a
    stack<int> s;   //create an empty stack
    string result;
    
    //initialize current root as minimum possible value
    int root = INT_MIN;
    
    //Traverse given array
    for(int i = 0; i < n; i++)
    {
        //if we find a node who is on the right side and smaller than root then return false
        if(a[i] < root)
        {
            result = "NO";
            return result;
        }
            
        //if a[i] is in right subtree of stack top keep removing items smaller than a[i] and make the last removed item as new root
        while(!s.empty() && s.top()<a[i])
        {
            root = s.top();
            s.pop();
        }
        //at this point either stack is empty or a[i] is smaller than root, push a[i]
        s.push(a[i]);
    }
    result = "YES";
    return result;
}
