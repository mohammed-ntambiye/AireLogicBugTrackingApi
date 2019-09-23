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
    public class AccountsController : Controller
    {

        protected ApplicationDbContext DbContext;

        public AccountsController(ApplicationDbContext context)
        {
            DbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbContext.Database.EnsureCreated();
            return Ok(DbContext.Users.ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            return Ok(DbContext.Users.FirstOrDefault(b => b.UserId == id));

        }

        [HttpPost]
        public IActionResult Post([FromBody]UserModel value)
        {
            try
            {
                DbContext.Database.EnsureCreated();
                DbContext.Users.Add(value);
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

        }
    }
}