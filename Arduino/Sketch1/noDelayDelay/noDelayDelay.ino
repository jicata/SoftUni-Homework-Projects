/*
 Name:		randomBruh.ino
 Created:	9/2/2015 1:21:21 PM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
int ledPin8Green = 8;
int ledPin9Yellow = 9;
int ledPin10Red = 10;
int ledConditionGreen = LOW;
int ledConditionYellow = LOW;
int ledConditionRed = HIGH;

unsigned long lastCheck = 0;
const long redLightOn = 6000;
const long redAndYellowLightsOn = 2000;
const long greenLightOn = 10000;
const long yellowLightOn = 2000;
bool redOn = true;
bool redAndYellowOn = false;
bool greenOn = false;
bool yellowOn = false;


void setup() {
	
	pinMode(ledPin8Green, OUTPUT);
	pinMode(ledPin9Yellow, OUTPUT);
	pinMode(ledPin10Red, OUTPUT);
	digitalWrite(ledPin10Red, ledConditionRed);
}

// the loop function runs over and over again until power down or reset
void loop() {
	unsigned long currentCheck = millis();
	
	if ((currentCheck - lastCheck >= redLightOn) && redOn)
	{
		lastCheck = currentCheck;
		redOn = !redOn;
		redAndYellowOn = !redAndYellowOn;
		digitalWrite(ledPin9Yellow, HIGH);
		
	}

	unsigned long currentCheck2 = millis();
	if ((currentCheck2 - lastCheck >= redAndYellowLightsOn) && redAndYellowOn)
	{
		lastCheck = currentCheck2;
		redAndYellowOn = !redAndYellowOn;
		greenOn = !greenOn;
		digitalWrite(ledPin10Red, LOW);
		digitalWrite(ledPin9Yellow, LOW);
		digitalWrite(ledPin8Green, HIGH);
	}

	unsigned long currentCheck3 = millis();
	if ((currentCheck3 - lastCheck >= greenLightOn) && greenOn)
	{
		lastCheck = currentCheck3;
		greenOn = !greenOn;
		yellowOn = !yellowOn;
		digitalWrite(ledPin8Green, LOW);
		digitalWrite(ledPin9Yellow, HIGH);
	}

	unsigned long currentCheck4 = millis();
	if ((currentCheck4 - lastCheck >= yellowLightOn) && yellowOn)
	{
		lastCheck = currentCheck4;
		yellowOn = !yellowOn;
		redOn = !redOn;
		digitalWrite(ledPin9Yellow, LOW);
		digitalWrite(ledPin10Red, HIGH);
	}
	
  
}
