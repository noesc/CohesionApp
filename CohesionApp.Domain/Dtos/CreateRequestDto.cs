using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CohesionApp.Domain.Dtos
{
    public class CreateRequestDto
    {
        [Required]
        public string BuildingCode { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
