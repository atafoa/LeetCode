/*
Basically we are checking at index, what is the longest suffix of string which is also prefix.
Initially lets take array, arr[0] =0 since the length of longest prefix that also sufix is0.
Now we just iterate through the string,at every index we have two cases,
case-1 s[len] == s[i] means which for a string ending at indexi, there is a len which is matching the prefix that also a suffix, so we increment our len and increase our index i.
case-2 s[len] != s[i], here we again have two cases,
->if the len == 0 then our cur len of prefix that also suffix is 0,
->but if our len != 0, we need to check whether if we match our char at len-1 ,in this case we donot increment our i, so we somewhere the len is matched it goed under case 1, or eventually len will become 0 and goes to another part of ** case -2**
*/


class Solution {
public:
    string longestPrefix(string s) {
        int n = s.length();
        int arr[n];
        arr[0] = 0;
        int i = 1,len = 0;
        
        while(i < n)
        {
            if(s[len] == s[i])
            {
                arr[i] = ++len;
                i++;
            }
            else
            {
                if(len != 0)
                   len = arr[len-1];
                else
                {
                    arr[i] = 0;
                    i++;
                }
            }
        }
        return s.substr(0,len);
    }
};