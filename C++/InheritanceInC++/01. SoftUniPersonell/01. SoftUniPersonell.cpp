// 01. SoftUniPersonell.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SoftUniPerson.h"
#include "SoftUniTeacher.h"
#include "Student.h"

int main()
{
	Student pesho = Student(1234, "Tosho", "Advanced C#", 60);
	SoftUniTeacher jica = SoftUniTeacher(1, "jicata", "Advanced C#", 5, 70);
	Teacher tosho = Teacher(2, "Pesho", "Advanced Java", 2);

	vector<SoftUniPerson> persons;
	//persons.assign()
	
    return 0;
}

