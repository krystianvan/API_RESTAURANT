using RestaurantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var role = GetRoles();
                    _dbContext.Roles.AddRange(role);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name= "KFC",
                    Category = "Fast Food",
                    Description="OPISSSS",
                    ContactEmail="kfc@kurczak.com",
                    HasDelivery=true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "KURCZOTK OGIN",
                            Price = 10,
                        },
                        new Dish()
                        {
                            Name = "KURCZOTK Lagodny",
                            Price = 11,
                        },
                    },
                    Address = new Address()
                    {
                        City="ZAGOROW",
                        Street="Dluga",
                        PostalCode="30-301"
                    }
                },
                 new Restaurant()
                {
                    Name= "MAC",
                    Category = "Fast Food",
                    Description="sips",
                    ContactEmail="mac@kurczak.com",
                    HasDelivery=true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "burger OGIN",
                            Price = 10,
                        },
                        new Dish()
                        {
                            Name = "burger Lagodny",
                            Price = 11,
                        },
                    },
                    Address = new Address()
                    {
                        City="ZAGOROW",
                        Street="Krotka",
                        PostalCode="30-301"
                    }
                },

            };
            return restaurants;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name= "User",
                },
                new Role()
                {
                    Name= "Manager",
                },
                new Role()
                {
                    Name= "Administrator",
                },
            };
            return roles;

        }
    }
}
