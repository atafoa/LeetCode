public class Solution {
    public bool IsSubsequence(string s, string t) {
        // use two pointers for two different strings
        // loop through both strings
        // if t[i] == s[j]
            // j++;
            // else check next char
        // return if j = s.length


        if (s.Equals(""))
            return true;
        
        int j = 0;
        for(int i = 0; i < t.Length && j < s.Length; i++)
        {
            if(t[i] == s[j])
                j++;
        }

        return j == s.Length;
    }
}