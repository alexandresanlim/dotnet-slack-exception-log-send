# Ex.SendToSlack() (Slack.Exception.Send)

![alt text](https://raw.githubusercontent.com/username/projectname/branch/path/to/img.png)

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
