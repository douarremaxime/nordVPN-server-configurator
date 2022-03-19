# nordVPN-server-configurator
A .NET 6.0 console application to configure the hostname of a NordVPN IKEv2 connection on Windows
## Description
nordVPN-server-configurator was developped for NordVPN® subscribers who use Windows 10 built-in VPN provider instead of NordVPN® GUI client application. nordVPN-server-configurator is a simple console application that quickly and reliably queries NordVPN for a server recommendation and updates the hostname of the configured VPN connection.  
It saves the user the trouble to have to visit [NordVPN® server tools](https://nordvpn.com/servers/tools/) and update their connection manually.
## Prerequisites
* A NordVPN® subscription
* [A Windows VPN connection configured for NordVPN®](https://support.nordvpn.com/Connectivity/Windows/1047410092/How-to-connect-to-NordVPN-with-IKEv2-IPSec-on-Windows-10.htm) **The VPN connection must be named: `NordVpn`**
## How to install 
* Download [NordVPN Server Configurator.zip](https://github.com/douarremaxime/nordVPN-server-configurator/blob/master/NordVPN%20Server%20Configurator.zip)
* Extract in the application destination folder
* Run NordVpnServerConfigurator.exe
## How to build
* Clone the repository
* Execute `dotnet build`
