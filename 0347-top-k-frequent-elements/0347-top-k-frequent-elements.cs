public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // Bucket sort

        // Step 1: Build the frequency map of elements in the nums array
        Dictionary<int, int> freqMap = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (freqMap.ContainsKey(num))
                freqMap[num]++;
            else
                freqMap[num] = 1;
        }

        // Step 2: Prepare a list of lists to store elements with the same frequency
        List<int>[] buckets = new List<int>[nums.Length + 1];
        foreach (var num in freqMap.Keys) {
            int freq = freqMap[num];
            if (buckets[freq] == null)
                buckets[freq] = new List<int>();
            buckets[freq].Add(num);
        }

        // Step 3: Build the result array from buckets in descending order of frequency
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--) {
            if (buckets[i] != null)
                result.AddRange(buckets[i]);
        }

        // Step 4: Convert the result list to an array and return
        return result.ToArray();

    }
}