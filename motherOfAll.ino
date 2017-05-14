/* FSR + serial. 
 
Connect one end of FSR to 5V, the other end to Analog 0.
Then connect one end of a 10K resistor from Analog 0 to ground
Connect LED from pin 11 through a resistor to ground 
 
For more information see www.ladyada.net/learn/sensors/fsr.html */
 
int fsrAnalogPin = 0; // FSR is connected to analog 0
int LEDpin = 11;      // connect Red LED to pin 11 (PWM pin)
int fsrReading = 0;       // the analog reading from the FSR resistor divider
//int LEDbrightness;
 
void setup(void) {
  Serial.begin(9600);   // We'll send debugging information via the Serial monitor
  pinMode(LEDpin, OUTPUT);
}
 
void loop(void) {
//    fsrReading = analogRead(fsrAnalogPin);
//  fsrReading = map(analogRead(fsrAnalogPin), 0, 1023, 0, 100);

  fsrReading = map(analogRead(fsrAnalogPin), 0, 1023, 0, 255);
//  Serial.print("Analog reading = ");
//  Serial.print(fsrReading);
//  Serial.print('\n');
  Serial.write(fsrReading);

//  if (fsrReading >= 80) {
//    Serial.print(1);
//    Serial.print('\n');
//  } 

 
  // we'll need to change the range from the analog reading (0-1023) down to the range
  // used by analogWrite (0-255) with map!
//  LEDbrightness = map(fsrReading, 0, 1023, 0, 255);
  // LED gets brighter the harder you press
//  analogWrite(LEDpin, LEDbrightness);
 
  delay(50);
}

