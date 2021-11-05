using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureLab_GirlsandBoys.Models;

namespace AzureLab_GirlsandBoys.Data
{
    public class AzureLab_GirlsandBoysContext : DbContext
    {
        public AzureLab_GirlsandBoysContext (DbContextOptions<AzureLab_GirlsandBoysContext> options)
            : base(options)
        {
        }

        public DbSet<AzureLab_GirlsandBoys.Models.Tasks> Tasks { get; set; }
    }
}
