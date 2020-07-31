using DirectScale.Disco.Extension.Services;
using System.Web;
using Demo.Api.MobileCoach;
using Demo.Helpers;

namespace Demo.PartnerIntegrations
{
    public interface IMobileCoachService
    {
        MobileCoachResponse GetMobileCoachChecksum(int associateId);
    }
    internal class MobileCoachService : IMobileCoachService
    {
        private readonly IAssociateService _associateService;
        private readonly IEncryptionService _encryptionService;

        private const string _token = "eCBMuDOcScWHeTwE3TlHd8B6vnC6r7Gg5oX0";
        private const string _secretKey = "ooyrmqoGtqVqB8zJ0lKj2IAFSN8hPsHx3aAd";
        private const string _urlKey = "ec30da6fcda494dce97e6fd360be8ff33bde4acd2dd2dc9ca18cbe73b15a21c7";
        private const string _baseUrl = "https://admin.mobilecoach.com/widgets/";

        public MobileCoachService(IAssociateService associateService, IEncryptionService encryptionService)
        {
            _associateService = associateService;
            _encryptionService = encryptionService;
        }

        public MobileCoachResponse GetMobileCoachChecksum(int associateId)
        {
            var user = _associateService.GetAssociate(associateId);
            var mobileUser = new MobileCoachUser
            {
                Email = user.EmailAddress,
                FirstName = user.DisplayFirstName,
                LastName = user.DisplayLastName,
                UserId = user.BackOfficeId
            };
            var url = $"{_baseUrl}{_urlKey}/loader.js?email={mobileUser.Email}&first_name={mobileUser.FirstName}&last_name={mobileUser.LastName}&user_id={mobileUser.UserId}&secret={_secretKey}";
            var encodedUrl = HttpUtility.HtmlEncode(url);
            var urlHash = _encryptionService.SetShaOneString(encodedUrl);
            return new MobileCoachResponse
            {
                Token = _token,
                Checksum = urlHash,  //encodedUrl,
                User = mobileUser
            };
        }
    }
}
