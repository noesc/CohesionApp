using CohesionApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohesionApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) :
            base(options)
        { }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
