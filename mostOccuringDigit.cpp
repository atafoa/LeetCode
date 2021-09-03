/*

Given an array of numbers, find the most occurring digit in it. Input integer is given as an array of numbers

Example:

Input: [25,1,45,23]

Output: [5,2]

Time Complexity: O(N)
Aux Space Complexity: O(N)

Hashmap
{1:1, 2:2, 3:1, 4:1, 5:2}

[2,5] or [5,2]



Approach
Create a hashmap to store each digit and the frequency of each digit
Find the modulus of each number and store that in the hashmap while number less than 9
	If its a number we havent seen before add it to hashmap with frequency 1
	Else update frequency of number
Print numbers with highest frequency

*/

#include <iostream>
#include <vector>
#include <map>

using namespace std;

vector<int> countFreq(vector<int> numbers)
{
	int size = numbers.size(); //array size
	map<int,int> frequency; //frequency map
	int num = 0;
	int max_count = 0;
	vector<int> result;
	
	//traverse through array storing frequency
	for(int i = 0; i < size; i++)
	{

		//reverse order digit extractor using modulus and division by 10
		while( numbers[i] > 0)
		{	num = numbers[i]%10;
			//cout << "Digit is: " << num <<endl;
			numbers[i] /= 10;

			//if number does not exist in map insert it with frequency 1
			if(frequency.find(num) == frequency.end())
			{
				frequency.insert(make_pair(num,1));
			}
			else //update frequency
			{
				frequency[num]++;
			}
		}
	}

	for(auto& it: frequency)
	{
		//cout << it.first << ' ' << it.second << '\n';
		if(it.second > max_count) // if frequency is higher than max count update max count to new frequency
		{
			max_count = it.second;
		}
	}

	for(auto& it: frequency)
	{
		if(it.second == max_count) //print out elements with max frequency
		{
			result.push_back(it.first);
		}
	}

	return result;
}

int main()
{
	vector<int> numbers = {25,1,43,25};
	vector<int> results;
	results = countFreq(numbers);

	for(int i = 0; i < results.size(); i++)
	{
		cout << results[i] <<" ";
	}
	cout << endl;
}

