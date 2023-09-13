public class Solution {
    public int MaxProfit(int[] prices) {
        // brute force
        // iterate through the array keeping track of the min price seen so far and potential profit
        // profit = prices[i] - min
        // update max profit with the max of its current value and max profit
        // update min price to be the min current and prev min

        // TC O(n) SC O(1)

        int minPrice = prices[0];
        int maxProfit = 0;

        for( int i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            minPrice = Math.Min(prices[i], minPrice);
        }

        return maxProfit;

    }
}