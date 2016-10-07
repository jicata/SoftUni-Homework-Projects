#pragma once
#include <string>

class Company
{
public:
	Company();
	Company(std::string name, int employees);
	std::string name;
	int employeeCount;
};
