using Microsoft.EntityFrameworkCore;
using Ordering.API.Core.Entities;
using Ordering.API.Core.Repositories.Base;
using Ordering.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Core.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrderByUsername(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.Username == userName).ToListAsync();
            return orderList;
        }
    }
}
