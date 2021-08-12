/*
Given a matrix A, write a matrix M for which every element [i,j] is the sum of all elements of A left and above A[i,j]

Considering the following matrix A:

[
  [3, 7, 1],
  [2, 4, 0],
  [9, 4, 2]
]
Compute M:

[
  [3,  10, 11],
  [5,  16, 17],
  [14, 29, 32]
]
*/

#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);


/*
 * Complete the 'findMatrix' function below.
 *
 * The function is expected to return a 2D_INTEGER_ARRAY.
 * The function accepts 2D_INTEGER_ARRAY a as parameter.
 */

vector<vector<int>> findMatrix(vector<vector<int>> a) {

    int rows = a.size();
    int cols = a[0].size();
    
    for(int i = 0; i < rows; i++)
        for(int j = 1; j < cols; j++)
            a[i][j] += a[i][j-1];
            
    for(int i = 1; i < rows; i++)
        for(int j = 0; j < cols; j++)
            a[i][j] += a[i-1][j];
            
    return a;
}


