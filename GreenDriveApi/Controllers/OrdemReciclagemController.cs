using Microsoft.AspNetCore.Mvc;
using GreenDriveApi.Data;
using GreenDriveApi.Models;

namespace GreenDriveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemReciclagemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdemReciclagemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(OrdemReciclagem ordem)
        {
            var bateria = _context.Baterias.Find(ordem.BateriaId);
            var estacao = _context.EstacoesCarga.Find(ordem.EstacaoId);

            if (bateria == null || estacao == null)
                return BadRequest("Bateria ou Estação inválida.");

            // REGRA SoH > 60
            if (bateria.SaudeBateria > 60)
            {
                return BadRequest("Bateria com saúde superior a 60%. Use Second Life.");
            }

            // 💸 REGRA TAXA AMBIENTAL
            if (estacao.TipoCarga == "Ultra-Rapida")
            {
                ordem.CustoProcessamento += 250;
            }

            _context.OrdensReciclagem.Add(ordem);
            _context.SaveChanges();

            return Ok(ordem);
        }
    }
}