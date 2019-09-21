# Ex.SendToSlack() (Slack.Exception.Send)

![alt text](https://imgur.com/XZfKzqt)

## <a name="very_simple"/> Very Simple
```csharp
try
{
    throw new DivideByZeroException();
}
catch (System.Exception ex)
{
    await ex.SendToSlack();
}
```
