#include "stdafx.h"
#include "VoteCollectorMenu.h"


VoteCollectorMenu::VoteCollectorMenu()
{
	
}


VoteCollectorMenu::~VoteCollectorMenu()
{
}

void  VoteCollectorMenu::PrintCollectedData()
{
	this->GetTotalVotes();
	this->PrintVotesInNumbers();
	this->PrintVotesInPercentage();
}
void VoteCollectorMenu::MapByAge(Voter* voter)
{
	if(this->votesByAge.count(voter->age) == 0)
	{
		votesByAge[voter->age] = std::tuple<int, int>(0,0);
	}
	if(voter->vote == Enums::Remain)
	{
		std::get<0>(this->votesByAge[voter->age])++;
	}
	else
	{
		std::get<1>(this->votesByAge[voter->age])++;
	}
}

void VoteCollectorMenu::MapByEthnos(Voter* voter)
{
	if (this->votesByEthnos.count(voter->ethnos) == 0)
	{
		votesByEthnos[voter->ethnos] = std::tuple<int, int>(0, 0);
	}
	if (voter->vote == Enums::Remain)
	{
		std::get<0>(this->votesByEthnos[voter->ethnos])++;
	}
	else
	{
		std::get<1>(this->votesByEthnos[voter->ethnos])++;
	}
}

void VoteCollectorMenu::MapByName(Voter* voter)
{
	if (this->votesByName.count(voter->name) == 0)
	{
		votesByName[voter->name] = std::tuple<int, int>(0, 0);
	}
	if (voter->vote == Enums::Remain)
	{
		std::get<0>(this->votesByName[voter->name])++;
	}
	else
	{
		std::get<1>(this->votesByName[voter->name])++;
	}
}

void VoteCollectorMenu::MapByResidence(Voter* voter)
{
	if (this->votesByPlaceOfResidence.count(voter->placeOfResidence) == 0)
	{
		votesByPlaceOfResidence[voter->placeOfResidence] = std::tuple<int, int>(0, 0);
	}
	if (voter->vote == Enums::Remain)
	{
		std::get<0>(this->votesByPlaceOfResidence[voter->placeOfResidence])++;
	}
	else
	{
		std::get<1>(this->votesByPlaceOfResidence[voter->placeOfResidence])++;
	}
}

void VoteCollectorMenu::MapByGender(Voter* voter)
{
	if (this->votesByGender.count(voter->gender) == 0)
	{
		votesByGender[voter->gender] = std::tuple<int, int>(0, 0);
	}
	if (voter->vote == Enums::Remain)
	{
		std::get<0>(this->votesByGender[voter->gender])++;
	}
	else
	{
		std::get<1>(this->votesByGender[voter->gender])++;
	}
}

void VoteCollectorMenu::RegisterVoter(Voter* voter)
{
	this->voters.push_back(voter);
	this->ages.insert(voter->age);
	this->placesOfResidence.insert(voter->placeOfResidence);
	this->names.insert(voter->name);
	this->ethnoses.insert(voter->ethnos);
	MapByAge(voter);
	MapByEthnos(voter);
	MapByName(voter);
	MapByResidence(voter);
	MapByGender(voter);
}

void VoteCollectorMenu::GetTotalVotes()
{
	for (Voter* voter : voters)
	{
		if(voter->vote == Enums::Leave)
		{
			this->leaveVotes++;
		}
		else
		{
			this->remainVotes++;
		}
	}
}

void VoteCollectorMenu::PrintVotesInNumbers()
{
	printf("Remain votes: %d\nLeave votes: %d\n", this->remainVotes, this->leaveVotes);
	
}

void VoteCollectorMenu::PrintVotesInPercentage()
{
	float remainPercentage = ((float)remainVotes / (float)voters.size()) * 100.0;
	float leavePercentage = ((float)leaveVotes / (float)voters.size()) * 100.0;
	printf("Remain votes: %.2f\nLeave votes: %.2f\n", remainPercentage, leavePercentage);
}
