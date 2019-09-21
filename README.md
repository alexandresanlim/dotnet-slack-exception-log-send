# Ex.SendToSlack() (Slack.Exception.Send)

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
![alt text](https://i.imgur.com/Pc0MXIj.png)


