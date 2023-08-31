public class Solution {
    public int Compress(char[] chars) {
        /*
        Approach
        store the current char in 'current' and compare it to the rest of character array, simultaneously keep the count and  updated character when needed. j is the pointer to the place on which it has to be updated, storing the frequency of chanracters in 'counter' and converted that integer to a string and updated it into the array and finally returned the arrays last pointer*/ 

        var i = 0;
        var j = 0;

        while(i < chars.Length)
        {
            var current = chars[i];
            var counter = 0;

            while(i < chars.Length && chars[i] == current)
            {
                i++;
                counter++;
            }

            chars[j++] = current;

            if(counter > 1)
            {
                foreach ( var counterChar in counter.ToString())
                {
                    chars[j++] = counterChar;
                }
            }
        }

        return j;
    }
}