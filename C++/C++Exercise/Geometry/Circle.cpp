#include "stdafx.h"
#include "Circle.h"


Circle::Circle(double radius) : TwoDimensionalShape(side)
{
}


Circle::~Circle()
{
}

double Circle::CalculateSurface()
{
	return (this->side * this->side) * 3.14;
}
