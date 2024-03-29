﻿using Application.FoodDelivery.DTO;

namespace Application.FoodDelivery.UseCaseContracts
{
    public interface IGetAllProductsUseCase
    {
        Task<ProductsResponse> Execute();
    }
}
