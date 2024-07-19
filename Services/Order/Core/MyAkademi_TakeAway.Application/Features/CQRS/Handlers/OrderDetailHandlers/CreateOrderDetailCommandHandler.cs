using MyAkademi_TakeAway.Application.Features.CQRS.Commands.OrderDetailCommands;
using MyAkademi_TakeAway.Application.Interfaces;
using MyAkademi_TakeAway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademi_TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                Amount = command.Amount,
                OrderingId = command.OrderingId,
                Price = command.Price,
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                TotalPrice = command.TotalPrice
            });
        }
    }
}
