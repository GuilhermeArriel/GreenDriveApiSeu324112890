using Microsoft.AspNetCore.Mvc;
using GreenDriveApi.Data;
using GreenDriveApi.Models;

namespace GreenDriveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacaoCargaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstacaoCargaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(EstacaoCarga estacao)
        {
            _context.EstacoesCarga.Add(estacao);
            _context.SaveChanges();
            return Ok(estacao);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.EstacoesCarga.ToList());
        }
    }
}