public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        //get GCD then get index
        var gcd = GetGCD(str1.Length, str2.Length);
        Console.WriteLine(gcd);
        string ls = str2.Substring(0, gcd);
        int idx = 0, count = 0;
        if (str1.Contains(ls)){
            if ((str1.Length/ls.Length) != MatchStringCount(str1, ls, idx))
               return "";
            else
            {
                //confirm if ls is equivalent to the remaining string of str2
                count = 0;
                idx = ls.Length;
                if (ls.Length != str2.Length)
                {
                    if (MatchStringCount(str2, ls, idx) == 0)
                        return "";
                }
                return ls;
            }
        }
        else
            return "";
    }
    public int GetGCD(int a, int b)
    {
        while (b != 0)
        {
            int rd = a % b;
            a = b;
            b = rd;
        }

        return a;
    }

    public int MatchStringCount(string a, string b, int index)
    {
        int count = 0;
        while ((index = a.IndexOf(b, index)) != -1)
        {
            count += 1;
            index += b.Length;
        }

        return count;
    }
}