// Pointerss.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

class Chair
{
public:
	int numberOfLegs;
	unsigned char color[3];
};

int main()
{
	Chair aChair;
	aChair.numberOfLegs = 4;
	aChair.color[0] = 182;
	aChair.color[1] = 0x0F;
	aChair.color[2] = 0xDD;

	Chair * pointerToChair = &aChair;
	std::cout <<(int) pointerToChair->color[0] << std::endl;
	printf("Number of legs: %d\n", pointerToChair->color[0]);
	printf("Number of legs: %d\n", aChair.color[0]);
	return 0;

}

