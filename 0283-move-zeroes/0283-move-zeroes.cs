public class Solution {
    public void MoveZeroes(int[] nums) {
        // brute force, loop through encounter a zero swap it with the next char till the end
        // if not a zero skip

        // optimize, quick sort the array around the last element
        // swap the left and the right

        int left = 0;

        for(int right = 0; right < nums.Length; right++)
        {
            if(nums[right] != 0)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
            }
        }
    }
}