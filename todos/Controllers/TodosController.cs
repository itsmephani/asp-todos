using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todos.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        // GET: api/todos
        [HttpGet]
        public IActionResult Get() {
            using (var context = new TodosContext())
            {
                return Ok(context.Todos.ToList());
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            if (!ModelState.IsValid) {
                //throw new InvalidOperationException("Invalid");
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new {id = todo.Id}, todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo todo)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Todo {
        public int Id { get; set; }

        [MinLength(10)]
        public string Text { get; set; }
    }
}
