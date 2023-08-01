class Solution {
public:
    vector<int> productExceptSelf(vector<int>& nums) {
        /*
        Create an array ans and initializeall of it's elements to 1 and a variable temp = 1.
        Traverse the array from start to end.
        For every index i update ans[i] as ans[i] = temp and temp = temp * nums[i], i.e store the product upto i-1 index from the start of array.
        Now again, temp = 1 and traverse the array in the reverse direction.
        For every index i update ans[i] as ans[i] = ans[i] * temp and *temp = temp nums[i], i.e multiply with the product upto i+1 index from the end of array.

        Time Complexity : O(n)
        Auxiliary Space : O(1)
        */
        int n=nums.size(), temp=1;
        vector<int> ans(n, 1);
        
        for(int i=0;i<n;i++){
            ans[i] *= temp;
            temp *= nums[i];
        }
        temp = 1;
        for(int i=n-1;i>=0;i--){
            ans[i] *= temp;
            temp *= nums[i];
        }
        return ans;
    }
};