using AppointmentManagement.UI.DTOs;
using AutoMapper;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CivilManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Vendor");

            return View(_mapper.Map<IList<AppUserListDto>>(users));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserDto appUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(appUserDto);
                user.UserName = appUserDto.Email;

                user.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appUserDto.FirstName.ToLower());
                user.LastName =  appUserDto.LastName.ToUpper();

                var result = await _userManager.CreateAsync(user, appUserDto.Password);

                if (result.Succeeded)
                {
                    if (appUserDto.Role == "Vendor")
                    {
                        await _userManager.AddToRoleAsync(user, "Vendor");
                    }
                    TempData["Message"] = "Kayıt başarıyla oluşturulmıştur";

                    return RedirectToAction("Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(appUserDto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return View(_mapper.Map<AppUserEditDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUserEditDto appUserEditDto)
        {
            ModelState.Remove("PasswordNew");
            ModelState.Remove("PasswordConfirm");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(appUserEditDto.Id);

                if (user.PhoneNumber != appUserEditDto.PhoneNumber)
                {
                    if (_userManager.Users.Any(x => x.PhoneNumber == appUserEditDto.PhoneNumber))
                    {
                        ModelState.AddModelError("PhoneNumber", "Sisteme kayıtlı telefon numarası girdiniz");
                        return View();
                    }
                }
               
              

                user.UserName = appUserEditDto.UserName;
                user.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appUserEditDto.FirstName.ToLower()); ;
                user.LastName = appUserEditDto.LastName.ToUpper(); ;
                user.VendorCode = appUserEditDto.VendorCode;
                user.VendorDescription = appUserEditDto.VendorDescription;
                user.Email = appUserEditDto.Email;
                user.IsLocked = appUserEditDto.IsLocked;
                user.PhoneNumber = appUserEditDto.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (appUserEditDto.PasswordNew != null)
                    {
                        var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                        await VendorPasswordChange(user, passwordResetToken, appUserEditDto.PasswordNew);
                    }
                    await _userManager.UpdateSecurityStampAsync(user);

                    TempData["Message"] = "Kayıt başarıyla güncellenmiştir";
                    return View(appUserEditDto);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(appUserEditDto);
        }

        public async Task VendorPasswordChange(AppUser user, string token, string password)
        {
            await _userManager.ResetPasswordAsync(user, token, password);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user != null)
                {
                    if (user.IsLocked)
                    {
                        await _signInManager.SignOutAsync();

                        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, false);

                        if (result.Succeeded)
                        {
                            var role = await _userManager.GetRolesAsync(user);
                            
                            if (role.Contains("Vendor"))
                            {
                                return RedirectToAction("Index", "Vendor");
                            }
                            else if (role.Contains("Secretary"))
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalıdır.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcınız kapatılmıştır");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                }
                
            }


            return View(loginDto);
        }

        public IActionResult Denied()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}