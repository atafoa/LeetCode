public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int[] result = new int[temperatures.Length];
        Stack<int> nextWarmer = new Stack<int>();

        for(int i = temperatures.Length - 1; i >= 0; i--)
        {
            while(nextWarmer.TryPeek(out var res))
            {
                if(temperatures[res] <= temperatures[i])
                {
                    nextWarmer.Pop();
                    continue;
                }
                else
                {
                    result[i] = res - i;
                    nextWarmer.Push(i);
                    break;
                }
            }

            if(nextWarmer.Count == 0)
            {
                nextWarmer.Push(i);
                result[i] = 0;
            }
        }
        return result;
    }
}