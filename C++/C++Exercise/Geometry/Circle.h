#pragma once
#include "TwoDimensionalShape.h"

class Circle : public TwoDimensionalShape
{
public:
	Circle(double radius);
	~Circle();
	double CalculateSurface();
};

