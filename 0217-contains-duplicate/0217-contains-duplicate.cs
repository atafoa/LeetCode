public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        //Approach
        // iterate through the array storing the frequency of each element in a map
        // if freqency of any element is more than one return true
        // else false

        Dictionary<int,int> map = new Dictionary<int,int>();
        foreach(int num in nums)
        {
            if(map.ContainsKey(num))
            {
                map[num]++;
            }
            else
            {
                map.Add(num,1);
            }

        }

        foreach(var key in map)
        {
            if(key.Value > 1)
            {
                return true;
            }
        }

        return false;
    }
}