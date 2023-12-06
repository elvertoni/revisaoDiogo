using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("api/livro")]
public class LivroController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public LivroController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    //GET: api/livro/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Livro> livros =
                _ctx.Livros
                .Include(x => x.Genero)
                .ToList();
            return livros.Count == 0 ? NotFound() : Ok(livros);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Livro livro)
    {
        try
        {
            Genero? genero =
                _ctx.Generos.Find(livro.GeneroId);
            if (genero == null)
            {
                return NotFound();
            }
            livro.Genero = genero;
            _ctx.Livros.Add(livro);
            _ctx.SaveChanges();
            return Created("", livro);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public IActionResult Buscar([FromRoute] int id)
    {
        try
        {
            Livro? livroCadastrado =
                _ctx.Livros
                .Include(x => x.Genero)
                .FirstOrDefault(x => x.LivroId == id);
            if (livroCadastrado != null)
            {
                return Ok(livroCadastrado);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Livro? livroCadastrado = _ctx.Livros.Find(id);
            if (livroCadastrado != null)
            {
                _ctx.Livros.Remove(livroCadastrado);
                _ctx.SaveChanges();
                return Ok(_ctx.Livros
                .Include(x => x.Genero)
                .ToList());
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id,
        [FromBody] Livro livro)
    {
        try
        {
            //Expressões lambda
            Livro? livroCadastrado =
                _ctx.Livros.FirstOrDefault(x => x.LivroId == id);

            if (livroCadastrado != null)
            {

                Genero? genero =
                    _ctx.Generos.Find(livro.GeneroId);
                if (genero == null)
                {
                    return NotFound();
                }
                livroCadastrado.Genero = genero;
                livroCadastrado.Nome = livro.Nome;
                livroCadastrado.Descricao = livro.Descricao;
                livroCadastrado.Quantidade = livro.Quantidade;
                livroCadastrado.Preco = livro.Preco;
                _ctx.Livros.Update(livroCadastrado);
                _ctx.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}