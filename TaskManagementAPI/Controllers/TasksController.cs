using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskManagementAPI.Models.Task>>> GetTasks()
    {
        return await _context.Tasks.Include(t => t.Documents).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskManagementAPI.Models.Task>> GetTask(int id)
    {
        var task = await _context.Tasks.Include(t => t.Documents).FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    [HttpPost]
    public async Task<ActionResult<TaskManagementAPI.Models.Task>> PostTask(TaskManagementAPI.Models.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, TaskManagementAPI.Models.Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TaskExists(int id)
    {
        return _context.Tasks.Any(t => t.Id == id);
    }

}
