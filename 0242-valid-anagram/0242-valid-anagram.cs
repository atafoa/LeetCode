public class Solution {
    public bool IsAnagram(string s, string t) {
        // Approach
        // if both strings aren't the same length return false
        // store the frequency of each character in both strings
        // increasing frequency count for chars in s and decreasing count for t
        // if every element in the dictionary has a frequency of 0 return true
        // else false

        // alternate approach
        // sort strings and compare

        if(s.Length != t.Length)
        {
            return false;
        }

        var dict = new Dictionary<char, int>();
        foreach(char c in s.ToCharArray())
        {
            if(!dict.ContainsKey(c))
            {
                dict.Add(c,0);
            }
            else
                dict[c]++;
        }

        foreach(char c in t.ToCharArray())
        {
            if(!dict.ContainsKey(c) || dict[c] < 0)
                return false;
            else
            {
                dict[c]--;
            }
        }

        return true;

    }
}