#pragma once
#include <string.h>
#include "stdafx.h"
#include <iostream>

using namespace std;

class SoftUniPerson
{
public:
	SoftUniPerson(unsigned short id, string name, string course);
	SoftUniPerson();
	~SoftUniPerson();
	virtual void setId(unsigned short id);
	virtual unsigned short getId();
	virtual void setName(string name);
	virtual string getName();
	virtual void setCurrentCourse(string course);
	virtual string getCurrentCourse();
private:
	unsigned short id;
	string name;
	string currentCourse;
};

