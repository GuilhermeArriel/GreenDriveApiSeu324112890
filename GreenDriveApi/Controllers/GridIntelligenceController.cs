using Microsoft.AspNetCore.Mvc;
using GreenDriveApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenDriveApi.Controllers
{
    [ApiController]
    [Route("api/intelligence")]
    public class GridIntelligenceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GridIntelligenceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("carbon-footprint")]
        public async Task<IActionResult> GetCarbonFootprint()
        {
            // Simulação de latência (3 segundos)
            await Task.Delay(3000);

            var resultado = await _context.OrdensReciclagem
                .Include(o => o.EstacaoCarga)
                .GroupBy(o => o.EstacaoCarga!.Localizacao)
                .Select(g => new
                {
                    Cidade = g.Key,
                    CustoTotal = g.Sum(x => x.CustoProcessamento)
                })
                .ToListAsync();

            return Ok(resultado);
        }
    }
}