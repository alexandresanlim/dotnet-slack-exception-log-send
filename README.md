


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

# 🚀 Getting Start

# Prepare your slack channel to receive the exceptions

### 1 - Lets create a channel and a webhook url to receive exception messages.

 1.1 On slack app select add channel > Create a new channel > Set a name, example: "bug-report" or "exceptions" > Confirm
 
Results:

![image](https://user-images.githubusercontent.com/5353685/101170411-2d7c3b80-361d-11eb-9b6d-e8545e2511f1.png)

### 2 - Install Incoming WebHook App

 2.1 Select browse Slack > Apps > Find "Incoming Webhooks" > Add
 
<img width='500' src='https://user-images.githubusercontent.com/5353685/101171414-7aacdd00-361e-11eb-85e4-8f652ba61e6b.png' />

### 3 - On new tab select add to slack.

3.1 Select your channel to receive exceptions messages from your application > Add Integration

<img width='700' src='https://user-images.githubusercontent.com/5353685/101173510-661e1400-3621-11eb-824d-3721d55fc100.png' />

3.2 It's ready! Copy the webhook URL generated.

<img width='700' src='https://user-images.githubusercontent.com/5353685/101173743-b4cbae00-3621-11eb-9616-ad8bb3c7e1a5.png' />


# Prepare your application to send the exceptions

### 1 - Install this [Nuget Package](https://www.nuget.org/packages/Slack.Exception.Send)

### 2 - On your start appliction, create a new configuration of Slack.Exception.Send
```csharp
SlackExceptionSend.Start(new Config
{
    WebHookUrl = "YOUR WEBHOOK URL TO TEST HERE"
});
```
### 3 - Finish! You can use ex.SendToSlack() on exceptions to be your aplication will be solid!

# More!

## Support for extra fields
```csharp
try
{
    throw new DivideByZeroException();
}
catch (System.Exception e)
{
    await e.SendToSlackAsync(new List<Webhooks.SlackField>
    {
         new Webhooks.SlackField
         {
             Title = "Username",
             Value = "Alexandre Sanlim",
             Short = true
         },
         new Webhooks.SlackField
         {
             Title = "S.O",
             Value = "Windows 10",
             Short = true
         },
         new Webhooks.SlackField
         {
             Title = "New Field 3",
             Value = "Hi, I'am a new long field to show in GitHub sample 😎",
         }
    });
}
```
Results in:

<img width='800' src='https://user-images.githubusercontent.com/5353685/101176947-f78f8500-3625-11eb-99c2-87ba2827e3df.png' />


<img src='https://forthebadge.com/images/badges/built-with-love.svg' />





