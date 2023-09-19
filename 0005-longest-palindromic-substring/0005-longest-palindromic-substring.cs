public class Solution {
    public string LongestPalindrome(string s) {
        // we can traverse the string once
        //  expand around middle char checking if its a palindrome
        // Once found new palindrome longer update length
        // shift pointers
        // for even length we can

        string res = "";
        int length = 0;

        
        for(int i = 0; i < s.Length; i++)
        {
            //odd length
            int l = i;
            int r = i;
            while(l >= 0 && r < s.Length && s[l] == s[r])
            {
                if(r - l + 1 > length)
                {
                    res = s.Substring(l, r - l+1);
                    length = r - l + 1;
                }

                l--;
                r++;  
            }
        
            //even length
            l = i;
            r = i+1;
            while(l >= 0 && r < s.Length && s[l] == s[r])
            {
                if(r - l + 1 > length)
                {
                    res = s.Substring(l, r - l+1);
                    length = r - l + 1;
                }

                l--;
                r++;  
            }
        }

        return res;
    }
}