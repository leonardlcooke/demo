using DirectScale.Disco.Extension.Api;
using System;
using System.Net;

namespace Demo.Api.MobileCoach
{
    public class MobileCoachResponse
    {
        public string Token { get; set; }
        public string Checksum { get; set; }
        public MobileCoachUser User { get; set; }
        public int Status { get { return 0; } }
    }
}
