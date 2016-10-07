#pragma once
#include "TwoDimensionalShape.h"

class Square: public TwoDimensionalShape
{
public:
	Square(double side);
	~Square();
	double CalculateSurface();

};

