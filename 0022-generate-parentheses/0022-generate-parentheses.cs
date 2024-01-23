public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        // only going to add open if open < n
        // only going to add closing if closing < open
        // valid if open == closed == n
        
        var list = new List<string>();
        var buffer = new char[n * 2];
        
        Helper(n, list, opened: 1, closed: 0, buffer, '(');
            
        return list;
        
    }
    private void Helper(
        int n, IList<string> list, int opened, int closed, char[] buffer, char ch)
    {
        if(closed > opened || opened > n)
            return;
        
        buffer[opened + closed - 1] = ch;
        
        if(closed == n)
            list.Add(new string(buffer));
        
        Helper(n, list, opened + 1, closed, buffer, '(');
        Helper(n, list, opened, closed + 1, buffer, ')');
    }
}