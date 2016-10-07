/*
 Name:		forFade.ino
 Created:	9/2/2015 12:53:24 PM
 Author:	Maika
*/

// the setup function runs once when you press reset or power the board
int ledPin = 3;
int brightness = 255;
void setup() {

}

// the loop function runs over and over again until power down or reset
void loop() {
	for (int i = 0; i <= brightness; i++)
	{
		analogWrite(ledPin, i);
		delay(30);
		if (i == 255)
		{
			
			for (int j = i; j > 0; j--)
			{
				analogWrite(ledPin, j);
				delay(30);
			}
		}
	
	}
}
