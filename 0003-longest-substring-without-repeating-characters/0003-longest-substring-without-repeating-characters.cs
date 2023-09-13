public class Solution {
    public int LengthOfLongestSubstring(string s) {
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