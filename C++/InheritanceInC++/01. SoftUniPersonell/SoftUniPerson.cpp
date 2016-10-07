#include "stdafx.h"
#include "SoftUniPerson.h"


SoftUniPerson::SoftUniPerson(unsigned short id, string name, string course)
{
	this->setId(id);
	this->setName(name);
	this->setCurrentCourse(course);
}
void SoftUniPerson::setId(unsigned short id)
{
	this->id = id;
}
unsigned short SoftUniPerson::getId()
{
	return this->id;
}
void SoftUniPerson::setName(string name)
{
	this->name = name;
}
string SoftUniPerson::getName()
{
	return  this->name;
}
void SoftUniPerson::setCurrentCourse(string  course)
{
	this->currentCourse = course;
}
string SoftUniPerson::getCurrentCourse()
{
	return this->currentCourse;
}








SoftUniPerson::~SoftUniPerson()
{
}
