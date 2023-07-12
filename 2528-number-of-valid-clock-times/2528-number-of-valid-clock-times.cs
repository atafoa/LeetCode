public class Solution {
    public int CountTime(string time) {
        int counter = 1;
        if(time[0] == '?' && time[1] == '?')
        {
            counter *= 24;
        }
        else if (time[0] == '?')
        {
            counter *= (time[1] >= '0' && time[1] <= '3') ? 3 : 2;
        }
        else if (time[1] == '?')
        {
            counter *= time[0] <= '1' ? 10 : 4;
        }

        if(time[3] == '?' && time[4] == '?')
        {
            counter *= 60;
        }
        else if(time[3] == '?')
        {
            counter *= 6;
        }
        else if (time[4] == '?')
        {
            counter *= 10;
        }

        return counter;
    }
}