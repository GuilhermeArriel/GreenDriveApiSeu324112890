using Microsoft.AspNetCore.Mvc;
using GreenDriveApi.Data;
using GreenDriveApi.Models;

namespace GreenDriveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroTelemetriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistroTelemetriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(RegistroTelemetria registro)
        {
            var bateria = _context.Baterias.Find(registro.BateriaId);

            if (bateria == null)
                return BadRequest("Bateria não encontrada.");

            // REGRA
            if (registro.Temperatura > 85)
            {
                Console.WriteLine($"ALERTA DE SEGURANÇA: Risco térmico detectado na bateria {bateria.NumeroSerie}!");
                return BadRequest("Temperatura acima do limite permitido.");
            }

            _context.RegistrosTelemetria.Add(registro);
            _context.SaveChanges();

            return Ok(registro);
        }
    }
}