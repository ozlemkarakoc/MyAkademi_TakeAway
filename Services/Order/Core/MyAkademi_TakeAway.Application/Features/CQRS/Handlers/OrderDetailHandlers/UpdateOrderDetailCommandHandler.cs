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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.Amount = command.Amount;
            values.Price = command.Price;
            values.TotalPrice = command.TotalPrice;
            values.ProductId = command.ProductId;
            values.ProductName = command.ProductName;
            values.Ordering = command.Ordering;
            values.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(values);
        }
    }
}
