# JoyWarrior28A12L example codes
This repository includes some example projects for the JoyWarrior28A12L to communicate with the device.  

&nbsp;
## Features
The basic features of the JoyWarrior28A12L:
- Four analog axes (potentiometer or voltage input) with 12 bit resolution each
- Supports up to 8 buttons, direct connected to the chip or 16 buttons in 4x4 matrix
- Four auxiliary outputs for LEDs or other uses
- Internal A/D converter for minimal external circuitry
- Minimal external circuitry
- Uses system drivers from Windows, Linux and MacOSX

&nbsp;
### Data format for input and output
The JoyWarrior28A12L use for input 11 bytes of data. The data will be formatet as 12Bit LSB first in the following order:  
```
BYTE[0]: ReportID (0x00 by default)  
BYTE[1..2]: Axis 0  
BYTE[3..4]: Axis 1  
BYTE[5..6]: Axis 2  
BYTE[7..8]: Axis 3  
BYTE[9] : Button (8bit)  
or  
Byte[9..10] Button (16Bit in 4x4 matrix)  
```

For the output the JoyWarrior use 5 bytes of data as 8Bit values:  
```
BYTE[0]: ReportID (0x00 by default)  
Byte[1]: Output 0  
Byte[2]: Output 1  
Byte[3]: Output 2  
Byte[4]: Output 3  
```
The value for the output will be:
```
0x00: Idle  
0x01: Static on  
0x02: Fast blink  
0x03: Heartbeat  
```
More Information can be found in the [datasheet](https://www.codemercs.com/downloads/joywarrior/JW28_Datasheet.pdf) of JoyWarrior28A12L.


&nbsp;
## Links and further information
[Product site](https://www.codemercs.com/de/joystick/analog) for more informations, datasheets, and software/tools for the JoyWarrior28A12L device  
[Company site](https://www.codemercs.com) for information on more devices.

&nbsp;
## Contact
If you have any questions about the IO-Warrior please contact **support@codemercs.com** or using the [issues](https://github.com/codemercs-com/jw28a12l/issues) section in this repository. 
There is also a company [forum](https://forum.codemercs.com/) with many solved questions.