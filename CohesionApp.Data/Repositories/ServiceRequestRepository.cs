using CohesionApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohesionApp.Data.Repositories
{
    public class ServiceRequestRepository : BaseRepository<ServiceRequest>, IServiceRequestRepository
    {
        public ServiceRequestRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
