public class Solution {
    public int Search(int[] nums, int target) {
        // Binary Search
        int low = 0, high = nums.Length - 1;
        // find the index of the smallest value using binary search
        // Loop will terminate since mid < hi, and lo or hi will shrink by at least 1.
        // Proof by contradiction that mid < hi: if mid==hi, then lo==hi and loop would have been terminated.
        while ( low < high )
        {
            int mid = ( low + high ) / 2;
            if ( nums[mid] > nums[high])
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        // low = high is the index of the smallest value and also the number of places rotated
        int rotated = low;
        low = 0; 
        high = nums.Length - 1;

        // binary search accouting for rotation
        while ( low <= high )
        {
            int mid = ( low + high ) / 2;
            int realMid = ( mid + rotated ) % nums.Length;
            if(nums[realMid] == target)
                return realMid;
            if(nums[realMid] < target)
                low = mid + 1;
            else 
                high = mid - 1;
        }
        
        return -1;
    }
}