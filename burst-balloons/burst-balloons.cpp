/*
The Crux of the problem lies in determining which balloon should be the last one to burst, because this is what is going to affect the final product of any three elements in hand

So we have to consider out of all possible options, which balloon when burst at last gives the maximum value of product
*/


class Solution {
public:
    int maxCoins(vector<int>& nums) {
        // size of the balloon array
        int n = nums.size();
        
        // Padding the balloon array front and back
        nums.insert(nums.begin(), 1);
        nums.push_back(1);
        
        //A 2D DP table to keep track of which element we are taking about(size n+2 for the corners)
        vector<vector<int>> dp(n + 2, vector<int>(n + 2, 0));
        
        // This is O(n^3) solution
        // We will be taking a window starting from 1 and going on to n (win_size)
        // Left and right boundaries of this window will be: left(1 to (n-win_size+1)), right              (left+win_size-1)
        // last burst balloon is to be chosen (choose one by one from left to right)
        
        // The result we need is for the entire array: from index (1) to (N) we will build up to that result from within the dp table
         for (int win_size = 1; win_size <= n; win_size++) 
            for (int left = 1; left + win_size - 1 <= n; ++left) {
                
                int right = win_size + left - 1;
                for (int last = left; last <= right; ++last){ 
                    dp[left][right] = max(dp[left][right], nums[left - 1] * nums[last] * nums[right + 1] + 
                                          dp[left][last - 1] + dp[last + 1][right]);
                }
                
            }
        
        
        return dp[1][n];
    }
};