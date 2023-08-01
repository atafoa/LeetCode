public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        // iterate through the array
        // check if the current element is 0
        //   if 0 check the previous and next element are also 0 then we can plant a flower there
        //   else skip
        // return true if count is greater than or equal to n

        int count = 0;
        for ( int i = 0; i < flowerbed.Length; i++)
        {
            if(flowerbed[i] == 0 && (i == 0 || flowerbed[i-1] == 0) && ( i == flowerbed.Length - 1 || flowerbed[i+1] == 0))
            {
                flowerbed[i] = 1;
                count++;
            }
        }
        return count >= n;
    }
}