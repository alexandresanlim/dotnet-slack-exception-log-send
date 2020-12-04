# Slack Exception Send
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

### Prepare your slack channel to receive the exceptions

## Lets create a channel and a webhook url to receive exception messages.

 - On slack app select add channel > Create a new channel > Set a name, example: "bug-report" or "exceptions" > Confirm

![image](https://user-images.githubusercontent.com/5353685/101170411-2d7c3b80-361d-11eb-9b6d-e8545e2511f1.png)

### Install Incoming WebHook App

 - Select browse Slack > Apps > Find "Incoming Webhooks" > Add
<img width='500' src='https://user-images.githubusercontent.com/5353685/101171414-7aacdd00-361e-11eb-85e4-8f652ba61e6b.png' />

### On new tab select add to slack.

 - Select your channel to receive slack exceptions messages > Add Integration

<img width='800' src='https://user-images.githubusercontent.com/5353685/101173510-661e1400-3621-11eb-824d-3721d55fc100.png' />

 - It's ready! Copy the webhook URL generated.

<img width='800' src='https://user-images.githubusercontent.com/5353685/101173743-b4cbae00-3621-11eb-9616-ad8bb3c7e1a5.png' />

1 - Install this [Nuget Package](https://www.nuget.org/packages/Slack.Exception.Send)

3 - Create a new configuration of Slack.Exception.Send
```csharp
public TestSendException()
{
    SendException.CreateConfig(new SendToSlackConfig
    {
        WebHookUrl = "YOUR WEBHOOK URL"
    });
}
```
4 - Finish! Now your aplication will be solid!

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

![alt text](https://i.imgur.com/sjXiF91.png)


[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)



