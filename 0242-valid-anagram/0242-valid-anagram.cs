public class Solution {
    public bool IsAnagram(string s, string t) {
        // Approach
        // if both strings aren't the same length return false
        // store the frequency of each character in both strings
        // increasing frequency count for chars in s and decreasing count for t
        // if every element in the dictionary has a frequency of 0 return true
        // else false

        if(s.Length != t.Length)
        {
            return false;
        }

        var map = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (map.ContainsKey(c))
            {
                map[c]++;
            }
            else {
                map.Add(c,1);
            }

            if (map.ContainsKey(t[i]))
            {
                map[t[i]]--;
            }
            else
            {
                map.Add(t[i], -1);
            }
        }
        return !map.Any(x => x.Value != 0); // if all values are 0 return true

    }
}