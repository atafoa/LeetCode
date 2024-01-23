public class Solution {
    public int SingleNumber(int[] nums) {
      int res = 0;
        foreach(int n in nums)
        {
            res = n ^ res;
        }
        return res;
    }
}