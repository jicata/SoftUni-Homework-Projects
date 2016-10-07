// 01. SmallLargeBeer.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;



int main()
{
	void MyCompare(int number);
	int myNum;
	cin >> myNum;
	MyCompare(myNum);

	return 0;
}
void MyCompare(int number)
{
	if (number > 10)
	{
		cout << "Larger" << endl;
	}
	else if (number < 10)
	{
		cout << "Smaller" << endl;
	}
	else
	{
		cout << "Beer" << endl;
	}
}

