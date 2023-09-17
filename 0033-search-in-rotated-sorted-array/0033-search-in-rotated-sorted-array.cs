public class Solution {
    public int Search(int[] nums, int target) {
        // Binary Search
        int left = 0; 
        int right = nums.Length - 1;

        // first case
        while (left <= right)
        {
            int mid = ( left + right ) / 2;
            if (target == nums[mid])
            {
                return mid;
            }

            // left sorted portion
            if(nums[left] <= nums[mid])
            {
                if(target > nums[mid] || target < nums[left])
                {
                    left = mid + 1; //search right portion
                }
                else //target less that mid but greater than left
                {
                    right = mid - 1; //search left
                }
            }
            else // right sorted portion
            {
                if(target < nums[mid] || target > nums[right])
                {
                    right = mid - 1; //search left portion
                }
                else //target greater than mid and less than right
                {
                    left = mid + 1; //search right
                }
            }
        } 
        return -1;
    }
}