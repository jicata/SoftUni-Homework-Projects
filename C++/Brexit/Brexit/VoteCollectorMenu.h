#pragma once
#include "Voter.h"
#include "vector"
#include "map"
#include "set"


class VoteCollectorMenu
{
public:
	VoteCollectorMenu();
	~VoteCollectorMenu();
	void PrintCollectedData();
	void MapByAge(Voter* voter);
	void MapByEthnos(Voter* voter);
	void MapByName(Voter* voter);
	void MapByResidence(Voter* voter);
	void MapByGender(Voter* voter);
	int remainVotes;
	int leaveVotes;

	std::vector<Voter*> voters;
	void RegisterVoter(Voter* voter);
	void GetTotalVotes();
	void PrintVotesInNumbers();
	void PrintVotesInPercentage();
	std::map<int, std::tuple<int,int>> votesByAge;
	std::map<std::string, std::tuple<int, int>> votesByName;
	std::map<std::string, std::tuple<int, int>> votesByEthnos;
	std::map<std::string, std::tuple<int, int>> votesByPlaceOfResidence;
	std::map<Enums::Gender, std::tuple<int, int>> votesByGender;
	std::set<int> ages;
	std::set<std::string> names;
	std::set<std::string> ethnoses;
	std::set<std::string> placesOfResidence;
};

