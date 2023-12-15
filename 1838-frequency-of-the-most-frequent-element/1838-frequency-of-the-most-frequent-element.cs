/*
Sorting:

The array nums is sorted in ascending order. Sorting is crucial for the sliding window approach, as it allows us to efficiently adjust the window based on the current element.
Sliding Window:

Two pointers, left and right, are used to define the subarray. The right pointer is advanced to include elements in the current subarray, while the left pointer is adjusted to maintain a valid subarray.
Subarray Sum and Adjustments:

currentSum represents the sum of elements in the current subarray. The code adds the current element (nums[right]) to this sum.
A while loop checks if the current subarray violates the condition (sum + k < nums[right] * length). If it does, the code adjusts the subarray by removing the leftmost element and updating the sum. This ensures that the condition is satisfied.
Update Maximum Frequency:

The maximum frequency (maxFrequency) is updated by comparing it with the length of the current subarray (right - left + 1). The length represents the number of elements in the valid subarray.
Return Result:

The final result is the maximum frequency found after processing the entire array.

Time complexity
O(NlogN): The code sorts the array, which has a time complexity of O(n log n), where n is the length of the input array nums.
The main loop iterates through each element in the sorted array once, so it has a time complexity of O(n), where n is the length of the input array.
Overall, the dominant factor is the sorting operation, making the time complexity O(n log n).

Space Complexity
O(1): The space complexity is O(1) because the code uses a constant amount of extra space, regardless of the size of the input array. The additional space is used for variables like maxFrequency, currentSum, and loop variables (left and right), and it does not depend on the input size. Hence, the space complexity is constant.

*/

public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        int maxFrequency = 0; // Initialize the maximum frequency
        long currentSum = 0; // Initialize the current sum of the subarray

        Array.Sort(nums); // Sort the array in ascending order

        for (int left = 0, right = 0; right < nums.Length; ++right) {
            currentSum += nums[right]; // Include the current element in the subarray sum

            // Check if the current subarray violates the condition (sum + k < nums[right] * length)
            while (currentSum + k < (long)nums[right] * (right - left + 1)) {
                currentSum -= nums[left]; // Adjust the subarray sum by removing the leftmost element
                left++; // Move the left pointer to the right
            }

            // Update the maximum frequency based on the current subarray length
            maxFrequency = Math.Max(maxFrequency, right - left + 1);
        }

        return maxFrequency;
    }
}