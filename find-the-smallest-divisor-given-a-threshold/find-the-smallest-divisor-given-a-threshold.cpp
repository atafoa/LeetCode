/*

No chance for an elegant/smart mathematical approach here, so the best thing you can do is to compute the overall sum of the ceiling of each quotient for each divisor at each iteration.

Proceeding with a binary search would still save you a lot of computation.

In order to proceed, I first of all created a helper function dividedSum that takes the original vector and a number, returning the sum of all its elements divided by said number - rounding up.

Notice that I computed it using div, which returns us both the quotient and the reminder in a single operation: we can take the quotient and add 1 when we have any remainder - easily done turning the latter into a boolean.

In the main function, we are going to need 3 support variables: st, ed and mid are going to be our pointers in the binary search routine, with the first 2 initialised to 2 and to the maximum element of nums respectively, while mid is going to be given a value at the beginning of each loop.

And speaking of loops, we are going to have one as long as st < ed (pretty pointless to go on otherwise) and inside our loop we will:

assign the average of st and ed to mid (without fearing any overflow, given the expected ranges);

compute dividedSum(nums, mid) and
increase st to mid + 1 if the computed value is > t ;
decrease ed to mid otherwise.

Once we are done looping, we can just return st
*/



class Solution {
public:
    int dividedSum(vector<int>& nums, int d) {
        int res = 0;
        for (int n: nums) {
            auto qr = div(n, d);
            res += qr.quot + bool(qr.rem);
        }
        return res;
    }
    int smallestDivisor(vector<int>& nums, int t) {
        // support variables
        int st = 1, ed = *max_element(begin(nums), end(nums)), mid;
        // binary search loop
        while (st < ed) {
            mid = (st + ed) / 2;
            if (dividedSum(nums, mid) > t) st = mid + 1;
            else ed = mid;
        }
        return st;
    }
};