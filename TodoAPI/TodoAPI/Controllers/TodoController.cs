using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count() <= 0)
            {
                _context.TodoItems.Add(new TodoItem { userId = 1, content = "test", createTime = DateTime.Now });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("GetByTipId/{tipId}", Name = "GetByTipId")]
        public TodoItem GetByTipID(int tipId)
        {

            return _context.TodoItems.FirstOrDefault(val => val.tipId == tipId);
        }

        [HttpGet("GetByUserId/{userId}", Name = "GetByUserId")]
        public IEnumerable<TodoItem> GetByUserID(int userId)
        {
            return _context.TodoItems.Where(val => val.userId == userId);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            var ret = CreatedAtRoute("GetByTipId", new { tipId = item.tipId }, item);
            Debug.WriteLine($"gg :{ret.GetType()}");
            return ret;
        }
    }
}
