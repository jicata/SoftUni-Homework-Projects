/*
 Name:		buttonWhile.ino
 Created:	9/2/2015 11:32:27 AM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
const int ledPin = 13;
const int button = 7;


int ledState = HIGH;
int buttonState;
int lastButtonState = LOW;

int lastDebounceTime;
int debounceDelay = 50;

void setup() {
	pinMode(button, INPUT);
	pinMode(ledPin, OUTPUT);

	digitalWrite(ledPin, ledState);
	Serial.begin(9600);
}

// the loop function runs over and over again until power down or reset
void loop() {
	
	int reading = digitalRead(button);

	if (reading != lastButtonState)
	{
		lastDebounceTime = millis();
	}
	if (millis() - lastDebounceTime >debounceDelay)
	{ 
		if (reading != buttonState)
		{
			buttonState = reading;
			if (buttonState == HIGH)
			{
				ledState = !ledState;
			}
		}
	}
	digitalWrite(ledPin, ledState);
	lastButtonState = reading;
	Serial.println(buttonState);
}
