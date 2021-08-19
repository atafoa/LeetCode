/*
Since each digit can possibly mean one of several characters, we'll need to create code that branches down the different paths as we iterate through the input digit string (D).

This quite obviously calls for a depth-first search (DFS) approach as we will check each permutation of characters and store them in our answer array (ans). For a DFS approach we can use one of several options, but a recursive solution is generally the cleanest.

But first, we'll need to set up a lookup table (L) to convert a digit to its possible characters. Since the digits are actually low-indexed integers, we can actually choose between an array or map/dictionary here with little difference.

For our DFS function (dfs), we'll have to feed it the current position (pos) in D as well as the string (str) being built. The function will also need to have access to D, L, and ans.

The DFS function itself is fairly simple. It will push a completed str onto ans, otherwise it will look up the characters that match the current pos, and then fire off new recursive functions down each of those paths.

Once we're done, we should be ready to return ans.
*/
#include <map>

 unordered_map<char, string> L ({{'2',"abc"},{'3',"def"},{'4',"ghi"},{'5',"jkl"},{'6',"mno"},{'7',"pqrs"},{'8',"tuv"},{'9',"wxyz"}}); 
class Solution {
public:
   
    vector<string> letterCombinations(string digits) {
        int len = digits.size();
        vector<string> ans;
        if(!len)
            return ans;
        dfs(0,len, "", ans, digits);
        return ans;
    }
    
    void dfs(int pos, int &len, string str, vector<string> &ans, string &digits)
    {
        if(pos == len)
            ans.push_back(str);
        else
        {
            string letters = L[digits[pos]];
            for(int i = 0; i < letters.size(); i++)
            {
                dfs(pos+1, len, str+letters[i], ans, digits);
            }
        }
    }
};