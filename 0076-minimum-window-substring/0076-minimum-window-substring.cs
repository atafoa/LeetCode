public class Solution {
    public string MinWindow(string s, string t) 
    {
        /*
        The approach is to find a window which satisfies the condition (characters in string s window matches the number in string t). This can be acheived by moving the right pointer forward. After finding the window, try to shrink the window by moving the left pointer to potentially find a window of a smaller size.

To determine whether the string s window satisfies the condition, we can keep track of a variable "have" which indicates whether adding the last character satisfies the number of characters in t, and another variable "need" which indicates the number of unique characters in t. When have matches need, the window is valid.
*/
        int have = 0, need = t.Length, left = 0, right = 0;
        string result = null, tempStr = null;
        IDictionary<char, int> targetMap = new Dictionary<char, int>();
        IDictionary<char, int> currentMap = new Dictionary<char, int>();

        //Filling the target Map.
        foreach (var ch in t)
        {
            targetMap.TryAdd(ch, 0);
            targetMap[ch] += 1;
        }

        while (right < s.Length)
        {
            if (targetMap.ContainsKey(s[right]))
            {
                currentMap.TryAdd(s[right], 0);
                currentMap[s[right]] += 1;

                if (currentMap[s[right]] <= targetMap[s[right]])
                {
                    have++;
                }

                while (have == need && left < s.Length)
                {
                    if (currentMap.ContainsKey(s[left]))
                    {
                        if (currentMap[s[left]] <= targetMap[s[left]])
                        {
                            have--;
                        }
                        currentMap[s[left]]--;
                        if (currentMap[s[left]] == 0)
                        {
                            currentMap.Remove(s[left]);
                        }
                    }
                    tempStr = s.Substring(left, right - left + 1);
                    if (have != need &&  (result == null || tempStr.Length < result.Length))
                    {
                        result = tempStr;
                    }
                    left++;
                }

            }
            right++;
        }
        return (result == null ? "" : result);
    }
}