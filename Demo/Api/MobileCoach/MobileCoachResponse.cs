using DirectScale.Disco.Extension.Api;
using System;

namespace Demo.Api.MobileCoach
{
    [Serializable]
    public class MobileCoachResponse : ApiResponse
    {
        public string Token { get; set; }
        public string Checksum { get; set; }
        public MobileCoachUser User { get; set; }
    }
}
