#pragma once
#include "ThreeDimensionalShape.h"

class Sphere : public ThreeDimensionalShape
{
public:
	Sphere(double radius);
	~Sphere();
	double CalculateSurface();
};

