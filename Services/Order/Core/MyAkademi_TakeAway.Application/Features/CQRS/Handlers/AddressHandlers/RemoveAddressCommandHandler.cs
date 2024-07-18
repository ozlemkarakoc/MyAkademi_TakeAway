using MyAkademi_TakeAway.Application.Features.CQRS.Commands.AddressCommands;
using MyAkademi_TakeAway.Application.Interfaces;
using MyAkademi_TakeAway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademi_TakeAway.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
