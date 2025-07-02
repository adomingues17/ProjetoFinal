using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;
using System.Security.Claims;

namespace ProjetoFinal.Controllers;

[Authorize]
public class ReservasController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ReservasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Create(int localId, DateTime dataInicio, DateTime dataFim)
    {
        var local = await _context.Local.FindAsync(localId);
        if (local == null) return NotFound();

        var reserva = new Reserva
        {
            LocalId = local.IdLocal,
            Local = local,
            DataInicio = dataInicio,
            DataFim = dataFim,
            ValorTotal = (decimal)(dataFim - dataInicio).TotalDays * local.PrecoPorNoite
        };
        return View(reserva);
    }

    // POST: /Reservas/Criar
    // Documentação: Salva a reserva no banco de dados.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CriarConfirmado(Reserva reserva)
    {
        // Re-validação de segurança para garantir que o local ainda está disponível
        var isDisponivel = !_context.Reserva.Any(r =>
            r.LocalId == reserva.LocalId &&
            r.DataInicio < reserva.DataFim &&
            r.DataFim > reserva.DataInicio);

        if (!isDisponivel)
        {
            TempData["Erro"] = "Desculpe, este local não está mais disponível para as datas selecionadas.";
            return RedirectToAction("Index", "Home");
        }

        // Pega o ID do usuário logado
        reserva.UsuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _context.Reserva.Add(reserva);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Sucesso));
    }

    // GET: Reservas/Sucesso
    public IActionResult Sucesso()
    {
        return View();
    }

    // GET: /Reservas
    // Documentação: Lista todas as reservas para o administrador.
    public async Task<IActionResult> Index()
    {
        var reservas = await _context.Reserva
            .Include(r => r.Local) // Inclui dados do Local relacionado
            .Include(r => r.Usuario) // Inclui dados do Usuário relacionado
            .OrderByDescending(r => r.DataInicio)
            .ToListAsync();

        return View(reservas);
    }

}
