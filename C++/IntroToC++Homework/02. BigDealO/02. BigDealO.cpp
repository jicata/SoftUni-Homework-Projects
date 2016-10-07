// 02. BigDealO.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream";
#include "string";
using namespace std;

int main()
{
	void SearchForO(string str);
	string sampleString;
	cin >> sampleString;
	SearchForO(sampleString);
    return 0;
}
void SearchForO(string str)
{
	//int length = sizeof(str) / sizeof(*str);
	bool discovered = false;
	for (unsigned int i = 0; i < str.length(); i++)
	{
			if(str[i] == 'o')
			{
				discovered = true;
				break;
			}
	}
	if(discovered)
	{
		cout << "YES" << endl;
		return;
	}
	cout << "NO" << endl;
}

