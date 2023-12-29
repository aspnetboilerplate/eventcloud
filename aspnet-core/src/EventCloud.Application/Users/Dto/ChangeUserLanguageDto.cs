using System.ComponentModel.DataAnnotations;

namespace EventCloud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}