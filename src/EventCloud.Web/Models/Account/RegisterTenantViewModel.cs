using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Web.Models.Account
{
    public class RegisterTenantViewModel : IInputDto
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        public string Password { get; set; }
    }
}