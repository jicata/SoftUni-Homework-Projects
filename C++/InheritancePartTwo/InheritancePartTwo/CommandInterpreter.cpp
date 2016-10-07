#include "stdafx.h"
#include "CommandInterpreter.h"
#include "iostream"


CommandInterpreter::CommandInterpreter(Store * store)
{
	this->store = store;
}


CommandInterpreter::~CommandInterpreter()
{
	//delete &this->store;
}

void CommandInterpreter::InterpretCommand(string itemCode)
{
	
	if (itemCode.length() >= 10)
	{
		int itemIndex = FindItem(itemCode);
		if (itemIndex == -1)
		{
			cout << "Item not found" << endl;
			return;
		}
		cout << "Change Price? Y/N" << endl;
		string change;
		cin >> change;
		
		if (change == "N")
		{
			AddToBasket(this->store->items[itemIndex]);
		}
		else
		{
			this->ChangeItemPrice(this->store->items[itemIndex]);
		}
	}
		
		
	
	else
	{
		if (itemCode == "C")
		{
			this->ClearBasket();
		}
		else if (itemCode == "T")
		{
			this->DisplayTotalValue();
		}
		else
		{
			this->BuyItems();
		}
	}
}

int CommandInterpreter::FindItem(string itemCode)
{
	for (unsigned int i = 0; i < store->items.size(); i++)
	{
		if(store->items[i]->id == itemCode)
		{
			return i;
		}
	}
	return -1;
	
}
void CommandInterpreter::AddToBasket(Item * item)
{
	cout << "Item " << item->name << " with ID " << item->id << " and price "<< item->price <<" leva has been successfully added to your basket!" << endl;
	this->store->totalValue += item->price;
}



void CommandInterpreter::ClearBasket()
{
	this->store->totalValue = 0;
	cout << "Basket cleared" << endl;
}

void CommandInterpreter::DisplayTotalValue()
{
	cout << "Total value of items in your basket: " << this->store->totalValue << endl;
}

void CommandInterpreter::BuyItems()
{
	double customerMoney;
	cout << "Please enter the amount of money" << endl;
	cin >> customerMoney;
	printf("The change is %.2f leva\n", customerMoney - this->store->totalValue);
	this->store->KasovaBelejka(customerMoney);
}

void CommandInterpreter::ChangeItemPrice(Item* item)
{
	double newPrice;
	cout << "Please enter the new price for the item " << item->name<< endl;
	cin >> newPrice;
	item->price = newPrice;
	cout << "Item " << item->name << " price successfully changed to " << item->price <<" leva" <<endl;
}


