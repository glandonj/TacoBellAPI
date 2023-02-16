using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/Drink
        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        //api/Drink/name?t=Water
        [HttpGet("name")]
        public Drink GetByTitle(string n)
        {
            return dbContext.Drinks.FirstOrDefault(d => d.Name.Contains(n));
        }

        //api/Drink?Id=6&Name=Regular%20Iced%20Coffee&Cost=1.79&Slushie=false
        [HttpPost]
        public Drink AddDrink(Drink d)
        {
            d.Id = 0;
            dbContext.Drinks.Add(d);
            dbContext.SaveChanges();
            return d;
        }
        //api/Drink?Id=2
        [HttpDelete]
        public Drink DeleteDrink(int Id)
        {
            Drink d = dbContext.Drinks.FirstOrDefault(d => d.Id == Id);
            dbContext.Drinks.Remove(d);
            dbContext.SaveChanges();
            return d;
        }
    }
}

