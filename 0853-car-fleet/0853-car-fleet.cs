public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        //sort arrays
        // for each speed pair get a number of steps left to the target
        // if greater than existing then we have a block - we can leave a single item in the stack thats a fleet
        // repeat for all positions/speed pairs
        // return the size of the stack

        var stack = new Stack<double>();
        Array.Sort(position, speed);
        for(int i = 0; i < position.Length; i++)
        {
            var current = (double)(target - position[i]) / speed[i];
            while (stack.Any() && current >= stack.Peek())
            {
                stack.Pop();
            }
            stack.Push(current);
        }
        return stack.Count();
    }
}