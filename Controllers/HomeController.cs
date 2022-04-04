using AirTiquiciaTry.Models;
using AirTiquiciaTry.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AirTiquiciaTry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> ValidarUsuario(string username, string password, string returnUrl)
        {
            LoginDAO usuarios = new LoginDAO();
            UsuariosModel usuarioValidado = usuarios.ValidateCredentials(username, password);
            if (usuarioValidado != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", usuarioValidado.username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuarioValidado.username));
                claims.Add(new Claim(ClaimTypes.Name, usuarioValidado.nombre));
                claims.Add(new Claim(ClaimTypes.Email, usuarioValidado.email));
                claims.Add(new Claim(ClaimTypes.Role, usuarioValidado.rol));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    bool sirveONo = User.IsInRole("admin");
                if (usuarioValidado.rol == "admin")
                    {
                        ViewData["isAdmin"] = "yes";
                        return Redirect("/Admin/Index");
                    }
                    else {
                        return Redirect("/Home/Index");
                    }
                }
            }
            TempData["Error"] = "Error. Usuario o contraseña incorrectos";
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        { 
        await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}