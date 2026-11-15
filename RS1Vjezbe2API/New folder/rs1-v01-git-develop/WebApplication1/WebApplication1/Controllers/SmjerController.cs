using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmjerController(AppDbContext db) : Controller
    {

        [HttpGet]
        public async Task<List<Smjer>> GetAll(CancellationToken ct)
        {
            IQueryable<Smjer> upit = db.Smjerovi;
            return await upit.OrderBy(x => x.Naziv).Select(x => new Smjer
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).ToListAsync(ct);
        }
    }
}
