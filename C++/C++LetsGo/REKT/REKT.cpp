// REKT.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <math.h>
using namespace std;

class Point
{
	int _x;
	int _y;
public:
	Point(int x = 0, int y = 0)
	{
		this->setX(x);
		this->setY(y);
		cout << "Point CREATED" << endl;
	}
	~Point()
	{
		cout << "Point DESTROYED" << endl;
	}
	int x()
	{
		return this->_x;
	};
	void setX(int x)
	{
		this->_x = x;
	};
	int y()
	{
		return this->_y;
	};
	void setY(int y)
	{
		this->_y = y;
	};
};
class Size
{
	double _width;
	double _height;
public:
	Size(double width= 0, double height=0)
	{
		this->setWidth(width);
		this->setHeight(height);
		cout << "Size CREATED" << endl;
	}
	~Size()
	{
		cout << "Size DESTROYED" << endl;
	}
	double width()
	{
		return this->_width;
	}
	void setWidth(double width)
	{
		this->_width = width;
	}
	double heigth()
	{
		return this->_height;
	}
	void setHeight(double height)
	{
		this->_height = height;
	}

};
class Rectangle
{
	Point _pointOfOrigin;
	Size _size;
public:
	void setPointOfOrigin(int x, int y)
	{
		this->_pointOfOrigin = Point(x, y);
	}
	Point pointOfOrigin()
	{
		return this->_pointOfOrigin;
	}
	void setSize(double width, double height)
	{
		this->_size = Size(width, height);
	}
	Size size()
	{
		return this->_size;
	}

	Rectangle(int x, int y, double width, double height)
	{
		this->setPointOfOrigin(x, y);
		this->setSize(width, height);
	}

	~Rectangle()
	{
		
	};
	
	
	double CalculateArea()
	{
		return this->size().width() * this->size().heigth();
	};
	double CalculateParameter()
	{
		return (this->size().width() + this->size().heigth()) * 2;
	}
	double CalculateDiagonal()
	{
		double left = this->size().width() * this->size().width();
		double right = this->size().heigth() *this->size().heigth();
		return sqrt(left + right);
	}
};



int main()
{		
	Rectangle rekt = Rectangle(2,2,2,2);
	cout << rekt.CalculateArea() << endl;
	cout << rekt.CalculateParameter() << endl;
	cout << rekt.CalculateDiagonal() << endl;
    return 0;
}

