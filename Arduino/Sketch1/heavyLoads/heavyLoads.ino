/*
 Name:		heavyLoads.ino
 Created:	9/3/2015 10:36:23 AM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
//TRAFFIC LIGHT
int pedestrianLightPin = 5;
unsigned long lastPedestrianCheck = 0;
const long pedestrianInterval = 300;
bool relayOn = false;


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
const long yellowLightOn = 3000;
bool redOn = true;
bool redAndYellowOn = false;
bool greenOn = false;
bool yellowOn = false;
int counter = 0;
//TRAFFIC LIGHT

//-------------------------------

//MOTOR + BUTTONDEBOUNCE
int button = 7;
int pinEN = 2;
int pin1A = 3;
int pin2A = 4;
int potencio = A0;
bool itWorks = false;

int potencioMeasure;
int doDupka = 255;

int buttonState = LOW;
int lastButtonState = LOW;

int lastDebounceTime;
int debounceDelay = 50;
//MOTOR + BUTTONDEBOUNCE

bool penis = false;
void setup() {
	
	pinMode(pedestrianLightPin, OUTPUT);
	pinMode(ledPin8Green, OUTPUT);
	pinMode(ledPin9Yellow, OUTPUT);
	pinMode(ledPin10Red, OUTPUT);
	digitalWrite(ledPin10Red, ledConditionRed);

	pinMode(button, INPUT);
	pinMode(pinEN, OUTPUT);
	pinMode(pin1A, OUTPUT);
	pinMode(pin2A, OUTPUT);
	Serial.begin(9600);

}

// the loop function runs over and over again until power down or reset
void loop() {
	
	//TRAFFIC LIGHT ALGORITHM
	unsigned long currentCheck = millis();
	unsigned long currentCheck2 = millis();
	unsigned long currentCheck3 = millis();
	unsigned long currentCheck4 = millis();
	

	if ((currentCheck - lastCheck >= redLightOn) && counter == 0)
	{
		itWorks = false;
		lastCheck = currentCheck;
		counter++;
		redAndYellowOn = true;
		digitalWrite(ledPin9Yellow, HIGH);

	}

	
	else if ((currentCheck2 - lastCheck >= redAndYellowLightsOn) && counter == 1)
	{
		lastCheck = currentCheck2;
		redOn = !redOn;
		redAndYellowOn = !redAndYellowOn;
		greenOn = !greenOn;
		counter++;
		digitalWrite(ledPin10Red, LOW);
		digitalWrite(ledPin9Yellow, LOW);
		digitalWrite(ledPin8Green, HIGH);
		
	}

	
	else if ((currentCheck3 - lastCheck >= greenLightOn) && counter == 2)
	{
		lastCheck = currentCheck3;
		greenOn = !greenOn;
		yellowOn = !yellowOn;
		digitalWrite(ledPin8Green, LOW);
		digitalWrite(ledPin9Yellow, HIGH);
		counter++;
	}

	
	else if ((currentCheck4 - lastCheck >= yellowLightOn) && counter == 3)
	{
		lastCheck = currentCheck4;
		yellowOn = !yellowOn;
		redOn = !redOn;
		digitalWrite(ledPin9Yellow, LOW);
		digitalWrite(ledPin10Red, HIGH);
		counter = 0;
	}
	Serial.println(counter);
	if (counter == 0)
	{
		unsigned long pedestrianLightCheck = millis();
		if ((pedestrianLightCheck - lastPedestrianCheck >= pedestrianInterval) && relayOn == false)
		{
			lastPedestrianCheck = pedestrianLightCheck;
			digitalWrite(pedestrianLightPin, HIGH);
			relayOn = true;
			
		}
		else if (relayOn == true && (pedestrianLightCheck - lastPedestrianCheck < pedestrianInterval))
		{
			digitalWrite(pedestrianLightPin, LOW);
			relayOn = false;
		}
		

	}
	
	
	//TRAFFIC LIGHT ALGORITHM
	// 0 = red
	// 1 = red+yellow
	// 2 = green
	// 3 = yellow

	//------------------------------------

	//MOTOR + BUTTON ALGORITHM
	Serial.println(counter);
	if (counter != 0)
	{
		
		digitalWrite(pedestrianLightPin, LOW);
		
		int reading = digitalRead(button);
		

		if (reading != lastButtonState)
		{
			lastDebounceTime = millis();
		}
		if (millis() - lastDebounceTime > debounceDelay)
		{
			
			if (reading != lastButtonState)
			{
				penis = true;
				buttonState = reading;
				if (buttonState == HIGH)
				{
					itWorks = !itWorks;
				}

			}
		}
		//Serial.println(reading);
		//Serial.println(lastButtonState);
		//Serial.println(buttonState);
		Serial.println(penis);
		//Serial.println(itWorks);
		if (itWorks && counter == 2)
		{

			potencioMeasure = analogRead(potencio);
			//Serial.println(potencioMeasure);
			int jega = potencioMeasure / 4;
			


			if (jega > 150)
			{
				digitalWrite(pin1A, HIGH);
				digitalWrite(pin2A, LOW);
				analogWrite(pinEN, jega);
			}

			else if (jega < 120)
			{
				digitalWrite(pin1A, LOW);
				digitalWrite(pin2A, HIGH);
				analogWrite(pinEN, doDupka - jega);
			}
			else
			{

				analogWrite(pinEN, 0);
			}
		}
		else
		{
			analogWrite(pinEN, 0);
		}

		
		lastButtonState = reading;
		
	}
	//MOTOR + BUTTON ALGORITHM
	
	
	
	//Serial.println(buttonState);
	
	//delay(200);

	
	
}

