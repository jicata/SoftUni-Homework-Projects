#pragma once
#include <string>
using namespace std;

class Item
{
public:
	Item(string id, string name, double price);
	Item();
	~Item();
	string id;
	string name;
	double price;
	
};

