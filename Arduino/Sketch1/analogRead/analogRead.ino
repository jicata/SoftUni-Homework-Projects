/*
 Name:		analogRead.ino
 Created:	9/1/2015 11:11:51 AM
 Author:	Maika

*/

// the setup function runs once when you press reset or power the board
int buttonPin = 10;
int ledPin = 13;
int pokazanie;
bool light = false;
int clickCounter = 0;
void setup() {
	pinMode(buttonPin, INPUT);
	pinMode(ledPin, OUTPUT);
}

// the loop function runs over and over again until power down or reset
void loop() {
	pokazanie = digitalRead(buttonPin);
	if (pokazanie == HIGH &&(clickCounter ==0 && light == false))
	{
		clickCounter += 1;
		light = true;
		if (light == true && clickCounter == 1)
		{
			digitalWrite(ledPin, HIGH);
		}
		delay(1000);

	}
	else if (pokazanie == HIGH && (clickCounter > 0 && light != false))
	{
		digitalWrite(ledPin, LOW);
		clickCounter = 0;
		light = false;
		
	}
	
	
	
	

	//if (pokazanie == HIGH)
	//{
	//	digitalWrite(ledPin, LOW);
	//}
  
}
