#include <Arduino.h>
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
 
#include <iostream>
#include <string>
#include <vector>
#include <sstream>
 
#include <SPI.h>
 
Adafruit_BME280 bme;
 
String status;
 
//setup pins to read spinner:
const int DGM_A = 36;
const int DGM_B = 39;
 
//bool Pin_DGM_1_QUAD_A;
//bool Pin_DGM_1_QUAD_B;
char Gc_DGM_1_Old = 0;
bool Gb_New_DGM_1 = 0;
bool shouldSend = false;
hw_timer_t * timer = NULL;
 
//global long
long Gl_Pulse_DGM_1 = 0;
 
int my_system_counter = 1000;
 
int giterator = 0;
char sOutput[1024];
 
const uint crc_table16[] =
 
{
0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7, 0x8108, 0x9129, 0xA14A, 0xB16B,
0xC18C, 0xD1AD, 0xE1CE, 0xF1EF, 0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE, 0x2462, 0x3443, 0x0420, 0x1401,
0x64E6, 0x74C7, 0x44A4, 0x5485, 0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4, 0xB75B, 0xA77A, 0x9719, 0x8738,
0xF7DF, 0xE7FE, 0xD79D, 0xC7BC, 0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B, 0x5AF5, 0x4AD4, 0x7AB7, 0x6A96,
0x1A71, 0x0A50, 0x3A33, 0x2A12, 0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41, 0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD,
0xAD2A, 0xBD0B, 0x8D68, 0x9D49, 0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78, 0x9188, 0x81A9, 0xB1CA, 0xA1EB,
0xD10C, 0xC12D, 0xF14E, 0xE16F, 0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E, 0x02B1, 0x1290, 0x22F3, 0x32D2,
0x4235, 0x5214, 0x6277, 0x7256, 0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xA7DB, 0xB7FA, 0x8799, 0x97B8,
0xE75F, 0xF77E, 0xC71D, 0xD73C, 0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB, 0x5844, 0x4865, 0x7806, 0x6827,
0x18C0, 0x08E1, 0x3882, 0x28A3, 0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92, 0xFD2E, 0xED0F, 0xDD6C, 0xCD4D,
0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9, 0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8, 0x6E17, 0x7E36, 0x4E55, 0x5E74,
0x2E93, 0x3EB2, 0x0ED1, 0x1EF0,
};

//output: label, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
void xlabelth(void *pvParameters );
void xambtempth(void *pvParameters );
void xreftempth(void *pvParameters );
void xambhumth(void *pvParameters );
void xpulsecountth(void *pvParameters );
void xchecksumth(void *pvParameters );
 
void IRAM_ATTR onTimer() {
   shouldSend = true; 
}
 
void add_sout(String input) {
  boolean go = true;
  int striterator = 0;
  while (go) {
    if (input[striterator] == '\0') {
      go = false;
    } else {
      sOutput[giterator++] = input[striterator++];
    }
   
  }
  sOutput[giterator++] = ',';
  //giterator++;
  sOutput[giterator++] = ' ';
  //giterator++;
}
 
 
void Read_Quad_1(void) {
  //read pins
  bool Pin_DGM_1_QUAD_A = digitalRead(DGM_A);
  bool Pin_DGM_1_QUAD_B = digitalRead(DGM_B);
 
  char c_Previous_Quad_Value;
  char c_Current_Quad;
 
  if (Pin_DGM_1_QUAD_A) {
    c_Current_Quad = 0b00000010;
  } else {
    c_Current_Quad = 0b00000000;
  }
 
  if (Pin_DGM_1_QUAD_B) {
    c_Current_Quad |= 0b00000001;
  }
 
 if (c_Current_Quad != Gc_DGM_1_Old) {
    c_Previous_Quad_Value = Gc_DGM_1_Old;        // Must have the Gc_DGM_1_Old FIRST
    Gc_DGM_1_Old = c_Current_Quad;
 
    //case 0;
    Gb_New_DGM_1 = true;
    if (c_Previous_Quad_Value == 3) {
      if (c_Current_Quad == 2) {
        Gl_Pulse_DGM_1++;
        return;
      }
      if (c_Current_Quad == 1) {
        if (Gl_Pulse_DGM_1) {
          Gl_Pulse_DGM_1--;
        }
        return;
      }
    }
 
    //case 1;
    if (c_Previous_Quad_Value == 2) {
      if (c_Current_Quad == 0) {
        Gl_Pulse_DGM_1++;
        return;
      }
      if (c_Current_Quad == 3) {
        if (Gl_Pulse_DGM_1) {
          Gl_Pulse_DGM_1--;
        }
        return;
      }
    }
 
    //case 2;
    if (c_Previous_Quad_Value == 0) {
      if (c_Current_Quad == 1) {
        Gl_Pulse_DGM_1++;
        return;
      }
      if (c_Current_Quad == 2) {
        if (Gl_Pulse_DGM_1) {
          Gl_Pulse_DGM_1--;
        }
        return;
      }
    }
 
    //case 3;
    if (c_Previous_Quad_Value == 1) {
      if (c_Current_Quad == 3) {
        Gl_Pulse_DGM_1++;
        return;
      }
      if (c_Current_Quad == 0) {
        if (Gl_Pulse_DGM_1) {
          Gl_Pulse_DGM_1--;
        }
        return;
      }
    }
    //end if changed
  }
  //end function
}
 
 
void setup() {
  Serial.begin(460800);

  //create timer that sends data 5 times a second (aka once every 200ms)
  timer = timerBegin(0, 80, true);
  timerAttachInterrupt(timer, &onTimer, true);
  timerAlarmWrite(timer, 200000, true);
  timerAlarmEnable(timer);
  //originally 9600
 
  //initialize pins to be read:
  pinMode(DGM_A, INPUT_PULLDOWN);
  pinMode(DGM_B, INPUT_PULLUP);
  //end DGM pins
 
  //make interrputs
  attachInterrupt(DGM_A, Read_Quad_1, CHANGE);
  attachInterrupt(DGM_B, Read_Quad_1, CHANGE);
 
  status = bme.begin(0x76);  
}

void loop() {

  //output: label, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
  //reset sOutput
  for (int a = 0; a < 1024; a++) {
    sOutput[a] = '\0';
  }
  giterator = 0;
  //write a start of the block
  sOutput[giterator] = '>';
  giterator++;
 
  //label
  add_sout("Cal-DGM-v1.0");

  //AMBIENT TEMP
  //PRETEND REF METER TEMP
  //and ambient humidity just for funzies
  //output: label, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
  
  //ok lowkey where am i getting the commas from
  //oh im getting it from add_sout

  
  //add temp
  //MAYBE CONVERT THIS
  int ambtemp = bme.readTemperature();
  char ambtempbuff [sizeof(ambtemp)*4+1];
  char *ambtempchar = itoa(ambtemp,ambtempbuff,10);
  String ambtempstr = ambtempchar;
  add_sout(ambtempstr);
  

  //add pretend ref meter temp
  //MAYBE CONVERT THIS??
  int reftemp = 1234;
  char reftempbuff [sizeof(reftemp)*4+1];
  char *reftempchar = itoa(reftemp,reftempbuff,10);
  String reftempstr = reftempchar;
  add_sout(reftempstr);

  //add ambient humidity
  //MAYBE CONVERT THIS!
  int ambhum = bme.readHumidity();
  char ambhumbuff [sizeof(ambhum)*4+1];
  char *ambhumchar = itoa(ambhum, ambhumbuff, 10);
  String ambhumstr = ambhumchar;
  add_sout(ambhumstr);




  //rtos - real time operating system
  // have different prcessses (threads) that operate independently
  //sensors take different tiems to read
  // thread each sensor
  // u have globals for each sensor output
  //send those globals at regular intervals
  //each sensor updates its correlated global when it is ready
  // lock the var when ur sending it so it doesn't conflict when it is being read

  char pulsebuff[sizeof(Gl_Pulse_DGM_1)*8+1];
  char *pulsechar = ltoa(Gl_Pulse_DGM_1,pulsebuff,10);
  String pulseString = pulsechar;
  add_sout(pulseString);
  my_system_counter += 1000;

  // Calculate CRC
  int iAccum = 0xFFFF;
  for (int i = 0; i < 1024; i++) {                         // #define SD_DATA_SECTOR_SIZE 510
   iAccum = ((iAccum & 0x00FF) << 8) ^ crc_table16[( (iAccum >> 8) ^ sOutput[i] ) & 0x00FF];
    }
  //append iAccum to string
  //make iAccum to string
  char accumbuff [sizeof(iAccum)*4+1];
  char *acchar = itoa(iAccum,accumbuff,10);
  String accumstring = acchar;
  add_sout(accumstring);
 
 
 
  //ultimate end
  sOutput[giterator++] = 13;
  sOutput[giterator++] = 10;
  sOutput[giterator] = '\0';
 
  if (shouldSend) {
    shouldSend = false;
    Serial.print(sOutput);
  }

}
