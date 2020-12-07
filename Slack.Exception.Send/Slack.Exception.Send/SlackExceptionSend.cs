using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Exception.Send
{
    public static class SlackExceptionSend
    {
        public static SlackClient SlackClient { get; set; }

        public static Config Config { get; set; }

        public static void Start(Config config)
        {
            Config = config;
        }

        public static void Start(string webHookUrl, string color = "#c0392b")
        {
            Config = new Config
            {
                Color = color,
                WebHookUrl = webHookUrl
            };
        }

        public static async Task<bool> SendToSlackAsync(this System.Exception ex, ExtraInfo extraInfo = null)
        {
            try
            {
                var slackMessage = GetExceptionText(ex, extraInfo);
                return await SlackClient.PostAsync(slackMessage).ConfigureAwait(false);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static bool SendToSlack(this System.Exception ex, ExtraInfo extraInfo = null)
        {
            try
            {
                var slackMessage = GetExceptionText(ex, extraInfo);
                return SlackClient.Post(slackMessage);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        private static SlackMessage GetExceptionText(System.Exception ex, ExtraInfo extraInfo = null)
        {
            if (string.IsNullOrEmpty(Config?.WebHookUrl))
                throw new ArgumentException("WebHookUrl not found");

            SlackClient = new SlackClient(Config.WebHookUrl);

            var st = new StackTrace(ex, true);

            var frame = st.GetFrame(0);

            var message = ex?.Message;

            if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                message += "\n\nInnerException.Message: " + ex?.InnerException?.Message;

            return BuildSlackMessage(frame, message, extraInfo);
        }

        private static SlackMessage BuildSlackMessage(StackFrame frame, string message, ExtraInfo extraInfo = null)
        {
            var fields = new List<SlackField>
            {
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
                    Title = "File",
                    Value = frame.GetFileName().ToString(),
                }
            };

            if (extraInfo?.Fields != null && extraInfo.Fields.Count > 0)
                fields.AddRange(extraInfo.Fields);

            var slackAttachment = new SlackAttachment
            {
                Text = message,
                Color = Config.Color,
                Fields = fields,
            };

            if (extraInfo?.Actions != null && extraInfo.Actions.Count > 0)
                slackAttachment.Actions = extraInfo.Actions;

            return new SlackMessage()
            {
                Attachments = new List<SlackAttachment>
                {
                    slackAttachment
                },
            };
        }
    }
}
