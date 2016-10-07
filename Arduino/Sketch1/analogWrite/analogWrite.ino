/*
 Name:		Sketch2.ino
 Created:	9/1/2015 12:37:44 PM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
int pinNummer = 9;
int counter = 0;
void setup() {
	
}

// the loop function runs over and over again until power down or reset
void loop() {
	
	for (int i = counter; i < 250; counter++)
	{
		analogWrite(pinNummer, 250 - counter);
		delay(30);
	}

}
