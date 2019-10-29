using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AireLogicBugTrackingApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace AireLogicBugTrackingApi.Controllers
{
    [Route("api/[controller]")]
    public class BugsController : Controller
    {
        protected ApplicationDbContext DbContext;
   

        public BugsController(ApplicationDbContext context)
        {
            DbContext = context;  
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbContext.Database.EnsureCreated();
            return Ok(DbContext.Bugs.ToList());
        }

        [HttpGet("OpenBugs")]
        public IActionResult OpenBugs()
        {
            DbContext.Database.EnsureCreated();
            return Ok(DbContext.Bugs.Where(b => b.IsOpen ==true));
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            DbContext.Database.EnsureCreated();
            return Ok(DbContext.Bugs.FirstOrDefault(b => b.BugId == id));
               
        }

        [HttpPost]
        public IActionResult Post([FromBody]BugsModel value)
        {
            try
            {
                value.Author = new UserModel { };
                DbContext.Database.EnsureCreated();
                DbContext.Bugs.Add(value);
                DbContext.SaveChanges();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.ToString());
                return StatusCode(500);
            }
            return Accepted();
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DbContext.Bugs.Remove(DbContext.Bugs.Single(c => c.BugId == id));
            DbContext.SaveChanges();
        }
    }
}
