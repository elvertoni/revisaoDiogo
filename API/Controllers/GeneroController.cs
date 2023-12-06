namespace API.Controllers;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

[ApiController]
[Route("api/genero")]
public class GeneroController : ControllerBase
{
    private readonly AppDataContext _context;

    public GeneroController(AppDataContext context)
    {
        _context = context;
    }

    // GET: api/genero/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Genero> generos = _context.Generos.ToList();
            return Ok(generos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/genero/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Genero genero)
    {
        try
        {
            _context.Add(genero);
            _context.SaveChanges();
            return Created("", genero);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}