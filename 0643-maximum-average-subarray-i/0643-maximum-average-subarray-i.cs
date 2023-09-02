public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        
        //sliding window
        // maintain sum = su = the sum of A[i-K+1] + A[i-K+2] + ... + A[i]. Then, when we have K elements in this sum (if i >= K-1), it is a candidate to be the maximum sum

        double sum = 0, avg = 0;
        
        for(int i = 0; i < k; i++) sum += nums[i];
        avg = sum / k;
        for(int i = k; i < nums.Length; i++)
        {               
            sum = sum + nums[i] - nums [i - k];
            if(avg < sum / k) avg = sum / k;
        }

        return avg;       
    }
}