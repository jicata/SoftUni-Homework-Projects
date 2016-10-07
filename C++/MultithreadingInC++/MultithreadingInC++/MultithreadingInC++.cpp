// MultithreadingInC++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream"
#include  <thread>
#include <vector>
#include <mutex>
using namespace std;
mutex mtx;

int frequencyOfPrimes(int n)
{
	int i, j;
	int freq = n - 1;
	for (i = 2; i <= n; i++)
	{
		for (j = sqrt(i); j > 1; --j)
		{
			if (i%j == 0)
			{
				--freq;
				break;
			}
		}
	}
	return freq;
}
void exitTheRoom(int i)
{
	mtx.lock();
	//this_thread::sleep_for(std::chrono::milliseconds(20));
	unsigned long sleepy= 20;
	_sleep(sleepy);
	printf("Person %d has exited the room \n", i);
	mtx.unlock();
}

int main()
{
	vector<thread> threadVector;
	for (int i = 0; i < 10000; ++i)
	{
		threadVector.push_back(thread(exitTheRoom, i));
	}
	for (int i = 0; i < threadVector.size(); ++i)
	{
		threadVector[i].join();
	}
	return 0;
	clock_t watch;
	//thread aThread;
	int frequency;

	watch = clock();
	std::cout << "Calculating synchronously.." << std::endl;
	for (int i = 0; i < 5; i++)
	{
		frequency = frequencyOfPrimes(999999);
	}

	printf("The number of primes up to 100000 is %d \n", frequency);
	watch = clock() - watch;
	printf("The process took about %f seconds to complete\n", ((float)watch) / CLOCKS_PER_SEC);
	cout << endl;
	watch = clock();
	std::cout << "Calculating Asynchronously.." << std::endl;
	for (int i = 0; i < 5; i++)
	{
		threadVector.push_back(thread(frequencyOfPrimes, 999999));

	}
	for (int i = 0; i < threadVector.size(); ++i)
	{
		threadVector[i].join();
	}


	printf("The number of primes up to 100000 is %d \n", frequency);
	watch = clock() - watch;
	printf("The process took about %f seconds to complete\n", ((float)watch) / CLOCKS_PER_SEC);
	//aThread.join();
	return 0;
}

