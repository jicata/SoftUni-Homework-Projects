// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <iostream>
#include <string>

using namespace std;

class Car
{
public:
	string make;
	string model;
	float horsePower;
	double zeroToHundred;
	float fuelConsumption;
	bool isRunning;

	void Run();
	void Stop();
};

void Car::Run()
{
	isRunning = true;
}
void Car::Stop()
{
	isRunning = false;
}


int main(int argc, char ** argv)
{
	Car fordMustangRTR;
	fordMustangRTR.make = "Ford";
	fordMustangRTR.model = "Mustang RTR";
	fordMustangRTR.horsePower = 510;
	fordMustangRTR.isRunning = false;

	Car fordFocus;
	fordFocus.make = "Ford";
	fordFocus.model = "Focus";
	fordFocus.horsePower = 60;
	fordFocus.isRunning = false;

	
	cout << fordMustangRTR.model << " " << fordMustangRTR.isRunning << endl;
	cout << fordFocus.make << " " << fordFocus.horsePower << endl;

	fordMustangRTR.Run();
	cout << fordMustangRTR.model << " " << fordMustangRTR.isRunning << endl;
	cout << fordFocus.make << " " << fordFocus.horsePower << endl;

	return 0;
   
}

