public class Solution {
    public int LongestOnes(int[] nums, int k) {
        // update the number of 0's in the current window when either left or right values change

        // window condition have at most k zeros to flip

        int left = 0, max = 0, windowZeroCount = 0;

        for(int right = 0; right < nums.Length; right++)
        {
            windowZeroCount += 1 - nums[right];

            while ( windowZeroCount > k)
            {
                if(nums[left++] == 0)
                {
                    windowZeroCount--;
                }
            }

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}