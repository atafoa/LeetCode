public class Solution 
{
    public string ReverseWords(string s)
	{
        /* 
        The idea here is to iterate over the string in one time , starting from right to left using two "cursors" (rightCursor and leftCursor)

1/both cursors start at the end of the string
2/rightCursor starts by finding out the closest non-space character (and skipping spaces)
3/as soon as it finds one , leftCursor gets it's value by starting from rightCursor and walking down the string until it encounters a space or gets out of the strings bounds , then return the index of the last letter of the word
4/now rightCursor and leftCursor define the start and end indicies of the first word encountered
5/extract the word using StringBuilder.Append by passing the original string and indicies
6/apprend a space to separate the words
7/set both cursors after the end of the word found
8/repeat starting from step 2 until we reach the end of the string an no more letters are found
9/remove the last redundant space in the StringBuilder
10/return the result
*/


        int sLength = s.Length;
        int rightCursor = sLength - 1;
        int leftCursor = rightCursor;
        
        StringBuilder sb = new StringBuilder();
        
        while(TryFindStartOfWorld(rightCursor , s , out rightCursor))
        {
            // gives index of last letter in the current word
            leftCursor = IndexOfWordEnd(rightCursor , s);

            sb.Append(s , leftCursor , (rightCursor - leftCursor) + 1 );

			// step over the last letter to "leave the current word" and start finding the next word
            
            sb.Append(' ');
            
            rightCursor =  --leftCursor;
        }
        
		// remove the last added space
        sb.Remove(sb.Length - 1 , 1);
        
        return sb.ToString();
    }
    
	// this is a helper method that a right index that is assumed to be a start of a word
	// returns the index of the last letter of the word
    private int IndexOfWordEnd(int rightIndex, string s )
    {
        int leftIndex = rightIndex;
        
        while( leftIndex > 0 && s[leftIndex - 1] != ' ')
        {   
            leftIndex--;
        }
        
        return leftIndex;
    }
    
	// This is a helper method that takes a starting index and give 2 results
	// the return bool tells us if we reached the end of the string
	// the out int startOfFirstWord return the index of the first encountred char that's isn't empty (if return bool is "false" then this should be ignored)
    private bool TryFindStartOfWorld(int startIndex , string s , out int startOfFirstWord)
    {
        while(startIndex > -1 )
        {
            if(s[startIndex] != ' ')
            {
                startOfFirstWord = startIndex;
                return true;
            }
            
            startIndex--;
        }
        
        startOfFirstWord = -1;
        return false;
    }
}