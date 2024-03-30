using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")] // api/User
public class UserController : ControllerBase
{
    //Mock data for users
    private static readonly List<User> _users = new List<User>
    {
        new User{
                Id = 1,
                Username = "Mean",
                Email = "meannocha@gmail.com",
                Fullname = "Teerapat"
        },
        new User{
                Id = 2,
                Username = "Ryu",
                Email = "ryucri@gmail.com",
                Fullname = "Putti"
        }
    };

    //GET: api/User
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_users);
    }

    //Get user by id
    //GET: api/User/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    //Create new user
    //POST: api/User
    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        _users.Add(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }

    //Update user by id
    //PUT: api/User/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] User user)
    {
        //Validate user id
        if (id != user.Id){
            return BadRequest();
        }

        //Find existing user
        var existingUser = _users.Find(u => u.Id == id);
        if (existingUser == null){
            return NotFound();
        }

        //Update user
        existingUser.Username = user.Username;
        existingUser.Email = user.Email ;
        existingUser.Fullname = user.Fullname;

        //Return updated user
        return Ok(existingUser);
    }

    //Delete user by id
    //DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        _users.Remove(user);
        return NoContent();
    }
}