#include "stdafx.h"
#include "Item.h"

Item::Item(string id, string name, double price)
{
	this->id = id;
	this->name = name;
	this->price = price;
}

Item::Item()
{
}

Item::~Item()
{
	delete &this->id;
}
