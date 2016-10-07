#include "stdafx.h"
#include "Store.h"


Store::Store()
{
	//this->items.resize(10);
}


Store::~Store()
{
	delete &items;
}

void Store::KasovaBelejka(double moneyaPaid)
{
	printf("CandyShop\nBIC: 123456789\nAddress: At Courage's\nPurchases: %.2f\nGiven: %.2f\nChange: %.2f", 
		totalValue, moneyaPaid, moneyaPaid - totalValue);
}
