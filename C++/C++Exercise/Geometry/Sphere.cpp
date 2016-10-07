#include "stdafx.h"
#include "Sphere.h"


Sphere::Sphere(double radius) : ThreeDimensionalShape(radius, radius)
{
}


Sphere::~Sphere()
{
}

double Sphere::CalculateSurface()
{
	return 4 * 3.14*(this->sideOne *this->sideTwo);
}
