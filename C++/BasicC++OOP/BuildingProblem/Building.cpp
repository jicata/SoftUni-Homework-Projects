#include "stdafx.h"
#include "iostream"
#include "BuildingHeader.h"

using namespace std;

Building::Building()
{
	
}
Building::Building(int floors, int offices, int freeSeats, Company company)
{

	this->floorCount = floors;
	this->officesCount = offices;
	this->freeWorkingSeats = freeSeats;
	this->company = company;
	this->totalWorkingSeats = CalculateTotalSeats();
}
int Building::CalculateTotalSeats()
{
	return this->company.employeeCount + this->freeWorkingSeats;
}
//floor -> rooms ->