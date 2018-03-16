using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace EventCloud.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
        
        public bool RememberClient { get; set; }
    }
}
