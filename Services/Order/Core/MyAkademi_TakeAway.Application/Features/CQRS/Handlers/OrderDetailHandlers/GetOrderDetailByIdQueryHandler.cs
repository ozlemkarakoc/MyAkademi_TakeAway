using MyAkademi_TakeAway.Application.Features.CQRS.Queries.OrderDetailQuries;
using MyAkademi_TakeAway.Application.Features.CQRS.Results.OrderDetailResult;
using MyAkademi_TakeAway.Application.Interfaces;
using MyAkademi_TakeAway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademi_TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrdetDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrdetDetailByIdQueryResult
            {
                Amount = values.Amount,
                OrderDetailId = values.OrderDetailId,
                Ordering = values.Ordering,
                Price = values.Price,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                TotalPrice = values.TotalPrice
            };
        }
    }
}
