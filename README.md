- With this package you will be able to create a bug report with Slack application, inspect and track any issues your users run into while running your app.


[![Nuget](https://img.shields.io/nuget/dt/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)
[![Nuget](https://img.shields.io/nuget/v/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)

## <a name="very_simple"/> How to use?
```csharp
try
{
    //To force exception
    throw new DivideByZeroException();
}
catch (System.Exception ex)
{
    ex.SendToSlack();
}
```
Results in:

![alt text](https://i.imgur.com/Pc0MXIj.png)

## Getting Start

1 - Install this [Nuget Package](https://www.nuget.org/packages/Slack.Exception.Send)

2 - Install and add a new configuration Incoming WebHooks Slack App:

![image](https://user-images.githubusercontent.com/5353685/94029386-21f5d400-fd93-11ea-9148-e29bee9993aa.png)

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
4 - Use in "catch"
```csharp
try
{

}
catch (System.Exception e)
{
    e.SendToSlack();
}
```    

## <a name="many_field"/> Support for extra fields
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

      

## Benefits
* Create a bug report
* Support to MobileServiceInvalidOperationException

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)



