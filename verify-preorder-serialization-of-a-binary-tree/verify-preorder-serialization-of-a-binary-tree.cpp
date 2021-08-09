/*
Let's analyse this problem first: it's a binary tree and it's traversed in pre-order. Then there are two points right here:

empty nodes can only be children
parents always go before children
According to binary tree, we also know that the amount of emptynodes will exactly larger than non-empty nodes by one. So before we reach the end: the amount of empty nodes can never be larger and when reaching the end, it will be exactly one.

How are we going to check the empty and non-empty?

quite simple here, since the nodes are separated by comma, we can just traverse the string and once encountering a comma, we check its previous character, if it's # which represents empty nodes otherwise non-empty ones; as for the last node, we are about to take advantage of the termination character \0 as another splitter, same as comma to ensure cleanness of code.
The solution will be as follows then.
*/

class Solution {
public:
    bool isValidSerialization(string preorder) 
    {
        int len = preorder.length(), diff = 0;
        for(int i = 0; i <= len; ++i)
        {
            if(preorder[i]==',' || preorder[i]=='\0')
            {
                if(preorder[i-1] == '#') 
                    diff++;
                else 
                    diff--;
                if(diff==1 && i==len) 
                    return true;
                if(diff > 0) 
                    return false;
            }
        }
        return diff == 1;
    }
};