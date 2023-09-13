public class Solution {

    public class Range {
        public int Low {get; set;}
        public int High {get; set;}
        public int Length => High - Low + 1;

         public Range(int val) : this(val, val) { }

        public Range(int low, int high) 
        {
            Low = low;
            High = high;
        }
    }
    public int LongestConsecutive(int[] nums) {
        /*
        Use a HashSet to track prev nums to avoid repeats
        Additionally, use 2 Dictionaries to store the highs and lows of each range
        Can creat a range object to represent the ranges, to make merging ranges easier

        Because a max size of slots is defined then HashSet and Dicts methods are in constant time
        Range class also only has constant operations
        This means for each iteration of nums we're only doing constant time operations, therefore
        */

        IDictionary<int, Range> lowDict = new Dictionary<int, Range>(nums.Length);
        IDictionary<int, Range> highDict = new Dictionary<int, Range>(nums.Length);
        HashSet<int> pastNums = new HashSet<int>(nums.Length);

        int longestLength = 0;
        foreach(int num in nums)
        {
            if (pastNums.Contains(num))
            {
                // Do nothing if we've already had this number
            }
            else if (lowDict.ContainsKey(num + 1))
            {
                Range range = lowDict[num + 1];
                lowDict.Remove(num + 1);

                //Handle Range Merging if needed
                if (highDict.ContainsKey(num - 1))
                {
                    Range rangeToMerge = highDict[num - 1];
                    highDict.Remove(rangeToMerge.High);
                    lowDict.Remove(rangeToMerge.Low);
                    range.Low = rangeToMerge.Low;
                }
                else
                {
                    range.Low = num;
                }
                lowDict.Add(range.Low, range);
                longestLength = range.Length > longestLength? range.Length : longestLength;
            }
            else if (highDict.ContainsKey(num - 1))
            {
                Range range = highDict[num - 1];
                highDict.Remove(num - 1);
                range.High = num;
                highDict.Add(num, range);
                longestLength = range.Length > longestLength? range.Length : longestLength;
            }
            else
            {
                Range range = new Range(num);
                lowDict.Add(range.Low, range);
                highDict.Add(range.High, range);
                longestLength = 1 > longestLength ? 1 : longestLength;
            }
            pastNums.Add(num);
        }
        
        return longestLength;
    }
}