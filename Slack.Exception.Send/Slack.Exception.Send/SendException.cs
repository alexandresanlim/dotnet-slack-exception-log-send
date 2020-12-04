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
        /// Set your Slack WebHookUrl here
        /// </summary>
        public string WebHookUrl { get; set; }
    }

    public static class SendException
    {
        public static SlackClient SlackClient { get; set; }

        public static SendToSlackConfig Config { get; set; }

        public static void Start(SendToSlackConfig config)
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

        public static async Task<bool> SendToSlackAsync(this System.Exception ex, List<SlackField> extraFields = null)
        {
            var slackMessage = GetExceptionText(ex, extraFields);
            return await SlackClient.PostAsync(slackMessage).ConfigureAwait(false);
        }

        public static bool SendToSlack(this System.Exception ex, List<SlackField> extraFields = null)
        {
            var slackMessage = GetExceptionText(ex, extraFields);
            return SlackClient.Post(slackMessage);
        }

        private static SlackMessage GetExceptionText(System.Exception ex, List<SlackField> extraFields = null)
        {
            if (string.IsNullOrEmpty(Config?.WebHookUrl))
                throw new ArgumentException("WebHookUrl not found");

            SlackClient = new SlackClient(Config.WebHookUrl);

            var st = new StackTrace(ex, true);

            var frame = st.GetFrame(0);

            var message = ex?.Message;

            if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                message += "\n\nInnerException.Message: " + ex?.InnerException?.Message;

            return BuildSlackMessage(frame, message, extraFields);
        }

        private static SlackMessage BuildSlackMessage(StackFrame frame, string message, List<SlackField> extraFields = null)
        {
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
                    Value = frame.GetFileColumnNumber().ToString(),
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


            return new SlackMessage()
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
        }
    }
}
