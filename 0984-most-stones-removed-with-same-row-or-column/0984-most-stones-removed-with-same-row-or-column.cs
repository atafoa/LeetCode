public class Solution {
    public int RemoveStones(int[][] stones) {
        UnionFind uf = new UnionFind(stones.Length);

        for (int i = 0; i < stones.Length - 1; i++) {
            int thisX = stones[i][0];
            int thisY = stones[i][1];            
            
            for (int j = i + 1; j < stones.Length; j++) {
                if (thisX == stones[j][0] || thisY == stones[j][1]) {
                    uf.Union(i, j);
                }
            }
        }

        return stones.Length - uf.Count();
    }
}

public class UnionFind {
    int[] root;
    int[] rank;

    public UnionFind(int n) {
        root = new int[n];
        rank = new int[n];
        
        for (int i = 0; i < n; i++) {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int FindRoot(int x) {
        if (root[x] != root[root[x]]) {
            root[x] = FindRoot(root[x]);
        }

        return root[x];
    }

    public void Union(int x, int y) {
        int rootX = FindRoot(x);
        int rootY = FindRoot(y);

        if (rootX == rootY) {
            return;
        }

        if (rank[rootX] > rank[rootY]) {
            root[rootY] = rootX;
        } else {
            if (rank[rootY] > rank[rootX]) {
                root[rootX] = rootY;
            } else {
                //same ranks
                root[rootY] = rootX;
                ++rank[rootX];
            }
        }
    }

    public int Count() {
        int count = 0;
        for (int i = 0; i < root.Length; i++) {
            if (root[i] == i) {
                ++count;
            }
        }

        return count;
    }
}