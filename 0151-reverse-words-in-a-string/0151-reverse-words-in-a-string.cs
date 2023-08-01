public class Solution {
    public string ReverseWords(string s) {
        // using two pointers and a string builder
        bool previousGap = false;
        var result = new StringBuilder();

        int j = s.Length - 1;
        int i = s.Length - 1;

        while(i <= j && i>=0)
        {
            if(s[i]==' ')
                {
                    if(j-i>0)
                    {
                        if(previousGap)
                        {
                            result.Append(" ");
                        }
                        result.Append(s.Substring(i+1, j-i));
                        previousGap = true;
                    }
                    j = i-1;
                }
            i--;
        }
        if(j-i > 0) 
        {
            if(previousGap)
            { 
                result.Append(" ");
            }
            result.Append(s.Substring(i+1, j-i));
        }
        return result.ToString();
    }
}