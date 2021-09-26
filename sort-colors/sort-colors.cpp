class Solution {
public:
    // This question can be solved in a single pass by maintaining
    // three boundary variables
    // First boundary of number zero
    // Second boundary variable for number one
    // Third boundary variable for number two
    
    // First and second boundary variables are starting from 0
    // Third boundary variable starts from the end of the array
    
    // Boundary variable denote the boundary(inclusive) till which that element is present
    // Initially there is no element in the boundary so zero and one have boundary of
    // -1 before the first element and boundary of two is outside the last element
    
    // The elements between the boundary of number one and number zero are unsorted elements
    // So for each unsorted element check where it belongs and then swap it with the next
    // element to the boundary.
    
    // Now the only thing left is how to expand the boundary of a particular number.
    // When we encounter a particular element we always place it in front of its boundary 
    // and then increment that boundary
    
    // Some cases to handle. In Two's case the boundary is in reverse order so we decrement the 
    // boundary to expand it. So always decrement the boundary for two's. Now if we find 
    // current element as 2 then we swap the current element with the previous element to
    // boundary. Now the previous element to boundary is unsorted so we need to sort this number
    // too so we cant move forward before placing it in the correct order.
    
    // In zero's case the boundary is behind the one's boundary so while incrementing the 
    // boundary of zero's we also increment the boundary of 1 because 0 will eat up one space
    // of 1 so we have to increase the boundary of 1. We dont need to worry about the destroyed
    // 1 when swapping with zero because the next element to 0 is 1 and will always replace it
    // while swapping next element to boundary of zero.
    
    // Time Complexity O(n)
    // Space Complexity O(1)
    
    void singlePass(vector<int>&nums){
        int onesBound = -1;
        int zerosBound = -1;
        int twosBound = nums.size();
        int current = 0;
        // The space between onesBound and twosBound is the unsorted array
        while(current<twosBound){
            while(current<twosBound && nums[current] == 2){
                swap(nums[current], nums[--twosBound]);
            }
            while(current < twosBound && nums[current] == 1){
                swap(nums[current++], nums[++onesBound]);
            }
            while(current<twosBound && nums[current] == 0){
                swap(nums[current++], nums[++zerosBound]);
                onesBound++;
            }
        }
    }
    
    void sortColors(vector<int>& nums) {
        singlePass(nums);
    }
};