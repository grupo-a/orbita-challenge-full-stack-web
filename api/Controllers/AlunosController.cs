using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{

    private readonly AlunoContext _context;

    public AlunosController(AlunoContext context)
    {
        _context = context;
        System.Console.WriteLine("Controller");
    }

    [HttpGet]
    public ActionResult<List<Aluno>> GetAlunos()
    {
        return _context.Alunos.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Aluno>> AddAluno(Aluno aluno)
    {
        if (CpfAlunoExists(aluno.Cpf))
        {
            ModelState.AddModelError(nameof(Aluno.Cpf), "O cpf informado já está cadastrado");
            return ValidationProblem();
        }

        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAluno", new { RA = aluno.RA }, aluno);
    }

    [HttpPut("{ra}")]
    public async Task<ActionResult<Aluno>> UpdateAluno(int ra, Aluno aluno)
    {
        if (ra != aluno.RA)
        {
            return BadRequest();
        }

        _context.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoExists(ra))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{ra}")]
    public async Task<IActionResult> DeleteAluno(int ra)
    {
        if (_context.Alunos == null)
        {
            return NotFound();
        }
        var aluno = await _context.Alunos.FindAsync(ra);
        if (aluno == null)
        {
            return NotFound();
        }

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CpfAlunoExists(string cpf)
    {
        return _context.Alunos.Any(aluno => aluno.Cpf == cpf);
    }

    private bool AlunoExists(int ra)
    {
        return _context.Alunos.Any(aluno => aluno.RA == ra);
    }
}