using Microsoft.WindowsAzure.MobileServices;
using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Exception.Send
{
    public class SendToSlackConfig
    {
        public string Color { get; set; } = "#c0392b";

        /// <summary>
        /// Get your Slack WebHookUrl here: Finde Incoming-Webhooks in Slack Apps and SetUp a new configuration.
        /// </summary>
        public string WebHookUrl { get; set; }
    }

    public static class SendException
    {
        public static SlackClient SlackClient { get; set; }

        public static SendToSlackConfig Config { get; set; }

        public static void CreateConfig(SendToSlackConfig config)
        {
            Config = config;
        }

        public static void CreateConfig(string webHookUrl, string color = "#c0392b")
        {
            Config = new SendToSlackConfig
            {
                Color = color,
                WebHookUrl = webHookUrl
            };
        }

        public static async Task<bool> SendToSlack(this System.Exception ex, List<SlackField> extraFields = null)
        {
            if (string.IsNullOrEmpty(Config?.WebHookUrl))
                throw new ArgumentException("WebHookUrl not found");

            SlackClient = new SlackClient(Config.WebHookUrl);

            var st = new StackTrace(ex, true);

            var frame = st.GetFrame(0);

            var message = ex.Message;

            if (ex is MobileServiceInvalidOperationException)
            {
                var e = ex as MobileServiceInvalidOperationException;

                var msg = e.Response.Content != null ? await e?.Response?.Content?.ReadAsStringAsync() : "";

                if (!string.IsNullOrEmpty(msg))
                    message = msg;
            }

            var fields = new List<SlackField>
            {
                new SlackField
                {
                    Title = "Message Error",
                    Value = message,
                    Short = false
                },

                new SlackField
                {
                    Title = "Project Name",
                    Value = Assembly.GetCallingAssembly().GetName().Name,
                    Short = true
                },

                new SlackField
                {
                    Title = "Method",
                    Value = frame.GetMethod().ToString(),
                    Short = true
                },

                new SlackField
                {
                    Title = "Line Number",
                    Value = frame.GetFileLineNumber().ToString(),
                    Short = true
                },

                new SlackField
                {
                    Title = "Line Column",
                    Value = frame.GetFileLineNumber().ToString(),
                    Short = true
                },

                new SlackField
                {
                    Title = "File Name",
                    Value = frame.GetFileName().ToString(),
                }
            };

            if (extraFields != null)
                fields.AddRange(extraFields);


            var slackMessage = new SlackMessage()
            {
                Attachments = new List<SlackAttachment>
                {
                    new SlackAttachment
                    {
                        Color = Config.Color,
                        Fields = fields
                    },
                },
            };

            return await SlackClient.PostAsync(slackMessage).ConfigureAwait(false);
        }
    }
}
