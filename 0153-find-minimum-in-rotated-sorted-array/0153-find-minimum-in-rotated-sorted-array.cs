public class Solution {
    public int FindMin(int[] nums) {
        //Initialize left and right pointers
        int left = 0, right = nums.Length - 1;
        int result = nums[0];

        //Binary search
        while(left <= right)
        {
            if(nums[left] < nums[right])
            {
                result = Math.Min(result, nums[left]);
                break;
            }

            //calculate mid point
            int mid = (left + right) / 2;
            result = Math.Min(result, nums[mid]);

            // if mid is part of left portion of sorted array
            // search right portion
            if(nums[mid] >= nums[left]) 
            {
                left = mid + 1;
            }

            //Otherwise the min element must be in the left half of the array
            // Update right pointer
            else
            {
                right = mid - 1;
            }
        }

        //At the end of the while loop left pointer points to the min element of the array
        return result;
    }
}