public class Solution {
    public int LengthOfLongestSubstring(string s) {

        // use a set to keep track of unique characters
        // maintain two pointers left and right to represent bounds of current substring
        // The maxlength is the length of the longest substr encountered so far
        // iterate through the string
        // if the current char is not in set it means we have a unique char
        // insert the char into the set and update max length
        // if already present means char is repeating
        //      in this case move left pointer forward removing chars from the set until the repeating char gone
        // return maxLength

        
        int n = s.Length;
        HashSet<Char> set = new();
        int ans = 0, i = 0, j = 0;

        while(i < n && j < n)
        {
            // try to extend the range [i, j]
            if (!set.Contains(s[j]))
            {
                set.Add(s[j++]);
                ans = Math.Max(ans, j - i);
            }
            else
            {
                set.Remove(s[i++]);
            }
        }
        return ans;
    }
}