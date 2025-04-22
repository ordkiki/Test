using Microsoft.AspNetCore.Mvc;
using Test.model.dto;
using Test.model.entities;
using Test.repository;


namespace Test.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
   
    private readonly IUserRepository _userRep ;
    public UserController(IUserRepository userRepository)
    {
        _userRep = userRepository;
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<User>> Get(Guid id)
    {
        User user = await _userRep.GetUser(id);
        return Ok(user);
    }

    [HttpGet("/")]
    public async Task<ActionResult<List<User>>> GetAll () {
        List<User> users = await _userRep.GetAllUsers() ;
        return Ok (users);
    }

    [HttpPost("/")]
    public async Task<ActionResult<User>> Create (UserDto userDto) {
        User newUser = await _userRep.CreateUser(userDto);
        return Ok(newUser);
    }
}





