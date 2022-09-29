using Estacionamento.Database;
using Estacionamento.Helpers;
using Estacionamento.Models;
using Estacionamento.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Estacionamento.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        DataContext _Context;
        UserStore<AppUser> _UserStore;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _Context = context;
            _UserStore = new UserStore<AppUser>(_Context);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Conta bloqueada, tente mais tarde!");

                }
                ModelState.AddModelError("", "Usuario ou senha invalidos");
            }
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(UserHelper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(UserHelper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(UserHelper.User));
                await _roleManager.CreateAsync(new IdentityRole(UserHelper.Gerente));
                await _roleManager.CreateAsync(new IdentityRole(UserHelper.Funcionario));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new AppUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            if (!result.Succeeded) ModelState.AddModelError("WeakPassword", "Sua senha deve conter letras maiusculas, minusculas, numeros e caracteres especiais");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> newAdmin(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new AppUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> NovoFuncionario(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new AppUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult FogotPassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FogotPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Index", "Home");
                var code = _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPwd", "Account", new { userId = user.Id, code = code.Result }, protocol: HttpContext.Request.Scheme);
                if(callbackurl == null) return RedirectToAction("Index", "Home");
                return Redirect(callbackurl);
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ResetPwd(string? code)
        {
            return code == null ? RedirectToAction("Index", "Home"): View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPwd(ResetPwdVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Index", "Home");
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded) return RedirectToAction("Login");
                foreach(var error in result.Errors) ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Index", "Home");
        }

    }

}

