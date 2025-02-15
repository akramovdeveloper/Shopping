﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ApiBaseController
    {

        

  
        

        [HttpGet("/routes")]
        public async Task<string> getRoutes(IEnumerable<EndpointDataSource> endpointSources)
        {
           string result = string.Join("\n", endpointSources.SelectMany(source => source.Endpoints));
            return await Task.FromResult(result);
        }
      


        [Authorize]
        [HttpGet("/productPage.html")]
       
        public async Task<ContentResult> ProductPage()
        {

            string webrootpath = _hostEnviroment.WebRootPath;
            string path =  Path.Combine(webrootpath, "productPage.html");
            var html = System.IO.File.ReadAllText(path);
            
            return new ContentResult { Content = html , ContentType = "text/html",StatusCode=200};

        }

        [Authorize]
        [HttpGet("/checkoutlist.html")]
        public async Task<IActionResult> CheckoutList()
        {
            string webrootpath = _hostEnviroment.WebRootPath;
            string path = Path.Combine(webrootpath, "checkoutlist.html");
            var html = System.IO.File.ReadAllText(path);

            return new ContentResult { Content = html, ContentType = "text/html", StatusCode = 200 };
        }

        [Authorize]
        [HttpGet("/userpage.html")]
        public async Task<IActionResult> UserPage()
        {
            string webrootpath = _hostEnviroment.WebRootPath;
            string path = Path.Combine(webrootpath, "userpage.html");
            var html = System.IO.File.ReadAllText(path);

            return new ContentResult { Content = html, ContentType = "text/html", StatusCode = 200 };
        }

        // [Authorize]
        [AllowAnonymous]
        [HttpGet("/swagger/index.html")]
        public async Task<IActionResult> SwaggerPage()
        {
            return await Task.FromResult(Redirect("/swagger/index.html"));
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            var context = HttpContext;
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
            
        
        }
        

    }
}
