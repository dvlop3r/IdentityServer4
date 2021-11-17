using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("identity")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Employee> Get()
        {
            //return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
            var employees= new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Sarwan Hakm",
                    Position="Dotnet Developer"
                },
                new Employee
                {
                    Id=2,
                    Name="Sarwan Hakm",
                    Position="Api Developer"
                },
                new Employee
                {
                    Id=3,
                    Name="Sarwan Hakm",
                    Position="C# Developer"
                }
            };
            return Ok(employees);
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
