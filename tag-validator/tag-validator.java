/*
Approach Stack

Summarizing the given problem, we can say that we need to determine whether a tag is valid or not, by checking the following properties.

The code should be wrapped in valid closed tag.

The TAG_NAME should be valid.

The TAG_CONTENT should be valid.

The cdata should be valid.

All the tags should be closed. i.e. each start-tag should have a corresponding end-tag and vice-versa and the order of the tags should be correct as well.

In order to check the validity of all these, firstly, we need to identify which parts of the given codecode string act as which part from the above mentioned categories. To understand how it's done, we'll go through the implementation and the reasoning behind it step by step.

We iterate over the given codecode string. Whenever a < is encountered(unless we are currently inside <![CDATA[...]]>), it indicates the beginning of either a TAG_NAME(start tag or end tag) or the beginning of cdata as per the conditions given in the problem statement.

If the character immediately following this < is an !, the characters following this < can't be a part of a valid TAG_NAME, since only upper-case letters(in case of a start tag) or / followed by upper-case letters(in the case of an end tag). Thus, the choice now narrows down to only cdata. Thus, we need to check if the current bunch of characters following <!(including it) constitute a valid cdata. For doing this, firstly we find out the first matching ]]> following the current <! to mark the ending of cdata. If no such matching ]]> exists, the codecode string is considered as invalid. Apart from this, the <! should also be immediately followed by CDATA[ for the cdata to be valid. The characters lying inside the <![CDATA[ and ]]> do not have any constraints on them.

If the character immediately following the < encountered isn't an !, this < can only mark the beginnning of TAG_NAME. Now, since a valid start tag can't contain anything except upper-case letters, if a / is found after <, the </ pair indicates the beginning of an end tag. Now, when a < refers to the beginning of a TAG_NAME(either start-tag or end-tag), we find out the first closing > following the < to find out the substring(say ss), that constitutes the TAG_NAME. This ss should satisfy all the criterion to constitute a valid TAG_NAME. Thus, for every such ss, we check if it contains all upper-case letters and also check its length(It should be between 1 to 9). If any of the criteria isn't fulfilled, ss doesn't constitue a valid TAG_NAME. Hence, the codecode string turns out to be invalid as well.

Apart from checking the validity of the TAG_NAME, we also need to ensure that the tags always exist in pairs. i.e. for every start-tag, a corresponding end-tag should always exist. Further, we can note that in case of multiple TAG_NAME's, the TAG_NAME whose start-tag comes later than the other ones, should have its end-tag appearing before the end-tags of those other TAG_NAME's. i.e. the tag which starts later should end first.

From this, we get the intuition that we can make use of a stackstack to check the existence of matching start and end-tags. Thus, whenever we find out a valid start-tag, as mentioned above, we push its TAG_NAME string onto a stackstack. Now, whenever an end-tag is found, we compare its TAG_NAME with the TAG_NAME at the top the stackstack and remove this element from the stackstack. If the two don't match, this implies that either the current end-tag has no corresponding start-tag or there is a problem with the ordering of the tags. The two need to match for the tag-pair to be valid, since there can't exist an end-tag without a corresponding start-tag and vice-versa. Thus, if a match isn't found, we can conclude that the given codecode string is invalid.

Now, after the complete codecode string has been traversed, the stackstack should be empty if all the start-tags have their corresponding end-tags as well. If the stackstack isn't empty, this implies that some start-tag doesn't have the corresponding end-tag, violating the closed-tag's validity condition.

Further, we also need to ensure that the given codecode is completely enclosed within closed tags. For this, we need to ensure that the first cdata found is also inside the closed tags. Thus, when we find a possibility of the presence of cdata, we proceed further only if we've already found a start tag, indicated by a non-empty stack. Further, to ensure that no data lies after the last end-tag, we need to ensure that the stackstack doesn't become empty before we reach the end of the given codecode string, since an empty stackstack indicates that the last end-tag has been encountered.

Time complexity : O(n). We traverse over the given codecode string of length nn.

Space complexity : O(n). The stack can grow upto a size of n/3n/3 in the worst case. e.g. In case of <A><B><C><D>, nn=12 and number of tags = 12/3 = 4.





Approach Regex
Instead of manually checking the given codecode string for checking the validity of TAG_NAME, TAG_CONTENT and cdata, we can make use of an inbuilt java fuunctionality known as regular expressions.

A regular expression is a special sequence of characters that helps you match or find other strings or sets of strings, using a specialized syntax held in a pattern. They can be used to search, edit, or manipulate text and data. The most common quantifiers used in regular expressions are listed below. A quantifier after a token (such as a character) or group specifies how often that preceding element is allowed to occur.

? The question mark indicates zero or one occurrences of the preceding element. For example, colou?r matches both "color" and "colour".

* The asterisk indicates zero or more occurrences of the preceding element. For example, ab*c matches "ac", "abc", "abbc", "abbbc", and so on.

+ The plus sign indicates one or more occurrences of the preceding element. For example, ab+c matches "abc", "abbc", "abbbc", and so on, but not "ac".

{n} The preceding item is matched exactly n times.

{min,} The preceding item is matched min or more times.

{min,max} The preceding item is matched at least min times, but not more than max times.

| A vertical bar separates alternatives. For example, gray|grey can match "gray" or "grey".

() Parentheses are used to define the scope and precedence of the operators (among other uses). For example, gray|grey and gr(a|e)y are equivalent patterns which both describe the set of "gray" or "grey".

[...] Matches any single character in brackets.

[^...] Matches any single character not in brackets.

Thus, by making use of regex, we can directly check the validity of the codecode string directly(except the nesting of the inner tags) by using the regex expression below:

<([A-Z]{1,9})>([^<]*((<\/?[A-Z]{1,9}>)|(<!\[CDATA\[(.*?)]]>))?[^<]*)*<\/>

But, if we make use of back-referencing as mentioned above, the matching process takes a very large amount of CPU time. Thus, we use the regex only to check the validity of the TAG_CONTENT, TAG_NAME and the cdata. We check the presence of the outermost closed tags by making use of a stackstack as done in the last approach.

The rest of the process remains the same as in the last approach, except that we need not manually check the validity of TAG_CONTENT, TAG_NAME and the cdata, since it is already done by the regex expression. We only need to check the presence of inner closed tags.

import java.util.regex.*;
public class Solution {
    Stack < String > stack = new Stack < > ();
    boolean contains_tag = false;
    public boolean isValidTagName(String s, boolean ending) {
        if (ending) {
            if (!stack.isEmpty() && stack.peek().equals(s))
                stack.pop();
            else
                return false;
        } else {
            contains_tag = true;
            stack.push(s);
        }
        return true;
    }
    public boolean isValid(String code) {
        String regex = "<[A-Z]{0,9}>([^<]*(<((\\/?[A-Z]{1,9}>)|(!\\[CDATA\\[(.*?)]]>)))?)*";
        if (!Pattern.matches(regex, code))
            return false;
        for (int i = 0; i < code.length(); i++) {
            boolean ending = false;
            if (stack.isEmpty() && contains_tag)
                return false;
            if (code.charAt(i) == '<') {
                if (code.charAt(i + 1) == '!') {
                    i = code.indexOf("]]>", i + 1);
                    continue;
                }
                if (code.charAt(i + 1) == '/') {
                    i++;
                    ending = true;
                }
                int closeindex = code.indexOf('>', i + 1);
                if (closeindex < 0 || !isValidTagName(code.substring(i + 1, closeindex), ending))
                    return false;
                i = closeindex;
            }
        }
        return stack.isEmpty();
    }
}

Time complexity : Regular Expressions are/can be implemented in the form of Finite State Machines. Thus, the time complexity is dependent on the internal representation.
Space complexity : O(n). The stack can grow upto a size of n/3 in the worst case. e.g. In case of <A><B><C><D>, n=12 and number of tags = 12/3 = 4.

*/


public class Solution {
    Stack < String > stack = new Stack < > ();
    boolean contains_tag = false;
    public boolean isValidTagName(String s, boolean ending) {
        if (s.length() < 1 || s.length() > 9)
            return false;
        for (int i = 0; i < s.length(); i++) {
            if (!Character.isUpperCase(s.charAt(i)))
                return false;
        }
        if (ending) {
            if (!stack.isEmpty() && stack.peek().equals(s))
                stack.pop();
            else
                return false;
        } else {
            contains_tag = true;
            stack.push(s);
        }
        return true;
    }
    public boolean isValidCdata(String s) {
        return s.indexOf("[CDATA[") == 0;
    }
    public boolean isValid(String code) {
        if (code.charAt(0) != '<' || code.charAt(code.length() - 1) != '>')
            return false;
        for (int i = 0; i < code.length(); i++) {
            boolean ending = false;
            int closeindex;
            if(stack.isEmpty() && contains_tag)
                return false;
            if (code.charAt(i) == '<') {
                if (!stack.isEmpty() && code.charAt(i + 1) == '!') {
                    closeindex = code.indexOf("]]>", i + 1);
                    if (closeindex < 0 || !isValidCdata(code.substring(i + 2, closeindex)))
                        return false;
                } else {
                    if (code.charAt(i + 1) == '/') {
                        i++;
                        ending = true;
                    }
                    closeindex = code.indexOf('>', i + 1);
                    if (closeindex < 0 || !isValidTagName(code.substring(i + 1, closeindex), ending))
                        return false;
                }
                i = closeindex;
            }
        }
        return stack.isEmpty() && contains_tag;
    }
}
