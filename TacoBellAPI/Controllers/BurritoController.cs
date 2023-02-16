using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class BurritoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/Burrito
        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        //api/Burrito/Bean
        [HttpGet("Bean")]
        public List<Burrito> GetBean(bool beans)
        {
            return dbContext.Burritos.Where(b => b.Bean == beans).ToList();
        }

        //api/Burrito?Id=100&Name=Cheesy%20Bean%20and%20Rice%20Burrito&Cost=1.00&Bean=true
        [HttpPost]
        public Burrito AddBurrito(Burrito b)
        {
            b.Id = 0;
            dbContext.Burritos.Add(b);
            dbContext.SaveChanges();
            return b;
        }

        //api/Burrito?name=Burrito%20Supreme&Bean=true
        [HttpPut]
        public Burrito UpdateBurrito(string name, bool Bean)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Name == name);
            b.Bean = Bean;
            dbContext.Burritos.Update(b);
            dbContext.SaveChanges();
            return b;
        }
    }
}

