/*
Approach

Get number of bits in a number
left shift the answer by the number of bits and add current element
*/



class Solution {
public:
	// get number of bits in a number
    int getBinary(int n) {
        int count = 0;
        while(n > 0) {
            n = n / 2;
            count++;
        }
        return count;
    }
    int concatenatedBinary(int n) {
        long long ans = 1;
        int mod = 1e9 + 7;
        for(int i = 2; i <= n; i++) {
            int  bits = getBinary(i);  // number of bits in i
            ans = ((ans << bits) % mod + i) % mod; // left shift the answer by number of bits and add current element into it
        }
        return (int)ans;
    }
};