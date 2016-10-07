// WomanWastingMoney.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream";
using namespace std;
class BankAccount
{
public:
	double balance;
};
class Person
{
public:
	virtual void setName(string name)
	{
		this->name = name;
	}
	virtual string getName()
	{
		return this->name;
	}
protected:
	string name;
};

class Man:public Person
{
public:
	BankAccount bankAccount;
};

class Woman:public Person
{
public:
	BankAccount bankAccount;
	void wasteMoney();
};

int main()
{
   
}

