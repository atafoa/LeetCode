/*
Given an array of strings, return the longest common prefix that is shared amongst all strings. 
Note: you may assume all strings only contain lowercase alphabetical characters. 

Ex: Given the following arrays...

["colorado", "color", "cold"], return "col"
["a", "b", "c"], return ""
["spot", "spotty", "spotted"], return "spot"
*/

/*
The idea is to apply binary search method to find the string with maximum value L, which is common prefix of all of the strings. The algorithm searches space is the interval 
(minlen)
(0…minLen), where minLen is minimum string length and the maximum possible common prefix. Each time search space is divided in two equal parts, one of them is discarded, because it is sure that it doesn't contain the solution. There are two possible cases:

S[1...mid] is not a common string. This means that for each j > i S[1..j] is not a common string and we discard the second half of the search space.
S[1...mid] is common string. This means that for for each i < j S[1..i] is a common string and we discard the first half of the search space, because we try to find longer common prefix.


{leets, leetcode, leetc, leeds}

		leets
		/	\
	lee       ts
0 		mid		 min
lee in leetcode		
lee in leetc
lee in leeds
				/	\
				t 	s
				 mid min
				leet in leetcode
				leet in leetc
				leet not in leeds

					therefore lcp is lee
*/

class Solution {
public:
    string longestCommonPrefix(vector<string>& strs)
    {
	    if(strs.size() == 0)
		    return "";

	    int minLen = INT_MAX;
	    for(string str: strs)
	    {
            int size = str.size();
		    minLen = min(minLen,size);
	    }

	    int low = 1;
	    int high = minLen;

	    while(low <= high)
	    {
		    int middle = (low + high)/2;
		    if(isCommonPrefix(strs, middle))
			    low = middle + 1;
		    else
			    high = middle - 1;
	    }
	    return strs[0].substr(0, (low+high)/2);
    }

    bool isCommonPrefix(vector<string> strs, int len)
    {
	    for(int i = 1; i < strs.size(); i++)
	    {
		    if(strs[i].substr(0, len) != strs[0].substr(0, len))
		    {
			    return false;
		    }
	    }
	    return true;
    }

};