/*
Approach
The code aims to find the maximum amount of money you can rob from a row of houses, where each house contains a certain amount of money.

It handles two cases:

Robbing the first house and skipping the last house.

Skipping the first house and robbing the last house.

It uses a helper function RobHouse to calculate the maximum amount that can be robbed for a given range of houses.

In each case, it utilizes dynamic programming (DP) to optimize the solution:

It initializes an array dp of the same size as nums to store the maximum amount of money that can be robbed up to the ith house.

For each house, it calculates dp[i] as the maximum between:

The sum of the amount of money in the current house nums[i] and the amount of money robbed from the house two steps back dp[i-2].

The amount of money robbed from the previous house dp[i-1].

Finally, it returns the maximum value between the two cases.

*/

public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1) 
        {
            return nums[0];
        }
        // Instead of creating two separate arrays use the same array and pass the indecies in the function to calculate the max amount.
        int skipLastHouse = RobHouse(nums, 0, nums.Length-1);
        int skipFirstHouse = RobHouse(nums, 1, nums.Length);
        return Math.Max(skipLastHouse, skipFirstHouse);
    }
    private int RobHouse(int[] nums, int start, int end)
    {
        // This condition is added if nums.Length is 2 and we split the array.
        if (end - start == 1)
        {
            return nums[start];
        }
        int[] dp = new int[nums.Length];
        dp[start] = nums[start];
        dp[start + 1] = Math.Max(nums[start], nums[start+1]);
        for(int i=start+2; i<end; i++)
        {
            dp[i] = Math.Max(dp[i-2] + nums[i], dp[i-1]);
        }
        return dp[end - 1];
    }
}