using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFInal.Models;
using System.Diagnostics;

namespace ProjetoFInal.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context; // Injeção de dependência do DbContext
    }

    public async Task<IActionResult> Index(DateTime? dataInicio, DateTime? dataFim)
    {
        // Inicia a consulta por todos os locais
        var query = _context.Local.AsQueryable();

        // Se datas foram informadas, filtra os locais
        if (dataInicio.HasValue && dataFim.HasValue)
        {
            // Lógica: Queremos locais que NÃO tenham NENHUMA reserva que se sobreponha ao período desejado.
            // Uma sobreposição ocorre se:
            // (Reserva.Inicio < Pesquisa.Fim) E (Reserva.Fim > Pesquisa.Inicio)
            query = query.Where(l => !_context.Reserva.Any(r =>
                r.LocalId == l.IdLocal &&
                r.DataInicio < dataFim.Value &&
                r.DataFim > dataInicio.Value
            ));

            // Passa as datas para a View para preencher o formulário e calcular o preço
            ViewBag.DataInicio = dataInicio.Value;
            ViewBag.DataFim = dataFim.Value;
        }

        var locaisDisponiveis = await query.ToListAsync();
        return View(locaisDisponiveis);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
