public class Solution {
    public int Rob(int[] nums) {
        //we're trying to maximize the total money we can rob without hitting two adj houses
        // edge cases if no houses or just one house return 0 or the money in that house
        // initialize an array to keep track of max money at each house
        // Populate the DP array by iterating through the nums array. The value at dp[i] is either the value at dp[i - 1] (meaning we skip the current house) or nums[i] + dp[i - 2] (meaning we rob the current house and add it to the max money from two houses back).
        
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];

        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);

        return dp[nums.Length - 1];

    }
}