// RepairStuff.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"

using namespace std;

class Car;
class Man
{
public:
	void crashACar(Car &aCar);
};

class Car
{
public:
	
	Car()
	{
		needsARepair = true;
	}
	Car(float price) : price(price)
	{
		needsARepair = true;
	}
	float price;
	friend void Print(Car car);
	void Print();
	friend class Mechanic;
	friend void Man::crashACar(Car &aCar);
private:
	bool needsARepair;
};


void Man::crashACar(Car& aCar)
{
	aCar.needsARepair = true;
}
void Car::Print()
{
	
}

void Print(Car car)
{
	cout << car.needsARepair << endl;
}

class Mechanic
{
public:
	float priceForRepairingACar(Car &aCar)
	{
		return aCar.price * 0.05;
	}
	void repairACar(Car &aCar)
	{
		aCar.needsARepair = false;
		cout << aCar.needsARepair << endl;
	}
};





int main()
{
	Car trabant;
	Mechanic chichoGosho;
	Man bratTiJelio;
	//cout << trabant.needsARepair << endl;
	bratTiJelio.crashACar(trabant);
	//cout << trabant.needsARepair << endl;
	chichoGosho.repairACar(trabant);
	//cout << trabant.needsARepair << endl;
    return 0;
}

