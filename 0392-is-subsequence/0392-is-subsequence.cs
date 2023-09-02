public class Solution {
    public bool IsSubsequence(string s, string t) {
        // use two pointers for two different strings
        // loop through main string
        // if t[i] == s[j]
            // j++;
            // else check next char
        // once j is equal to s.length we can stop looping and return true


        if (s.Equals(""))
            return true;
        
        int j = 0;
        for(int i = 0; i < t.Length ; i++)
        {
            if(t[i] == s[j])
            {    j++;
                if (j == s.Length)
                    return true;
            }
        }

        return false;
    }
}