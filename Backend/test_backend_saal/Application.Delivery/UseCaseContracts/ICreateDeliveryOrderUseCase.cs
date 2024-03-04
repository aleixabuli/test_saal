using Application.FoodDelivery.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoodDelivery.UseCaseContracts
{
    public interface ICreateDeliveryOrderUseCase
    {
        Task<int> Execute(CreateDeliveryOrderInput createDeliveryOrderInput);
    }
}
