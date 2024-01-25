public class Solution {
    // tc O(2^n)
    public IList<IList<string>> Partition(string s) {
        var result = new List<IList<string>>();
        DFS(0, result, new List<string>(), s);
        return result;
    }
    
    public void DFS(int start, List<IList<string>> result, List<string> currentList, string s)
    {
        if(start >= s.Length)
        {
            result.Add(new List<string>(currentList));
            return;
        }
        
        for (int end = start; end < s.Length; end++)
        {
            if(isPalindrome(s, start, end))
            {
                // add current substring in the currentList
                currentList.Add(s.Substring(start, end - start + 1));
                DFS(end + 1, result, currentList, s);
                // backtrack and remove the current substring from currentList
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
    
    private bool isPalindrome(string s, int low, int high)
    {
        while(low < high)
        {
            if(s[low++] != s[high--])
                return false;
        }
        return true;
    }
}