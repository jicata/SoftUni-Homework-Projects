#include "stdafx.h"
#include "Teacher.h"


Teacher::Teacher(unsigned short id, string name, string currentCourse, float salary)
	:SoftUniPerson(id, name, currentCourse)
{
	this->salary = salary;
}
void Teacher::setSalary(float salary)
{
	this->salary = salary;
}
float Teacher::getSalary()
{
	return this->salary;
}




Teacher::~Teacher()
{
}
