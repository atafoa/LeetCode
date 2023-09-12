public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        // since each char would be lower case
        // we can count the chars from [a-z] the frequency of each char
        // using a hashmap with the key of the pattern of chars and value being how many strings have this pattern
        // TC O(mn) where m is the total number of strings and n is avg string length

        Dictionary<string, List<string>> charMap = new(); //mapping char count to list of anagrams
        foreach(var str in strs)
        {
            var charArr = str.ToCharArray();
            Array.Sort(charArr); // sort chars

            string newStr = new string(charArr);
            if(!charMap.ContainsKey(newStr))
            {
                charMap[newStr] = new List<string>();
            }
            charMap[newStr].Add(str);
        }

        return new List<IList<string>>(charMap.Values);

    }
}