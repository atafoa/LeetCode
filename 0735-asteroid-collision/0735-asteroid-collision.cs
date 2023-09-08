public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        /*
        Initialize an empty stack to store the asteroids that have not collided yet
        Iterate through asteroids array
        If the current asteroid is positive,
            push it into the stack as it will not collide with any other asteroid moving in the same direction
        if the current asteroid is negative
            check if it can collide with any positive asteroids in the stack
            keep popping positive asteroids from the stack while they are smaller than abs(neg ast).
            Handle the collisions based on the sizes of asteroids
        After processing all the asteroids, stack would be non collided asts, convert stack into array and return

        TC: O(N)
        SC: O(N)
        */

        Stack<int> stack = new Stack<int>();

        foreach(int asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
            }
            else
            {
                while(stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroid))
                {
                    stack.Pop();
                }

                if(stack.Count == 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
                else if (stack.Peek() == Math.Abs(asteroid))
                {
                    stack.Pop();
                }
            }
        }

        int[] result = new int[stack.Count];
        for (int i = stack.Count - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }

        return result;
    }
}