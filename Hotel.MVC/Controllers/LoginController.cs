using AutoMapper;
using Hotel.MVC.DTO;
using Hotel.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Otel.Entity.Authentication;

namespace Hotel.MVC.Controllers
{
    public class LoginController : Controller
    {


        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;

        public LoginController(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            LoginDTO loginDTO = new();
            return View(loginDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Wrong Password or Email Adress");
                return View(loginDTO);
            }

            AppUser? user = await userManager.FindByEmailAsync(loginDTO.Email);

            bool IsAdmin = false;
            bool IsMember = false;

            if (user != null)
            {
                List<string> roles = (List<string>)await userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (role == "Admin")
                    {
                        IsAdmin = true;
                    }
                    else
                    {
                        IsMember = true;
                    }
                }




                var result = await signInManager.PasswordSignInAsync(user, loginDTO.Password, true, true);

                if (result.Succeeded)
                {
                    if (IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "AdminArea" });
                    }
                    else if (IsMember)
                    {
                        return RedirectToAction("Index", "Home");

                        //return RedirectToAction("Index", "Home", new { Area = "MembersArea" });
                    }
                }
            }
            ModelState.AddModelError("", "Email yada sifre hatalidir");
            return View(loginDTO);
        }


        public async Task<IActionResult> Register()
        {
            UserCreateDTO createDTO = new();
            return View(createDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var user = mapper.Map<AppUser>(createDTO);

            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Bilgileri Duzgun Giriniz");
            //    return View(createDTO);

            //}

            //var result = await userManager.CreateAsync(user, createDTO.Password);
            //var rolresult = await userManager.AddToRoleAsync(user, "User");
            //if (result.Succeeded)
            //{
            //    // Gonderilecek email icerisnde Token gereklidir. Bunu da buradan aliyoruz
            //    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

            //    string mesaj = $@"<html>
            //                        <head>
            //                            <meta charset='UTF-8'/>
            //                    </head>
            //                     <body>
            //                        <p> Merhaba {user.UserName} </p>
            //                        <p> Uyelik islemlerini tamamlamak icin asaðýdaki linki tiklayin </p>
            //                    <a href='http://localhost:5068/Login/ConfirmEmail?uid={user.Id}&code={code}'> Onaylayin</a>

            //                     </body>
            //                     </html>
            //                       ";
            //    EmailHelper emailHelper = new EmailHelper();
            //    bool sonuc = emailHelper.SendEmail(user.Email, mesaj);
            //    if (sonuc)
            //    {
            //        return RedirectToAction("Login", "Login");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Mail Gonderiminde hata olustu");
            //        return View(createDTO);
            //    }

            //}



            //return View(createDTO);

            AppUser user = mapper.Map<AppUser>(registerDTO);
            user.UserName = registerDTO.Email;

            //user.LockoutEnabled = true;
            //user.AccessFailedCount = 5;

            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {

                var userRole = await roleManager.FindByNameAsync("User");
                if (userRole == null)
                {
                    userRole = new AppRole();
                    userRole.Name = "User";
                    await roleManager.CreateAsync(userRole);

                }
                await userManager.AddToRoleAsync(user, userRole.Name);


                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("", "Kayıt Başarısız");
            return View(registerDTO);
        
    }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
