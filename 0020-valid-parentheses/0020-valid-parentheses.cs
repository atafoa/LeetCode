public class Solution {
     public bool IsValid(string s) {
        /*
            Only two bad cases
            1. ), or )) or {)
            we see a closing paren and there is no opening paren before it to match, or the wrong paren
            2. (()
            Extra opening paren
        */


        //Create a dict to store map of brackets
        //Create a stack to store open brackets as encountered
        //Iterate over each char in string
        // if a char is an open bracket, push it onto the stack
        // if character is a closing bracket pop the top element from the stack and compare it with the corresponding closing bracket in the dict.
        // if the popped bracket and the corresponding bracket in the dict do not match false
        // if stack is empt at end of loop return true

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
            else // c is opening paren
            {
                stack.Push(c);
            }
        }
        return !stack.Any();
    }
}