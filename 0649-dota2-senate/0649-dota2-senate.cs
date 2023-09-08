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

        var radiants = 0;
        var dires = 0;

        var direVotes = 0; 
        var radiantVotes = 0;

        //Filling the queue and count party members
        var senators = new Queue<char>();
        foreach (var senator in senate) 
        {
            senators.Enqueue(senator);
            if (senator == 'R') 
            {
                radiants++;
            }
            else
            {
                dires++;
            } 
        }

        //Until on party is victorious we keep iterating
        while (radiants > 0 && dires > 0) 
        {
            var isDire = senators.Peek() == 'D';

            if (isDire) 
            {
                //Check if senator is banned
                if (radiantVotes > 0) 
                {
                    radiantVotes--;
                    senators.Dequeue();
                    dires--;
                } 
                //If senator wasnt banned senator can ban someone else
                else 
                {
                    direVotes++;
                    senators.Enqueue(senators.Dequeue());
                }
            } 
            else 
            {
                //Check if senator is banned
                if (direVotes > 0) 
                {
                    direVotes--;
                    senators.Dequeue();
                    radiants--;
                } 
                //If senator wasnt banned senator can ban someone else
                else 
                {
                    radiantVotes++;
                    senators.Enqueue(senators.Dequeue());
                }
            }
        }

        //When there is a victor we announce it
        return radiants > 0 ? "Radiant" : "Dire";

    }
}