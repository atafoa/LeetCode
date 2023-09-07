public class Solution {
    public string RemoveStars(string s) {
        /*
        Stack
        iterate over the string s from the start
        if s[i] is a star pop from the stack
        otherwise push non star char to stack

        while the stack is not empty
        Append the top character of the stack to the answer and remove it from the stack
        reverse the string
        */

        Stack<char> st = new Stack<char>();

        for ( int i = 0; i < s.Length; i++)
        {
            if(s[i] == '*')
            {
                st.TryPop(out var c); //if string starts with * we'd be popping an empty stack
            }
            else
            {
                st.Push(s[i]);
            }
        }

        return string.Concat(st.Reverse()); //reverse stack and add to string
    }
}