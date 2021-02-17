using MediatR;
using Ordering.API.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.Queries
{
    public class GetOrderByUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUsernameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
