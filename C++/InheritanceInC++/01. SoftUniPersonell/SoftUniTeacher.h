#pragma once
#include "Teacher.h"
class SoftUniTeacher :
	public Teacher
{
public:
	SoftUniTeacher(unsigned short id, string name, string currentCourse, float salary, unsigned daysSinceJoin);
	SoftUniTeacher();
	~SoftUniTeacher();
	void setDaysSinceJoin(unsigned short days);
	unsigned short getDaysSinceJoin();
private:
	unsigned short daysSinceJoin;

};

