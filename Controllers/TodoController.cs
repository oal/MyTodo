using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTodo
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext db;

        public TodoController(ApplicationDbContext db) {
            this.db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return db.Todos.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Todo Post([FromBody]Todo todo)
        {
            db.Todos.Add(todo);
            db.SaveChanges();

            return todo;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo todo)
        {
            db.Todos.Update(todo);
            db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
