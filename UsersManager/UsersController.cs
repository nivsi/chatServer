using Microsoft.AspNetCore.Mvc;

namespace chatServer.UsersManager;
[ApiController]
[Route("apiUsers/[controller]")]

public class UsersController: Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    //get user by email
    //GetUserByEmail
    [HttpGet("getUser/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        if (email == string.Empty)
        {
            return BadRequest("email is empty");
        }
        var user =  await _userService.GetUserByEmail(email);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
    
    //Create new user
    //CreateUser
    [HttpPost("createNewUser")]
    public async Task<IActionResult> CreateUser([FromBody] User? user)
    {
        if(user is null)
            return BadRequest("user data is missing");
        var createUser = await _userService.CreateUser(user);
        if (createUser == null)
        {
            //retrun 409
            return Conflict("user with this email already exists");
        }

        return Ok(createUser);
    }
    
    //Update user
    //UpdateUser
    [HttpPut("updateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] User? user)
    {
        if(user is null)
            return BadRequest("user data is missing");
        var updateUser = await _userService.UpdateUser(user);
        if (updateUser == null)
        {
            //retrun 404
            return NotFound("user with this email does not exist");
        }

        return Ok(updateUser);
    }
    
    //Delete user by email
    //RemoveUser
    [HttpDelete("removeUser/{email}")]
    public async Task<IActionResult> RemoveUser(string email)
    {
        if (email == string.Empty)
        {
            return BadRequest("email is empty");
        }
        var isRemoved = await _userService.RemoveUser(email);
        if (!isRemoved)
        {
            //retrun 404
            return NotFound("user with this email does not exist");
        }

        return Ok("user removed successfully");
    }

}