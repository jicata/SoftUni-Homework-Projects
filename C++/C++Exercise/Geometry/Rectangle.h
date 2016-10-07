#pragma once
#include "TwoDimensionalShape.h"

class Rectangle : public TwoDimensionalShape
{
public:
	Rectangle(double width, double length);
	~Rectangle();
	double CalculateSurface();
	double length;
};

