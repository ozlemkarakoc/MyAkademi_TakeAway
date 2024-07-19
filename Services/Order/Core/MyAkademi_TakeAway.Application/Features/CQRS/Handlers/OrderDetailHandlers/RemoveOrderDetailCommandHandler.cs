using MyAkademi_TakeAway.Application.Features.CQRS.Commands.OrderDetailCommands;
using MyAkademi_TakeAway.Application.Interfaces;
using MyAkademi_TakeAway.Domain.Entities;

namespace MyAkademi_TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
