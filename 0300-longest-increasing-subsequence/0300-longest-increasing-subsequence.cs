public class Solution {
    public int LengthOfLIS(int[] nums) {
        // dfs w caching
       Dictionary<int,int> cntMap = new Dictionary<int,int>();
       int i = nums.Length-1;
        while(i >= 0)
        {
            if(!cntMap.ContainsKey(nums[i]))
            {
                cntMap.Add(nums[i], 1);
            }
            
            GetMaxCount(nums[i], cntMap);

            i--;
        }
        return Enumerable.Max(cntMap.Values);
    }

    public void GetMaxCount(int num, Dictionary<int,int> cntMap)
    {
        foreach(var key in cntMap.Keys)
        {
            if(num < key)
            {
                cntMap[num] = Math.Max(cntMap[key]+1,cntMap[num]);
            }
        }
    }
}