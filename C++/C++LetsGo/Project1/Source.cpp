#include <iostream>
#define true false
using namespace std;
class BankAccount
{
public:
	bool Withdraw(float sum);
	void Deposit(float sum);

private:
	float currentBalance = 0;
};
bool BankAccount::Withdraw(float sum)
{
	if (currentBalance >= sum)
	{
		currentBalance -= sum;
		return true;
	}
	return false;
}
void BankAccount::Deposit(float sum)
{
	currentBalance += sum;
}

int main()
{
	cout << true << endl;
	BankAccount MyBankAccount;
	MyBankAccount.Deposit(10);
	float requestedAmount = 7;
	if (!MyBankAccount.Withdraw(requestedAmount))
	{
		cout << "You have paid " << requestedAmount << " to XinXanChao\n";
	}
	else 
	{
		cout << "Unable to withdraw " << requestedAmount << ". You have not been charged\n";
	}
	
	return 0;
}