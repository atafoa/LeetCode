/*
Priority Queue Implementation

Make a priority queue(binary max heap) which automatically arrange the element in sorted order.
Then pick the first element (which is maximum) and 2nd element(2nd max) , if both are equal we dont have to push anything , if not equal push difference of both in queue.
Do the above steps till queue size is equal to 1, then return last element. If queue becomes empty before reaching size==1 then return 0.
*/

class Solution {
public:
    int lastStoneWeight(vector<int>& stones) {
        priority_queue<int> pq;
        
        for(int i=0;i<stones.size();i++)
        {
            pq.push(stones[i]);
        }
        
        int max1,max2;
        
        while(!pq.empty())
        {
            if(pq.size()==1)
                return pq.top();
            
            max1=pq.top();
            pq.pop();
            
            max2=pq.top();
            pq.pop();
            
            if(max1!=max2)
                pq.push(max1-max2);
        }
            return 0;   
    }
};