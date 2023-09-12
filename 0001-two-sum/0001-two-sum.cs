public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        /*
        1 Create an empty hash map.
        2 Iterate over the array and for each element:
        1.1 Calculate the complement by subtracting the element from the target.
        1.2 Check if the complement exists in the hash map.
        1.3 If the complement exists, return the indices of the current element and the complement.
        1.4 If the complement does not exist, add the element and its index to the hash map.
        3 If no pair is found, return null or an empty result.
        */

        var prevMap = new Dictionary<int,int>(); //map of value and index

        for(int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if(prevMap.ContainsKey(diff))
            {
                return new int[] {prevMap[diff], i};
            }

            prevMap[nums[i]] = i;
        }

        return new int[0];

    }
}