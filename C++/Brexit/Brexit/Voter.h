#pragma once

#include <iostream>
namespace Enums
{
	enum Vote
	{
		Remain, Leave
	};
	enum Gender
	{
		Male, Female
	};
}

class Voter
{
public:
	
	Voter();
	Voter(std::string name, int age, Enums::Gender gender, std::string placeOfResidence, std::string ethnos, Enums::Vote vote);
	~Voter();
	std::string name;
	int age;
	Enums::Gender gender;
	std::string placeOfResidence;
	std::string ethnos;
	Enums::Vote vote;
};

