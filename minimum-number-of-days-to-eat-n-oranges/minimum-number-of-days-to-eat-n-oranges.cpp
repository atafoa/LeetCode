class Solution {
    unordered_map<int, int> dp;
public:
    int minDays(int n) {
        dp[0] = 0;
        return solve(n);
    }
    
    int solve(int n) {
        if (dp.find(n) != dp.end()) {
            return dp[n];
        }
        int ans = INT_MAX;
        if (n%3 == 0 && n%2 == 0) {         // Divisible by both -
            ans = min(ans, 1 + solve(n/3)); // So find whichever yields minimum among
            ans = min(ans, 1 + solve(n/2)); // n/2 and n/3.
            
        } else if (n%3 == 0) {              // Only divisible by 3, but not 2
                                            // which means this is an odd number.
            ans = min(ans, 1 + solve(n/3)); // Try n/3.
            ans = min(ans, 1 + solve(n-1)); // Or it may happen that going to the nearest 
                                            // even number i.e. (n-1) might yield better
                                            // answer (which can take n/2 route). So try that.
            
        } else if (n%2 == 0) {                  // Only divisible by 2, but not 3.
            ans = min(ans, 1 + solve(n/2));     // Try n/2.
                    
            // Similar to previous case, now find nearest number divisible by 3.
            if ((n-1)%3 == 0) {                 
                ans = min(ans, 1 + solve(n-1));
            } else {
                ans = min(ans, 2 + solve(n-2));
            }
            
        } else {                            // Not divisible by 3 and 2. Which means an odd number.
            ans = min(ans, 1+solve(n-1));   // (n-1) must be even, which will try n/2 route.
            if ((n-2)%3 == 0) {             // if n-2 is divisible by 3, then solve that which will
                                            // take n/3 route.
                ans = min(ans, 2 + solve(n-2));
            }
        }
        dp[n] = ans;                        // Very important - MEMOIZE.
        return dp[n];       // YAY, congratulations. Found the answer.
    }
};