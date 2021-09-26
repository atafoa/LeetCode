/*

As we have already known, every time we run through the row, about half of the numbers will be eliminated. But we conserve vacancies for these eliminated numbers for a clearer view.
e.g. n=13

I conclude these following rules by analyzing several examples:

1. Every time n/2 numbers will be eliminated.
-- so use an integer to cache the count of remained numbers.

2. For each round, It’s possible for the head of the remained numbers in the row (aka the head) to be moved right (possible, but not every time). The moving distance double itself each round.
e.g. n=13

3. If the elimination direction is from left to right (->), the head should be moved. – Since certainly the original head will be eliminated.
If the elimination direction is from right to left (<-), the result depends on the parity of the remain count.
- a. If remained count is even, the head doesn’t need to move. – since the last number eliminated in this round must be the number on its right.
e.g. n=13
image
In the 2nd round of this example, half of the remained numbers are eliminated on <- direction, since the remained count is even the head will escape from it.
- b. If remained count is odd, the head will move. – compared to the situation above, this rule explains itself.

Therefore, I conclude these rules:

1. remain starts as n, divide by 2 each row, stop the loop when remain=1.
2. Integer step caches the distance the head might need to move, starts as 1, multiply by 2 each row.
3. direction starts as ->, turn around each row.
4. when direction is ->, the head move forward;
   when direction is <-, the head move forward if remain is odd, else does nothing.
*/

class Solution {
public:
    int lastRemaining(int n) {
        int head=1, step=1;
        bool direction=true; //t for ->, f for <-;
        while (n>1) {
            if (direction)
                head+=step;
            else
                head+=n%2==0?0:step;
            step*=2;
            n/=2;
            direction=!direction;
        }
        return head;
    }
};