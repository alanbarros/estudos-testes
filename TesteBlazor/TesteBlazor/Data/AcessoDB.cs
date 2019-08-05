using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBlazor.Data.Models;

namespace TesteBlazor.Data
{
    public class AcessoDB : DbContext
    {
        public AcessoDB(DbContextOptions<AcessoDB> options) : base(options)
        {

        }

        public DbSet<Compra> Compras { get; set; }
    }
}
