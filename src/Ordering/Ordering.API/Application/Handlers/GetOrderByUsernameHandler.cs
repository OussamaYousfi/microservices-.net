using MediatR;
using Ordering.API.Application.Mapper;
using Ordering.API.Application.Queries;
using Ordering.API.Application.Responses;
using Ordering.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Handlers
{
    public class GetOrderByUsernameHandler : IRequestHandler<GetOrderByUsernameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUsernameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUsernameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrderByUsername(request.UserName);
            var orderResponseList = OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return orderResponseList;
        }
    }
}
