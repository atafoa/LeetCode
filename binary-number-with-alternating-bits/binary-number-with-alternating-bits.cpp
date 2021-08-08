/*
Convert to string
Convert given number to binary string then check that no two adjecent digits are the same

Java Solution
class Solution {
    public boolean hasAlternatingBits(int n) {
        String bits = Integer.toBinaryString(n);
        for (int i = 0; i < bits.length() - 1; i++) {
            if (bits.charAt(i) == bits.charAt(i+1)) {
                return false;
            }
        }
        return true;
    }
}

alternatively
We can get the last bit and the rest of the bits via n % 2 and n // 2 operations. Let's remember cur, the last bit of n. If the last bit ever equals the last bit of the remaining, then two adjacent bits have the same value, and the answer is False. Otherwise, the answer is True.

Also note that instead of n % 2 and n // 2, we could have used operators n & 1 and n >>= 1 instead.
*/



class Solution {
public:
    bool hasAlternatingBits(int n) {
        int curr = n % 2;
        n /= 2;
        while(n>0)
        {
            if(curr == n % 2)
                return false;
            curr = n % 2;
            n /= 2;
        }
        return true;
    }
};