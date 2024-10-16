using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Annotations;
[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;
    public TodoController(TodoContext context)
    {
        _context = context;
    }


    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        // Get items
        var todos = _context.Todos;
        return await todos.ToListAsync();
    }
    // GET: api/todo/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _context.Todos.SingleOrDefaultAsync(t => t.Id == id);

        if (todo == null)
            return NotFound();

        return todo;
    }
    // POST: api/item
    [HttpPost]
    [SwaggerOperation(Summary = "Get an item by id", Description = "Returns a specific item targeted by its identifier")]

    public async Task<ActionResult<Todo>> PostTodo(string title, bool isComplete)
    {
        var todo = new Todo(title, isComplete, DateTime.Now);

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }
    // PUT: api/item/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(int id, Todo item)
    {
        if (id != item.Id)
            return BadRequest();


        _context.Entry(item).State = EntityState.Modified;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Todos.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }


        return NoContent();
    }

    // DELETE: api/item/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var todo = await _context.Todos.FindAsync(id);


        if (todo == null)
            return NotFound();


        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();


        return NoContent();
    }






}
