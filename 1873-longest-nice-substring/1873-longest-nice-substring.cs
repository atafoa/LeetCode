public class Solution {
    public string LongestNiceSubstring(string s) {
        return DFS(s);
    }

     private string DFS(string s)
    {
        HashSet<char> hsSet = new HashSet<char>(s);
        if(s.Length < 2)
            return "";
        
        for(int i=0; i< s.Length; i++)
        {
            if( !hsSet.Contains(char.ToLower(s[i])) || !hsSet.Contains(char.ToUpper(s[i])))
            {
                string str1 = DFS(s.Substring(0,i));
                string str2 = DFS(s.Substring(i+1, s.Length-i-1));
                return str2.Length > str1.Length ? str2 : str1;
            }
        }
        return s;
    }
}