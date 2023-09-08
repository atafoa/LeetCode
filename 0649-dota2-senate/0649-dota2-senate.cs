public class Solution {
    public string PredictPartyVictory(string senate) {
     /*
        Greedy alg to ban the next senator using a single queue
        Count the number of senators of each party
        Initialized the floating ban count of each party to 0
        Initialize a queue of senators with the order same as senate
        While both parties have at least one eligible senator
            Pop the next turn senator from q
            If the senator is eligible to vote
                Float the ban on the opp party
                Push the current senator to back of q
            Else
                Decrement floating ban count
                Decrement party count
        Return the party which has at least one eligible senator
        */

        // Number of Senators of each party
        int rCount = 0, dCount = 0;

        //Floating Ban Count
        int dFloatingBan = 0, rFloatingBan = 0;

        //Queue of Senators
        Queue<char> q = new Queue<char>();
        foreach( char c in senate)
        {
            q.Enqueue(c);
            if ( c == 'R')
            {
                rCount++;
            }
            else
            {
                dCount++;
            }
        }

        //While any party has eligible senators
        while (rCount > 0 && dCount > 0)
        {
            char curr = q.Dequeue();

            // If eligible, float the ban on the other party, enqueue again.
            // If not, decrement the floating ban and count of the party.
            if (curr == 'D') 
            {
                if (dFloatingBan > 0) 
                {
                    dFloatingBan--;
                    dCount--;
                } 
                else 
                {
                    rFloatingBan++;
                    q.Enqueue('D');
                }
            } 
            else 
            {
                if (rFloatingBan > 0) 
                {
                    rFloatingBan--;
                    rCount--;
                } 
                else 
                {
                    dFloatingBan++;
                    q.Enqueue('R');
                }
            }
        }

        //Return the party with eligible senators
        return rCount > 0 ? "Radiant" : "Dire";

    }
}