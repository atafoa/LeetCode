/*
Lets build the logic first.
Say the given string is s="acbc"
At frist, we try to find where a mismatch occurs. Say we assain a pointer to the beginning and a pointer to the last position. i.e i=0,j=2;
Now we check if s[i] != s[j], if it is so, then a mismatch occured. We can either delete s[i] and check if s is palindrome, or we can delete s[j] and check if s is palindorme. In this case, s[0]!=s[2], so we delete s[2], the rest is acb, which is not palindrome. Now we delete s[0], the string is now cbc which is a palindrome. So the final answer is Yes.
*/


class Solution {
public:
    bool palin(string s,int index) //this function delete s[i] or s[j] 
    {                                           // and checks whether rest is palindrome or not
        string temp1,temp2;
        for(int i=0;i<s.length();i++)
        {
            if(i!=index) temp1+=s[i];
        }
        temp2=temp1;
        reverse(temp2.begin(),temp2.end());
        if(temp1==temp2) return true;
        return false;
    }
    bool validPalindrome(string s) {
        int i=0,j=s.length()-1;
        while(i<j)
        {
            if(s[i]!=s[j]) //mismatch occured;
            {
                if(palin(s,i)==true) return true; //delete s[i] and check;
                if(palin(s,j)==true) return true; //delete s[j] and check;
                return false; 
            }
            i++; // s[i]==s[j], so i++ and j-- 
            j--;
        }
        return true;
    }
};