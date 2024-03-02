using Sitecore.Data;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WbbHackathon.Feature.IACarousel
{
    public static class Templates
    {
        public struct HeroCarouselAI
        {
            public static ID Id = new ID("{3655A117-5AEF-4A69-8E75-8EEE80F8BA22}");

            public struct Fields
            {
                public static ID Prompt = new ID("{74819860-BD90-4CE3-96D1-708B35974F1F}");
                public static ID NumberOfImages = new ID("{E385D532-9F7C-4B74-A569-4ACB3D3FE286}");
                public static ID Height = new ID("{D08A003D-554B-44CE-BCDB-DAF58688B4D1}");
                public static ID Width = new ID("{16F170A9-00AC-4A41-B3ED-880450D51029}");
                public static ID ImageCreativeModel = new ID("{868CE3A8-1618-4F77-BAE8-3CBFDC12AA99}");
            }
        }

        public struct ImageCreationModel
        {
            public static ID Id = new ID("{14DAF934-CF9D-4A08-AA14-C9D989EC2F74}");

            public struct Fields
            {
                public static ID Id = new ID("{B8EE2C12-A190-4F9D-91CA-75F9E4C1A630}");
                public static ID Name = new ID("{31CAA58B-6A75-49E6-A02B-C71F64338499}");
                public static ID Description = new ID("{23F0D857-976B-4778-BB42-51DAF32A9322}");
            }
        }
    }
}