using Microsoft.AspNetCore.Authorization;
using RestaurantApi.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        PageResult<RestaurantDto> GetAll(RestaurantQuery query);
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Update(int id, EditRestaurantDto dto);
    }
}