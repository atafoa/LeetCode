public class Solution {
    public bool IsPalindrome(string s) {
        // Approach
        // two pointers starting from the start and end of string
        // traverse the whole string checking if characters are the same lowercase letter
        // if no match then not a palindrome

        if(s.Length == 0 || s == null)
        {
            return true;
        }

        int i = 0;
        int j = s.Length - 1;

        while(i <= j)
        {
            while(!(isValid(s[i])) && i < j) // ignoring punctuation and whitespace from left
            {
                i++;
            }

            while(!(isValid(s[j])) && i < j) // ignoring punctuation and whitespace from right
            {
                j--;
            }

            if (Char.ToLower(s[i]) != Char.ToLower(s[j])) // palindrome condition
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }

    public bool isValid(char c)
    {
         if( (c >= 'a' && c <= 'z')  || (c >= 'A' && c <= 'Z')  || (c >= '0' && c <= '9') )
        {
            return true;
        }
        return false;
    }
}