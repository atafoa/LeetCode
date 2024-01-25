public class Solution {
    //tc O(amount * len(coin))
    // sc O(amount)
    public int CoinChange(int[] coins, int amount) {
    //Build DP array
	int[] dp = new int[amount + 1];
	//Fill array with Amount + 1
	for (int i = 0; i < dp.Length; i++)
	{
		dp[i] = amount + 1;
	}
	//Base case
	dp[0] = 0;

	//Outer loop is for coins
	foreach (int coin in coins)
	{
		//Iterate over DP array to find how many coins needed to form that total of amount
		//Start from the denomination of coin as it's not possible to make total less than the denomination with this coin
		for (int i = coin; i <= amount; i++)
		{
			//Update the DP array with minimum number of coins needed to make the total
			dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
		}
	}
	//Catch condition where if its not possible to form total with given coins return -1
	return dp[amount] <= amount ? dp[amount] : -1;
    }
}