using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;
using RestaurantApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]

    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        //[Authorize(Policy = "CreatedAtLeast2Restaurants")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery]RestaurantQuery query)
        {
            var restaurantsDtos = _restaurantService.GetAll(query);

            return Ok(restaurantsDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            //Nie potrzebujemy poniewaz zastepuje to api controller
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            
            var id = _restaurantService.Create(dto);

            return Created($"api/restaurant/{id}", null);
        }



        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RestaurantDto>> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<RestaurantDto>> Delete([FromRoute] int id)
        {
             _restaurantService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] EditRestaurantDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
           _restaurantService.Update(id, dto);
            
            
                return Ok();
            
        }
    }
}
