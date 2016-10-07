#pragma once
class Shape
{
public:
	Shape();
	~Shape();
	virtual double CalculateSurface() = 0;
};

