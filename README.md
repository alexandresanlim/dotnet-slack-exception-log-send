# Slack.Exception.Send


## <a name="ByKey"/> ByKey
```csharp
try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                await e.SendToSlack();
            }
```
