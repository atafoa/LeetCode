public class Solution {
    public bool IsValid(string s) {
        /*
            Only two bad cases
            1. ), or )) or {)
            we see a closing paren and there is no opening paren before it to match, or the wrong paren
            2. (()
            Extra opening paren
        */
        Dictionary<char, char> paren = new();
        paren.Add(')', '(');
        paren.Add('}', '{');
        paren.Add(']', '[');

        Stack<char> stack = new();

        foreach(var c in s)
        {
            if(paren.ContainsKey(c)) // if closing paren
            {
                if(!stack.Any() || stack.ElementAt(0) != paren[c]) //if stack is not empty or we have the wrong open paren
                {
                    return false;
                }
                stack.Pop();
            }
            else // c is closing paren
            {
                stack.Push(c);
            }
        }
        return !stack.Any();
    }
}