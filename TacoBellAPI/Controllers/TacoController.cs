using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/Taco
        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }
        //ANY CHANGES TO DB (ADDING OR UPDATING) DON'T FORGET TO dbContext.SaveChanges()

        //api/Taco/SoftShell
        [HttpGet("SoftShell")]
        public List<Taco> GetSoftShell(bool soft)
        {
            return dbContext.Tacos.Where(t => t.SoftShell == soft).ToList();
        }

        //api/Taco/Cost
        [HttpGet("Cost")]
        public List<Taco> GetByCost(float cost)
        {
            return dbContext.Tacos.Where(c => c.Cost <= cost).ToList();
        }
    }
}

