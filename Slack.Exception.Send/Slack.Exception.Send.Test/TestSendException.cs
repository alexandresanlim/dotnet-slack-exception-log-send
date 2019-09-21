using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;

namespace Slack.Exception.Send.Test
{
    [TestClass]
    public class TestSendException
    {
        [TestMethod]
        public async Task SendSimpleException()
        {
            try
            {
                SendException.CreateConfig(new SendToSlackConfig
                {
                    WebHookUrl = "YOUR_WEBHOOK_URL"
                });

                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlack();
                Assert.IsTrue(send);
            }
        }

        [TestMethod]
        public async Task SendMobileServiceInvalidOperationException()
        {
            try
            {
                SendException.CreateConfig(new SendToSlackConfig
                {
                    WebHookUrl = "YOUR_WEBHOOK_URL"
                });
               
                throw new MobileServiceInvalidOperationException("Error", new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }
            catch (System.Exception e)
            {
                var send = await e.SendToSlack();
                Assert.IsTrue(send);
            }
        }


        [TestMethod]
        public async Task WebHookNotFoundException()
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (System.Exception e)
            {
                await Assert.ThrowsExceptionAsync<System.ArgumentException>(async () => await e.SendToSlack());
            }
        }
    }
}
