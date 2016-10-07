#pragma once
#include "SoftUniPerson.h"
#include <vector>

class Student: public SoftUniPerson
{
public:
	Student(unsigned short id, string name, string course, short score);
	~Student();
	void setCurrentScore(short score);
	short getCurrentScore();
	short getAverageMark();
private:
	string currentCourse;
	short currentScore;
	short averageMark;
};

