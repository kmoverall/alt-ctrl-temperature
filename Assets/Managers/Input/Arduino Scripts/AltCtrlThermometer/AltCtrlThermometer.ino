// Include the libraries we need
#include <OneWire.h>
#include <DallasTemperature.h>

// Data wire is plugged into port 2 on the Arduino
#define ONE_WIRE_BUS 3

// Setup a oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs)
OneWire oneWire(ONE_WIRE_BUS);

// Pass our oneWire reference to Dallas Temperature. 
DallasTemperature sensors(&oneWire);

DeviceAddress thermometer;

int placementPin = 4;
int val = 0;
int temp = 0;

/*
 * The setup function. We only start the sensors here
 */
void setup(void)
{
  // start serial port
  Serial.begin(9600);
  // Start up the library
  sensors.begin();
  sensors.setResolution(12);
  sensors.setWaitForConversion(false);
  if (!sensors.getAddress(thermometer, 0)) Serial.println("Unable to find address for Device 0"); 

  pinMode(placementPin, INPUT);
}

/*
 * Main function, get and show the temperature
 */
void loop(void)
{ 
  // call sensors.requestTemperatures() to issue a global temperature 
  // request to all devices on the bus
  sensors.requestTemperaturesByAddress(thermometer); // Send the command to get temperatures

  val = digitalRead(placementPin);
  temp = sensors.getTemp(thermometer);
  
  char ans[8];
  sprintf(ans, "%u %u", temp, val);
  Serial.println(ans);
  
}
