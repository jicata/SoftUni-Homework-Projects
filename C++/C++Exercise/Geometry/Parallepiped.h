#pragma once
#include "ThreeDimensionalShape.h"

class Parallepiped : public ThreeDimensionalShape
{
public:
	Parallepiped(double sideOne, double sideTwo);
	~Parallepiped();
	double CalculateSurface();
};

