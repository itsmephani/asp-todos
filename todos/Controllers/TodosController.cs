using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using todos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todos.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private TodosContext _context {get; set;}

        public TodosController() {
            _context = new TodosContext();
        }

        // GET: api/todos
        [HttpGet]
        public IActionResult Get() {
            return Ok(_context.Todos.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            if (!ModelState.IsValid)
            {
                //throw new InvalidOperationException("Invalid");
                return BadRequest(ModelState);
            }

            var createdTodo = _context.Todos.Add(new Todo {
                Description = todo.Description, 
                IsDone = todo.IsDone
            });
            _context.SaveChanges();

            return CreatedAtAction("Post", createdTodo);
        }

        // PUT api/todos/{id}
        [HttpPut("{id=int}")]
        public IActionResult Put(int id, [FromBody]Todo todo)
        {
            var updatedTodo = _context.Todos.Update(new Todo
            {
                Id = todo.Id,
                Description = todo.Description,
                IsDone = todo.IsDone
            });
            _context.SaveChanges();

            // Different name from action name in first argument throwing
            // no route found error.
            return CreatedAtAction("Put", updatedTodo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Todos.Remove(_context.Todos.Find(id));
            _context.SaveChanges();

            return CreatedAtAction("Delete", new { mesasge = "Todo removed Successfully"});
        }
    }
}
