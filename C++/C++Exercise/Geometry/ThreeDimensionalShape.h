#pragma once
#include "Shape.h"

class ThreeDimensionalShape : public Shape
{
public:
	ThreeDimensionalShape(double sideOne, double sideTwo);
	~ThreeDimensionalShape();
	double sideOne;
	double sideTwo;

};

