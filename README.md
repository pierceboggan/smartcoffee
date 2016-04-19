# SmartCoffee
Brew a perfect cup of coffee from iOS and Android apps using Xamarin, Azure IoT Hub, and Microsoft Cognitive Services.

[Insert Video]

### Mobile Apps
SmartCoffee brings control over your coffee maker directly to you, wherever you are. To accomplish this, we built mobile apps for iOS and Android using Xamarin, which allows us to build native mobile apps for iOS, Android, and Windows using C#. Xamarin allows us to share significant amounts of our code across multiple platforms, while still maintaining 100% access to the underlying platform APIs and building native user interfaces with iOS and Android designers. SmartCoffee utilizes Xamarin.Forms to take this a step further, allowing us to build native user interfaces for iOS, Android, and Windows from a single, shared C# or XAML codebase.

The mobile application has two main functions:

* Remotely start and stop the brewing process.
* Control the coffee maker remotely using spoken commands.

To accomplish these functions, SmartCoffee utilizes Azure IoT Hub and Microsoft Cognitive Services, which are described in greater detail below.

### Raspberry Pi
The Rapsberry Pi was invented in 2006 to revolutionize computing education. Ten years later, it has become the defacto standard for building Internet of Things applications.

What is the Raspberry Pi?
> The Raspberry Pi is a low cost, credit-card sized computer that plugs into a computer monitor or TV, and uses a standard keyboard and mouse. It is a capable little device that enables people of all ages to explore computing, and to learn how to program in languages like Scratch and Python. It’s capable of doing everything you’d expect a desktop computer to do, from browsing the internet and playing high-definition video, to making spreadsheets, word-processing, and playing games.
Source: https://www.raspberrypi.org/help/what-is-a-raspberry-pi/

Windows IoT Core is a compact, portable version of the Windows 10 operating system that is optimized for devices such as the Raspberry Pi. As a developer, one of the awesome things about Windows 10 IoT Core is that it allows me to build applications in C# using the Universal Windows Platform (UWP) API. This brings C# not only to the desktop, web, game consoles, and mobile phones, but now to devices such as the Raspberry Pi as well.

SmartCoffee uses the Raspberry Pi as a "field gateway" (described later) that acts as a communication medium between Azure IoT Hub and our coffee maker. When the SmartCoffee app running on the Raspberry Pi receives a message, such as "turn on", the Raspberry Pi acts on that message supplies power to our coffee maker to begin the brewing process.

### Azure IoT Hub
What is IoT Hub? 
-high level
-what this enables
-diagrams

How do the mobile apps / raspberry pi interact with it?
-communication via several protocols, but in this we will use AMQPLite - secure communication protocol.
-mobile apps send a message via AMQP (a cloud-to-device) message to IoT Hub. just like any message, it has a recipient and body. in this case, the recipient is the device ID of coffee maker, and the body is the message we want to tell the coffee maker, such as "turn on" or "turn off".

A Raspberry Pi, acting as a "field gateway" device, receives messages sent to that particular device from IoT Hub, and acts accordingly. In our case, this means altering the power to the Raspberry Pi's GPIO pins to begin or halt the brewing process. But it could mean do so much more - such as get the current temperature in my apartment, or set the lighting for my living room. The Raspberry Pi can also send "device to cloud" messages to report back to the cloud device telemetry. 

### Microsoft Cognitive Services
What is Microsoft Cognitive Services? How do the mobile apps utilize it. Specifically what is Bing Speech API. How do we utilize it?

# Build Your Own
Interested in building your own? Download the completed source for 

# License
Copyright (c) 2016 Pierce Boggan

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
