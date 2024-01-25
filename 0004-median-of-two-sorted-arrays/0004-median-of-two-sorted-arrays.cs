public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // apply binary search on the smaller array, partitioning both arrays. This method ensures we find the median without explicitly merging the arrays
        if (nums1.Length > nums2.Length) {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }
        
        int m = nums1.Length;
        int n = nums2.Length;
        int low = 0, high = m;
        
        while (low <= high) {
            int partitionX = (low + high) / 2;
            int partitionY = (m + n + 1) / 2 - partitionX;
            
            int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            
            int minX = (partitionX == m) ? int.MaxValue : nums1[partitionX];
            int minY = (partitionY == n) ? int.MaxValue : nums2[partitionY];
            
            if (maxX <= minY && maxY <= minX) {
                if ((m + n) % 2 == 0) {
                    return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
                } else {
                    return Math.Max(maxX, maxY);
                }
            } else if (maxX > minY) {
                high = partitionX - 1;
            } else {
                low = partitionX + 1;
            }
        }
        
        throw new ArgumentException("Input arrays are not sorted.");
    }
}