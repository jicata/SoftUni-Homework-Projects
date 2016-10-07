

// COULD USE SOME VALIDATION AND INNER ENCAPSULATION
// BUT MEH
#include "stdafx.h"
#include "string"
#include  "VoteCollectorMenu.h"

void PopulateVoteParser(std::map<std::string, Enums::Vote>* voteParser)
{
	(*voteParser)["Remain"] = Enums::Vote::Remain;
	(*voteParser)["Leave"] = Enums::Vote::Leave;
}
void PopulateGenderParser(std::map<std::string, Enums::Gender>* genderParser)
{
	(*genderParser)["Male"] = Enums::Gender::Male;
	(*genderParser)["Female"] = Enums::Gender::Female;
}

int main()
{
	VoteCollectorMenu voteCollectorMenu = VoteCollectorMenu();

	std::map<std::string, Enums::Vote>* voteParser = new std::map<std::string, Enums::Vote>();
	std::map<std::string, Enums::Gender>* genderParser =new  std::map<std::string, Enums::Gender>();
	
	PopulateGenderParser(genderParser);
	PopulateVoteParser(voteParser);


	std::string userCommand;
	std::cout << "Enter 1 to vote" << std::endl;
	std::cin >> userCommand;
	while (userCommand != "12344321")
	{
		std::string name;
		int age;
		std::string genderStr;
		Enums::Gender gender;
		std::string placeOfResidence;
		std::string ethnos;
		std::string voteStr;
		Enums::Vote vote;
		
		std::cout << "Enter your name: ";
		std::cin >> name;
		std::cout << "Enter your age: ";
		std::cin >> age;
		std::cout << "Enter your gender: ";
		std::cin >> genderStr;
		gender = genderParser->at(genderStr);
		std::cout << "Enter your place of residence: ";
		std::cin >> placeOfResidence;
		std::cout << "Enter your ethnos: ";
		std::cin >> ethnos;
		std::cout << "Enter your vote (it's anonymus): ";
		std::cin >> voteStr;
		vote = voteParser->at(voteStr);
		Voter* voter = new Voter(name, age, gender, placeOfResidence, ethnos, vote);

		voteCollectorMenu.RegisterVoter(voter);
		std::cout << "Your vote has been registered" << std::endl;
		std::cout << "Enter 1 to vote" << std::endl;
		std::cin >> userCommand;
	}
	voteCollectorMenu.PrintCollectedData();
	std::string collectorInput;
	std::cin >> collectorInput;
	while(collectorInput!= "Exit")
	{
		if(collectorInput=="Age")
		{
			std::cout << "Age groups that voted: ";
			for (int age : voteCollectorMenu.ages)
			{
				std::cout << age << ' ';
			}
			std::cout << std::endl;
			std::cout << "Enter age group for voters" << std::endl;
			int ageGroup;
			std::cin >> ageGroup;
			int remain = std::get<0>(voteCollectorMenu.votesByAge[ageGroup]);
			int leave = std::get<1>(voteCollectorMenu.votesByAge[ageGroup]);
			printf("In the age group <%d> %d people voted REMAIN and %d people voted LEAVE\n", ageGroup, remain, leave);
		}
		else if (collectorInput == "Ethnos")
		{
			std::cout << "Ethnoses of voters: ";
			for (std::string ethnos : voteCollectorMenu.ethnoses)
			{
				std::cout << ethnos << ' ';
			}
			std::cout << std::endl;
			std::cout << "Enter ethnos for voters" << std::endl;
			std::string ethnos;
			std::cin >> ethnos;
			int remain = std::get<0>(voteCollectorMenu.votesByEthnos[ethnos]);
			int leave = std::get<1>(voteCollectorMenu.votesByEthnos[ethnos]);
			std::cout << "For voters belonging to the <" << ethnos << "> ethnos , " << remain << " people voted REMAIN and " << leave << " people voted LEAVE" << std::endl;
		}
		else if(collectorInput == "Name")
		{
			std::cout << "Names of voters: ";
			for (std::string name : voteCollectorMenu.names)
			{
				std::cout << name << ' ';
			}
			std::cout << std::endl;
			std::cout << "Enter name for voters" << std::endl;
			std::string name;
			std::cin >> name;
			int remain = std::get<0>(voteCollectorMenu.votesByName[name]);
			int leave = std::get<1>(voteCollectorMenu.votesByName[name]);
			std::cout << "From voters named <" << name << "> , " << remain << " people voted REMAIN and " << leave << " people voted LEAVE" << std::endl;
		}
		else if (collectorInput == "Residence")
		{
			std::cout << "Residences of voters: ";
			for (std::string residence : voteCollectorMenu.placesOfResidence)
			{
				std::cout << residence << ' ';
			}
			std::cout << std::endl;
			std::cout << "Enter residence for voters" << std::endl;
			std::string residence;
			std::cin >> residence;
			int remain = std::get<0>(voteCollectorMenu.votesByPlaceOfResidence[residence]);
			int leave = std::get<1>(voteCollectorMenu.votesByPlaceOfResidence[residence]);
			std::cout << "From voters located at <" << residence << "> , " << remain << " people voted REMAIN and " << leave << " people voted LEAVE" << std::endl;
		}
		else if (collectorInput == "Gender")
		{
			int femaleVoters = std::get<0>(voteCollectorMenu.votesByGender[Enums::Gender::Female]) + std::get<1>(voteCollectorMenu.votesByGender[Enums::Gender::Female]);
			int maleVoters = voteCollectorMenu.voters.size() - femaleVoters;
			std::cout << "Of all the voters " << femaleVoters << " are female voters and " << maleVoters << " are male voters" << std::endl;
			std::cout << "Enter gender for voters" << std::endl;
			std::string genderStr;
			std::cin >> genderStr;
			Enums::Gender gender = genderParser->at(genderStr);
			int remain = std::get<0>(voteCollectorMenu.votesByGender[gender]);
			int leave = std::get<1>(voteCollectorMenu.votesByGender[gender]);
			std::cout << "For voters belonging to the <" << genderStr << "> gender , " << remain << " people voted REMAIN and " << leave << " people voted LEAVE" << std::endl;
		}

		std::cin >> collectorInput;
	}
}


