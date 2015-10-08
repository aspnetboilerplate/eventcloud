using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace EventCloud.Events.Dtos
{
    public class EventRegisterInput : IInputDto
    {
        [Required]
        public Guid EventId { get; set; }
    }
}