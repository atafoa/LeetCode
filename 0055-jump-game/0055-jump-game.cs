public class Solution {
    public bool CanJump(int[] nums) {
        // The end of the array is true, since that means we are at the solution.
        int goal = nums.Length - 1;
        
        // loop backwards through the array we want to check if our current num can jump us to the nearestTrue
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            // If we can jump to the nearest true, we become the nearest true.
            if(i + nums[i] >= goal)
            {
                goal = i;
            }
        }
        
        // If jumpable goal == 0 else goal would be < 0 return false
        return goal == 0;
    }
}