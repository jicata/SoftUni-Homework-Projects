#pragma once
#include "SoftUniPerson.h"
class Teacher :
	public SoftUniPerson
{
public:
	Teacher(unsigned short id, string name, string currentCourse, float salary);
	~Teacher();
	void setSalary(float salary);
	float getSalary();
private:
	float salary;
};

