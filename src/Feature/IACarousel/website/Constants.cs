using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WbbHackathon.Feature.IACarousel
{
    public class Constants
    {
        public static string GenerationEndPoint = Settings.GetSetting("GenerationEndpoint");
        public static string ApiToken = Settings.GetSetting("GenerationApiToken");
    }
}