public class Solution {
    public int MaxOperations(int[] nums, int k) {
        /*
        Let's declare a map to store value-count pair. We traverse the array, checking for each value if its complementary is on the map. If so, we decrease the count for the complementary value. This imitates removing a pair from the array. If there is no complementary, we add current value to the map with count 1, or increase existing count by 1.

        TC O(n)
        SC O(n)
        */

        var map = new Dictionary<int, int>();
        int answer = 0;
        
        foreach(int num in nums)
        {
            if(map.ContainsKey(k - num) && map[k - num] > 0)
            {
                map[k - num]--;
                answer++;
            }
            else
            {
                if (!map.TryAdd(num, 1))
                {
                    map[num]++;
                }
            }
        }
        
        return answer;
    }
}