using AntuchovGindulina.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Utilities.Encoders;
using System.Security.Claims;

namespace AntuchovGindulina.Pages
{
    public class AuthModel : BagePageModel
    {
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string? returnUrl) 
        {
            var form = HttpContext.Request.Form;
            if (!form.ContainsKey("Login") || !form.ContainsKey("Pass"))
                return BadRequest("Email и/или пароль не установлены");

            string login = form["Login"];
            string password = form["Pass"];

            var db = new MydbContext();
            Employee? emplo = db.Employees.FirstOrDefault(s => s.Login == login && s.Password == password);

            if (emplo is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, emplo.Login) };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(returnUrl ?? "/");

        }
    }

}
