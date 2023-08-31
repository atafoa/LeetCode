public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int n = nums.Length;  // size of the array

        if(n < 3)
            return false;  //array size less than 3 fale by default because of constraints

        int left = Int32.MaxValue;
        int mid = Int32.MaxValue;

        for(int i = 0; i < n; i++)
        {
             //if nums[i] is greater than mid means nums[i] is also greater than left means two elements before index i is less than nums[i] and that are left and mid. we find that it sataisfy the condition of triplet so we return true.
            if(nums[i] > mid)
                return true;

             //if nums[i] is greater than left and less than mid then it is clear that we find b in a < b < c because it is quite possible that c can be INT_MAX.
            else if(nums[i] > left && nums[i] < mid)
                mid = nums[i];
            
            //if nums[i] less than left then we update the value of left to nums[i] because we find a smaller element than it's previous value.
            else if(nums[i] < left)
                left = nums[i];
        }

        return false; // when traversed whole array then no triplet

    }
}