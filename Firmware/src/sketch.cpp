#include <Arduino.h>
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
 
#include <iostream>
#include <string>
#include <vector>
#include <sstream>

 
#include <SPI.h>

#include "Adafruit_MAX31855.h"
#include <LiquidCrystal.h>
 
Adafruit_BME280 bme;
 
String status;
 
//setup pins to read spinner 
//WILL HAVE TO CHANGE FOR DGM1 and DGM2
const int DGM_A = 32; // 36
const int DGM_B = 35; // 39
 
//globals for dgm
char Gc_DGM_1_Old = 0;
bool Gb_New_DGM_1 = 0;
bool shouldSend = false;
hw_timer_t * timer = NULL;
hw_timer_t * fasterTimer = NULL;
long Gl_Pulse_DGM_1 = 0;
boolean timerShouldSend = false;
long preciseTimer = 0;
long holderambtemp = 0;
long oldgoal = 0;
long oldgl = 0;
long zgivenpulses = 0;
boolean newSend = false;
int seqnum = 0;
//boolean yesNumRecieved = false;

//iterator for output string
int giterator = 0;
//ultimate output string
char sOutput[1024];


//pins for MAX31855
#define MAXDO   25
#define MAXCS   26
#define MAXCLK  27

Adafruit_MAX31855 thermocouple(MAXCLK, MAXCS, MAXDO);  //initialize thermometer with correct pins
 
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

//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum

static int pressure;
//more accurate as double
static double doublepressure;
//array for average
#define PRESSUREBLOCKSIZE 10
int pressureArr [PRESSUREBLOCKSIZE];
int pressureitr = 0;
//iterator for above array

//others are the same deal
#define AMBBLOCKSIZE 10
static int ambtemp;
static double doubleambtemp;
int ambtempArr [10];
int ambtempitr = 0;

#define REFBLOCKSIZE 10
static int reftemp;
static double doublereftemp;
int reftempArr [10];
int reftempitr = 0;

#define HUMBLOCKSIZE 10
static int ambhum;
static double doubleambhum;
int ambhumArr [10];
int ambhumitr = 0;

static int pulsecount;  //no average needed
static int checksum;  //this is handled in main

static long zInboundsNum = 0;
long testzin = 0;

long counter10ms = 0;
//for reading the pulse count!
long givenTestCurrPulses = 0;
long goalPulseCount = 0;
double givenTestTimer = 0.0;
long oldTestPulses = 0;
bool sendPulseAndTimer = false;
long oldPulseCont = 0;
String ambtempindicator;
long savedCounter10ms = 0;
int resendCounter = 0;
boolean resendBoolean = false;
double resendTimer = 0.0;
//double oldTimer = 0;
String holderoftimer = "";
double debugz[16] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
long currzPulses = 0;
long oldTimer = 0;

//ambtempindicator[0] = '\0';
//ambtempindicator[1] = '\0';


//initialize threading
void xmainth(void *pvParameters);
void xpressure(void *pvParameters);
void xambtempth(void *pvParameters);
void xreftempth(void *pvParameters);
void xambhumth(void *pvParameters);
void xprocessInbound(void *pvparameters);
 
//system timer, this value changes 5 times a second 
int inBoundsLength = 0;
int oldInBoundsLength = 0;
boolean readyInBounds = false;
boolean timertwohundo = false;
boolean temppermflag = false; //DELETE THIS AND REPLACE WITH timerShouldSend in all instances
boolean oktoprocess = false;

void IRAM_ATTR onTimer() {
  timertwohundo = true;
  
   shouldSend = true; 
   //counter10ms += 1;
}

//global faster timer for more PRECISON
void IRAM_ATTR fasteronTimer() {
  //mongol
  counter10ms += 1;
  preciseTimer = counter10ms;
  //givenTestCurrPulses = Gl_Pulse_DGM_1 - oldPulseCont;
  //reset the resendBoolean if > 5;
  resendTimer += 1;

  
  //IMPERIALMIGHT
  //if (givenTestCurrPulses >= goalPulseCount) {
  // if (oktoprocess && (Gl_Pulse_DGM_1 >= goalPulseCount)) {  //weird logic oktoprocess
  //   //FOUND THE THING 
  //   //zInboundsNum will be the flag indicator?
  //   //ambhum should be the time elapsed
  //   //oldTestPulses = givenTestCurrPulses;

  //   temppermflag = true;

  //   oldTestPulses = Gl_Pulse_DGM_1;
  //   timerShouldSend = true;
  //   savedCounter10ms = counter10ms;
  //   preciseTimer = counter10ms;
  //   oldTimer = counter10ms;
  //   counter10ms = 0;
  //   ///////////////zInboundsNum = 0;
  //   resendBoolean = true;
  //   resendCounter = 0;
  // }
}
 
//function to append a string to the ultimate output 
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
  sOutput[giterator++] = ' ';
}
 
//called upon interrupt to read changes in the spinner 
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
  }
    
}
 
 
void setup() {
  Serial.begin(460800);
  //make sure baud rate is the same on all devices and applications!!
  status = bme.begin(0x76);  

  //thermometer
  //thermocouple.begin(); idk if this is necessary????

  //create timer that sends data 5 times a second (aka once every 200ms)
  timer = timerBegin(1, 80, true);
  fasterTimer = timerBegin(3,80,true);



  timerAttachInterrupt(timer, &onTimer, true);
  timerAttachInterrupt(fasterTimer,&fasteronTimer,true);

  timerAlarmWrite(timer, 200000, true);
  timerAlarmWrite(fasterTimer,10000,true);

  timerAlarmEnable(timer);
  timerAlarmEnable(fasterTimer);
 
  //initialize pins to be read:
  pinMode(DGM_A, INPUT_PULLDOWN);
  pinMode(DGM_B, INPUT_PULLUP);
  
  //make interrputs for DGM
  attachInterrupt(DGM_A, Read_Quad_1, CHANGE);
  attachInterrupt(DGM_B, Read_Quad_1, CHANGE);

  //START THREADING
  //main prints globals, and all other tasks update those globals
  //make main its own core!
  xTaskCreatePinnedToCore(xmainth, "xmainth", 1500, NULL, 1, NULL, 0);  //main will send things 5 times a sec

  xTaskCreatePinnedToCore(xpressure, "xpressure", 1500, NULL, 1, NULL, 1); // this is using a weirdly large ammount of memory??
  xTaskCreatePinnedToCore(xambtempth, "xambtempth", 1500, NULL, 1, NULL, 1);
  xTaskCreatePinnedToCore(xreftempth, "xreftempth", 1500, NULL, 1, NULL, 1);
  xTaskCreatePinnedToCore(xambhumth, "xambhumth", 1500, NULL, 1, NULL, 1);
  xTaskCreatePinnedToCore(xprocessInbound, "processInbound", 1500, NULL, 1, NULL, 1);
 
}

void loop() {
  //empty bc threading lets goo
}
//LABEL, PRESSURE, AMBHUM(working), REFTEMP, Timer, Pulsecount

void xmainth(void *pvParameters) {
  (void) pvParameters;
  while (1) {
    //IN THE CASE THAT WE DO RECIEVE A TIMER:::::::: mongol
    //debugz[0] = double(Gl_Pulse_DGM_1);
  //debugz[1] = double(goalPulseCount);
  currzPulses = Gl_Pulse_DGM_1 - oldPulseCont;
  if (oktoprocess && (Gl_Pulse_DGM_1 >= goalPulseCount)) {  //weird logic oktoprocess
  
  
    //FOUND THE THING 
    //zInboundsNum will be the flag indicator?
    //ambhum should be the time elapsed
    //oldTestPulses = givenTestCurrPulses;
    //debugging values:

    temppermflag = true;

    oldTestPulses = currzPulses;
    timerShouldSend = true;
    savedCounter10ms = counter10ms;
    preciseTimer = counter10ms;
    //oldTimer = counter10ms;
    counter10ms = 0;
    ///////////////zInboundsNum = 0;
    resendBoolean = true;
    resendCounter = 0;
  }

 //iterator for the final output string
 for (int a = 0; a < 1024; a++) {
    sOutput[a] = '\0';
  }
  giterator = 0;
  //write a start of the block
  sOutput[giterator] = '>';
  giterator++;
 
  //labell
  add_sout("Cal-DGM-v1.0");  // the add_sout appends the string WITH COMMA AND SPACE to the ultimate output string

  //add pressure 
  char pressurebuff [sizeof(pressure)*4+1];
  char *pressurechar = itoa(pressure,pressurebuff,10);
  String pressurestring = pressurechar;
  add_sout(pressurechar);

  //honsetly I can mess with amb temp here
  
  // //add amb temp this is the pulsecount todo change zInboundsNum
  // char ambtempbuff [sizeof(0)*4+1];
  // char *ambtempchar = itoa(0,ambtempbuff,10);
  // String ambtempstring = ambtempchar;
  // add_sout(ambtempchar);
  // if (shouldSend) {
  //   oldTestPulses = givenTestCurrPulses;
  //   //maybe do this multiple times to make sure??
  // char ambtempbuff [sizeof(givenTestCurrPulses)*4+1];
  // char *ambtempchar = itoa(givenTestCurrPulses,ambtempbuff,10);
  // String ambtempstring = ambtempchar;
  // add_sout(ambtempchar);
  // }

  //amb temp which is kinda under production: Ming
  //logic is timerShouldSend
  if (resendTimer >= 700) {
    resendBoolean = false;
    resendCounter = 0;
    resendTimer = 0;
    //RESET OTHER STUFF 
    //including but not limited to currzpulses
    //NEWDO
  }

  if (resendBoolean) {  //temppermflag
    resendCounter++;
    holderambtemp = 12345;

    //send this until the next num is recieved!!!!!******
    //or just like 5 times or smth
  } else {
    //comment works, so it appears this is reset - i will try to do based on time rather than instances?
    //THIS ELSE NEEDS TO HAPPEN THO???
    holderambtemp = 0;

  }
  char ambtempbuff [sizeof(holderambtemp)*4+1];
  char *ambtempchar = itoa(holderambtemp,ambtempbuff,10);
  String ambtempstring = ambtempchar;
  add_sout(ambtempchar);

  // old but good for debugging
  // char ambtempbuff [sizeof(goalPulseCount)*4+1];
  // char *ambtempchar = itoa(goalPulseCount,ambtempbuff,10);
  // String ambtempstring = ambtempchar;
  // add_sout(ambtempchar);

  // if (timerShouldSend) {
  //   oldTestPulses = givenTestCurrPulses;
  //   //maybe do this multiple times to make sure??
  //   //GIVEN TEST PULSES?????????????
  //   //TOOD SEND MULTIPLE TIMES IN CASE CORRUPTED
  // char ambtempbuff [sizeof(zInboundsNum)*4+1];
  // char *ambtempchar = itoa(zInboundsNum,ambtempbuff,10);
  // String ambtempstring = ambtempchar;
  // add_sout(ambtempchar);
  // } else {
  // char ambtempbuff [sizeof(0)*4+1];
  // char *ambtempchar = itoa(0,ambtempbuff,10);
  // String ambtempstring = ambtempchar;
  // add_sout(ambtempchar);
  // }


  //add ref meter temp
  //this is being neg sometimes??
  char reftempbuff [sizeof(reftemp)*4+1];
  char *reftempchar = itoa(reftemp,reftempbuff,10);
  String reftempstring = reftempchar;
  add_sout(reftempstring);

  //CHANGE FROM ambHUM Hann
  // char ambhumbuff [sizeof(ambhum)*4+1];
  // char *ambhumchar = itoa(ambhum,ambhumbuff,10);
  // String ambhumstring = ambhumchar;
  // add_sout(ambhumstring);
  //REPLACE WITH PRECISE TIMER!!!!!!!!!!!!!!!!!!
  //if (ShouldSend) {
    if (resendBoolean) {
    //send old timer
    char ambhumbuff [sizeof(oldTimer)*8+1];
    char *ambhumchar = itoa(oldTimer,ambhumbuff,10);
    String ambhumstring = ambhumchar;
    add_sout(ambhumstring);
  } else {
    char ambhumbuff [sizeof(preciseTimer)*8+1];
    char *ambhumchar = itoa(preciseTimer,ambhumbuff,10);
    String ambhumstring = ambhumchar;
    add_sout(ambhumstring);
  }
  
  //}
  

  // char ambhumbuff [sizeof(preciseTimer)*4+1];
  // char *ambhumchar = itoa(preciseTimer,ambhumbuff,10);
  // String ambhumstring = ambhumchar;
  // if (timerShouldSend) {
  //   oktoprocess = false;
  //   timerShouldSend = false;
  //   //add_sout("99"+ambhumstring);
  //   add_sout(ambhumstring);
  //   //reset timers
  //   //HARGOW to reset everything
  //   counter10ms = 0;
  //   preciseTimer = 0;
  //   zInboundsNum = 0;
  //   goalPulseCount = 0;
  // } else {
  //   add_sout(ambhumstring);

  // }
  
  //BRUHfasdfasdfadsf
  // if (timerShouldSend) {
  // timerShouldSend = false;
  // char ambhumbuff [sizeof(preciseTimer)*4+1];
  // char *ambhumchar = itoa(preciseTimer,ambhumbuff,10);
  // String ambhumstring = ambhumchar;
  // add_sout(ambhumstring);
  // } 
  // else {
  // char ambhumbuff [sizeof(preciseTimer)*4+1];
  // char *ambhumchar = itoa(preciseTimer,ambhumbuff,10);
  // String ambhumstring = ambhumchar;
  // add_sout(ambhumstring);
  // }
  //BRUHasdfasdfadsf
  // char ambhumbuff [sizeof(preciseTimer)*4+1];
  // char *ambhumchar = itoa(preciseTimer,ambhumbuff,10);
  // String ambhumstring = ambhumchar;
  // add_sout(ambhumstring);
  // if (timerShouldSend) {
  //   timerShouldSend = false;
  //   preciseTimer = 0;
  //   counter10ms = 0;
  //   //zInboundsNum = 0;
  //   //find better way to reset the inbouds number!!
  // }

  //add pulse count
  if (resendBoolean) {
    char pulsebuff[sizeof(zgivenpulses)*8+1];
    char *pulsechar = ltoa(zgivenpulses,pulsebuff,10);
    String pulseString = pulsechar;
    add_sout(pulseString);
  } else {
    //currzPulses
    char pulsebuff[sizeof(currzPulses)*8+1];
    char *pulsechar = ltoa(currzPulses,pulsebuff,10);
    String pulseString = pulsechar;
    add_sout(pulseString);
  }
  // char pulsebuff[sizeof(Gl_Pulse_DGM_1)*8+1];
  // char *pulsechar = ltoa(Gl_Pulse_DGM_1,pulsebuff,10);
  // String pulseString = pulsechar;
  // add_sout(pulseString);
//logitech
  /// Calculate CRC
  uint16_t iAccum = 0xFFFF;
  for (int i = 0; i < giterator; i++) {                         // #define SD_DATA_SECTOR_SIZE 510
   iAccum = ((iAccum & 0x00FF) << 8) ^ crc_table16[( (iAccum >> 8) ^ sOutput[i] ) & 0x00FF];
    }
  char accumbuff [sizeof(iAccum)*4+1];
  char *acchar = itoa(iAccum,accumbuff,10);
  String accumstring = acchar;
  add_sout("|"+accumstring);

  //add_sout("---");
  add_sout("db");
  debugz[0] = oldPulseCont;
  //debugz[1] = oldTestPulses;
  debugz[1] = 222;
  debugz[2] = zInboundsNum;
  //debugz[3] = oldTimer;
  debugz[3] = testzin;
  debugz[4] = oldgoal;
  //debugz[5] = oldgl;
  debugz[5] = Gl_Pulse_DGM_1;
  //debugz[6] = zgivenpulses;
  debugz[6] = goalPulseCount;
  debugz[7] = 111;
  for (int ii = 0; ii < 8; ii++) {
    char z [sizeof(debugz[ii])*4+1];
  char *zz = itoa(debugz[ii],z,10);
  String sd = zz;
  add_sout(sd);
  }

  // //stopping value ddebug
  // char zaccumbuff [sizeof(goalPulseCount)*4+1];
  // char *zacchar = itoa(goalPulseCount,zaccumbuff,10);
  // String zaccumstring = zacchar;
  // add_sout(zaccumstring);
  // //global pulses
  
  //ultimate end
  sOutput[giterator++] = 13;  //line feed
  sOutput[giterator++] = 10;  //carriage return
  sOutput[giterator] = '\0';  //null terminator
 
  //will send the output string 5 times a second 
  //output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
  if (shouldSend) {
    shouldSend = false;
    Serial.print(sOutput);
  }
  if (timerShouldSend) {
    oktoprocess = false;
    timerShouldSend = false;
    //add_sout("99"+ambhumstring);
    //add_sout(ambhumstring);
    //reset timers
    //HARGOW to reset everything
    //debug before reset
    oldgoal = goalPulseCount;
    oldgl = Gl_Pulse_DGM_1;
    zgivenpulses = currzPulses;
    oldTimer = preciseTimer;
    //oldtestpulses or currzpulses
    //endd eubg
    counter10ms = 0;
    preciseTimer = 0;
    zInboundsNum = 0;
    goalPulseCount = 0;
  }
  //end while
  vTaskDelay(1);
  }

}

//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum
void xpressure(void *pvParameters) {
  int temppressure;
  int sumpressure;
  (void) pvParameters;
  while (1) {
    doublepressure = double (bme.readPressure());
    //convert pascal to mmHg
    doublepressure /= 133.322;
    doublepressure *=100;
    temppressure = int (doublepressure);
    pressureArr[pressureitr] = temppressure;
    pressureitr++;
    if (pressureitr >=PRESSUREBLOCKSIZE) {pressureitr = 0;}
    sumpressure = 0;
    for (int i = 0; i < PRESSUREBLOCKSIZE; i++) {sumpressure += pressureArr[i];}
    pressure = (sumpressure/PRESSUREBLOCKSIZE);

    vTaskDelay(1);
  }
}

void xambtempth(void *pvParameters) {
  int tempambtemp;
  int sumambtemp;
  (void) pvParameters;
  while (1) {
    doubleambtemp = thermocouple.readInternal();
    doubleambtemp *= 100;
    tempambtemp = int (doubleambtemp);  // this is in celsius

    //take the average of BLOCKSIZE measurements, and update the global ambient temp with the average
    ambtempArr[ambtempitr] = tempambtemp;
    ambtempitr++;
    if (ambtempitr >=AMBBLOCKSIZE) {ambtempitr = 0;}
    sumambtemp = 0;
    for (int i = 0; i < AMBBLOCKSIZE; i++) {sumambtemp += ambtempArr[i];}
    ambtemp = (sumambtemp/AMBBLOCKSIZE);

    vTaskDelay(1);
  }
}
//output: label, pressure, ambient temp, pretend ref meter temp, ambient humidity, pulse count, checksum

void xreftempth(void *pvParameters) {
  int tempreftemp;
  int sumreftemp;
  (void) pvParameters;
  while (1) {
    doublereftemp = thermocouple.readCelsius();
    doublereftemp *= 100;
    tempreftemp = doublereftemp;

    reftempArr[reftempitr] = tempreftemp;
    reftempitr++;
    if (reftempitr >=REFBLOCKSIZE) {reftempitr = 0;}
    sumreftemp = 0;
    for (int i = 0; i < REFBLOCKSIZE; i++) {sumreftemp += reftempArr[i];}
    reftemp = (sumreftemp/REFBLOCKSIZE);

    vTaskDelay(1);
  }
}

void xambhumth(void *pvParameters) {
  int tempambhum;
  int sumambhum;
  (void) pvParameters;
  while (1) {
    doubleambhum = double (bme.readHumidity());
    doubleambhum *= 100;
    tempambhum = doubleambhum;
    
    ambhumArr[ambhumitr] = tempambhum;
    ambhumitr++;
    if (ambhumitr >=HUMBLOCKSIZE) {ambhumitr = 0;}
    sumambhum = 0;
    for (int i = 0; i < HUMBLOCKSIZE; i++) {sumambhum += ambhumArr[i];}
    ambhum = (sumambhum/HUMBLOCKSIZE);

    vTaskDelay(1);

  }
}


char inBoundsString[256];
 void xprocessInbound(void *pvParameters) {

  char inLength;
  while (1) {
    if (timertwohundo) {
      timertwohundo = false;
      inBoundsLength = Serial.available();
      if (oldInBoundsLength == inBoundsLength) {
        readyInBounds = true;
        oldInBoundsLength = 0;
      } else {
        oldInBoundsLength = inBoundsLength;
        //ZINBOUNDS FALSE?????????????????????????????????????????????????????????????????????????????????????
      } 
      if (inBoundsLength == 0) {readyInBounds = false;}
      //=======================================

      if (readyInBounds) {
        //HARGOW RESET EVERYTHING
        counter10ms = 0;
        preciseTimer = 0;
        zInboundsNum = 0;
        goalPulseCount = 0;
        //oktoprocess = true;
        //idk if necessary tbh lol

        readyInBounds = false;
        inLength = Serial.available();
        Serial.readBytes(inBoundsString, inLength);
        zInboundsNum = 0;
        for (int i = 0 ; i < 255; i++) {
          if (inBoundsString[i]== 13) { break; }
          else {
            zInboundsNum *= 10;
            zInboundsNum += inBoundsString[i] - '0';
            //IS zInboundsNum now the pulse count??
            // goalPulseCount = Gl_Pulse_DGM_1 + zInboundsNum;
            // oldPulseCont = Gl_Pulse_DGM_1;
            //DOES THIS ONLY HAPPEN ONCE????
          }

        }
        oktoprocess = true;
        seqnum = zInboundsNum % 10;
        zInboundsNum /= 10;
        testzin = zInboundsNum;
        goalPulseCount = Gl_Pulse_DGM_1 + zInboundsNum;
        oldPulseCont = Gl_Pulse_DGM_1;
        //WHY DOES IT NOT WORK IF I PUT GOAL PULSE COUNT HERE THO??????????????????????
        //i should reset some other vals here?!!?!??!!?!??!?!!?

        //end for 
     } // end ready in bounds
   }
   //zInboundsNum = 5555;
    vTaskDelay(1);
  }

 }
 //newline??