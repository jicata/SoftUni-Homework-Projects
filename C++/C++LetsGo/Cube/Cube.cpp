// Cube.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "string"
#include <math.h>
class Cube
{
public:
	Cube(double side)
	{
		this->side = side;
	}
	double side;
};
double Perimeter(const Cube &cube)
{
	return (cube.side * cube.side) * 6;
}
double Volume(const Cube &cube)
{
	return pow(cube.side, 3);
}

int main()
{
	Cube cube = Cube(1);
	printf("Perimeter of cube is %.2f\n", Perimeter(cube));
	printf("Volume of cube is %.2f\n", Volume(cube));
	return 0;
}

