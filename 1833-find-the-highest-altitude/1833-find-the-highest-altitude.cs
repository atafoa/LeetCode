public class Solution {
    public int LargestAltitude(int[] gain) {
        /*
        This can be solved by taking the maximum altitudes at each step in the journey. The altitude at a step can be determined as the altitude at the previous step plus the gain at the current step. Hence, we will start from 0 and keep adding the gain in altitude to it at each step, and after each addition, we will update the maximum altitude we have seen so far.
        */

        int currentAltitude = 0;
        int highestPoint = currentAltitude;

        foreach(int altitudeGain in gain)
        {
            currentAltitude += altitudeGain;
            highestPoint = Math.Max(highestPoint, currentAltitude);
        }

        return highestPoint;
    }
}