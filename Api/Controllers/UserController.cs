using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Api.Service;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task CreateUser(CreateUserModel model) => await _userService.createUser(model);
      
        [HttpGet]
       public async Task <List<UserModel>> GetUser() => await _userService.GetUser();
        
            
     }
}
