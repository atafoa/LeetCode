public class Solution {
    public int LongestCommonSubsequence(string s1, string s2) {
       int[,] dp = new int[2, s2.Length + 1];
        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i%2, j] = dp[(i - 1)%2, j - 1] + 1;
                }
                else
                {
                    dp[i%2, j] = Math.Max(dp[(i-1)%2, j], dp[i%2, j - 1]);
                }
            }
        }
        return Math.Max(dp[1, s2.Length],dp[0, s2.Length]);
    }
}