/*
 Name:		fivePinIfElse.ino
 Created:	9/2/2015 10:54:00 AM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
int potencio = A0;
int measure;
int ledTwo = 2;
int ledThree = 3;
int ledFour = 4;
int ledFive = 5;
int ledSix = 6;
bool flag = false;

void setup() {
	pinMode(ledTwo, OUTPUT);
	pinMode(ledThree, OUTPUT);
	pinMode(ledFour, OUTPUT);
	pinMode(ledFive, OUTPUT);
	pinMode(ledSix, OUTPUT);

}

// the loop function runs over and over again until power down or reset
void loop() {
	measure = analogRead(potencio);

	if (measure < 200)
	{
		flag = false;
		digitalWrite(ledTwo, LOW);
		digitalWrite(ledThree, LOW);
		digitalWrite(ledFour, LOW);
		digitalWrite(ledFive, LOW);
		digitalWrite(ledSix, LOW);
	}
	else if (measure < 400)
	{
		flag = false;
		digitalWrite(ledTwo, HIGH);
		digitalWrite(ledThree, LOW);
		digitalWrite(ledFour, LOW);
		digitalWrite(ledFive, LOW);
		digitalWrite(ledSix, LOW);
	}
	else if (measure < 600)
	{
		flag = false;
		digitalWrite(ledTwo, HIGH);
		digitalWrite(ledThree, HIGH);
		digitalWrite(ledFour, LOW);
		digitalWrite(ledFive, LOW);
		digitalWrite(ledSix, LOW);
	}
	else if (measure < 800)
	{
		flag = false;
		digitalWrite(ledTwo, HIGH);
		digitalWrite(ledThree, HIGH);
		digitalWrite(ledFour, HIGH);
		digitalWrite(ledFive, LOW);
		digitalWrite(ledSix, LOW);
	}
	else if (measure < 1000)
	{
		flag = false;
		digitalWrite(ledTwo, HIGH);
		digitalWrite(ledThree, HIGH);
		digitalWrite(ledFour, HIGH);
		digitalWrite(ledFive, HIGH);
		digitalWrite(ledSix, LOW);
	}
	else
	{
		flag = true;
		digitalWrite(ledTwo, HIGH);
		digitalWrite(ledThree, HIGH);
		digitalWrite(ledFour, HIGH);
		digitalWrite(ledFive, HIGH);
		digitalWrite(ledSix, HIGH);
	}
	if (flag == true)
	{
		digitalWrite(ledTwo, HIGH);
		delay(10);
		digitalWrite(ledTwo, LOW);
		delay(10);
	    digitalWrite(ledThree, HIGH);
		delay(10);
		digitalWrite(ledThree, LOW);
		delay(10);
	    digitalWrite(ledFour, HIGH);
		delay(10);
		digitalWrite(ledFour, LOW);
		delay(10);
	    digitalWrite(ledFive, HIGH);
		delay(10);
		digitalWrite(ledFive, LOW);
		delay(10);
	    digitalWrite(ledSix, HIGH);
		delay(10);
		digitalWrite(ledSix, LOW);
		delay(10);
	}
}
