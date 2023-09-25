public class Solution {
    public int LongestCommonSubsequence(string s1, string s2) {
        // create a 2d array of size s1 and s2
        // iterate through the array and check the characters are equal
        // if equal add 1 to the previous diagonal value
        // else take the max of prev row and prev col
        // return the last value in the array

        int[,] dp = new int[s1.Length+1,s2.Length+1];
        for(int i = 1; i <= s1.Length; i++)
        {
            for(int j = 1; j <= s2.Length; j++)
            {
                if(s1[i-1] == s2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1]+1;
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }

        return dp[s1.Length, s2.Length];
    }
}