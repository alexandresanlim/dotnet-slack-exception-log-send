using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slack.Webhooks;
using System;
using System.Threading.Tasks;

namespace Slack.Exception.Send.Test
{
    [TestClass]
    public class TestSendException
    {

        public TestSendException()
        {
            SendException.Start(new Config
            {
                WebHookUrl = "https://hooks.slack.com/services/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"
            });
        }

        [TestMethod]
        public async Task SendASimpleException()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlackAsync();
                Assert.IsTrue(send);
            }
        }

        [TestMethod]
        public async Task AddExtraField()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlackAsync(new ExtraInfo
                {
                    Fields = new System.Collections.Generic.List<Webhooks.SlackField>
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
                             Value = "Hi, I'am a new long field to show in GitHub sample",
                         }
                    }
                });
                Assert.IsTrue(send);
            }
        }

        [TestMethod]
        public async Task AddActions()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlackAsync(new ExtraInfo
                {
                    Actions = new System.Collections.Generic.List<Webhooks.SlackAction>
                    {
                        new SlackAction
                        {
                            Type = SlackActionType.Button,
                            Text = "Open an issue",
                            Style = SlackActionStyle.Danger,
                            Url = "https://URLToOpenAnIssueHere.com"
                        }
                    }
                });
                Assert.IsTrue(send);
            }
        }

        [TestMethod]
        public async Task AddExtraFieldAndAction()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlackAsync(new ExtraInfo
                {
                    Fields = new System.Collections.Generic.List<SlackField>
                    {
                        new Webhooks.SlackField
                        {
                            Title = "Extra field",
                            Value = "Extra field value",
                            Short = true
                        },
                    },
                    Actions = new System.Collections.Generic.List<Webhooks.SlackAction>
                    {
                        new SlackAction
                        {
                            Type = SlackActionType.Button,
                            Text = "Open an issue",
                            Style = SlackActionStyle.Danger,
                            Url = "https://URLToOpenAnIssueHere.com"
                        }
                    }
                });
                Assert.IsTrue(send);
            }
        }


        [TestMethod]
        public async Task WebHookNotFoundException()
        {
            try
            {
                SendException.Start(new Config
                {
                    WebHookUrl = ""
                });

                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                await Assert.ThrowsExceptionAsync<System.ArgumentException>(async () => await e.SendToSlackAsync());
            }
        }

        //[TestMethod]
        //public async Task GitHubSampleMobileService()
        //{
        //    try
        //    {
        //        throw new MobileServiceInvalidOperationException("Error", new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        //    }
        //    catch (System.Exception e)
        //    {
        //        await e.SendToSlackAsync();
        //    }
        //}

        //[TestMethod]
        //public async Task SendMobileServiceInvalidOperationException()
        //{
        //    try
        //    {
        //        throw new MobileServiceInvalidOperationException("Error", new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        //    }
        //    catch (System.Exception e)
        //    {
        //        var send = await e.SendToSlackAsync();
        //        Assert.IsTrue(send);
        //    }
        //}
    }
}
