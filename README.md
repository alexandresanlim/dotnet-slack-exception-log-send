


# Slack Exception Send

<img width='200' src='https://user-images.githubusercontent.com/5353685/101387243-f1570e00-389c-11eb-8386-f3228235bf6f.png'/>

[![Nuget](https://img.shields.io/nuget/dt/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)
[![Nuget](https://img.shields.io/nuget/v/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)

With this .net package you will be able to create a bug report with Slack application, inspect and track any issues your users run into while running your app.


# How to use?
It's really simple, send an error to be tracked as a handled exception using the function SendToSlack:
```csharp
try
{
    //your code here
}
catch (System.Exception ex)
{
    ex.SendToSlack();
}
```
Results in:

![alt text](https://i.imgur.com/Pc0MXIj.png)

## How to start it?
We have a [great wiki article](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki) explaining exactly that or follow the steps:

[1 - Prepare your Slack channel to receive exceptions](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/1---Prepare-your-slack-channel-to-receive-exceptions)<br/>
[2 - Prepare your application to send exceptions](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/2-Prepare-your-application-to-send-exceptions-to-Slack-channel)<br/>
[3 - Customizations](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/3-Customizations)<br/>
[3.1 - Add extra fields](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/3.1-Add-extra-fields)<br/>
[3.2 - Add actions](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/3.2-Add-Actions)<br/>
[4 - Execute tests on this project](https://github.com/alexandresanlim/DotNet.Slack.ExceptionSend/wiki/4-Execute-tests-on-this-project)<br/>
    
<img src='https://forthebadge.com/images/badges/built-with-love.svg' />





