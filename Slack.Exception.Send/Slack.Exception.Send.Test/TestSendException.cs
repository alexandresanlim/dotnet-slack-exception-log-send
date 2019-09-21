using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;

namespace Slack.Exception.Send.Test
{
    [TestClass]
    public class TestSendException
    {

        public TestSendException()
        {
            SendException.CreateConfig(new SendToSlackConfig
            {
                WebHookUrl = "https://hooks.slack.com/services/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"
            });
        }

        [TestMethod]
        public void GitHubSample()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                e.SendToSlack();
            }
        }

        [TestMethod]
        public async Task GitHubSampleMobileService()
        {
            try
            {
                throw new MobileServiceInvalidOperationException("Error", new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }
            catch (System.Exception e)
            {
                await e.SendToSlackAsync();
            }
        }


        [TestMethod]
        public async Task SendSimpleException()
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
        public async Task SendMobileServiceInvalidOperationException()
        {
            try
            {
                throw new MobileServiceInvalidOperationException("Error", new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlackAsync();
                Assert.IsTrue(send);
            }
        }


        [TestMethod]
        public async Task WebHookNotFoundException()
        {
            try
            {
                SendException.CreateConfig(new SendToSlackConfig
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
    }
}
