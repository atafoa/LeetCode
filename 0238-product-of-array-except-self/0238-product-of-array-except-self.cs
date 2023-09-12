public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        /*
        Use two arrays to calculate the left of the products and right of the products of the arry
        First, the left array iterates through the current index's left and calculate the product
        At the second loop iterate through right array and calculate the product of the current product
        Multiply the left and right array elements

        Time Complexity : O(n)
        Auxiliary Space : O(n)
        */

         List<int> left = new List<int>();
        List<int> right = new List<int>();

        List<int> result = new List<int>();


        int leftMultp = 1;
        int rightMultp = 1;

        for(int i = 0; i < nums.Length; i++)
        {
            if(i == 0)
                left.Add(1);
            
            leftMultp *= nums[i];

            left.Add(leftMultp);
        }

        for(int i = nums.Length - 1; i >= 0; i--)
        {
            if(i == nums.Length - 1)
                right.Add(1);
            
            rightMultp *= nums[i];
            right.Add(rightMultp);

        }

        for(int i = 0; i < nums.Length; i++)
            result.Add(left[i] * right[nums.Length - 1 - i]);

        return result.ToArray();
    }
}