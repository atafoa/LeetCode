public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        // find largest candy
        // if candy[i] + extra candies > max return true
        // else false

        var maxValue = 0;

        for (var i = 0; i < candies.Length; ++i)
        {
            maxValue = Math.Max(maxValue, candies[i]);
        }

        var result = new bool[candies.Length];

        for (var i = 0; i < candies.Length; ++i)
        {
            if (candies[i] + extraCandies >= maxValue)
            {
                result[i] = true;
            }
        }

        return result;
    }
}