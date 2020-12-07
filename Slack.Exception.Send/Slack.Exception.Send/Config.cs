using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.Exception.Send
{
    public class Config
    {
        public string Color { get; set; } = "#c0392b";

        /// <summary>
        /// Set your Slack WebHookUrl here
        /// </summary>
        public string WebHookUrl { get; set; }
    }
}
