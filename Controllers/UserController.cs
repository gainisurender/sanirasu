

using Microsoft.AspNetCore.Mvc;
using Sanirasu.Models;
using Sanirasu.Repositories;

namespace Sanirasu.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _repository;

    public UserController(ILogger<UserController> logger, IUserRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    public async Task<User> CreateUser([FromBody]User user)
    {
        User response = await _repository.Create(user);
        return response;
    }
    [HttpGet]
    public async Task<List<User>> GetUsersList()
    {
        var userList = await _repository.GetUserList();
        return userList;
    }
    [HttpGet("{uId}")]
    public async Task<User> GetUserById(long uId)
    {
        var user = await _repository.GetUserById(uId);
        return user;
    }
    [HttpDelete("{uId}")]
    public async Task DeleteUser(long uId)
    {
        await _repository.Delete(uId);
    }
    [HttpPut("{uId}")]
    public async Task<User> UpdateUser(long uId, [FromBody]User user)
    {
        await _repository.Update(uId,user);
        return null;
    }

    
}