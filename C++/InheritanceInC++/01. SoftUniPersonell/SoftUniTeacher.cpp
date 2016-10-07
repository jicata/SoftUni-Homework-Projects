#include "stdafx.h"
#include "SoftUniTeacher.h"


SoftUniTeacher::SoftUniTeacher(unsigned short id, string name, string currentCourse, float salary, unsigned daysSinceJoin) 
	:Teacher(id, name, currentCourse, salary)
{
	this->setDaysSinceJoin(daysSinceJoin);
};

void SoftUniTeacher::setDaysSinceJoin(unsigned short days)
{
	this->daysSinceJoin = days;
}
unsigned short SoftUniTeacher::getDaysSinceJoin()
{
	return this->daysSinceJoin;
}


SoftUniTeacher::~SoftUniTeacher()
{
}
