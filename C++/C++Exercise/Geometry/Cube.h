#pragma once
#include "ThreeDimensionalShape.h"

class Cube : public ThreeDimensionalShape
{
public:
	Cube(double side);
	~Cube();
	double CalculateSurface();
};

