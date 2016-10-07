// WhaleOnACanvass.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
using namespace std;

class Size
{
public:
	float x;
	float y;
};


class PaintObject
{
public:
	char color[4];
	Size size;
	Size sheetSize;
	char backgroundColor[4];

};
class Whale
{
public:
	Size size;
	char skinColor[4];
	unsigned short mass;
};

class PaintWhale:public Whale, public PaintObject
{
public:
	void calcWhaleOnSheet();
	double scaleFactor();
};

void PaintWhale::calcWhaleOnSheet()
{
	double scaleFactorOnX = this->Whale::size.x / this->PaintObject::sheetSize.x;
	double scaleFactorOnY = this->Whale::size.y / this->PaintObject::sheetSize.y;
	double desiredScaleFactor;
	if(scaleFactorOnX > scaleFactorOnY)
	{
		desiredScaleFactor = scaleFactorOnX;
	}
	else
	{
		desiredScaleFactor = scaleFactorOnY;
	}
	this->PaintObject::size.x = this->Whale::size.x / desiredScaleFactor;
	this->PaintObject::size.y = this->Whale::size.y / desiredScaleFactor;
}


double PaintWhale::scaleFactor()
{
	return this->PaintObject::size.x / this->Whale::size.x;

}


int main()
{
	PaintWhale aPaintWhale;
	aPaintWhale.Whale::size.x = 12;
	aPaintWhale.Whale::size.y = 4;
	aPaintWhale.PaintObject::size.x = 0.3;
	aPaintWhale.PaintObject::size.y = 0.2;
	aPaintWhale.calcWhaleOnSheet();
	cout << aPaintWhale.scaleFactor();
	return  0;
}

