#include "stdafx.h"
#include "Voter.h"


Voter::Voter()
{
}

Voter::Voter(std::string name, int age, Enums::Gender gender, std::string placeOfResidence, std::string ethnos, Enums::Vote vote)
{
	this->name = name;
	this->age = age;
	this->gender = gender;
	this->placeOfResidence = placeOfResidence;
	this->ethnos = ethnos;
	this->vote = vote;
}

Voter::~Voter()
{
}
