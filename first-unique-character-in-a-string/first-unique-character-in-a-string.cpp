/*
Approach - Map with two string traversals

Traverse the string storing each character and its frequency in a map
Using the map traverse the string again returning the position where we get frequency of char as 1

Input: leetcode
Output: 0

l 1
e 2
t 1
c 1
o 1
d 1

0..345
l..tcod
*/

class Solution {
public:
    int firstUniqChar(string s) {
        int n = s.length(); 
        map<char,int>mp; //map to store the frequency of each character
        
        for(char c : s)
        {
            mp[c]++; //we push every char into map so that we get the frequency of character
        }
        
        for(int i=0; i<n; i++)
            if(mp[s.at(i)] == 1) //we traverse the map and return the position where we get frequency of char is 1
                return i;

        return -1;
    }
};