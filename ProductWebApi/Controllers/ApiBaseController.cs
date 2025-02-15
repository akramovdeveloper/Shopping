﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProductWebApi.Attributes;
using Shopping.Application.Interfaces;

namespace ProductWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[CustomException]
public class ApiBaseController : Controller
{ 
    protected  ICategoryService _categoryService
       => HttpContext.RequestServices.GetRequiredService<ICategoryService>();
    
    protected  IMapper _mapper
        => HttpContext.RequestServices.GetRequiredService<IMapper>();
    protected  IUserService _userService 
        => HttpContext.RequestServices.GetRequiredService<IUserService>();
    protected IWebHostEnvironment _hostEnviroment 
        => HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

    protected IPermissionService _permissionService 
        => HttpContext.RequestServices.GetRequiredService<IPermissionService>();
    protected IProductService _productService 
        => HttpContext.RequestServices.GetRequiredService<IProductService>();
    protected IRoleService _roleService 
        => HttpContext.RequestServices.GetRequiredService<IRoleService>();

   
    protected IOrderRepository _orderRepository 
        => HttpContext.RequestServices.GetRequiredService<IOrderRepository>();
   
    protected ICartItemService _cartItemService 
        => HttpContext.RequestServices.GetRequiredService<ICartItemService>();

    protected IHashStringService _hashStringService
        => HttpContext.RequestServices.GetRequiredService<IHashStringService>();
}

