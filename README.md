# Ex.SendToSlack() (Slack.Exception.Send)

![Screenshot](img/screenshot.png)

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
