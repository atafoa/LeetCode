public class StockSpanner {
    Stack<(int,int)> _st;
    int day;

    public StockSpanner() {
        _st = new();
        day = 0;
    }
    
    public int Next(int price) {
        //add day
        day++;

        //rebuild stack
        var(prevPrice, dayPrev) = (0,0);
        while(prevPrice <= price && _st.Count>0)
            (prevPrice, dayPrev) = _st.Pop();

        //check if the last day out of the while loop
        if(prevPrice > price)
            _st.Push((prevPrice, dayPrev));
        //adjust dayPrev as zero if stack is empty
        if(_st.Count == 0)
            dayPrev = 0;

        //push current input in stack before return
        _st.Push((price,day));

        return day - dayPrev;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */