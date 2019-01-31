using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Common.Models;

namespace TodoApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepo;

        public TodoController(ITodoRepository repo)
        {
            _todoRepo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            try
            {
                var resultToReturn = await _todoRepo.GetAllTodos();
                return new ObjectResult(resultToReturn);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(long id)
        {
            var resultToReturn =  await _todoRepo.GetTodo(id);
            if (resultToReturn == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(resultToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Create([FromBody]Todo todoToCreate)
        {
            try
            {
                todoToCreate.Id = await _todoRepo.GetNextId();
                await _todoRepo.Create(todoToCreate);
                return new OkObjectResult(todoToCreate);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Update(long id, [FromBody]Todo todo)
        {
            try
            {
                var todoInDb = await _todoRepo.GetTodo(id);
                if (todoInDb == null)
                {
                    return NotFound();
                }
                todo.Id = todoInDb.Id;
                todo.IntenalId = todoInDb.IntenalId;
                await _todoRepo.Update(todo);
                return new OkObjectResult(todo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var todoInDb = await _todoRepo.GetTodo(id);
                if (todoInDb == null)
                {
                    return NotFound();
                }
                await _todoRepo.Delete(id);
                return new OkResult();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}

