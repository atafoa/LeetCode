public class Solution {
    public int CharacterReplacement(string s, int k) {
        // Base case
        if (s.Length == 0)
            return 0;

        int[] charMap = new int[26];
        // initialize largestCount & start pointer
        int start = 0, largestCount = 0, maxLength = 0;

        //Traverse through the string
        for(int end = 0; end < s.Length; end++)
        {
            //Get the largest count of single, unique char in current window
            charMap[s[end] - 'A'] += 1;
            largestCount = Math.Max(largestCount, charMap[s[end]- 'A']);

            // we are allowed to have at most k replacements in window
            // so if max char frequency + distance between start and end is greater than K
            // this means we have considered changing more than k characters. shrink window
            // then there are more chars in the window than we can replace, shrink window
            while((end - start + 1) - largestCount > k)
            {
                charMap[s[start] - 'A'] -= 1;
                start++;
            }
            //Get max length of repeating chars
            maxLength = Math.Max(maxLength, end - start + 1); // end - start + 1 is size of curr window
        }

        return maxLength;
    }
}