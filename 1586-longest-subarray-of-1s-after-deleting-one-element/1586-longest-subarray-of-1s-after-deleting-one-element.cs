public class Solution {
    public int LongestSubarray(int[] nums) {
        /*
        We always move forward with pointer R whenever nums[R] points to zero we will increment our counter of maxZero by 1. As a next step we check if we have more than 1 zeros in our subarray then we need to shrink our window from using L pinter. Make sure to decrement maxZero if the nums[L] poining to 0. This will eliminate the 0 from our subarray.

For every step check if maxZero in current subarray is less than 1 update maxLen of subarray.
        */

        int left = 0;
        int right = 0;
        int maxLen = 0;
        int deletedZero = 0;

        while(right < nums.Length)
        {
            if(nums[right] == 0)
                deletedZero++;
            
            if(deletedZero > 1)
            {
                if(nums[left] == 0)
                    deletedZero--;
                
                left++;
            }

            if(deletedZero <= 1)
            {
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            right++;
        }

        return maxLen - 1;
    }
}