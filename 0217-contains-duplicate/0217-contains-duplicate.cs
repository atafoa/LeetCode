public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        // simpler approach
        // use a hashset to store elements since hash set has to be unique
        // if array length is not equal set length then we know theres a dup

        HashSet<int> set = new HashSet<int>(nums);

        return nums.Length != set.Count;
    }
}