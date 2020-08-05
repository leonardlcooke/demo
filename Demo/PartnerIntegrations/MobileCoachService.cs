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

        // This configuration is set for the QA environment, for the Demo instance. 
        private const string _token = "8Nzegi_iIgVgwHRiOOZD9_oGp13LkXueLxiS";
        private const string _secretKey = "mWloZHnf6SOXot1rbPcTrAlGJXAdHTupV7LI";
        private const string _urlKey = "134a9bac6f4532fe75399b2371377313e780698797b2dc4ba72fbe425da27db4";
        private const string _baseUrl = "https://qa.mobilecoach.com/widgets/"; //"https://admin.mobilecoach.com/widgets/";

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
