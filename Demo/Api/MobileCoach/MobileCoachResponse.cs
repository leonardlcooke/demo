using DirectScale.Disco.Extension.Api;

namespace Demo.Api.MobileCoach
{
    public class MobileCoachResponse : ApiResponse
    {
        public string Token { get; set; }
        public string Checksum { get; set; }
        public MobileCoachUser User { get; set; }
    }
}
