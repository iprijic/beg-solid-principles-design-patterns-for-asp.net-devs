﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LSP.Core
{
    public class GuestSettings : IReadableSettings,ISettings
    {
        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("GuestName", "John");
            return settings;
        }

        public string SetSettings(Dictionary<string, string> settings)
        {
            throw new NotImplementedException();
        }
    }
}
