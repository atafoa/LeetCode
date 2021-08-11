/*
The Greedy strategy here is to always choose the interval with the largest space that is yet to be watered. Now we could have done this by storing all the inytervals for each tap and then selecting the largest uncovered interval each time. But this choosing interval method cannot be done in O(1) time as each time we choose an interval, the unused space in the other intervals also changes.

So what we do is that since we know we have to cover each interval atleast once in our optimal solution, we start from the origin.

For each tap, we store the farthest coordinate to the right that can be civered by the same tap in an array. Then, while traversing the array, we also store the max right coordinate that has been covered by the all the coordinates we have visited till now. We also store the max right fot the current tap. Once we cross the max right for the current tap, we set the new value as the next rightmost tap. This way , by maintaining two variables current farthest and next farthest, even if we see a coordinate greater than the max coordinate covered by the current tap, we dont have to find whether we have to include it or not in out answer. We just update the distance in our next farthest variable. This way, if we find a better interval in the future, we can include that when we fnd the uncovered coordinate in the future. This works because through this, we only open a tap when we need to open it and and by then we already have the best further distance we need.
Time Complexity->O(n)
Space Complexity->O(n)

class Solution {
public:
    int minTaps(int n, vector<int>& ranges) {
        
        vector<int>maxRightUsingSameTap(n+1);
        for(int i=0;i<=n;i++)
        {
            int leftRange=max(0,i-ranges[i]);
            int rightRange=min(n,i+ranges[i]);
            maxRightUsingSameTap[leftRange]=max(maxRightUsingSameTap[leftRange],rightRange);
        }
        
        int curr_reachable=maxRightUsingSameTap[0];
        int next_reachable=maxRightUsingSameTap[0];
        int taps=1;
        for(int i=1;i<=n;i++)
        {
            if(i>next_reachable)
            {
                return -1;
            }
            if(i>curr_reachable)
            {
                taps++;
                curr_reachable=next_reachable;
            }
            next_reachable=max(next_reachable,maxRightUsingSameTap[i]);
        }
        return taps;
    }
};

Approach-2 (Typical DP)
Here, for each tap, we check the left and the right range. Then for each tap in this range, we check if adding an extra tap to the taps required till the left border is less than or equal to the number currently there. If yes, then we update the answer.
Here dp[i] is the minimum number of taps to water from 0 to i.
Time Complexity->O(NR) where R is the avg. range for each tap.

class Solution {
public:
    int minTaps(int n, vector<int>& ranges) {
        
        vector<int>dp(n+1, n+2);
        dp[0]=0;
        for(int i=0;i<=n;i++)
        {
            int leftRange=max(0,i-ranges[i]);
            int rightRange=min(n,i+ranges[i]);
            for(int j=leftRange+1;j<=rightRange;j++)
            {
                dp[j]=min(dp[j],dp[leftRange]+1);
            }
        }
        return dp[n]>n+1?-1:dp[n];
    }
};

*/
class Solution {
public:
    int minTaps(int n, vector<int>& ranges) {
        
        vector<int>dp(n+1, n+2);
        dp[0]=0;
        for(int i=0;i<=n;i++)
        {
            int leftRange=max(0,i-ranges[i]);
            int rightRange=min(n,i+ranges[i]);
            for(int j=leftRange+1;j<=rightRange;j++)
            {
                dp[j]=min(dp[j],dp[leftRange]+1);
            }
        }
        return dp[n]>n+1?-1:dp[n];
    }
};