using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkschopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkschopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var carWorshop = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Test",
                        Description = "Test",
                        ContactDetails = new()
                        {
                            City = "City",
                            PhoneNumber = "123456789",
                            PostalCode = "01-895",
                            Street = "street"
                        },
                        About = "Test",
                    };
                    carWorshop.EncodeName();
                    _dbContext.CarWorkshops.Add(carWorshop);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
