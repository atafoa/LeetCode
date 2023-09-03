public class Solution {
    public int PivotIndex(int[] nums) {
        /*
        Let's say we knew S as the sum of the numbers, and we are at index i. If we knew the sum of numbers    leftsum that are to the left of index i, then the other sum to the right of the index would just be S - nums[i] - leftsum.

    As such, we only need to know about leftsum to check whether an index is a pivot index in constant time. Let's do that: as we iterate through candidate indexes i, we will maintain the correct value of leftsum.

    Time complexity O(n)
    Space O(1)
    */

        int sum = 0, leftSum = 0;
        foreach( int x in nums)
        {
            sum += x;
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            if(leftSum == sum - leftSum - nums[i])
            {
                return i;
            }
            leftSum += nums[i];
        }
        return -1;
    }
}