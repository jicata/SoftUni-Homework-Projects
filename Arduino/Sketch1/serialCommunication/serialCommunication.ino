/*
 Name:		Sketch2.ino
 Created:	9/1/2015 12:55:24 PM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
//int photoResistor = A0;
int potencio = A0;
int pinLed3 = 3;
int pinLed5 = 5;
int maxPower = 255;

//int photoPokazanie;
int potencioPokazanie;

void setup() {
	Serial.begin(9600);

}

// the loop function runs over and over again until power down or reset
void loop() {
	//photoPokazanie = analogRead(photoResistor);

	potencioPokazanie = analogRead(potencio);
	
	analogWrite(pinLed3, potencioPokazanie/4);
	analogWrite(pinLed5, maxPower - (potencioPokazanie / 4));
	
	
	
	
	
}
