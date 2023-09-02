public class Solution {
    public int MaxVowels(string s, int k) {
        // sliding window
        // keep a sliding window of size k
        // let i be the index of the new element in the window, increment count if s[i] is a vowel

        // if i>=k then we need to pop s[i-k] from the window and decement count.
        // if s[i-k] is a vowel then the answer is the max count

        //TC O(N)
        //SC O(1)

        int n = s.Length;
        int vowelCount = 0;

        //traverse the string
        int max = Int32.MinValue;
        for(int i = 0; i < n; i++)
        {
            if(i < k)
            {
                if(isVowel(s[i]))
                {
                    vowelCount++;
                }
            }
            else
            {
                //update max
                max = Math.Max(max, vowelCount);

                if(isVowel(s[i]))
                {
                    vowelCount++;
                }

                if(isVowel(s[i - k]))
                {
                    vowelCount--;
                }
            }
        }

        max = Math.Max(max, vowelCount);
        return max;
    }

    public bool isVowel(char c)
    {
        if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
        {
            return true;
        }
        
        return false;
    }
}