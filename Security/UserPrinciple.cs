using Qimmah.Security.Attributes;

namespace Qimmah.Security
{
    public class UserPrinciple
    {
        [ClaimMapper("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")]
        public long ID { get; set; }

        [ClaimMapper("LanguageID")]
        public int LanguageID { get; set; }

        [ClaimMapper("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")]
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
