using CorridaFiapWebAsp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorridaFiapWebAsp.Context
{
    public class AllCorridaContext : DbContext { 
        public DbSet<Corrida> Corridas { get; set; }
        public AllCorridaContext(DbContextOptions op) : base(op)
        {
                
        }
    }
}
