using CohesionApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohesionApp.Data.Entities
{
    public class ServiceRequest : BaseEntity<ServiceRequest>
    {
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public override void CopyFrom(ServiceRequest entity)
        {
            BuildingCode = entity.BuildingCode;
            Description = entity.Description;
            CurrentStatus = entity.CurrentStatus;
        }
    }
}
