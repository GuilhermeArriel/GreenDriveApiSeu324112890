using Microsoft.AspNetCore.Mvc;
using GreenDriveApi.Data;
using GreenDriveApi.Models;

namespace GreenDriveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BateriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BateriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Bateria bateria)
        {
            _context.Baterias.Add(bateria);
            _context.SaveChanges();
            return Ok(bateria);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Baterias.ToList());
        }
    }
}