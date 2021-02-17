using MediatR;
using Ordering.API.Application.Commands;
using Ordering.API.Application.Mapper;
using Ordering.API.Application.Responses;
using Ordering.API.Core.Entities;
using Ordering.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null)
            {
                throw new ApplicationException("not mapped");
            }
            var newOrder = await _orderRepository.AddAsync(orderEntity);
            var orderResponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);
            return orderResponse;
        }
    }
}
