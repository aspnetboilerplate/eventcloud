using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace EventCloud.Events
{
    public class CreateEventInput : IInputDto
    {
        [Required]
        [StringLength(Event.MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(Event.MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Range(0, 60)]
        public int MinAgeToRegister { get; set; }
    }
}