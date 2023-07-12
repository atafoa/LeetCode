public class Solution {
    public int LongestNiceSubarray(int[] nums) {

        /*When adding a new number to the "window" (incrementing right), check whether it's "nice", by comparing it to the other numbers already existing in the window (all array numbers between left and right indexes).

Since any mismatch will invalidate the entire window, speed it up by checking from right towards left, instead of slowly incrementing the left variabile in a loop, as the usual template goes.
*/
        int left = 0, max = 0;

        for(int right = 0; right < nums.Length; right++ )
        {
            for(int i = right - 1; i >= left; i--)
            {
                if((nums[right] & nums[i]) != 0)
                {
                    left = i + 1;
                    break;
                }
            }

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}