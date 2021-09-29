/*
Approach

Two pointers starting from the start and end of string
We want to traverse the whole string checking if the characters we're pointing to have the same lowercase 
letter
if they do not match string is not a valid palindrome
    else return true

i        j
race a car
 i      j 
race a car
    i
    e
return false

Other Asumptions
One letter string is a palindrome
Empty string is a palindrome
*/

class Solution {
public:
     bool isValid(char c)
    {
        if( (c >= 'a' && c <= 'z')  || (c >= 'A' && c <= 'Z')  || (c >= '0' && c <= '9') )
        {
            return true;
        }
        return false;
    }
    
    bool isPalindrome(string s) {
    
    if(s.empty() || s.size() == 1)
            return true;
        
    int i = 0;
    int j = s.size()-1;
        
    while(i <= j)
    {
        while(!( isValid(s[i]) ) && i < j ) //ignoring punctuation and whitespace from left
            i++;
        
         while(!( isValid(s[j]) ) && i < j ) //ignoring punctuation and whitespace from right
            j--;
        
         if( tolower(s[i]) != tolower(s[j]) )      // palindrome condition
            return false ;
        
        i++;//incrementing pointers
        j--;
    }
        return true;
        
        
    }
};