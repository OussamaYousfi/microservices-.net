using Microsoft.EntityFrameworkCore;
using Ordering.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
