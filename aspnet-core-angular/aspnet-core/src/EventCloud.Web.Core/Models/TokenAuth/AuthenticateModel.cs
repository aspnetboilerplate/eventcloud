using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace EventCloud.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [Display(Name = "Usuário ou E-mail", Description = "Nome de Usuário ou E-mail")]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [Display(Name = "Senha", Description = "Senha do Usuário")]
        public string Password { get; set; }
        
        public bool RememberClient { get; set; }
    }
}
