using Slack.Webhooks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.Exception.Send
{
    public class ExtraInfo
    {
        public ExtraInfo()
        {
            Fields = new List<SlackField>();
            Actions = new List<SlackAction>();
        }

        public List<SlackField> Fields { get; set; }

        public List<SlackAction> Actions { get; set; }
    }
}
