using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Controllers;

[Authorize(Roles = "Admin")] // Apenas administradores podem acessar este controller
public class UsersController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // ... outras actions para listar usuários

    [HttpPost]
    public async Task<IActionResult> AddToRole(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
        // Redirecionar para a página de gerenciamento do usuário
        return RedirectToAction("ManageUserRoles", new { id = userId });
    }

    public IActionResult Index()
    {
        return View();
    }

}