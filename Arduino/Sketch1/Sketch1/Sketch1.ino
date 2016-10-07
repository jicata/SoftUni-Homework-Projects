int pinClicker = 5;
const long interval = 100;
unsigned long lastCheck = 0;
bool relayOn = false;

void setup() {
	// put your setup code here, to run once:
	pinMode(pinClicker, OUTPUT);
	Serial.begin(9600);
	
}
void LightON(int pin)
{
	digitalWrite(pin, HIGH);
}
void LightOFF(int pin)
{
	digitalWrite(pin, LOW);
	
}
void loop() {
	/*unsigned long currentCheck = millis();
	if ((currentCheck - lastCheck >= interval) && relayOn == false)
	{
		lastCheck = currentCheck;
		digitalWrite(pinClicker, HIGH);
		relayOn = true;
	}
	else if (relayOn == true && (currentCheck - lastCheck <= interval))
	{
		digitalWrite(pinClicker, LOW);
		relayOn = false;
	}*/
	Serial.println(lastCheck);
	
	

}