public class Solution {
    public int FindMin(int[] nums) {
        //Initialize left and right pointers
        int left = 0, right = nums.Length - 1;

        //Binary search
        while(left < right)
        {
            //calculate mid point
            int mid = left + (right - left) / 2;

            // if mid element is greater than last element of the array
            // then min element must be in right half of the array
            // so update left pointer
            if(nums[mid] > nums[right]) 
            {
                left = mid + 1;
            }

            //Otherwise the min element must be in the left half of the array
            // Update right pointer
            else
            {
                right = mid;
            }
        }

        //At the end of the while loop left pointer points to the min element of the array
        return nums[left];
    }
}