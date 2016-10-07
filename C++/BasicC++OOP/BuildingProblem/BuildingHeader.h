#pragma once
#include "CompanyHeader.h"

class Building
{
public:
	int CalculateTotalSeats();
	Building();
	Building(int floors, int offices, int freeSeats, Company company);
	Company company;
	int floorCount;
	int officesCount;
	int freeWorkingSeats;
	int totalWorkingSeats;
};
