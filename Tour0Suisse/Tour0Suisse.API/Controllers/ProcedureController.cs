using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour0Suisse.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tour0Suisse.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        static private DBTour0SuisseLINQ DB_CURD;

        static  ProcedureController()
        {
            string ConnectionString =
                "Server=DESKTOP-BNVQBMF;Database=Tour0Suisse;user id=API_User;password=1234@Test;";

            DB_CURD = new DBTour0SuisseLINQ(ConnectionString);
        }

        // POST: api/<ProcedureController>/login/Email/Password
        [HttpPost]
        public int LogIN(string Email, string Password)
        {
            return DB_CURD.LogIn(Email, Password); ;
        }

        //// GET api/<ProcedureController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProcedureController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProcedureController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProcedureController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
