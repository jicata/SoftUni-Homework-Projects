#pragma once
#include "Shape.h"

class TwoDimensionalShape : public Shape
{
public:
	TwoDimensionalShape(double side);
	~TwoDimensionalShape();
	double side;
};

