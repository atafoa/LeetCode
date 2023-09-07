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

        Stack st = new Stack();

        for ( int i = 0; i < s.Length; i++)
        {
            if(s[i].Equals('*'))
            {
                st.Pop();
            }
            else
            {
                st.Push(s[i]);
            }
        }

        string answer = "";
        while(st.Count > 0)
        {
            answer += st.Peek();
            st.Pop();
        }

        return Reverse(answer);
    }

    public static string Reverse( string s )
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}