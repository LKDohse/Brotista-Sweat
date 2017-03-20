using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BTS.API.Proxy;
using BTS.API.Models;

namespace BTS.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassesController : Controller
    {
        ClassProxy classProxy = new ClassProxy(); 
        // GET api/values
        [HttpGet]
        public async Task<List<ClassApiModel>> Get()
        {
            var result = await classProxy.GetAllClasses();

            return result;  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
