using System.Security.Claims;

namespace Civica.Core.EPortal.Web.Models
{
    public class UserVm : ClaimsPrincipal
    {
        public int Id { get; set; }
        public string LoginID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public bool ?SMS { get; set; }
        public bool CanMakeEnquiry { get; set; }
        public bool CanCreateCase { get; set; }
        public bool CanMakeBooking { get; set; }
        public bool SelfServiceUser { get; set; }
        public bool LoginSucceeded { get; set; }
        public string SecurityMessage { get; set; }
        public int PasswordChanges { get; set; }
        //public EPortalConfigurationVm Configuration { get; set; }
    }
}
