#include "stdafx.h"
#include "Rectangle.h"


Rectangle::Rectangle(double width, double length) : TwoDimensionalShape(width)
{
}


Rectangle::~Rectangle()
{

}

double Rectangle::CalculateSurface()
{
	return length * side;
}

