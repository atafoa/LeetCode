public class Solution {
    public int MaxSubArray(int[] nums) {
        //iterate through array
        // when we encounter a negative prefix we need to remove negative numbers from cur sum
        // if curr sum is negative then set to 0;
        int maxSub = nums[0];
        int curSum = 0;

        foreach( int n in nums)
        {
            if(curSum < 0)
                curSum = 0;
            curSum += n;
            maxSub = Math.Max(maxSub, curSum);
        }
        return maxSub;
    }
}