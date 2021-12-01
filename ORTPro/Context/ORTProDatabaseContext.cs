using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORTPro.Models;
namespace ORTPro.Context
{
    public class ORTProDatabaseContext : DbContext
    {
        public ORTProDatabaseContext(DbContextOptions<ORTProDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Profesional> Profesionales { get; set; }
    }
}
