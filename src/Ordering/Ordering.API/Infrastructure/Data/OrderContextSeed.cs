using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                orderContext.Database.Migrate();
                if (!(await orderContext.Orders.AnyAsync()))
                {
                    orderContext.Orders.AddRange(GetPreConfiguredOrders());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { Username = "swn", FirstName = "Oussama", LastName = "Yousfi",EmailAddress="oussama.yousfi@esprit.tn",AddressLine="Mourouj",Country="Tunisia"}
            };
        }
    }
}
