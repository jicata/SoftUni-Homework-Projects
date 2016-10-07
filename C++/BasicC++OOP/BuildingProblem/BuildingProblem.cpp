// BuildingProblem.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include "BuildingHeader.h"



using namespace std;

int main()
{
	///XYZ , 6 floors, 127 offices, 600 employees, 196 free seats
	///RAPID, 8 floors, 210 offices, 822 employees, 85 free seats (1 res)
	///SoftUni, 11 floors, 106 offices, 200 employees, 60 free seats
	Company XYZComp = Company("XYZ Industries", 600);
	Company RapidDevComp = Company("Rapid Development Company", 822);
	Company SoftUniComp = Company("SoftUni", 200);

	Building XYZBuilding = Building(6, 127, 196, XYZComp);
	Building RapidBuilding = Building(7, 210, 85, RapidDevComp);
	Building SoftUniBuilding = Building(11, 106, 60, SoftUniComp);

	Building businessPark[3];
	businessPark[0] = XYZBuilding;
	businessPark[1] = RapidBuilding;
	businessPark[2] = SoftUniBuilding;

	int lengthOfBuildings = sizeof(businessPark) / sizeof(businessPark[0]);

	void MostEmployees(Building buildings[], int lengthOfBuildings);
	void MostFreePlaces(Building buildings[], int lengthOfBuildings);
	void HighestLoadFactor(Building buildings[], int lengthOfBuildings);
	void MostPeoplePerFloor(Building buildings[], int lengthOfBuildings);
	void LeastPeoplePerFloor(Building buildings[], int lengthOfBuildings);
	void MostOfficesPerFloor(Building buildings[], int lengthOfBuildings);
	void LeastOfficesPerFloor(Building buildings[], int lengthOfBuildings);
	void MostPeoplePerOffice(Building buildings[], int lengthOfBuildings);
	void LeastPeoplePerOffice(Building buildings[], int lengthOfBuildings);

	MostEmployees(businessPark, lengthOfBuildings);
	cout << endl;
	MostFreePlaces(businessPark, lengthOfBuildings);
	cout << endl;
	HighestLoadFactor(businessPark, lengthOfBuildings);
	cout << endl;
	MostPeoplePerFloor(businessPark, lengthOfBuildings);
	cout << endl;
	LeastPeoplePerFloor(businessPark, lengthOfBuildings);
	cout << endl;
	MostOfficesPerFloor(businessPark, lengthOfBuildings);
	cout << endl;
	LeastOfficesPerFloor(businessPark, lengthOfBuildings);
	cout << endl;
	MostPeoplePerOffice(businessPark, lengthOfBuildings);
	cout << endl;
	LeastPeoplePerOffice(businessPark, lengthOfBuildings);
	return 0;
}
void LeastPeoplePerOffice(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].company.employeeCount / (double)buildings[i].officesCount;
		double highestFactor = (double)building.company.employeeCount / (double)building.officesCount;
		if (currentLoadFactor < highestFactor)
		{
			building = buildings[i];
		}
	}
	double perOffice = (double)building.company.employeeCount / (double)building.officesCount;
	cout << building.company.name << " is the company with least people per office " << perOffice << endl;
}
void MostPeoplePerOffice(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].company.employeeCount / (double)buildings[i].officesCount;
		double highestFactor = (double)building.company.employeeCount / (double)building.officesCount;
		if (currentLoadFactor > highestFactor)
		{
			building = buildings[i];
		}
	}
	double perOffice = (double)building.company.employeeCount / (double)building.officesCount;
	cout << building.company.name << " is the company with most people per office " << perOffice << endl;
}
void LeastOfficesPerFloor(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].officesCount / (double)buildings[i].floorCount;
		double highestFactor = (double)building.officesCount / (double)building.floorCount;
		if (currentLoadFactor < highestFactor)
		{
			building = buildings[i];
		}
	}
	double perFloor = (double)building.officesCount / (double)building.floorCount;
	cout << building.company.name << " is the company with least offices per floor " << perFloor << endl;
}
void MostOfficesPerFloor(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].officesCount / (double)buildings[i].floorCount;
		double highestFactor = (double)building.officesCount / (double)building.floorCount;
		if (currentLoadFactor > highestFactor)
		{
			building = buildings[i];
		}
	}
	double perFloor = (double)building.officesCount/ (double)building.floorCount;
	cout << building.company.name << " is the company with most offices per floor " << perFloor << endl;
}
void LeastPeoplePerFloor(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].company.employeeCount / (double)buildings[i].floorCount;
		double highestFactor = (double)building.company.employeeCount / (double)building.floorCount;
		if (currentLoadFactor < highestFactor)
		{
			building = buildings[i];
		}
	}
	double perFloor = (double)building.company.employeeCount / (double)building.floorCount;
	cout << building.company.name << " is the company with least employees per floor " << perFloor << endl;
}
void MostPeoplePerFloor(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].company.employeeCount / (double)buildings[i].floorCount;
		double highestFactor = (double)building.company.employeeCount / (double)building.floorCount;
		if (currentLoadFactor > highestFactor)
		{
			building = buildings[i];
		}
	}
	double perFloor = (double)building.company.employeeCount / (double)building.floorCount;
	cout << building.company.name << " is the company with most employees per floor " << perFloor << endl;
}
void HighestLoadFactor(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		double currentLoadFactor = (double)buildings[i].company.employeeCount / (double)buildings[i].totalWorkingSeats;
		double highestFactor = (double)building.company.employeeCount / (double)building.totalWorkingSeats;
		if (currentLoadFactor > highestFactor)
		{
			building = buildings[i];
		}
	}
	double factor =(double)building.company.employeeCount / (double)building.totalWorkingSeats;
	cout << building.company.name << " is the company with the highest employee load factor of " <<factor<< endl;
}
void MostEmployees(Building buildings[], int lengthOfBuildings)
{	
	Company leComp = buildings[0].company;
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		if (buildings[i].company.employeeCount >= leComp.employeeCount)
		{
			leComp = buildings[i].company;
		}
	}

	cout << leComp.name << " is the company with the most employees: " << leComp.employeeCount << endl;
}
void MostFreePlaces(Building buildings[], int lengthOfBuildings)
{
	Building building = buildings[0];
	for (int i = 1; i < lengthOfBuildings; i++)
	{
		if (buildings[i].freeWorkingSeats >= building.freeWorkingSeats)
		{
			building = buildings[i];
		}
	}

	cout << building.company.name << " is the company with the most free spaces: " << building.freeWorkingSeats << endl;
}