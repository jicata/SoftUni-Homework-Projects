#include "stdafx.h"
#include "Parallepiped.h"


Parallepiped::Parallepiped(double sideOne, double sideTwo) : ThreeDimensionalShape(sideOne, sideTwo)
{
}


Parallepiped::~Parallepiped()
{
}

double Parallepiped::CalculateSurface()
{
	return sideOne + (2 * sideTwo);
}
