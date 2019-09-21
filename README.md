# Ex.SendToSlack() (Slack.Exception.Send)

[![Nuget](https://img.shields.io/nuget/dt/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)
[![Nuget](https://img.shields.io/nuget/v/Slack.Exception.Send)](https://www.nuget.org/packages/Slack.Exception.Send)

[![Nuget Status](https://img.shields.io/nuget/dt/OData.QueryBuilder.svg)](https://www.nuget.org/packages/OData.QueryBuilder)

## <a name="very_simple"/> Very Simple to use
```csharp
try
{
    throw new DivideByZeroException();
}
catch (System.Exception ex)
{
    ex.SendToSlack();
}
```
## <a name="result"/>It's the Awesome Result:

![alt text](https://i.imgur.com/Pc0MXIj.png)

## Benefits
* Create a bug report

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)



