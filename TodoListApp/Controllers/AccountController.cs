using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if (await _accountService.CheckIfUserWithNameExist(registerUserDTO.Name))
            {
                ViewBag.UserJustExists = true;
                return View(registerUserDTO);
            }

            await _accountService.CreateUserInDatabase(registerUserDTO);
            return RedirectToAction("Index", "Home");
        }
    }
}
