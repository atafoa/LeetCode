public class Solution {
    public int MaxArea(int[] height) {
        /*
        Implemented two pointer approach in order to make linear time complexity.
Since we need max area of container and it can be calculated as x * y

x can be height.Length -1 and it decrements every time so it should be x--
y is height and we set two pointer on the left which is left =0, and right which is at the end of array, height.Length - 1

Notice, the y should be selected smaller value since if we select bigger value the water container is not able to keep water on that specific area so it will be overflowed.

For example, the inital value of x will be 8 and we got two value(pointers) in heights array, 1 and 7. If we do 8 * 7, container won't keep all water since the first value in height array is 1 which is too small. Therefore, we need to select smaller height between left and right pointer using Math.Min built in function.

We want to keep track maximum area of container and return it as output. That being said, if height[left] is smaller than height[right] we want to move left pointer as one step forward and if that is opposite case, right pointer should be moved one step backward.

if(height[left] < height[right]) left ++
if(height[left] > height[right]) right --
For two both cases, as I mentioned eariler, x should be decremented no matter height[left] or height[right] is bigger or smaller.

Finally, we keep update max width(area) of the container using Math.Max built in function with that x and miniHeight and return it as output.

TC O(N)
SC O(1)
    */

    int x = height.Length - 1;
    int left = 0, right = height.Length -1; //pointer in height
    int maxWidth = 0;

    while(left < right)
    {
        int minHeight = Math.Min(height[left], height[right]);
        maxWidth = Math.Max(maxWidth, x * minHeight);

        if(height[left] < height[right])
        {
            x--;
            left++;
        }
        else
        {
            x--;
            right --;
        }
    }

    return maxWidth;
    }
}