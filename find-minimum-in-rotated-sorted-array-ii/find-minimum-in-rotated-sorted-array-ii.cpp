/*

Implement binary search to find the min element

*/


class Solution {
public:
    int findMin(vector<int>& n) {
        int start = 0,size = n.size();
        int end = size-1;
        while(start < end){
            int mid = start +(end - start)/2;
            
            if(n[mid] > n[end]) 
                start = mid+1;              // left side has small values (rotated array)
            else if(n[mid] < n[end]) 
                end = mid;                  // right side has small value (not rotated)
            else 
                end--;                       // mid value equal to end move towards small
        }
        return n[start];
    }
};