//  observation : 
//  Assume I have a number 1101001
//  We'll start from left to right to save number of operations
//  1000000->0 takes 2^7-1 = 127 steps  
//  0100000->0 takes 2^6-1 = 63 steps  
//  0001000->0 takes 2^4-1 = 15 steps  
//  0000001->0 takes 2^1-1 = 1 step  
//  Pattern : Required steps  = 127-63+15-1 = 78
//  Reason : To convert 1000000->0, 
//  Step 1 : 1(100000)
//  Step 2 : 0(100000)
// We observe that we require some steps( lets say x) to convert (000000) to (100000). However, since 1101001 already has 1 in the 5th bit(from right)
// we will save some steps. Number of steps saved (say y) will be equal to number of steps reqd to convert (000000) to (100000)
// So, we don't need to follow all the 2^7-1 steps to convert 1000000 to 0 as 0100000 can be obtained in less number of steps.
// From here, 0100000 will convert itself to 0 and we'll need to add its 2^6-1 steps
// But again, we'll see 0001000 will save some steps in this process. So, our final answer becomes
// pow(2,7)-1 -(pow(2,6)-1 - (pow(2,4)-1 - pow(2,1)-1))
// which simplifies to pow(2,7)-1 - pow(2,6)-1 + pow(2,4)-1 - pow(2,1)-1

class Solution {
public:
int minimumOneBitOperations(int n)
{
    int ans=0,mul=1;
    for(int i=30;i>=0;i--){
        if(n&(1<<i)){
            ans+=mul*((1<<(i+1))-1);
            mul*=-1;
        }
    }
    return ans;
}
};