#pragma once
#include "Store.h"
class CommandInterpreter
{
public:
	CommandInterpreter(Store* store);
	~CommandInterpreter();
	Store * store;
	int FindItem(string itemCode);
	void InterpretCommand(string itemCode);
	void AddToBasket(Item* item);
	void ClearBasket();
	void DisplayTotalValue();
	void BuyItems();
	void ChangeItemPrice(Item* item);


};

