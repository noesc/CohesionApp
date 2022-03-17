using CohesionApp.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CohesionApp.Domain.Dtos
{
    public class UpdateRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string BuildingCode { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public CurrentStatus CurrentStatus { get; set; }
    }
}
