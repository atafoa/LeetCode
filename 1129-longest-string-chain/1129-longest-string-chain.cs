public class Solution {
    public int LongestStrChain(string[] words) {
        Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
        Dictionary<string, int> dp = new Dictionary<string, int>();
        int max_chain = 0;
        foreach (var word in words) {
            dp[word] = 1;
            for (int i = 0; i < word.Length; i++) {
                string prev_word = word.Remove(i, 1);
                if (dp.ContainsKey(prev_word)) {
                    dp[word] = Math.Max(dp[word], dp[prev_word] + 1);
                }
            }
            max_chain = Math.Max(max_chain, dp[word]);
        }
        return max_chain;
    }
}