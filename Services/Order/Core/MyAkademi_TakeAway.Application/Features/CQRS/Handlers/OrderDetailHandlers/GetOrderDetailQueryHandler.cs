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
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                Amount = x.Amount,
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TotalPrice = x.TotalPrice
            }).ToList();
        }
    }
}
