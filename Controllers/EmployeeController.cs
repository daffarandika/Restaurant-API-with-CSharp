using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly LatihanLksKabContext _context;

        public EmployeeController(LatihanLksKabContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAt(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employee request)
        {
            _context.Employees.Add(request);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpPut]
        public async Task<IActionResult> Put(Employee request)
        {
            int id = request.Employeeid;
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return BadRequest("Menu not found.");
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Password = request.Password;
            employee.Handphone = request.Handphone;
            employee.Position = request.Position;

            await _context.SaveChangesAsync();

            return Ok("success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("employee not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok("success");
        }
    }
}
