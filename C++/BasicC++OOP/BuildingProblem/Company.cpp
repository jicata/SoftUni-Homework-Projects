#include "stdafx.h"
#include "string"
#include "CompanyHeader.h"
using namespace std;

Company::Company(string name, int employees)
{
	this->name = name;
	this->employeeCount = employees;
}
Company::Company()
{
	
}
