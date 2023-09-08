public class RecentCounter {

    private readonly Queue<int> requestQueue;
    private const int TimeThreshold = 3000; // Time threshold in milliseconds

    public RecentCounter() 
    {
        // Initialize a queue to store store incoming request timestamps
        requestQueue = new Queue<int>();
    }
    
    public int Ping(int t) 
    {
        //Add the current request timestamp to the queue.
        AddRequest(t);

        //Remove outdated requests older than 3000 milliseconds
        RemoveOutdatedRequests(t, 3000);

        // Return the count of requests within the 3000 milliseconds window.
        return GetCurrentRequestCount();
    }

    private void AddRequest(int timestamp) 
    {
        // Enqueue the incoming request timestamp to the queue.
        requestQueue.Enqueue(timestamp);
    }

    private void RemoveOutdatedRequests(int currentTimestamp, int timeThreshold) 
    {
        // Remove requests from the front of the queue that are older than the time threshold.
        while (IsRequestOutdated(requestQueue.Peek(), currentTimestamp)) 
        {
            requestQueue.Dequeue();
        }
    }

    private bool IsRequestOutdated(int requestTimestamp, int currentTimestamp) 
    {
        return (currentTimestamp - requestTimestamp) > TimeThreshold;
    }

    private int GetCurrentRequestCount() 
    {
        // Return the current count of requests in the queue.
        return requestQueue.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */