# SmartCoffee
Brew a perfect cup of coffee from iOS and Android apps using [Xamarin](https://www.xamarin.com/), [Azure IoT Hub](https://azure.microsoft.com/en-us/services/iot-hub/), and [Microsoft Cognitive Services](https://www.microsoft.com/cognitive-services/).

[Insert Video]

## Build Your Own
Interested in building your own smart coffee maker, for free? Check out the [SmartCoffee mini-hack](https://github.com/pierceboggan/smartcoffee-minihack), which will take you step-by-step in creating your own smart coffee maker from scratch using Xamarin, Azure IoT Hub, and Microsoft Cognitive Services.

## Architecture Overview
### Mobile Apps
SmartCoffee brings control over your coffee maker directly to you, wherever you are. To accomplish this, we built mobile apps for iOS and Android using Xamarin, which allows us to [build native mobile apps for iOS, Android, and Windows using C#](https://www.xamarin.com/). Xamarin allows us to share significant amounts of our code across multiple platforms, while still maintaining 100% access to the underlying platform APIs and building native user interfaces with iOS and Android designers. SmartCoffee utilizes Xamarin.Forms to take this a step further, allowing us to [build native user interfaces for iOS, Android, and Windows](https://www.xamarin.com/forms) from a single, shared C# or XAML codebase.

The mobile application has two main functions:

* Remotely start and stop the brewing process.
* Control the coffee maker remotely using spoken commands.

To accomplish these functions, SmartCoffee utilizes Azure IoT Hub and Microsoft Cognitive Services, which are described in greater detail below.

### Raspberry Pi
The [Rapsberry Pi](https://www.raspberrypi.org/) was invented in 2006 to revolutionize computing education. Ten years later, it has become the defacto standard for building Internet of Things applications.

What is the Raspberry Pi?
> The Raspberry Pi is a low cost, credit-card sized computer that plugs into a computer monitor or TV, and uses a standard keyboard and mouse. It is a capable little device that enables people of all ages to explore computing, and to learn how to program in languages like Scratch and Python. It’s capable of doing everything you’d expect a desktop computer to do, from browsing the internet and playing high-definition video, to making spreadsheets, word-processing, and playing games.
Source: https://www.raspberrypi.org/help/what-is-a-raspberry-pi/

[Windows IoT Core](https://developer.microsoft.com/en-us/windows/iot/iotcore) is a compact, portable version of the Windows 10 operating system that is optimized for devices such as the Raspberry Pi. As a developer, one of the awesome things about Windows 10 IoT Core is that it allows me to build applications in C# using the Universal Windows Platform (UWP) API. This brings C# not only to the desktop, web, game consoles, and mobile phones, but now to devices such as the Raspberry Pi as well.

SmartCoffee uses the Raspberry Pi as a "field gateway" (described later) that acts as a communication medium between Azure IoT Hub and our coffee maker. When the SmartCoffee app running on the Raspberry Pi receives a message, such as "turn on", the Raspberry Pi acts on that message supplies power to our coffee maker to begin the brewing process.

### Azure IoT Hub
Azure IoT Hub allows us to connect, monitor, and control our smart devices from anywhere. SmartCoffee uses Azure IoT Hub to make our coffee maker accessible from anywhere in the world with an internet connection, regardless of physical locations. In addition, Azure IoT Hub allows us to configure identities for each of our smart devices and provides per-device security mechanisms, so we can ensure that our messages are confidential and tamperproof. We can also collect device telemetry, giving us valuable insight the data our IoT solutions may be collecting.

[Diagram]

The SmartCoffee app sends cloud-to-device messages to IoT Hub. Just like any message, we must specify a recipient (our unique identifier for our smart coffee maker) and a body (the action for the device to take). Azure IoT Hub receives that message and forwards it to correct device, based on unique identifier. SmartCoffee utilizes the concept of a "[field gateway](https://azure.microsoft.com/en-us/documentation/articles/iot-hub-guidance/#field-gateways)" (in this case a Raspberry Pi 3) which acts as a communication broker between Azure IoT Hub and our coffee maker. 

[Code]

When the Raspberry Pi receives a cloud-to-device message from Azure IoT Hub, it checks the body of the message to see what action should be taken. For example, if the message contains "turn coffee on", the Raspberry Pi supplies power to the correct GPIO pins to power the coffee maker and begin the brewing process. If the message contains "turn coffee off", the Raspberry Pi reduces the power to the coffe maker to halt the brewing process. The Raspberry Pi can also send device-to-cloud messages to report back device telemetry, such as the current state of the coffee maker.

[Code]

We recently utilized Azure and Xamarin to build MyDriving, an [open-source mobile application for iOS, Android, and Windows](https://azure.microsoft.com/en-us/campaigns/mydriving/) that collects car telemetry data from an OBD-II reader in the car, and reports that data to the cloud to gain valuable insights on routes and driving patterns. 

<a href="https://www.youtube.com/watch?v=S7sSz556oKk">
<img align="center" src="https://img.youtube.com/vi/S7sSz556oKk/0.jpg">
</a>

### Microsoft Cognitive Services
What is Microsoft Cognitive Services? How do the mobile apps utilize it. Specifically what is Bing Speech API. How do we utilize it?

## License
Copyright (c) 2016 Pierce Boggan

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
