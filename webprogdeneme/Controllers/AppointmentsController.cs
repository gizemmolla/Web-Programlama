using FitnessCenter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public AppointmentsController(ApplicationDbContext db) => _db = db;

    // GET: /api/appointments/by-member/1
    [HttpGet("by-member/{memberId:int}")]
    public async Task<IActionResult> GetByMember([FromRoute] int memberId)
    {
        var list = await _db.Randevular.AsNoTracking()
            .Where(r => r.UyeId == memberId)
            .OrderByDescending(r => r.Baslangic)
            .ToListAsync();
        return Ok(list);
    }
}
