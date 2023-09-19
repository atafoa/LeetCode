public class Solution {
    public int CountSubstrings(string s) {
     /*
     Initialize variables oddSubstrings, evenSubstrings, and noOfSubstrings to keep track of the count of odd length palindromic substrings, even length palindromic substrings, and the total number of palindromic substrings.

Iterate through the string s using a loop variable i.

For each character at index i, expand around the center using the ExpandAroundCenter function:

Initialize a counter counter to 0.

While the left and right pointers are within the bounds of the string and the characters at those positions are the same, increment the counter and expand the pointers outward.

Return the counter representing the number of palindromic substrings centered at index i.

In each iteration, calculate oddSubstrings by expanding with i as the center (odd length) and evenSubstrings by expanding with i and i+1 as the center (even length).

Add both oddSubstrings and evenSubstrings to noOfSubstrings.

After iterating through the entire string, return noOfSubstrings, which represents the total count of palindromic substrings.
*/

    int oddSubstrings, evenSubstrings, noOfSubstrings = 0;
    for(int i=0; i<s.Length; i++)
    {
        oddSubstrings = ExpandAroundCenter(s, i, i);
        evenSubstrings = ExpandAroundCenter(s, i, i+1);
        noOfSubstrings += oddSubstrings + evenSubstrings;
    }

    return noOfSubstrings;

    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        int counter = 0;
        while(left >=0 && right < s.Length && s[left] == s[right])
        {
            counter += 1;
            left--;
            right++;
        }
        return counter;
    }
}