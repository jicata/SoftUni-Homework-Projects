#include "stdafx.h"
#include "Student.h"


Student::Student(unsigned short id, string name, string course, short score) : SoftUniPerson(id, name, course)
{
	this->setCurrentScore(score);
}

void Student::setCurrentScore(short score)
{
	this->currentScore = score;
}
short Student::getCurrentScore()
{
	return this->currentScore;
}
short Student::getAverageMark()
{
	int averageScore = 0;
	if(this->getCurrentScore() == NULL)
	{
		return averageScore;
	}	
	
}





Student::~Student()
{
}
