using CohesionApp.Data.Enums;

namespace CohesionApp.Domain.Dtos
{
    public class RequestDto
    {
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
    }
}
