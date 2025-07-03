using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /*
        // --- REGISTRO (GET) ---
        // Ação que exibe o formulário de registro.
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        */
        // --- REGISTRO (POST) ---
        // Ação que processa os dados do formulário de registro.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                // Crie o usuário APENAS UMA VEZ.
                var result = await _userManager.CreateAsync(user, model.Password);

                // Se a criação for bem-sucedida, execute a sequência correta.
                if (result.Succeeded)
                {
                    // 1. Adiciona o novo usuário ao papel "Colaborador".
                    await _userManager.AddToRoleAsync(user, "Colaborador");

                    // 2. Faz o login do usuário recém-criado.
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // 3. Redireciona para a página inicial.
                    return RedirectToAction("Index", "Home");
                }

                // Se a criação falhar, adicione os erros ao ModelState para exibi-los na view.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            // Se o ModelState não for válido, retorne a view com o modelo para que o usuário possa corrigir os dados.
            return View(model);
        }
        */
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
