class Solution {
public:
    int search(vector<int>& nums, int target) {
    int start = 0;
    int end = nums.size();
    int mid;
 
   while(start < end)
   {
     mid = ((start + end)/2);
     if(nums[mid] == target)
          return mid;
          
    if(nums[start] < nums[mid])
    {
      if(target >= nums[start] && target <= nums[mid])
      {
        end = mid;
      }
      else
      {
        start = mid;
      }
    }
    else
    {
      if(target >= nums[start] || target <= nums[mid])
      {
        end = mid;
      }
      else
      {
        start = mid;
      }
    }
   }
   return -1;
    }
};