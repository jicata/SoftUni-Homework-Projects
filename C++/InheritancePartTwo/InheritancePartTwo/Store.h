#pragma once
#include "Item.h"
#include "vector"

class Store
{
public:
	Store();
	~Store();
	void KasovaBelejka(double moneyPaid);
	double totalValue;
	vector<Item*> items;
	friend class CommandInterpreter;
};

