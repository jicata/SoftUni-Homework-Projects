#include "stdafx.h"
#include "Square.h"


Square::Square(double side) 
	: TwoDimensionalShape(side)
{

}


Square::~Square()
{
}

double Square::CalculateSurface()
{
	return  this->side * this->side;
}
