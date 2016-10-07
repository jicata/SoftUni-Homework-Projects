// InheritancePartTwo.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
//#include "Store.h"
#include "CommandInterpreter.h"
#include <iostream>

int main()
{
	Store* kooperateto = new Store();
	Item candy = Item("1234567899", "Fudge", 2.50);
	Item* assaultRifle = new Item("6666666666", "Kalashnikov", 200);
	Item* iceCream = new Item("0000000000", "Bochko", 1);
	//kooperateto->items.push_back(candy);
	kooperateto->items.push_back(assaultRifle);
	kooperateto->items.push_back(iceCream);

	Store * jenskiqPazar = new Store(*kooperateto);
	CommandInterpreter interpretor = CommandInterpreter(kooperateto);


	string command;
	cin >> command;
	while(command!="End")
	{
		interpretor.InterpretCommand(command);
		cin >> command;
	}
    return 0;
}

