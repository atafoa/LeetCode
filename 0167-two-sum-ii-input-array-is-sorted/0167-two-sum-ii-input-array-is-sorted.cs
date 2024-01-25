public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        //sliding window
        int l = 0;
        int r = numbers.Length - 1;
        int[] ans = new int[2];
        
        while(l < r)
        {
            if(numbers[l] + numbers[r] == target)
            {
                ans[0] = l + 1;
                ans[1] = r + 1;
                return ans;
            }
            else if (numbers[l] + numbers[r] > target)
            {
                r--;
            }
            else
            {
                l++;
            }
        }
        
        return ans;
    }
}