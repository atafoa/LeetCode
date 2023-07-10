public class Solution {
    public IList<bool> PrefixesDivBy5(int[] nums) {
        bool[] res = new bool[nums.Length];
        res[0] = (nums[0] == 0);

        for(int i=1; i<nums.Length; i++)
        {
            nums[i] += (2 * nums[i-1]) % 5;

            if(nums[i] % 5 == 0)
            {
                res[i] = true;
                nums[i] = 0;
            }
        }
        return res;
    }
}