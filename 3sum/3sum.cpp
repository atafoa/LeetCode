/*
There are already several posts about this problem, but just to make it clear for myself, I will still write this post.

The point of 2 sum is to show that 2 sum can be solved in O(n) time using maps.

The point of 3 sum is to show that first, 3 sum can be solved in less than O(n^3) by the basic knowledge that we can pick an element and solve 2 Sum for the rest of the elements (hinting at O(n). However, since we don't want the elements to repeat and we are already taking O(n^2) time, we can afford a O(nlogn) search beforehand. The problem also has a test case that needs to handle duplicates of the first element, so we can add a condition like

if (i>0 && nums[i] == nums[i-1]) continue;
to handle this and then solve the rest with 2 sum (using maps O(n)) which passes but is slow.

However, the optimization is that since we are already sorting the array, we can search for the second and third elements using 2 pointer method. If the sum of the triplet > 0, we decrement the high pointer, < 0 increment the low pointer, and if equal to zero we add the triplet.

The last trick is how to update the pointers when a triplet is found. Note that if either one of the second or third triplet is the same after the update, the last element will result in exactly the same triplet. So, we must update both the low and the high pointers to different values from their current elements.

Hence, keep incrementing the low pointer till it is at an element higher than the one it was on, and similarly decrement the high pointer till it is at an element lower than the one it was on.

We don't have to do this in the > 0 or < 0 cases because in those cases the triplet would never be a candidate for the final result, hence a repeat of > 0 or < 0 after the update will not affect the results.
*/


class Solution {
public:
   vector<vector<int>> threeSum(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        int n = nums.size(); // use n and not nums.size() to avoid an error in C++ where nums.size() - 2 doesn't fit in unsized int
        vector<vector<int>> res;
        for(int i = 0; i<n-2; i++)
        {
            if(i > 0 && nums[i] == nums[i-1])    
            {
                continue;
            }
            
            int j = i + 1; //low pointer
            int k = n - 1; //high pointer
            
            while(j < k)
            {
                if(nums[i] + nums[j] + nums[k] == 0)
                {
                    res.push_back({nums[i],nums[j],nums[k]});
                    
                    while(j < k && nums[j] == nums[j+1]) // keep in mind j < k in these inner loops
                    {
                        j++;
                    }
                    while(j < k && nums[k] == nums[k-1])
                    {
                        k--;
                    }
                    
                    j++;
                    k--;
                }
                else if(nums[i] + nums[j] + nums[k] > 0)
                {
                    k--;
                }
                else
                {
                    j++;
                }
            }
        }
        
        return res;
    }
};