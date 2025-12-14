using FitnessCenter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Controllers;

[ApiController]
[Route("api/trainers")]
public class TrainersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public TrainersController(ApplicationDbContext db) => _db = db;

    // GET: /api/trainers
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.Antrenorler.AsNoTracking().ToListAsync());

    // GET: /api/trainers/available?date=2025-12-15
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable([FromQuery] DateTime date)
    {
        var dateStr = date.ToString("yyyy-MM-dd");
        var result = await _db.Antrenorler.AsNoTracking()
            .Where(a => a.MusaitlikSaatleri.Any(s => s.StartsWith(dateStr)))
            .ToListAsync();

        return Ok(result);
    }
}
