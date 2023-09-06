public class Solution {
    public bool CloseStrings(string word1, string word2) {
        /*
        this problem is to find if we have the same characters in both words, so frequencies should match
        Find the characters frequencies in each word
        Then check if frequencies in both are matching or not
        */

        Dictionary<char, int> charFreqMap1 = new Dictionary<char, int>();
        Dictionary<char, int> charFreqMap2 = new Dictionary<char, int>();

        if(word1.Length != word2.Length)
        {
            return false;
        }

        for(int i = 0; i < word1.Length; i++)
        {
            if(charFreqMap1.ContainsKey(word1[i]))
            {
                charFreqMap1[word1[i]]++;
            }
            else
            {
                charFreqMap1.Add(word1[i], 1);
            }

            if(charFreqMap2.ContainsKey(word2[i]))
            {
                charFreqMap2[word2[i]]++;
            }
            else
            {
                charFreqMap2.Add(word2[i], 1);
            }
        }

        HashSet<char> taken = new HashSet<char>();
        foreach(var charFreq1 in charFreqMap1)
        {
            if(!charFreqMap2.ContainsKey(charFreq1.Key))
                return false;

            foreach(var charFreq2 in charFreqMap2)
            {
                if(!charFreqMap1.ContainsKey(charFreq2.Key))
                    return false;

                if(!taken.Contains(charFreq2.Key) && charFreq1.Value == charFreq2.Value)
                {
                    taken.Add(charFreq2.Key);
                    break;
                }
            }
        }

        return taken.Count == charFreqMap2.Count;
    }
}