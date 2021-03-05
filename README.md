# CS 376 - Cryptography & Network Security - Project

<img src="https://img.shields.io/badge/platform-windows-success.svg"> <img src="https://img.shields.io/badge/version-0.5.7-blue">

## Prototype Screenshots
![](images/host1.PNG)
![](images/client1.PNG)

### Finished Stuff
1. Sockets - Data is successfully transfered between Server & Client(s). (this has been tested and confirmed between two computers on the same network)
2. Logger - Desired information is logged. (Sent to user, console, and log.txt)
3. Threadding - Threadding is utilized throughout both the client and server for optimal performance.
4. UI implementation - MetroFrameworkUI is used to skin the application so it looks more appealing (.dll files for framework are included)
5. Client Handeling - Clients can be individually updated (currently in the form of right-clicking the client in the list)

### ToDo
1. Test different attack types to make sure they are effective (All attack types should be tested & confirmed working)
2. Improve error handling (fix ugly error messages and prevent crashes)
3. Implement data encryption between server & client (This will probably involve re-writing the server and client sockets to use SSLStreams and TCPClients)

### Important Notes
This program is purely for educational purposes. 
Nothing created here is designed to be used maliciously. 
We are not responsible for what you do with this program/source code.
