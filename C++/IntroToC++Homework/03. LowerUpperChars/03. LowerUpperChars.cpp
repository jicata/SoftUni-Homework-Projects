// 03. LowerUpperChars.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream";
#include "string";
using namespace std;

int main()
{
	void DiscoverChars(string input);
	string input;
	cin >> input;;
	DiscoverChars(input);
    return 0;
}
void DiscoverChars(string input)
{
	int upper = 0;
	int lower = 0;
	int other = 0;
	for (int i = 0; i < input.length(); i++)
	{
		if(isupper(input[i]))
		{
			upper++;
		}
		else if(islower(input[i]))
		{
			lower++;
		}
		else
		{
			other++;
		}
	}
	cout << "In the string " << input << " there are:" << endl;
	cout << upper << " uppercase characters." << endl;
	cout << lower << " lowercase characters." << endl;
	cout << other << " other characters." << endl;
}

